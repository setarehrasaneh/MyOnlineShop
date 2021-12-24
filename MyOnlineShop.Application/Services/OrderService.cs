using MyOnlineShop.Domain.Dtos;
using MyOnlineShop.Domain.Entities;
using MyOnlineShop.Domain.Enums;
using MyOnlineShop.Domain.Repositories;
using MyOnlineShop.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyOnlineShop.Application.Services
{
    public class OrderService : IOrderService
    {

        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IDiscountRepository _discountRepository;

        public OrderService(
            IProductRepository productRepository,
            IOrderRepository orderRepository,
            IDiscountRepository discountRepository
            )
        {
            this._productRepository = productRepository;
            this._orderRepository = orderRepository;
            this._discountRepository = discountRepository;
        } 
        public List<OrderItem> AddItemsToOrder(List<OrderItem> orderItems , int id)
        {
            if (orderItems == null)
            {
                orderItems = new List<OrderItem>();
                orderItems.Add(new OrderItem { Product = _productRepository.GetAll().Find(x => x.ProductId == id), Qty = 1 });
                return orderItems;
            }

            int index = orderItems.FindIndex(a => a.Product.ProductId == id);
            if (index != -1)
            {
                orderItems[index].Qty++;
            }
            else
            {
                orderItems.Add(new OrderItem { Product = _productRepository.GetAll().Find(x => x.ProductId == id), Qty = 1});
            }
            return orderItems;
            }

        public DiscountResultDto GetFactorTotalPrice(string code, decimal totalPrice)
        {
            var discount = _discountRepository.FindDiscount(code);
            var result = new DiscountResultDto();
            if (discount != null)
            {                
                result.DiscountId = discount.Id;
                if (discount.DiscountType == DiscountType.Amount)
                {
                    result.FinalFactorResult = totalPrice - discount.Value;
                }
                else
                {
                    result.FinalFactorResult = totalPrice - (totalPrice * discount.Value / 100);
                }
            }
            else
            {
                throw new Exception("کد معتبر نمی باشد");
            }
            return result;
        }

        public List<OrderItem> GetFragileItems(List<OrderItem> orderItems)
        {
            return orderItems.Where(items => items.Product.ProductType == ProductType.Fragile).ToList();
        }

        public List<OrderItem> GetNormalItems(List<OrderItem> orderItems)
        {
            return orderItems.Where(items => items.Product.ProductType == ProductType.Normal).ToList();
        }

        public decimal GetTotalPrice(List<OrderItem> orderItems)
        {
            if (orderItems != null && orderItems.Any())
            {
                return orderItems.Sum(item => (item.Product.Price + item.Product.Profit) * item.Qty);
            }
            return 0;
        }

        public void IsTotalPriceInRange(List<OrderItem> orderItems)
        {
            if (GetTotalPrice(orderItems) < 50000)
            {
                throw new Exception("Price Not In Range");
            }
        }

        public List<OrderItem> RemoveItemFromOrder(List<OrderItem> orderItems, int id)
        {
            int index = orderItems.FindIndex(a => a.Product.ProductId == id);
            orderItems.RemoveAt(index);
            return orderItems;
        }

        public bool SubmitOrder(Order order)
        {
           return _orderRepository.SubmitOrder(order);
        }
    }
}
