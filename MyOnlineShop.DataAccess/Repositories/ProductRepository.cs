using Microsoft.EntityFrameworkCore;
using MyOnlineShop.Domain.Entities;
using MyOnlineShop.Domain.Repositories;
using MyOnlineShop.InfraStructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlineShop.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            this._context = context;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
