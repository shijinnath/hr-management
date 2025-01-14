using MediatR;

namespace AuthService.Commands
{
    public class RegisterCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}
