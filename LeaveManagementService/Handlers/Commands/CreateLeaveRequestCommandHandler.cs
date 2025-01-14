using LeaveManagementService.Commands;
using LeaveManagementService.Data;
using LeaveManagementService.Models;
using MediatR;

namespace LeaveManagementService.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
    {
        private readonly LeaveDbContext _context;

        public CreateLeaveRequestCommandHandler(LeaveDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = new LeaveRequest
            {
                EmployeeId = request.EmployeeId,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                LeaveType = request.LeaveType,
                Reason = request.Reason,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow
            };

            _context.LeaveRequests.Add(leaveRequest);
            await _context.SaveChangesAsync(cancellationToken);

            return leaveRequest.Id;
        }
    }


}
