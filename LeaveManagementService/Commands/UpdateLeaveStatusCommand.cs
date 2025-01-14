using MediatR;

namespace LeaveManagementService.Commands
{
    public class UpdateLeaveStatusCommand : IRequest<bool>
    {
        public int LeaveRequestId { get; set; }
        public string Status { get; set; } // "Approved" or "Denied"
    }

}
