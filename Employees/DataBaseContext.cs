using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Employees.Models;
namespace Employees
{
    public class DataBaseContext : DbContext
    {
        private static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            optionsBuilder.UseSqlServer("Server=localhost\\SASHASQL;Database=Employee;Trusted_Connection=true;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>().Property(x => x.Birthday).HasColumnType("smalldatetime");
            modelBuilder.Entity<Employee>().HasKey(x => x.Pk_employee_id);
            modelBuilder.Entity<Department>().HasKey(x => x.Department_id);
            modelBuilder.Entity<Employee>().Property(x => x.Pk_employee_id).UseIdentityColumn();
            modelBuilder.Entity<Department>().Property(x => x.Department_id).UseIdentityColumn();
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }




    }
}
