using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyOnlineShop.Domain.Entities;
using MyOnlineShop.Domain.Helpers;
using MyOnlineShop.Domain.Service;
using MyOnlineShop.Models;
using System;
using System.Collections.Generic;

namespace MyOnlineShop.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        public IActionResult FinalizeOrder()
        {
            var cart = SessionHelper.GetObjectFromJson<List<OrderItem>>(HttpContext.Session, "cart");

            if (_orderService.GetTotalPrice(cart) < 50000)
            {
                throw new Exception("ثبت سفارش برای مبالغ کمتر از 50000 امکان پذیر نمیباشد");
            }

            OrderViewModel orderViewModel = new OrderViewModel
            {
                FragileItems = _orderService.GetFragileItems(cart),
                NormalItems = _orderService.GetNormalItems(cart),
                TotalPrice = _orderService.GetTotalPrice(cart)
            };

            return View(orderViewModel);
        }

        public IActionResult SubmitOrder()
        {
            var order = new Order
            {
                OrderItems = SessionHelper.GetObjectFromJson<List<OrderItem>>(HttpContext.Session, "cart")
            };

            string message;
            if (_orderService.SubmitOrder(order))
            {
                HttpContext.Session.Clear();
                message = "درخواست شما با موفقیت ثبت شد";
            };
           
            return View();
        }

        public IActionResult SubmitDiscount(string code)
        {
                return View();
        }
    }
}
