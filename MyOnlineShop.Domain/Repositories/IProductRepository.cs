using MyOnlineShop.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyOnlineShop.Domain.Repositories
{
    public interface IProductRepository
    {
        // get all product list
        Task<List<Product>> GetAll();
    }
}
