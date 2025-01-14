using LeaveManagementService.Data;
using LeaveManagementService.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementService.Services
{
    public class LeaveService : ILeaveService
    {
        private readonly LeaveDbContext _context;

        public LeaveService(LeaveDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LeaveRequest>> GetLeaveRequestsAsync()
        {
            return await _context.LeaveRequests.ToListAsync();
        }

        public async Task<LeaveRequest> GetLeaveRequestByIdAsync(int id)
        {
            return await _context.LeaveRequests.FindAsync(id);
        }

        Task<IEnumerable<LeaveRequest>> ILeaveService.GetLeaveRequestsAsync()
        {
            throw new NotImplementedException();
        }

        Task<LeaveRequest> ILeaveService.GetLeaveRequestByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }

}
