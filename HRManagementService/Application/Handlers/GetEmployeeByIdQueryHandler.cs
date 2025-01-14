using EmployeeService.Data;
using EmployeeService.Models;
using EmployeeService.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRManagementService.Application.Handlers
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly EmployeeDbContext _context;

        public GetEmployeeByIdQueryHandler(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Employees.Include(e => e.ReportingManager).FirstOrDefaultAsync(e => e.Id == request.EmployeeId, cancellationToken);
        }
    }
}
