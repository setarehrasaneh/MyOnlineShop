using MyOnlineShop.Domain.Dtos;
using MyOnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyOnlineShop.Domain.Service
{
    public interface IOrderService
    {
        decimal GetTotalPrice(List<OrderItem> orderItems);
        List<OrderItem> AddItemsToOrder(List<OrderItem> orderItems, int id);
        Task<bool> SubmitOrder(Order order);
        List<OrderItem> RemoveItemFromOrder(List<OrderItem> orderItems, int id);
        List<OrderItem> GetNormalItems(List<OrderItem> orderItems);
        List<OrderItem> GetFragileItems(List<OrderItem> orderItems);
        DiscountResultDto GetFactorTotalPrice(string code, decimal totalPrice);
        void IsTotalPriceInRange(List<OrderItem> orderItems);
    }
}
