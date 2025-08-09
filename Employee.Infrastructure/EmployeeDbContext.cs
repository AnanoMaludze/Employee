using Employee.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Employee.Infrastructure
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }
        public DbSet<Employees> Employees { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var e = modelBuilder.Entity<Employees>();
            e.ToTable("Employees");
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).HasMaxLength(200).IsRequired();
            e.HasMany(x => x.Subordinates)
                .WithOne()
                .HasForeignKey(x => x.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            
            e.HasData(
                new Employees { Id = 1, Name = "Main Manager", ManagerId = null },
                new Employees { Id = 2, Name = "Employee 1", ManagerId = 1 },
                new Employees { Id = 3, Name = "Employee 2", ManagerId = 1 },
                new Employees { Id = 4, Name = "Employee 3", ManagerId = 2 },
                new Employees { Id = 5, Name = "Employee 4", ManagerId = 2 },
                new Employees { Id = 6, Name = "Employee 5", ManagerId = 3 }
            
            );
        }
    }
}
