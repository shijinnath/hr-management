using LeaveManagementService.Data;
using LeaveManagementService.Models;
using LeaveManagementService.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementService.Handlers.Queries
{
    public class GetLeaveBalancesQueryHandler : IRequestHandler<GetLeaveBalancesQuery, IEnumerable<LeaveBalance>>
    {
        private readonly LeaveDbContext _context;

        public GetLeaveBalancesQueryHandler(LeaveDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LeaveBalance>> Handle(GetLeaveBalancesQuery request, CancellationToken cancellationToken)
        {
            return await _context.LeaveBalances
                .Where(lb => lb.EmployeeId == request.EmployeeId)
                .ToListAsync(cancellationToken);
        }
    }

}
