using LeaveManagementService.Models;
using MediatR;

namespace LeaveManagementService.Queries
{
    public class GetLeaveBalancesQuery : IRequest<IEnumerable<LeaveBalance>>
    {
        public int EmployeeId { get; set; }
    }

}
