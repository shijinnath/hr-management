using MediatR;

namespace LeaveManagementService.Commands
{
    public class ApproveLeaveRequestCommand : IRequest<bool>
    {
        public int LeaveRequestId { get; set; }
    }

}
