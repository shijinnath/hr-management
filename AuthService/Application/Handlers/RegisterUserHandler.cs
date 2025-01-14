using MediatR;
using AuthService.Data;
using AuthService.Models;
using System.Threading;
using System.Threading.Tasks;

namespace AuthService.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, bool>
    {
        private readonly AuthDbContext _dbContext;

        public RegisterCommandHandler(AuthDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Email = request.Email,
                Password = request.Password,
                FullName = request.FullName
            };

            _dbContext.Users.Add(user);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
