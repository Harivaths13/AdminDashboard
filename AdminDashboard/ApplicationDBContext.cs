using Microsoft.EntityFrameworkCore;
using AdminDashboard.Models;

namespace AdminDashboard;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)");

        // Seed initial products
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Mechanical Keyboard", Price = 99.99m, StockQuantity = 45, CreatedAt = new DateTime(2026, 9, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Product { Id = 2, Name = "Gaming Mouse", Price = 49.50m, StockQuantity = 80, CreatedAt = new DateTime(2026, 9, 5, 0, 0, 0, DateTimeKind.Utc) },
            new Product { Id = 3, Name = "UltraWide Monitor", Price = 399.00m, StockQuantity = 12, CreatedAt = new DateTime(2026, 9, 10, 0, 0, 0, DateTimeKind.Utc) },
            new Product { Id = 4, Name = "USB-C Dock", Price = 129.99m, StockQuantity = 25, CreatedAt = new DateTime(2026, 9, 15, 0, 0, 0, DateTimeKind.Utc) }
        );
    }
}