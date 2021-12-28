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
        public IActionResult Index()
        {
            var product = _productRepository.GetAll().Result.ToList();
            return View(product);
        }
    }
}
