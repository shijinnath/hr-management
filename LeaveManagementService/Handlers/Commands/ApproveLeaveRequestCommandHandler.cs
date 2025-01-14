using LeaveManagementService.Commands;
using LeaveManagementService.Data;
using MediatR;

namespace LeaveManagementService.Handlers.Commands
{
    public class ApproveLeaveRequestCommandHandler : IRequestHandler<ApproveLeaveRequestCommand, bool>
    {
        private readonly LeaveDbContext _context;

        public ApproveLeaveRequestCommandHandler(LeaveDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(ApproveLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _context.LeaveRequests.FindAsync(request.LeaveRequestId);

            if (leaveRequest == null)
            {
                throw new KeyNotFoundException($"Leave request with ID {request.LeaveRequestId} not found.");
            }

            leaveRequest.Status = "Approved";
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }

}
