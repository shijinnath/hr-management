using Microsoft.AspNetCore.Mvc;
using MediatR;
using AuthService.Commands;
using AuthService.Queries;
using AuthService.Models;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Common.Utilities;
using Common.Interfaces;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IJWTService jwtHelper;

        public AuthController(IMediator mediator, IJWTService jwtHelper)
        {
            this._mediator = mediator;
            this.jwtHelper = jwtHelper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {
            command.Password = PasswordHasher.HashPassword(command.Password);
            var result = await _mediator.Send(command);
            return result ? Ok() : BadRequest();
        }

        [HttpGet("user/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var query = new GetUserByEmailQuery { Email = email };
            var user = await _mediator.Send(query);
            return user != null ? Ok(user) : NotFound();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest command)
        {
            var query = new GetUserByEmailQuery { Email = command.Email };
            var user = await _mediator.Send(query);

            if (user == null || !PasswordHasher.VerifyPassword(command.Password, user.Password))
                return Ok(new  { Message = "Invalid username or password" });

            var token = this.jwtHelper.GenerateToken(new SharedModels.User { PasswordHash = user.Password, Username = user.Email, Role =   "Admin" });
            return Ok(new { Token = token, Message = "Login successful" });
        }
    }
}
