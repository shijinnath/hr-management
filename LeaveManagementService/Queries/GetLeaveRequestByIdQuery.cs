using LeaveManagementService.Models;
using MediatR;

namespace LeaveManagementService.Queries
{
    public class GetLeaveRequestByIdQuery : IRequest<LeaveRequest>
    {
        public int LeaveRequestId { get; set; }
    }

}
