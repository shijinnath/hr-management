using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementService.Models
{
    [PrimaryKey(nameof(Id))]
    public class LeaveCategory
    { 
         

        public int Id { get; set; }
        public string Name { get; set; } // E.g., "Sick Leave", "Casual Leave"
        public int MaxDaysAllowed { get; set; }
    }

}
