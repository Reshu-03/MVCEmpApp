using Microsoft.EntityFrameworkCore;

namespace MVCEmp.Data
{
    public class EmpDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public EmpDbContext(DbContextOptions<EmpDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().ToTable("dept");
            modelBuilder.Entity<Employee>().ToTable("employe");
        }
    }
}
