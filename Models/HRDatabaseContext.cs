using EmployeeApp.Models;
using Microsoft.EntityFrameworkCore;


namespace EmployeeApp.Models
{
    public class HRDatabaseContext : DbContext
    {
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
             (@"data source=Bahr\sqlexpress; initial catalog=EmployeesDB; integrated security=SSPI; TrustServerCertificate=True; encrypt=false;");
        }

    }
}
