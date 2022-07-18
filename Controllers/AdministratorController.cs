using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using YegnaGebiyaSystem.Models;
using YegnaGebiyaSystem.ViewModels;

namespace YegnaGebiyaSystem.Controllers
{
    [Authorize(Policy = "AdminRolePolicy")]
    public class AdministratorController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _adminRepository;
        private readonly GebiyaContext context;
        private readonly SignInManager<User> signInManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly UserManager<User> userManager;

        public AdministratorController(ILogger<HomeController> logger, IUserRepository adminRepository, GebiyaContext context,
                                        SignInManager<User> signInManager, IWebHostEnvironment hostingEnvironment, UserManager<User> userManager)
        {
            _logger = logger;
            _adminRepository = adminRepository;
            this.context = context;
            this.signInManager = signInManager;
            this.hostingEnvironment = hostingEnvironment;
            this.userManager = userManager;
        }

        private string ProcessUploadedFile(AdministratorAdminEditViewModel model)
        {
            string uniqueFileName = null;

            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        public IActionResult ViewCatagory()
        {
            IEnumerable<Category> categories = context.Categories.FromSqlRaw("Select * from Categories");
            return View(categories);
        }

        public IActionResult ViewSeller()
        {
            List<Seller> sellersList = context.Sellers.ToList();
            List<User> usersList = context.Users.ToList();
            var sellers = from s in sellersList
                          join u in usersList on s.Users.Id equals u.Id into table1
                          from u in table1.ToList()
                          select new SellerViewModel
                          {
                              seller = s,
                              user = u,
                          };
            return View(sellers);
        }

        public IActionResult ViewBuyer()
        {
            List<Buyer> buyersList = context.Buyers.ToList();
            List<User> usersList = context.Users.ToList();
            var buyers = from b in buyersList
                         join u in usersList on b.Users.Id equals u.Id into table1
                         from u in table1.ToList()
                         select new BuyerViewModel
                         {
                             buyer = b,
                             user = u,
                         };
            return View(buyers);
        }

        [HttpGet]
        public IActionResult ViewUsers()
        {
            var users = userManager.Users;
            return View(users);
        }
        [HttpGet]
        public IActionResult ViewState()
        {
            var users = userManager.Users;
            return View(users);
        }

        [HttpGet]
        public IActionResult ViewProduct()
        {
            List<Product> productsList = context.Products.ToList();
            List<Category> categories = context.Categories.ToList();
            List<Seller> sellersList = context.Sellers.ToList();
            List<User> usersList = context.Users.ToList();
            var products = from p in productsList
                           join c in categories on p.Cat_ID equals c.Category_ID into table1
                           from c in table1.ToList()
                           join s in sellersList on p.S_ID equals s.Seller_ID into table3
                           from s in table3.ToList()
                           join u in usersList on p.Sellers.Users.Id equals u.Id into table4
                           from u in table4.ToList()
                           select new ProductDisplayViewModel
                           {
                               category = c,
                               product = p,
                               seller = s,
                               user = u,
                           };
            return View(products);
        }


        public IActionResult ViewTracsaction()
        {
            List<OrderDetails> order_Lists = context.OrderDetails.ToList();
            List<Product> productsList = context.Products.ToList();
            List<Buyer> buyersList = context.Buyers.ToList();
            List<Seller> sellersList = context.Sellers.ToList();
            List<User> usersList = context.Users.ToList();
            var order = from o in order_Lists
                        join p in productsList on o.P_ID equals p.ID into table1
                        from p in table1.ToList()
                        join b in buyersList on o.B_ID equals b.B_ID into table2
                        from b in table2.ToList()
                        join s in sellersList on o.S_ID equals s.Seller_ID into table3
                        from s in table3.ToList()
                        join u in usersList on b.U_ID equals u.Id into table4
                        from u in table4.ToList()
                        select new orderListViewModel
                        {
                            order_List = o,
                            product = p,
                            buyer = b,
                            seller = s,
                            user = u,
                        };
            return View(order);
        }

        [HttpGet]
        public IActionResult Feedback()
        {
            List<Feedback> feedbacksList = context.Feedbacks.ToList();
            List<User> usersList = context.Users.ToList();
            var feedback = from f in feedbacksList
                           join u in usersList on f.Users.Id equals u.Id into table1
                           from u in table1.ToList()
                           select new FeedbackViewModel
                           {
                               feedback = f,
                               user = u,
                           };
            return View(feedback);
        }


        [HttpGet]
        public IActionResult ReplayFeedback(int id)
        {
            Feedback feedback = context.Feedbacks.Find(id);
            FeedbackViewModel feedbackViewModel = new FeedbackViewModel
            {
                ID = feedback.ID,
                Replay = feedback.Replay
            };

            return View(feedbackViewModel);
        }

        [HttpPost]
        public IActionResult ReplayFeedback(FeedbackViewModel model)
        {

            Feedback feedbacks = context.Feedbacks.Find(model.ID);
            feedbacks.Replay = model.Replay;
            context.Feedbacks.Update(feedbacks);
            context.SaveChanges();
            return RedirectToAction("Feedback");
        }


        [HttpGet]
        public IActionResult Profile()
        {
            User u = context.Users.SingleOrDefault(u => u.UserName == User.Identity.Name);
            User user = context.Users.Find(u.Id);
            AdministratorProfileViewModel administratorProfileViewModel = new AdministratorProfileViewModel()
            {
                User = user,
                PageTitle = "Profile",
                ExistingPhotoPath = user.Image

            };
            return View(administratorProfileViewModel);
        }

        [HttpGet]
        public IActionResult EditProfile(int id)
        {
            User user = _adminRepository.GetAdmin(id);
            AdministratorAdminEditViewModel administratorAdminEditViewModel = new AdministratorAdminEditViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                name = user.Name,
                ExistingPhotoPath = user.Image
            };

            return View(administratorAdminEditViewModel);
        }

        [HttpPost]
        public IActionResult EditProfile(AdministratorAdminEditViewModel model)
        {

            if (ModelState.IsValid)
            {
                User user = _adminRepository.GetAdmin(model.Id);
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.Name = model.name;
                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "Image", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    user.Image = ProcessUploadedFile(model);
                }
                _adminRepository.Update(user);
                return RedirectToAction("profile");
            }
            return View(model);
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToAction("login");
                }

                var result = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }
                await signInManager.RefreshSignInAsync(user);
                return View("ChangePasswordConfirmation");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            User user = _adminRepository.GetAdmin(id);
            AdministratorAdminEditViewModel administratorAdminEditViewModel = new AdministratorAdminEditViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                name = user.Name,
                State = user.Status,
                ExistingPhotoPath = user.Image
            };

            return View(administratorAdminEditViewModel);
        }

        [HttpPost]
        public IActionResult EditUser(AdministratorAdminEditViewModel model)
        {
            User user = _adminRepository.GetAdmin(model.Id);
            user.Status = model.State;
            _adminRepository.Update(user);
            return RedirectToAction("ViewUsers");
        }

        //[HttpPost]
        //public async Task<IActionResult> DeleteUser(string id)
        //{
        //    var user = await userManager.FindByIdAsync(id);

        //    Buyer buyer = context.Buyers.SingleOrDefault(o => o.U_ID == user.Id);
        //    Seller seller = context.Sellers.SingleOrDefault(o => o.U_ID == user.Id);
        //    Order_List order = context.Order_Lists.SingleOrDefault(o => o.B_ID == buyer.B_ID);
        //    Feedback feedback = context.Feedbacks.SingleOrDefault(o => o.Sender_ID == user.Id);
        //    Product product = context.Products.SingleOrDefault(o => o.S_ID == seller.Seller_ID);
        //    Sold_Items sold = context.Sold_Items.SingleOrDefault(o => o. == user);

        //    if (order != null)
        //    {
        //        context.Order_Lists.Remove(order);
        //        if (order != null)
        //        {
        //            context.Comments.Remove(order);
        //        }
        //        if (order != null)
        //        {
        //            context.Order_Lists.Remove(order);
        //        }
        //        context.Products.Remove(product);
        //        context.SaveChanges();
        //    }


        //    if (user == null)
        //    {
        //        ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
        //        return View("NotFound");
        //    }
        //    else
        //    {
        //        var result = await userManager.DeleteAsync(user);

        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("ViewUsers");
        //        }

        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError("", error.Description);
        //        }

        //        return View("ViewUsers");
        //    }
        //}


        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            Product product = context.Products.Find(id);
            ProductDisplayViewModel productDisplay = new ProductDisplayViewModel
            {
                ID = product.ID,
                Name = product.Name
            };

            return View(productDisplay);
        }

        [HttpPost]
        public IActionResult DeleteProduct(ProductDisplayViewModel model)
        {
            Product product = context.Products.Find(model.ID);
            Book book = context.Books.SingleOrDefault(b => b.P_ID == model.ID);
            Car car = context.Cars.SingleOrDefault(b => b.P_ID == model.ID);
            Cloth cloth = context.Cloths.SingleOrDefault(b => b.P_ID == model.ID);
            Computer computer = context.Computers.SingleOrDefault(b => b.P_ID == model.ID);
            House house = context.Houses.SingleOrDefault(b => b.P_ID == model.ID);
            Phone phone = context.Phones.SingleOrDefault(b => b.P_ID == model.ID);
            Shoes shoes = context.Shoes.SingleOrDefault(b => b.P_ID == model.ID);
            Comment comment = context.Comments.SingleOrDefault(b => b.Item_ID == model.ID);
            OrderDetails order = context.OrderDetails.SingleOrDefault(b => b.P_ID == model.ID);

            if (book != null)
            {
                context.Books.Remove(book);
                if (comment != null)
                {
                    context.Comments.Remove(comment);
                }
                if (order != null)
                {
                    context.OrderDetails.Remove(order);
                }
                context.Products.Remove(product);
                context.SaveChanges();
            }
            else if (car != null)
            {
                context.Cars.Remove(car);
                if (comment != null)
                {
                    context.Comments.Remove(comment);
                }
                if (order != null)
                {
                    context.OrderDetails.Remove(order);
                }
                context.Products.Remove(product);
                context.SaveChanges();
            }
            else if (cloth != null)
            {
                context.Cloths.Remove(cloth);
                if (comment != null)
                {
                    context.Comments.Remove(comment);
                }
                if (order != null)
                {
                    context.OrderDetails.Remove(order);
                }
                context.Products.Remove(product);
                context.SaveChanges();
            }
            else if (computer != null)
            {
                context.Computers.Remove(computer);
                if (comment != null)
                {
                    context.Comments.Remove(comment);
                }
                if (order != null)
                {
                    context.OrderDetails.Remove(order);
                }
                context.Products.Remove(product);
                context.SaveChanges();
            }
            else if (house != null)
            {
                context.Houses.Remove(house);
                if (comment != null)
                {
                    context.Comments.Remove(comment);
                }
                if (order != null)
                {
                    context.OrderDetails.Remove(order);
                }
                context.Products.Remove(product);
                context.SaveChanges();
            }
            else if (phone != null)
            {
                context.Phones.Remove(phone);
                if (comment != null)
                {
                    context.Comments.Remove(comment);
                }
                if (order != null)
                {
                    context.OrderDetails.Remove(order);
                }
                context.Products.Remove(product);
                context.SaveChanges();
            }
            else if (shoes != null)
            {
                context.Shoes.Remove(shoes);
                if (comment != null)
                {
                    context.Comments.Remove(comment);
                }
                if (order != null)
                {
                    context.OrderDetails.Remove(order);
                }
                context.Products.Remove(product);
                context.SaveChanges();
            }

            return RedirectToAction("ViewProduct");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Dashboard()
        {
            List<OrderDetails> order_Lists = context.OrderDetails.ToList();
            List<Product> productsList = context.Products.ToList();
            List<Buyer> buyersList = context.Buyers.ToList();
            List<Seller> sellersList = context.Sellers.ToList();
            List<User> usersList = context.Users.ToList();
            List<Sold_Items> soldList = context.Sold_Items.ToList();

            var userno = usersList.Count();
            var productno = productsList.Count();
            var orderno = order_Lists.Count();
            var soldno = soldList.Count();
            double TotalCost = 0;
            foreach (var item in productsList)
            {
                TotalCost = item.Price + TotalCost;
            }

            var order = from o in order_Lists
                        join p in productsList on o.P_ID equals p.ID into table1
                        from p in table1.ToList()
                        join b in buyersList on o.B_ID equals b.B_ID into table2
                        from b in table2.ToList()
                        join s in sellersList on o.S_ID equals s.Seller_ID into table3
                        from s in table3.ToList()
                        join u in usersList on b.U_ID equals u.Id into table4
                        from u in table4.ToList()
                        select new AdminDashboardViewModel
                        {
                            order_List = o,
                            product = p,
                            buyer = b,
                            seller = s,
                            user = u,
                            UserNumber = userno,
                            ProductNumber = productno,
                            OrderNumber = orderno,
                            TotalCost = TotalCost
                        };
            return View(order);
        }
    }
}
