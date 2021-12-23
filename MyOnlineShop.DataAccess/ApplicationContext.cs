using Microsoft.EntityFrameworkCore;
using MyOnlineShop.Domain.Entities;
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
    }
}
