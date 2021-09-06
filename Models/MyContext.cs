using Microsoft.EntityFrameworkCore;

namespace EmployeeTracking.Models
{
    public class MyContext : DbContext 
    {
        public MyContext(DbContextOptions options) : base(options) {}

        public DbSet<Employee> Employees {get; set;}
        
        public DbSet<Department> Departments {get; set;}
    }
}