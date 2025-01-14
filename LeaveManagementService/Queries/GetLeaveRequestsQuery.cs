using LeaveManagementService.Models;
using MediatR;

namespace LeaveManagementService.Queries
{
    public class GetLeaveRequestsQuery : IRequest<IEnumerable<LeaveRequest>> { }

}
