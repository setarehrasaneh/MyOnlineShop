using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyOnlineShop.Domain.Entities;
using MyOnlineShop.Domain.Helpers;
using MyOnlineShop.Domain.Repositories;
using MyOnlineShop.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlineShop.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        public IActionResult SubmitOrder()
        {
            var cart = SessionHelper.GetObjectFromJson<List<OrderItem>>(HttpContext.Session, "cart");
            if (_orderService.GetTotalPrice(cart) < 50000)
            {
               HttpContext.Response.WriteAsync("ثبت سفارش برای مبالغ کمتر از 50000 امکان پذیر نمیباشد");
            }

            return View();
        }
    }
}
