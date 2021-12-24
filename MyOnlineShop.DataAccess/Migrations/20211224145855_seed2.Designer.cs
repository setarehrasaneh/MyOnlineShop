﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyOnlineShop.InfraStructure;

namespace MyOnlineShop.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20211224145855_seed2")]
    partial class seed2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("MyOnlineShop.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MyOnlineShop.Domain.Entities.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiscountType")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Discounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "123-abc",
                            DiscountType = 1,
                            Value = 10000m
                        },
                        new
                        {
                            Id = 2,
                            Code = "456-def",
                            DiscountType = 2,
                            Value = 50m
                        });
                });

            modelBuilder.Entity("MyOnlineShop.Domain.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("DiscountId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DiscountId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MyOnlineShop.Domain.Entities.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("MyOnlineShop.Domain.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductType")
                        .HasColumnType("int");

                    b.Property<decimal>("Profit")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 5,
                            Description = "کفش چرم زنانه",
                            Name = "کفش زنانه",
                            Price = 190000.00m,
                            ProductType = 1,
                            Profit = 200000m
                        },
                        new
                        {
                            ProductId = 1,
                            Description = "تیشرت نخی مردانه",
                            Name = "تیشرت مردانه",
                            Price = 70000.00m,
                            ProductType = 1,
                            Profit = 0m
                        },
                        new
                        {
                            ProductId = 2,
                            Description = "گلدان شیشه ای متوسط",
                            Name = "گلدان شیشه ای",
                            Price = 190000.00m,
                            ProductType = 2,
                            Profit = 80000m
                        },
                        new
                        {
                            ProductId = 3,
                            Description = "دستبند زنجیر دار",
                            Name = "دستبند طلا",
                            Price = 8700000.00m,
                            ProductType = 1,
                            Profit = 0m
                        },
                        new
                        {
                            ProductId = 4,
                            Description = "سرویس چای خوری کریستال",
                            Name = "سرویس چای خوری",
                            Price = 500000.00m,
                            ProductType = 2,
                            Profit = 0m
                        },
                        new
                        {
                            ProductId = 6,
                            Description = "دمپایی پلاستیکی",
                            Name = "دمپایی",
                            Price = 30000.00m,
                            ProductType = 1,
                            Profit = 0m
                        });
                });

            modelBuilder.Entity("MyOnlineShop.Domain.Entities.Order", b =>
                {
                    b.HasOne("MyOnlineShop.Domain.Entities.Customer", null)
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId");

                    b.HasOne("MyOnlineShop.Domain.Entities.Discount", "Discount")
                        .WithMany()
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discount");
                });

            modelBuilder.Entity("MyOnlineShop.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("MyOnlineShop.Domain.Entities.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId");

                    b.HasOne("MyOnlineShop.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MyOnlineShop.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("MyOnlineShop.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
