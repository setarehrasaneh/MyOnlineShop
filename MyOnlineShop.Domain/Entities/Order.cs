using System;
using System.Collections.Generic;
using System.Text;

namespace MyOnlineShop.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public int DiscountId { get; set; }
        public Discount Discount { get; set; }
        

    }
}
