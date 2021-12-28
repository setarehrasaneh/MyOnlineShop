using MyOnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyOnlineShop.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<bool> SubmitOrder(Order order);
    }
}
