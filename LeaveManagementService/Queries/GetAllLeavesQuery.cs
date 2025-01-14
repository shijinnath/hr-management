using LeaveManagementService.Models;
using MediatR;

namespace LeaveManagementService.Queries
{
    public class GetAllLeavesQuery : IRequest<IEnumerable<LeaveRequest>> { }

}
