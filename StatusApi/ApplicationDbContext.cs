using Microsoft.EntityFrameworkCore;
using StatusApi.Models;
using StatusERP.Domain.Models;

namespace StatusApi
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Restaurant> Restaurants { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<InventoryMovement> InventoryMovements { get; set; } = null!;
        public DbSet<Supplier> Suppliers { get; set; } = null!;
        public DbSet<SupplierOrder> SupplierOrders { get; set; } = null!;
        public DbSet<SupplierOrderDetail> SupplierOrderDetails { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<SupplierOrder>()
                .Property(o => o.Total)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<SupplierOrder>()
                .Property(o => o.Status)
                .HasConversion<string>();

            modelBuilder.Entity<SupplierOrder>()
                .HasOne<Supplier>()
                .WithMany()
                .HasForeignKey(o => o.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SupplierOrder>()
                .HasOne<Restaurant>()
                .WithMany()
                .HasForeignKey(o => o.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SupplierOrderDetail>()
                .Property(d => d.UnitPrice)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<SupplierOrderDetail>()
                .Property(d => d.Subtotal)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<SupplierOrderDetail>()
                .HasOne<SupplierOrder>()
                .WithMany()
                .HasForeignKey(d => d.SupplierOrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SupplierOrderDetail>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InventoryMovement>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
