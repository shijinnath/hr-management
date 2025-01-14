using LeaveManagementService.Models;
using MediatR;

namespace LeaveManagementService.Queries
{
    public class GetLeaveByIdQuery : IRequest<LeaveRequest>
    {
        public int Id { get; set; }
    }

}
