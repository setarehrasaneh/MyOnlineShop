using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyOnlineShop.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
    }
}
