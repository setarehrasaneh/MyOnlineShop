using MyOnlineShop.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyOnlineShop.Domain.Entities
{
    public class Discount
    {
        [ForeignKey("Order")]
        public int Id { get; set; }
        public string Code { get; set; }
        public DiscountType DiscountType { get; set; }
        public decimal Value { get; set; }
        public Order Order { get; set; }

    }
}
