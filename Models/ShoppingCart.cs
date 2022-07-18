using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YegnaGebiyaSystem.Models
{
    public class ShoppingCart : IDisposable
    {
        private readonly GebiyaContext _gebiyaContext;

        private ShoppingCart(GebiyaContext gebiyaContext)
        {
            _gebiyaContext = gebiyaContext;
        }
        //public ShoppingCart() { }//for paypal function
        public string Id { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        static string cartId;
        public static ShoppingCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?
                              .HttpContext.Session;

            var context = service.GetService<GebiyaContext>();
            //if (!string.IsNullOrWhiteSpace(context.Current.User.Identity.Name))
            //{
            //    cartId = HttpContext.Current.User.Identity.Name;
            //}
            //else
            //{
                cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
                session.SetString("CartId", cartId);
            //}
          return new ShoppingCart(context) { Id = cartId };

        }
        public void Dispose()
        {
            if (_gebiyaContext != null)
            {
                _gebiyaContext.Dispose();
            }
        }
        public void AddToCart(Product product,int amount)
        {
            var shoppingCartItem = _gebiyaContext.ShoppingCartItems.SingleOrDefault(
                s => s.productId == product.ID && s.ShoppingCartId == Id);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                { 
                ShoppingCartId=Id,
                Product=product,
                productId= product.ID,
                Amount =1
                };
                _gebiyaContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _gebiyaContext.SaveChanges();
        }

        public void RemoveFromCart(ShoppingCartItem cartItem)
        {
            var shoppingCartItem = _gebiyaContext.ShoppingCartItems.FirstOrDefault(
                s=> s.ShoppingCartId == cartItem.ShoppingCartId );

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    _gebiyaContext.ShoppingCartItems.Update(shoppingCartItem);
                }
                else
                    _gebiyaContext.ShoppingCartItems.Remove(shoppingCartItem);
            }
            _gebiyaContext.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                (ShoppingCartItems = _gebiyaContext.ShoppingCartItems.Where(
                    c => c.ShoppingCartId == Id)
                .Include(s => s.Product).ToList());
        }

        public void ClearCart()
        {
            var cartItems = _gebiyaContext.ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == Id);
            _gebiyaContext.ShoppingCartItems.RemoveRange(cartItems);

            _gebiyaContext.SaveChanges();
        }

        public double GetShoppingCartTotal()
        {
            var total = _gebiyaContext.ShoppingCartItems.Where(
                   c => c.ShoppingCartId ==Id)
                .Select(c => c.Product.Price * c.Amount).Sum();

            return total;
        }
    }
}
