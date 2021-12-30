using MyOnlineShop.Domain.Dtos;
using MyOnlineShop.Domain.Entities;
using MyOnlineShop.Domain.Enums;
using MyOnlineShop.Domain.Exceptions;
using MyOnlineShop.Domain.Repositories;
using MyOnlineShop.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<OrderItem> AddItemsToOrder(List<OrderItem> orderItems, int id)
        {
            try
            {
                var products = _productRepository.GetAll().Result;
                
                //first item add to cart
                if (orderItems == null)
                {
                    orderItems = new List<OrderItem>();

                    orderItems.Add(new OrderItem { Product = products.Find(x => x.ProductId == id), Qty = 1 });
                    return orderItems;
                }
                
                int index = orderItems.FindIndex(a => a.Product.ProductId == id);
                //item exist in cart
                if (index != -1)
                {
                    orderItems[index].Qty++;
                }
                //item added to cart for the first time
                else
                {
                    orderItems.Add(new OrderItem { Product = products.Find(x => x.ProductId == id), Qty = 1 });
                }
                return orderItems;
            }
            catch (Exception ex)
            {

                return orderItems;
            }
        }

        public DiscountResultDto GetFactorTotalPrice(string code, decimal totalPrice)
        {
            var discount = _discountRepository.FindDiscount(code);
            var result = new DiscountResultDto();
            try
            {
                if (discount != null)
                {
                    result.DiscountId = discount.Id;
                    //calculate total price for amount discount
                    if (discount.DiscountType == DiscountType.Amount)
                    {
                        result.FinalFactorResult = totalPrice - discount.Value;
                    }
                    //calculate total price for percent discount
                    else
                    {
                        result.FinalFactorResult = totalPrice - (totalPrice * discount.Value / 100);
                    }
                }
                else
                {
                    throw new Exception("Code Is Invalid");
                }
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
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
                throw new OrderTimeNotInRangeException("Price Not In Range");
            }
        }

        public List<OrderItem> RemoveItemFromOrder(List<OrderItem> orderItems, int id)
        {
            try
            {
                int index = orderItems.FindIndex(a => a.Product.ProductId == id);
                orderItems.RemoveAt(index);
                return orderItems;
            }
            catch (Exception ex)
            {
                return orderItems;
            }

        }

        public bool SubmitOrder(Order order)
        {
            return _orderRepository.SubmitOrder(order).Result;
        }
    }
}
