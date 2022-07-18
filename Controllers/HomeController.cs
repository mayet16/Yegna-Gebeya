
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YegnaGebiyaSystem.Models;
using YegnaGebiyaSystem.ViewModels;

namespace YegnaGebiyaSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly GebiyaContext _gebiyaContext;
        public HomeController(GebiyaContext gebiyaContext)
        {
            _gebiyaContext = gebiyaContext;
        }

        [AllowAnonymous]
        public IActionResult Index(string searchString)

        {
            var item = from m in _gebiyaContext.Products.OrderByDescending(p => p.AddtDate)
                       .Where(p => p.Status.Equals("avaliable")).Take(6)
                       select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                item = item.Where(s => s.Category.Category_Name.Contains(searchString));
            }

            var feedback = _gebiyaContext.Feedbacks.Include(f => f.Users)
                          .Where(f => f.Sender_ID == f.Users.Id);

            var homeViewModel = new HomeViewModel()
            {
                Products = item,
                Feedbacks = feedback
            };
            //function to check the expire date of order
            var orderlist = _gebiyaContext.Orders;
            foreach (var Oitem in orderlist)
            {
                var odate = Oitem.Orderplaced;
                var curentdate = DateTime.Now;
                if ((curentdate - odate).TotalDays >= 10)
                {
                    var orderdetails = _gebiyaContext.OrderDetails.Include(od => od.Products)
                             .Where(od => od.OrderId == Oitem.OrderId);
                    foreach (var detail in orderdetails)
                    {
                        var product = _gebiyaContext.Products.Find(detail.P_ID);
                        product.Quantity = product.Quantity + 1;
                        product.Status = "avaliable";
                        _gebiyaContext.Products.Update(product);

                    }
                    _gebiyaContext.OrderDetails.RemoveRange(orderdetails);
                    _gebiyaContext.Orders.Remove(Oitem);
                }
            }
            _gebiyaContext.SaveChanges();

            return View(homeViewModel);
        }

        [AllowAnonymous]
        public ActionResult About()
        {

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {

            return View();
        }


        [HttpPost]
        [Authorize(Policy = "User")]
        public IActionResult SendFeedback(HomeViewModel model)
        {
            var feedback = _gebiyaContext.Feedbacks.Include(f => f.Users);

            if (ModelState.IsValid)
            {
                try
                {
                    string username = User.Identity.Name;

                    var user = _gebiyaContext.Users
                    .FirstOrDefault(s => s.UserName == username);
                    var feed = new Feedback()
                    {
                        FeedbackBody = model.Feedback.FeedbackBody,
                        Sent_Date = DateTime.Today,
                        Sender_ID = user.Id
                    };
                    HomeViewModel homeViewModel = new HomeViewModel()
                    {
                        Feedback = feed
                    };
                    _gebiyaContext.Feedbacks.Add(homeViewModel.Feedback);
                    _gebiyaContext.SaveChanges();
                }
                catch (Exception e)
                {
                    e.Message.Contains("You Can't give a feedback for a system! please login");
                }
            }
            return RedirectToAction("index", "home");
        }

        [AllowAnonymous]
        public IActionResult Notfound()
        {
            return View();
        }
        public IActionResult BuyerNotConfirm()
        {
            return View();
        }

    }
}
