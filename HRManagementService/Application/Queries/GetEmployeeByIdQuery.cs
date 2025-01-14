using EmployeeService.Models;
using MediatR;

namespace EmployeeService.Queries
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public int EmployeeId { get; set; }

        public GetEmployeeByIdQuery(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
