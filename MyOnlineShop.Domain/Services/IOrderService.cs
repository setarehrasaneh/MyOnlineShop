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
        //return total price of cart
        decimal GetTotalPrice(List<OrderItem> orderItems);
        //add an orderItem with id to cart , get old cart list and return new one 
        List<OrderItem> AddItemsToOrder(List<OrderItem> orderItems, int id);
        //add an order to table asyc 
        Task<bool> SubmitOrder(Order order);
        //remove an orderItem with id from cart,get old cart list and return new one  
        List<OrderItem> RemoveItemFromOrder(List<OrderItem> orderItems, int id);
        // extract Items Of Cart whith Type of Normal 
        List<OrderItem> GetNormalItems(List<OrderItem> orderItems);
        // extract Items Of Cart whith Type of Fragile 
        List<OrderItem> GetFragileItems(List<OrderItem> orderItems);
        //return total price of factor after calculating discount
        DiscountResultDto GetFactorTotalPrice(string code, decimal totalPrice);
        // check if total price is in valid range
        void IsTotalPriceInRange(List<OrderItem> orderItems);
    }
}
