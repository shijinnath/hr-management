using LeaveManagementService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LeaveManagementService.Data
{
    public class LeaveDbContext : DbContext
    {
        public LeaveDbContext(DbContextOptions<LeaveDbContext> options) : base(options) { }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveCategory> LeaveCategories { get; set; } 
        public DbSet<LeaveBalance> LeaveBalances { get; set; }
    }

}
