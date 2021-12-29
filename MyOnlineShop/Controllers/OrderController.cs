﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
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
        private readonly IStringLocalizer<OrderController> _stringLocalizer;

        public OrderController(IOrderService orderService, IStringLocalizer<OrderController> stringLocalizer)
        {
            this._orderService = orderService;
            this._stringLocalizer = stringLocalizer;
        }

        public IActionResult FinalizeOrder()
        {
            var cart = SessionHelper.GetObjectFromJson<List<OrderItem>>(HttpContext.Session, "cart");
            try
            {
               _orderService.IsTotalPriceInRange(cart);
                    OrderViewModel orderViewModel = new OrderViewModel
                    {
                        FragileItems = _orderService.GetFragileItems(cart),
                        NormalItems = _orderService.GetNormalItems(cart),
                        Finalprice = _orderService.GetTotalPrice(cart)
                    };

                return View(orderViewModel);
            }
            catch(Exception e)
            {
                ViewBag.ErrorTitle = _stringLocalizer["Error In Order Registration"];
                ViewBag.ErrorMessage = _stringLocalizer["Can Not Register Order Whit Less Than 50000 Total Amount"];
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult SubmitOrder(OrderViewModel orderViewModel)
        {
            try
            {
                var order = new Order
                {
                    OrderItems = SessionHelper.GetObjectFromJson<List<OrderItem>>(HttpContext.Session, "cart"),
                    DiscountId = orderViewModel.DiscountId
                };

                if (_orderService.SubmitOrder(order).Result)
                {
                    HttpContext.Session.Clear();
                };
                return View();
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult SubmitDiscount([FromBody] DiscountViewModel discountViewModel)
        {
            try
            {
                var result = _orderService.GetFactorTotalPrice(discountViewModel.Code, decimal.Parse(discountViewModel.FinalPrice));
                return Json(result);
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }
    }
}
