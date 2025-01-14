using Microsoft.EntityFrameworkCore;

namespace LeaveManagementService.Models
{
    [PrimaryKey(nameof(EmployeeId))]
    public class LeaveBalance
    {
        
        public int EmployeeId { get; set; }
        public string LeaveType { get; set; }
        public int TotalDays { get; set; }
        public int UsedDays { get; set; }
        public int RemainingDays => TotalDays - UsedDays;
    }

}
