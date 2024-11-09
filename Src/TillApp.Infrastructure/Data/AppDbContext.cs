using Microsoft.EntityFrameworkCore;
using TillApp.Domain.Entities;

namespace TillApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Product entity
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("money");

            // Seed 10 initial products
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductID = 1, Name = "Coke", Price = 2.20m },
                new Product { ProductID = 2, Name = "Burger", Price = 5.50m },
                new Product { ProductID = 3, Name = "Fries", Price = 2.80m },
                new Product { ProductID = 4, Name = "Pizza", Price = 7.50m },
                new Product { ProductID = 5, Name = "Salad", Price = 4.00m },
                new Product { ProductID = 6, Name = "Water", Price = 1.00m },
                new Product { ProductID = 7, Name = "Juice", Price = 2.50m },
                new Product { ProductID = 8, Name = "Ice Cream", Price = 3.00m },
                new Product { ProductID = 9, Name = "Coffee", Price = 1.80m },
                new Product { ProductID = 10, Name = "Tea", Price = 1.50m }
            );

            // Configure the Order entity
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.OrderID);
                entity.Property(o => o.OrderID)
                    .ValueGeneratedOnAdd();

                entity.Property(o => o.OrderName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(o => o.Amount)
                .HasColumnType("money");
            });

            // Configure the OrderItem entity
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(oi => oi.OrderItemID);
                entity.Property(oi => oi.OrderItemID)
                    .ValueGeneratedOnAdd();

                entity.Property(oi => oi.ItemName)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(o => o.Price)
                .HasColumnType("money");

                entity.HasOne<Order>() 
                .WithMany(o => o.Items)
                .HasForeignKey(oi => oi.OrderID)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
