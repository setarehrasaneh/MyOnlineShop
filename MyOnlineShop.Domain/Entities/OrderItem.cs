namespace MyOnlineShop.Domain.Entities
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Qty { get; set; }
        public Product Product { get; set; }
    }
}
