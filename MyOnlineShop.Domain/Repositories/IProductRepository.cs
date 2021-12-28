using MyOnlineShop.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyOnlineShop.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
    }
}
