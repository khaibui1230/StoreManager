using Microsoft.EntityFrameworkCore;
using StoreManager.Model;

namespace StoreManager.Data
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) { }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình quan hệ
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Table)
                .WithMany(t => t.Orders)
                .HasForeignKey(o => o.TableId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.MenuItem)
                .WithMany()
                .HasForeignKey(oi => oi.MenuItemId)
                .OnDelete(DeleteBehavior.Restrict);

            // Không cần HasConversion<int>() vì Status giờ là string

            // Seed data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed MenuItems
            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { Id = 1, Name = "Cà phê đen", Price = 25000.00M, Category = "Đồ uống" },
                new MenuItem { Id = 2, Name = "Trà sữa trân châu", Price = 35000.00M, Category = "Đồ uống" },
                new MenuItem { Id = 3, Name = "Bánh mì thịt nướng", Price = 30000.00M, Category = "Thức ăn" },
                new MenuItem { Id = 4, Name = "Nước cam ép", Price = 28000.00M, Category = "Đồ uống" },
                new MenuItem { Id = 5, Name = "Phở bò", Price = 50000.00M, Category = "Thức ăn" }
            );

            // Seed Tables
            modelBuilder.Entity<Table>().HasData(
                new Table { Id = 1, Number = 1, Status = "Available" },
                new Table { Id = 2, Number = 2, Status = "Occupied" },
                new Table { Id = 3, Number = 3, Status = "Reserved" },
                new Table { Id = 4, Number = 4, Status = "Available" },
                new Table { Id = 5, Number = 5, Status = "Occupied" }
            );

            // Seed Staff
            modelBuilder.Entity<Staff>().HasData(
                new Staff { Id = 1, Name = "Nguyễn Văn A", Role = "Admin" },
                new Staff { Id = 2, Name = "Trần Thị B", Role = "Waiter" },
                new Staff { Id = 3, Name = "Lê Văn C", Role = "Chef" },
                new Staff { Id = 4, Name = "Phạm Thị D", Role = "Waiter" },
                new Staff { Id = 5, Name = "Hoàng Văn E", Role = "Chef" }
            );

            // Seed Orders
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    OrderDate = new DateTime(2025, 3, 10, 9, 30, 0, DateTimeKind.Utc),
                    TableId = 1,
                    StaffId = 2,
                    Status = "Pending"
                },
                new Order
                {
                    Id = 2,
                    OrderDate = new DateTime(2025, 3, 10, 10, 15, 0, DateTimeKind.Utc),
                    TableId = 2,
                    StaffId = 4,
                    Status = "Completed"
                },
                new Order
                {
                    Id = 3,
                    OrderDate = new DateTime(2025, 3, 10, 12, 0, 0, DateTimeKind.Utc),
                    TableId = 3,
                    StaffId = 5,
                    Status = "Pending"
                }
            );

            // Seed OrderItems
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { Id = 1, OrderId = 1, MenuItemId = 1, Quantity = 2 }, // 2 Cà phê đen
                new OrderItem { Id = 2, OrderId = 1, MenuItemId = 3, Quantity = 1 }, // 1 Bánh mì
                new OrderItem { Id = 3, OrderId = 2, MenuItemId = 2, Quantity = 3 }, // 3 Trà sữa
                new OrderItem { Id = 4, OrderId = 3, MenuItemId = 5, Quantity = 1 }, // 1 Phở bò
                new OrderItem { Id = 5, OrderId = 3, MenuItemId = 4, Quantity = 2 }  // 2 Nước cam
            );
        }
    }
}