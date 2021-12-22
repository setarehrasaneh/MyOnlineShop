using MyOnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlineShop.Models
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public List<Product> Products { get; set; }
        public List<Customer> Customers { get; set; }

    }
}
