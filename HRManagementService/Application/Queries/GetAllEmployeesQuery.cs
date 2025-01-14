using EmployeeService.Models;
using MediatR;

namespace EmployeeService.Queries
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<Employee>>
    {
    }
}
