using Microsoft.EntityFrameworkCore;
using MetroChefApp.API.Models; // Link to your models

namespace MetroChefApp.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSets for all your models
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderStatusHistory> OrderStatusHistories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<WorkRoster> WorkRosters { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }

        // Optional: override OnModelCreating for relationships, constraints, etc.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Example: composite key for UserRole
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => ur.UserRoleId);

            // Example: relationships
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            // Configure decimal precision for prices
            modelBuilder.Entity<FoodItem>()
                .Property(f => f.Price)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.UnitPrice)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Salary>()
                .Property(s => s.TotalAmount)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Salary>()
                .Property(s => s.TotalHours)
                .HasColumnType("decimal(10,2)");
        }
    }
}
