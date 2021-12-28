using MyOnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOnlineShop.Domain.Repositories
{
    public interface IDiscountRepository
    {
        //find spesific discount with code
        Discount FindDiscount(string code);
    }
}
