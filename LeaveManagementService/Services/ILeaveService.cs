using LeaveManagementService.Models;

namespace LeaveManagementService.Services
{
    public interface ILeaveService
    {
        Task<IEnumerable<LeaveRequest>> GetLeaveRequestsAsync();
        Task<LeaveRequest> GetLeaveRequestByIdAsync(int id);
    }

}
