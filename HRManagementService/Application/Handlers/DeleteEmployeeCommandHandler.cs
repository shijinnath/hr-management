using EmployeeService.Commands;
using EmployeeService.Data;
using MediatR;

namespace HRManagementService.Application.Handlers
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly EmployeeDbContext _context;

        public DeleteEmployeeCommandHandler(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.EmployeeId);
            if (employee == null) return false;

            _context.Employees.Remove(employee);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
