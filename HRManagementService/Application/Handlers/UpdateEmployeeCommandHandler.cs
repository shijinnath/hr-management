using EmployeeService.Commands;
using EmployeeService.Data;
using EmployeeService.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
{
    private readonly EmployeeDbContext _context;

    public UpdateEmployeeCommandHandler(EmployeeDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        // Fetch the existing employee from the database
        var employee = await _context.Employees.FindAsync(new object[] { request.EmployeeId }, cancellationToken);

        if (employee == null)
        {
            throw new KeyNotFoundException($"Employee with ID {request.EmployeeId} not found.");
        }

        // Update the employee properties
        employee.Name = request.Name;
        employee.Department = request.Department;
        employee.Photo = request.Photo;
        employee.ReportingManager = request.ReportingManager;

        // Mark the entity as modified
        _context.Entry(employee).State = EntityState.Modified;

        // Save changes and return success indicator
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}
