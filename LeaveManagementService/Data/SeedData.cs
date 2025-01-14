using LeaveManagementService.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace LeaveManagementService.Data
{
    public static class SeedData
    {
        public static void Initialize(LeaveDbContext context)
        {
            if (!context.LeaveCategories.Any())
            {
                     context.LeaveCategories.AddRange(
                    new LeaveCategory { Name = "Sick Leave", MaxDaysAllowed = 10 },
                    new LeaveCategory { Name = "Casual Leave", MaxDaysAllowed = 12 }
                );
                context.SaveChanges();
            }
        }
    }

}
