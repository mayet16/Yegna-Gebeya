using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using YegnaGebiyaSystem.Helper;
using YegnaGebiyaSystem.Interfaces;
using YegnaGebiyaSystem.Models;

namespace YegnaGebiyaSystem.Controllers
{
    public class OrderController : Controller
    {
        private readonly GebiyaContext _gebiyaContext;
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(GebiyaContext gebiyaContext,IOrderRepository orderRepository,ShoppingCart shoppingCart)
        {
            _gebiyaContext = gebiyaContext;
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }
   
        public ViewResult Checkout()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Checkout(Order order)
        {

            string username = User.Identity.Name;
            var user = _gebiyaContext.Users.FirstOrDefault(u => u.UserName.Equals(username));
            var buyer = _gebiyaContext.Buyers.FirstOrDefault(b => b.U_ID == user.Id);

            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "your cart is empty add some product first");
            }
            if (ModelState.IsValid)
            {
               var orders= _orderRepository.CreateOrder(order, buyer.B_ID);
                _shoppingCart.ClearCart();
                if (orders != null)
                {
                    return RedirectToAction("CheckoutComplete");
                }
                else
                return RedirectToAction("OrderComplete");
            }
            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Your Transaction is Complete ! ";
            return View();
        }

        public IActionResult OrderComplete()
        {
            ViewBag.OrderCompleteMessage = "Thanks for your order ! ";
            return View();
        }
    }
}
