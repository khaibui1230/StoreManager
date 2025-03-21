﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreManager.Data;

#nullable disable

namespace StoreManager.Migrations
{
    [DbContext(typeof(RestaurantDbContext))]
    [Migration("20250312034923_fixOrderItem")]
    partial class fixOrderItem
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StoreManager.Model.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Đồ uống",
                            Name = "Cà phê đen",
                            Price = 25000.00m
                        },
                        new
                        {
                            Id = 2,
                            Category = "Đồ uống",
                            Name = "Trà sữa trân châu",
                            Price = 35000.00m
                        },
                        new
                        {
                            Id = 3,
                            Category = "Thức ăn",
                            Name = "Bánh mì thịt nướng",
                            Price = 30000.00m
                        },
                        new
                        {
                            Id = 4,
                            Category = "Đồ uống",
                            Name = "Nước cam ép",
                            Price = 28000.00m
                        },
                        new
                        {
                            Id = 5,
                            Category = "Thức ăn",
                            Name = "Phở bò",
                            Price = 50000.00m
                        });
                });

            modelBuilder.Entity("StoreManager.Model.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.Property<int?>("StaffId1")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.HasIndex("StaffId1");

                    b.HasIndex("TableId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderDate = new DateTime(2025, 3, 10, 9, 30, 0, 0, DateTimeKind.Utc),
                            StaffId = 2,
                            Status = "Pending",
                            TableId = 1,
                            TotalAmount = 0m
                        },
                        new
                        {
                            Id = 2,
                            OrderDate = new DateTime(2025, 3, 10, 10, 15, 0, 0, DateTimeKind.Utc),
                            StaffId = 4,
                            Status = "Completed",
                            TableId = 2,
                            TotalAmount = 0m
                        },
                        new
                        {
                            Id = 3,
                            OrderDate = new DateTime(2025, 3, 10, 12, 0, 0, 0, DateTimeKind.Utc),
                            StaffId = 5,
                            Status = "Pending",
                            TableId = 3,
                            TotalAmount = 0m
                        });
                });

            modelBuilder.Entity("StoreManager.Model.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int?>("MenuItemId1")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("MenuItemId1");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MenuItemId = 1,
                            OrderId = 1,
                            Price = 0m,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 2,
                            MenuItemId = 3,
                            OrderId = 1,
                            Price = 0m,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 3,
                            MenuItemId = 2,
                            OrderId = 2,
                            Price = 0m,
                            Quantity = 3
                        },
                        new
                        {
                            Id = 4,
                            MenuItemId = 5,
                            OrderId = 3,
                            Price = 0m,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 5,
                            MenuItemId = 4,
                            OrderId = 3,
                            Price = 0m,
                            Quantity = 2
                        });
                });

            modelBuilder.Entity("StoreManager.Model.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Staffs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Nguyễn Văn A",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Trần Thị B",
                            Role = "Waiter"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Lê Văn C",
                            Role = "Chef"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Phạm Thị D",
                            Role = "Waiter"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Hoàng Văn E",
                            Role = "Chef"
                        });
                });

            modelBuilder.Entity("StoreManager.Model.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Number = 1,
                            Status = "Available"
                        },
                        new
                        {
                            Id = 2,
                            Number = 2,
                            Status = "Occupied"
                        },
                        new
                        {
                            Id = 3,
                            Number = 3,
                            Status = "Reserved"
                        },
                        new
                        {
                            Id = 4,
                            Number = 4,
                            Status = "Available"
                        },
                        new
                        {
                            Id = 5,
                            Number = 5,
                            Status = "Occupied"
                        });
                });

            modelBuilder.Entity("StoreManager.Model.Order", b =>
                {
                    b.HasOne("StoreManager.Model.Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("StoreManager.Model.Staff", null)
                        .WithMany("Orders")
                        .HasForeignKey("StaffId1");

                    b.HasOne("StoreManager.Model.Table", "Table")
                        .WithMany("Orders")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Staff");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("StoreManager.Model.OrderItem", b =>
                {
                    b.HasOne("StoreManager.Model.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("StoreManager.Model.MenuItem", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("MenuItemId1");

                    b.HasOne("StoreManager.Model.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("StoreManager.Model.MenuItem", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("StoreManager.Model.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("StoreManager.Model.Staff", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("StoreManager.Model.Table", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
