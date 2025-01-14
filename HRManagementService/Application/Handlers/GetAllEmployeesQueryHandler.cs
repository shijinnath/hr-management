using EmployeeService.Data;
using EmployeeService.Models;
using EmployeeService.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRManagementService.Application.Handlers
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<Employee>>
    {
        private readonly EmployeeDbContext _context;

        public GetAllEmployeesQueryHandler(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Employees.Include(e => e.ReportingManager).ToListAsync(cancellationToken);
        }
    }
}
