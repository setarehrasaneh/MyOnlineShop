using MyOnlineShop.Domain.Enums;

namespace MyOnlineShop.Domain.Entities
{
    public class Discount
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DiscountType DiscountType { get; set; }
        public decimal Value { get; set; }
    }
}
