using LeaveManagementService.Commands;
using LeaveManagementService.Data;
using MediatR;

namespace LeaveManagementService.Handlers.Commands
{
    public class UpdateLeaveStatusCommandHandler : IRequestHandler<UpdateLeaveStatusCommand, bool>
    {
        private readonly LeaveDbContext _context;

        public UpdateLeaveStatusCommandHandler(LeaveDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateLeaveStatusCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _context.LeaveRequests.FindAsync(request.LeaveRequestId);
            if (leaveRequest == null) return false;

            leaveRequest.Status = request.Status;
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }

}
