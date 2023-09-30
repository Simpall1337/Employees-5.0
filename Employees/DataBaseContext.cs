using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Employees.Models;
namespace Employees
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

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
            modelBuilder.Entity<Employee>().HasKey(x => x.Id);
            modelBuilder.Entity<Department>().HasKey(x => x.DepartmentId);
            modelBuilder.Entity<Employee>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<Department>().Property(x => x.DepartmentId).UseIdentityColumn();
        }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
    }
}
