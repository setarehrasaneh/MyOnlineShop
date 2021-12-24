using Microsoft.EntityFrameworkCore;
using MyOnlineShop.Domain.Entities;
using MyOnlineShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOnlineShop.InfraStructure
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions options) :base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Discount> Discounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Discount>().HasData(
                 new { Id = 1, Code = "123-abc", DiscountType = DiscountType.Amount, Value = Decimal.Parse("10000") },
                 new { Id = 2, Code = "456-def", DiscountType = DiscountType.percent, Value = Decimal.Parse("50") });

            modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = 5, Name = "کفش زنانه", Description = "کفش چرم زنانه", ProductType = ProductType.Normal, Price = Decimal.Parse("190000.00"), Profit = Decimal.Parse("200000") },
            new Product { ProductId = 1, Name = "تیشرت مردانه", Description = "تیشرت نخی مردانه", ProductType = ProductType.Normal, Price = Decimal.Parse("70000.00"), Profit = Decimal.Parse("0") },
            new Product { ProductId = 2, Name = "گلدان شیشه ای", Description = "گلدان شیشه ای متوسط", ProductType = ProductType.Fragile, Price = Decimal.Parse("190000.00"), Profit = Decimal.Parse("80000") },
            new Product { ProductId = 3, Name = "دستبند طلا", Description = "دستبند زنجیر دار", ProductType = ProductType.Normal, Price = Decimal.Parse("8700000.00"), Profit = Decimal.Parse("0") },
            new Product { ProductId = 4, Name = "سرویس چای خوری", Description = "سرویس چای خوری کریستال", ProductType = ProductType.Fragile, Price = Decimal.Parse("500000.00"), Profit = Decimal.Parse("0") },
            new Product { ProductId = 6, Name = "دمپایی", Description = "دمپایی پلاستیکی", ProductType = ProductType.Normal, Price = Decimal.Parse("30000.00"), Profit = Decimal.Parse("0") });



        }
    }
}