using Microsoft.EntityFrameworkCore;
using MyOnlineShop.Domain.Entities;
using MyOnlineShop.Domain.Repositories;
using MyOnlineShop.InfraStructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOnlineShop.DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationContext _context;

        public OrderRepository(ApplicationContext context)
        {
            this._context = context;
        }
        public bool SubmitOrder(Order order)
        {
            try
            {
                _context.Orders.Add(order);
                order.OrderItems.ForEach(x => _context.Products.Attach(x.Product));
                if (order.Discount == null)
                {
                    _context.Entry(order.Discount).State = EntityState.Unchanged;
                }
        
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
