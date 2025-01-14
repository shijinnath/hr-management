using LeaveManagementService.Data;
using LeaveManagementService.Models;
using LeaveManagementService.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementService.Handlers.Queries
{
    public class GetAllLeavesQueryHandler : IRequestHandler<GetAllLeavesQuery, IEnumerable<LeaveRequest>>
    {
        private readonly LeaveDbContext _context;

        public GetAllLeavesQueryHandler(LeaveDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LeaveRequest>> Handle(GetAllLeavesQuery request, CancellationToken cancellationToken)
        {
            return await _context.LeaveRequests.ToListAsync(cancellationToken);
        }
    }

}
