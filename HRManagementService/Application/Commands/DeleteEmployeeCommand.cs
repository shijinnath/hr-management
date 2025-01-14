using MediatR;

namespace EmployeeService.Commands
{
    public class DeleteEmployeeCommand : IRequest<bool>
    {
        public int EmployeeId { get; set; }

        public DeleteEmployeeCommand(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
