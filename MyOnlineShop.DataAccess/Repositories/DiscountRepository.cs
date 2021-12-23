using MyOnlineShop.Domain.Entities;
using MyOnlineShop.Domain.Repositories;
using MyOnlineShop.InfraStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyOnlineShop.DataAccess.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly ApplicationContext _context;

        public DiscountRepository(ApplicationContext context)
        {
            this._context = context;
        }
        public Discount FindDiscount(string code)
        {
            return _context.Discounts.ToList().Where(x => x.Code == code).FirstOrDefault();
        }
    }
}
