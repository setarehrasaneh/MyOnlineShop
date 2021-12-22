using MyOnlineShop.Domain.Entities;
using System.Collections.Generic;

namespace MyOnlineShop.Domain.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
    }
}
