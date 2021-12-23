using MyOnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlineShop.Models
{
    public class OrderViewModel
    {
        public List<OrderItem> NormalItems { get; set; }
        public List<OrderItem> FragileItems { get; set; }
        public decimal Finalprice { get; set; }
        public int  DiscountId { get; set; }

    }
}
