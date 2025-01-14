using EmployeeService.Models;
using MediatR;

namespace EmployeeService.Commands
{
    public class UpdateEmployeeCommand : IRequest<bool>
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Photo { get; set; }
        public ReportingManager ReportingManager { get; set; }

        public UpdateEmployeeCommand(int employeeId, string name, string department, string photo, ReportingManager reportingManager)
        {
            EmployeeId = employeeId;
            Name = name;
            Department = department;
            Photo = photo;
            ReportingManager = reportingManager;
        }
    }
}
