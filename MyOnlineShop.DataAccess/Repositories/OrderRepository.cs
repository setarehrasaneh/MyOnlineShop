using Microsoft.EntityFrameworkCore;
using MyOnlineShop.Domain.Entities;
using MyOnlineShop.Domain.Repositories;
using MyOnlineShop.InfraStructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyOnlineShop.DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationContext _context;

        public OrderRepository(ApplicationContext context)
        {
            this._context = context;
        }
        public async Task<bool> SubmitOrder(Order order)
        {
            try
            {
                await _context.Orders.AddAsync(order);
                order.OrderItems.ForEach(x => _context.Products.Attach(x.Product));
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
