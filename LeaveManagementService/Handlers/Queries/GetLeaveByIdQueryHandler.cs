using LeaveManagementService.Data;
using LeaveManagementService.Models;
using LeaveManagementService.Queries;
using MediatR;

namespace LeaveManagementService.Handlers.Queries
{
    public class GetLeaveByIdQueryHandler : IRequestHandler<GetLeaveByIdQuery, LeaveRequest>
    {
        private readonly LeaveDbContext _context;

        public GetLeaveByIdQueryHandler(LeaveDbContext context)
        {
            _context = context;
        }

        public async Task<LeaveRequest> Handle(GetLeaveByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.LeaveRequests.FindAsync(new object[] { request.Id }, cancellationToken);
        }
    }

}
