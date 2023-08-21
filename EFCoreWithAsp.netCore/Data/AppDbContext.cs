using EFCoreWithAsp.netCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWithAsp.netCore.Data
{
    public class AppDbContext:DbContext
    {
        //Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //DbSet properties
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
