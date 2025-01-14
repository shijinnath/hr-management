using EmployeeService.Commands;
using EmployeeService.Data;
using EmployeeService.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRManagementService.Application.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly EmployeeDbContext _context;

        public CreateEmployeeCommandHandler(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            //_context.Employees.Add(request.Employee);
            //await _context.SaveChangesAsync(cancellationToken);
            //return request.Employee;

            // Create a new Employee entity from the request properties
            var employee = new Employee
            {
                Name = request.Name,
                Department = request.Department,
                Photo = request.PhotoUrl,
                ReportingManager = request.ReportingManager
            };

            // Add the entity to the DbContext
            //await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT ReportingManagers ON");
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync(cancellationToken);
            //await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT ReportingManagers OFF");


            // Return the created employee
            return employee;
        }
    }
}
