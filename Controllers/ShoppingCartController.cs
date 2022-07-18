using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YegnaGebiyaSystem.Models;
using YegnaGebiyaSystem.ViewModels;

namespace YegnaGebiyaSystem.Controllers
{
    [AllowAnonymous]
    public class ShoppingCartController : Controller
    {
        
        private readonly ShoppingCart _shoppingCart;
        private readonly GebiyaContext _gebiyaContext;
        IServiceProvider service;

        public ShoppingCartController(GebiyaContext gebiyaContext,ShoppingCart shoppingCart,
                IServiceProvider service)
        {
            this.service = service;
            _shoppingCart = shoppingCart;
            _gebiyaContext = gebiyaContext;
        }
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var SCVM = new ShoppingCartViewModel
            {
                ShoppingCart=_shoppingCart,
                ShoppingCartTotal=_shoppingCart.GetShoppingCartTotal()
            };

            return View(SCVM);
        }
        public IActionResult AddToShoppingCart( int id)
        {
            var selectedProduct = _gebiyaContext.Products.Include(s => s.Sellers).FirstOrDefault(
                                  p => p.ID == id);
            if (selectedProduct != null)
            {
                if (selectedProduct.Quantity < 0)
                {
                    return RedirectToAction("productnotfound", "home");
                }

                else if (selectedProduct.Quantity == 1)
                {
                    selectedProduct.Status = "Orderd";
                }

                selectedProduct.Quantity = selectedProduct.Quantity - 1;
                _shoppingCart.AddToCart(selectedProduct, 1);
                _gebiyaContext.Products.Update(selectedProduct);
            }
            else return RedirectToAction("productnotfound", "home");

            _gebiyaContext.SaveChanges();
            return RedirectToAction("index","home");

    }
      
        public RedirectToActionResult RemoveFromShoppingCart(int id)
        {
            var selectedProduct = _gebiyaContext.ShoppingCartItems.Include(s=>s.Product)
                         .FirstOrDefault( p => p.productId == id);
            if (selectedProduct != null)
            {
                var product = selectedProduct.Product;
                product.Quantity = product.Quantity + 1;
                product.Status = "avaliable";
                _shoppingCart.RemoveFromCart(selectedProduct);
                _gebiyaContext.Products.Update(product);
            }
            else return RedirectToAction("productnotfound", "home");
            _gebiyaContext.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
