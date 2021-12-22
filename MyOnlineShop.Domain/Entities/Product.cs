using MyOnlineShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyOnlineShop.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public ProductType ProductType { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal Profit { get; set; }
    }
}
