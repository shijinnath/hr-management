using Microsoft.EntityFrameworkCore;

namespace LeaveManagementService.Models
{
    [PrimaryKey(nameof(Id))]
    public class LeaveRequest
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LeaveType { get; set; } // "Sick Leave", "Casual Leave", etc.
        public string Status { get; set; } // "Pending", "Approved", "Denied"
        public string Reason { get; set; }
        public DateTime CreatedAt { get; set; }
    }


}
