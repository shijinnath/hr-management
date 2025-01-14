using EmployeeService.Models;
using MediatR;

public class CreateEmployeeCommand : IRequest<Employee>
{
    public string Name { get; set; }
    public string Department { get; set; }
    public string PhotoUrl { get; set; }
    public ReportingManager ReportingManager { get; set; }

    public CreateEmployeeCommand(string name, string department, string photoUrl, ReportingManager reportingManager)
    {
        Name = name;
        Department = department;
        PhotoUrl = photoUrl;
        ReportingManager = reportingManager;
    }
}
