
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using YegnaGebiyaSystem.Helper;
using YegnaGebiyaSystem.Interfaces;
using YegnaGebiyaSystem.Models;

namespace YegnaGebiyaSystem.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GebiyaContext _gebiyaContext;
        private readonly ShoppingCart _shoppingCart;
        BankAPI _api = new BankAPI();

        public OrderRepository(GebiyaContext gebiyaContext, ShoppingCart shoppingCart)
        {
            _gebiyaContext = gebiyaContext;
            _shoppingCart = shoppingCart;
        }

        public Order CreateOrder(Order order, int buyerId)
        {
            var shoppingcartItems = _shoppingCart.ShoppingCartItems;

            foreach (var item in shoppingcartItems)
            {
                order.OrderTotal = order.OrderTotal + item.Product.Price;
            }

            order.Orderplaced = DateTime.Now;
            _gebiyaContext.Orders.Add(order);
            _gebiyaContext.SaveChanges();


            foreach (var item in shoppingcartItems)
            {
                var orderDetail = new OrderDetails()
                {
                    Amount = item.Amount,
                    P_ID = item.productId,
                    OrderId = order.OrderId,
                    Price = item.Product.Price,
                    B_ID = buyerId,
                    S_ID = item.Product.S_ID
                };
                _gebiyaContext.OrderDetails.Add(orderDetail);
            }
            _gebiyaContext.SaveChanges();


            HttpClient client = _api.Initial();
            var postTalk = client.PostAsJsonAsync<Order>("BankAPI/postuser", order);
            postTalk.Wait();
            var result = postTalk.Result;

            if (result.IsSuccessStatusCode)
            {
                var orderdetails = _gebiyaContext.OrderDetails.Include(od => od.Products)
                                     .ThenInclude(p => p.Sellers)
                                 .Where(od => od.OrderId == order.OrderId);
                foreach (var detail in orderdetails)
                {
                    var vendor = _gebiyaContext.Sellers
                        .FirstOrDefault(v => v.Seller_ID == detail.Products.Sellers.Seller_ID);
                    vendor.Balance = vendor.Balance + ((float)detail.Price)*98/100;
                    _gebiyaContext.Sellers.Update(vendor);

                    var sold = new Sold_Items()
                    {
                        S_Date = DateTime.Now,
                        P_ID = detail.P_ID,
                        B_ID = buyerId,
                        S_ID = vendor.Seller_ID
                    };
                    _gebiyaContext.Sold_Items.Add(sold);
                }

                _gebiyaContext.OrderDetails.RemoveRange(orderdetails);
                _gebiyaContext.SaveChanges();
                _gebiyaContext.Orders.Remove(order);
                _gebiyaContext.SaveChanges();
            }

            else
            {
                return null;
            }
            return order;
        }

    }
}
