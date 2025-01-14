using MediatR;

namespace LeaveManagementService.Commands
{
    public class DenyLeaveRequestCommand : IRequest<bool>
    {
        public int LeaveRequestId { get; set; }
    }

}
