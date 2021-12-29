using Microsoft.AspNetCore.Mvc;
using MyOnlineShop.Domain.Entities;
using MyOnlineShop.Domain.Helpers;
using MyOnlineShop.Domain.Service;
using System;
using System.Collections.Generic;

namespace MyOnlineShop.Controllers
{
    public class CartController : Controller
    {

        private readonly IOrderService _orderService;

        public CartController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        public IActionResult Index()
        {
            try
            {

                var cart = SessionHelper.GetObjectFromJson<List<OrderItem>>(HttpContext.Session, "cart");
                ViewBag.cart = cart;
                ViewBag.total = _orderService.GetTotalPrice(cart);
                return View();
            }
            catch(Exception e)
            {
                return View("Error");
            }
        }

        public IActionResult AddToCart(int id)
        {
            try
            {
                List<OrderItem> cart = SessionHelper.GetObjectFromJson<List<OrderItem>>(HttpContext.Session, "cart");
                var newCart = _orderService.AddItemsToOrder(cart, id);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", newCart);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }

        public IActionResult RemoveFromCart(int id)
        {
            try
            {
                List<OrderItem> cart = SessionHelper.GetObjectFromJson<List<OrderItem>>(HttpContext.Session, "cart");
                var newCart = _orderService.RemoveItemFromOrder(cart, id);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", newCart);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }
    }
}
