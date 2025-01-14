using EmployeeService.Models;
using MediatR;

namespace EmployeeService.Queries
{
    public class GetReportingManagerQuery : IRequest<Employee>
    {
        public int ReportingManagerId { get; set; }

        public GetReportingManagerQuery(int reportingManagerId)
        {
            ReportingManagerId = reportingManagerId;
        }
    }
}
