using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YegnaGebiyaSystem.Helper;
using YegnaGebiyaSystem.Interfaces;
using YegnaGebiyaSystem.Models;
using YegnaGebiyaSystem.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YegnaGebiyaSystem.Controllers
{
    [Authorize(Policy = "User")]
    public class BuyerController : Controller
    {
        private readonly GebiyaContext _gebiyaContext;
        private readonly IOrderRepository _orderRepository;
        private readonly OrderedCart _orderCart;
        BankAPI _api = new BankAPI();

        public BuyerController(GebiyaContext gebiyaContext, IOrderRepository orderRepository,
                     OrderedCart orderCart)
        {
            _gebiyaContext = gebiyaContext;
            _orderRepository = orderRepository;
            _orderCart = orderCart;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewOrder()
        {
            string username = User.Identity.Name;

            var orderdetail = _gebiyaContext.OrderDetails.Include(o => o.Products).Include(od => od.Order)
                .Include(o => o.Sellers).ThenInclude(b => b.Users)
                .ThenInclude(o => o.Buyers).ThenInclude(b => b.Users)
                .Where(o => o.Buyers.Users.UserName == username);

            var orderViewModel = new OrderViewModel()
            {
                Orderdetail = orderdetail,
                OrderTotal = _orderCart.GetOrderCartTotal(username)
            };
            return View(orderViewModel);
        }

        public IActionResult ViewHistory()
        {
            string username = User.Identity.Name;

            var history = _gebiyaContext.Sold_Items.Include(o => o.Products)
                .Include(o => o.Sellers).ThenInclude(b => b.Users)
                .Include(o => o.Buyers).ThenInclude(b => b.Users)
                .Where(o => o.Buyers.Users.UserName == username);

            var orderViewModel = new OrderViewModel()
            {
                history_item = history
            };
            return View(orderViewModel);
        }

        public IActionResult Delete(int id)
        {
            var history = _gebiyaContext.Sold_Items.FirstOrDefault(h => h.S_i_ID == id);

            _gebiyaContext.Sold_Items.Remove(history);
            _gebiyaContext.SaveChanges();

            return RedirectToAction("ViewHistory", "Buyer");
        }

        public IActionResult Cancel(int id)
        {

            var orderlist = _gebiyaContext.OrderDetails
                .Include(od => od.Products)
                .FirstOrDefault(o => o.OrderDetailId == id);
            if (orderlist != null)
            {
                var item = orderlist.Products;

                item.Quantity = item.Quantity + 1;
                item.Status = "avaliable";
                _gebiyaContext.Products.Update(item);

                if (orderlist.Amount > 1)
                {
                    orderlist.Amount--;
                    _gebiyaContext.OrderDetails.Update(orderlist);
                }
                else
                    _gebiyaContext.OrderDetails.Remove(orderlist);
            }
            else
            {
                return RedirectToAction("NoOrder", "Buyer");
            }
            _gebiyaContext.SaveChanges();

            return RedirectToAction("ViewOrder", "Buyer");
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            string username = User.Identity.Name;
            var user = _gebiyaContext.Users.FirstOrDefault(u => u.UserName.Equals(username));
            var buyer = _gebiyaContext.Buyers.FirstOrDefault(b => b.U_ID == user.Id);

            var orderdetail = _gebiyaContext.OrderDetails.Include(o => o.Products).Include(od => od.Order)
                .Include(o => o.Sellers).ThenInclude(b => b.Users)
                .ThenInclude(o => o.Buyers).ThenInclude(b => b.Users)
                .Where(o => o.Buyers.Users.UserName == username);

            if (orderdetail == null)
            {
                ModelState.AddModelError("", "your cart is empty add some product first");
            }
            if (ModelState.IsValid)
            {
                Order order1 = CreateOrder(order);
                _orderCart.ClearCart(username);
                return RedirectToAction("CheckoutComplete", "Order");
            }
            return View(order);
        }

        public Order CreateOrder(Order order)
        {
            string username = User.Identity.Name;

            var email = order.Email;
            var username1 = order.Username;
            var password = order.Password;
            var orderId = order.OrderId;
            var totalPrice = order.OrderTotal;

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

                    var buyer = _gebiyaContext.Buyers.Include(b => b.Users)
                        .FirstOrDefault(b => b.Users.UserName == username);

                    vendor.Balance = vendor.Balance + ((float)detail.Price )* 98 / 100;
                    _gebiyaContext.Sellers.Update(vendor);

                    var sold = new Sold_Items()
                    {
                        S_Date = DateTime.Now,
                        P_ID = detail.P_ID,
                        B_ID = buyer.B_ID,
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
                //  ViewBag.TransactionNotCompleteMessage = "your Transact5ion is not complete ! ";
            }
            return order;
        }
    }
}
