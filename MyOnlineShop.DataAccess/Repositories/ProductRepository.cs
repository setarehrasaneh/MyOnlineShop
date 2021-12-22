using MyOnlineShop.Domain.Entities;
using MyOnlineShop.Domain.Repositories;
using MyOnlineShop.InfraStructure;
using System.Collections.Generic;
using System.Linq;

namespace MyOnlineShop.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            this._context = context;
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }
    }
}
