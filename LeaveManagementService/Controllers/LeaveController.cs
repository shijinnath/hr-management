using LeaveManagementService.Commands;
using LeaveManagementService.Queries;
using LeaveManagementService.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CommonSharedLibraries.Common.Models;
using System.Net;
using StackExchange.Redis;

namespace LeaveManagementService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLeaves()
        {
            var leaves = await _mediator.Send(new GetAllLeavesQuery());
            return Ok(new APIResponse<IEnumerable<LeaveRequest>> { StatusCode= (int)HttpStatusCode.OK,Message="Success", Data = leaves });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeaveById(int id)
        {
            var leave = await _mediator.Send(new GetLeaveByIdQuery { Id = id });
            if (leave == null) return NotFound();

            return Ok(leave);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLeave([FromBody] CreateLeaveRequestCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetLeaveById), new { id }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLeaveStatus(int id, [FromBody] string status)
        {
            var result = await _mediator.Send(new UpdateLeaveStatusCommand { LeaveRequestId = id, Status = status });
            if (!result) return NotFound();

            return NoContent();
        }

        [HttpGet("leave-balance")]
        public async Task<IActionResult> GetLeaveBalance([FromQuery] int employeeId)
        {
            var balances = await _mediator.Send(new GetLeaveBalancesQuery { EmployeeId = employeeId });
            return Ok(balances);
        } 
        [HttpGet("leave-category")]
        public async Task<IActionResult> GetLeaveCategory()
        {
            var leaveCategories = await _mediator.Send(new GetAllLeaveCategoryQuery());
            return Ok(new APIResponse<IEnumerable<LeaveCategory>> { StatusCode = (int)HttpStatusCode.OK, Message = "Success", Data = leaveCategories });
        }
        //[HttpPost]
        //public async Task<IActionResult> CreateLeaveRequest([FromBody] CreateLeaveRequestCommand command)
        //{
        //    var id = await _mediator.Send(command);
        //    return CreatedAtAction(nameof(GetLeaveRequestById), new { id }, null);
        //}

        [HttpGet("get-leave-request-by-id/{id}")]
        public async Task<IActionResult> GetLeaveRequestById(int id)
        {
            var leaveRequest = await _mediator.Send(new GetLeaveRequestByIdQuery { LeaveRequestId = id });
            if (leaveRequest == null)
            {
                return NotFound();
            }

            return Ok(leaveRequest);
        }
    }

}
