using Microsoft.AspNetCore.Mvc;
using MyOnlineShop.Domain.Entities;
using MyOnlineShop.Domain.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        public async Task<IActionResult> Index()
        {
            var product = await _productRepository.GetAll();
            return View(product);
        }
    }
}
