using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YegnaGebiyaSystem.Models
{
    public class OrderedCart
    {
        private readonly GebiyaContext _gebiyaContext;

        private OrderedCart(GebiyaContext gebiyaContext)
        {
            _gebiyaContext = gebiyaContext;
        }
        public static OrderedCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?
                              .HttpContext.Session;
            var context = service.GetService<GebiyaContext>();
            return new OrderedCart(context) { };

        }

        public List<OrderDetails> OrderDetails { get; set; }

        public double GetOrderCartTotal(string username)
        {
            var total = _gebiyaContext.OrderDetails.Where(
                   c => c.Buyers.Users.UserName == username)
                .Select(c => c.Products.Price * c.Amount).Sum();

            return total;
        }

        public void ClearCart(string username)
        {
            var cartItems = _gebiyaContext.OrderDetails.Include(od=>od.Order)
                .Where(cart => cart.Buyers.Users.UserName == username);

            foreach (var order in cartItems)
            {
                _gebiyaContext.Orders.Remove(order.Order);
            }
            _gebiyaContext.OrderDetails.RemoveRange(cartItems);
      
            _gebiyaContext.SaveChanges();
        }
    }
}
