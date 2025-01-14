using LeaveManagementService.Models;
using MediatR;

namespace LeaveManagementService.Queries
{
    public class GetLeavesByEmployeeQuery : IRequest<IEnumerable<LeaveRequest>>
    {
        public int EmployeeId { get; set; }
    }

}
