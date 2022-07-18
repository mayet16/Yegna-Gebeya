using System;
using System.Collections.Generic;
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
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private GebiyaContext _gebiyaContext;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly RoleManager<UserRole> roleManager;
        private readonly ILogger<AccountController> logger;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, GebiyaContext gebiyaContext,
                                      IWebHostEnvironment hostingEnvironment, RoleManager<UserRole> roleManager,
                                        ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _gebiyaContext = gebiyaContext;
            _hostingEnvironment = hostingEnvironment;
            this.roleManager = roleManager;
            this.logger = logger;
        }

        private string ProcessUploadedFile(ProfileViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                    model.Photo.CopyTo(fileStream);

            }

            return uniqueFileName;
        }

        [Authorize]
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [Authorize]
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
        [Authorize]
        [HttpGet]
        public ActionResult Profile()
        {
            string username = User.Identity.Name;
            //string username = "natyman";

            // Fetch the userprofile
            var user = _gebiyaContext.Users.FirstOrDefault(u => u.UserName.Equals(username));

            // Construct the viewmodel
            ProfileViewModel profilemodel = new ProfileViewModel()
            {
                Email = user.Email,
                UserName = user.UserName,
                Name = user.Name,
                ExistingImage = user.Image,
                PhoneNumber = user.PhoneNumber,
                Sex = user.Sex,
                Nationality = user.Nationality

            };
            return View(profilemodel);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Profile(ProfileViewModel profilemodel)
        {
            if (ModelState.IsValid)
            {
                string username = User.Identity.Name;
                // string username = "natyman";
                // Get the userprofile
                var user = _gebiyaContext.Users.FirstOrDefault(u => u.UserName.Equals(profilemodel.UserName));

                if (profilemodel.Photo != null)
                {
                    if (profilemodel.ExistingImage != null)
                    {
                        string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", profilemodel.ExistingImage);
                        System.IO.File.Delete(filePath);
                    }
                    user.Image = ProcessUploadedFile(profilemodel);
                }

                // Update fields
                user.UserName = profilemodel.UserName;
                user.Email = profilemodel.Email;
                user.Name = profilemodel.Name;
                user.PhoneNumber = profilemodel.PhoneNumber;
                user.Sex = profilemodel.Sex;
                user.Nationality = profilemodel.Nationality;

                _gebiyaContext.Entry(user).State = EntityState.Modified;

                _gebiyaContext.SaveChanges();

                return RedirectToAction("Index", "Home"); // or whatever
            }

            return View(profilemodel);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Register(string accountExist)
        {
            if (accountExist != null)
            {
                // ViewBag.AccountExisted = "The Bank Account Number is Not Your,Please Type Your Account Number Correctly";
                return View("Register");
            }
            return View();
        }


        [AllowAnonymous]
        [HttpPost]

        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var usersInUsername = _gebiyaContext.Users.SingleOrDefault(u => u.UserName == registerViewModel.UserName);
                    if (usersInUsername != null)
                    {
                        ViewBag.ErrorMessage = $"The UserName ={usersInUsername.UserName} Is Alerady Exist";
                        return View("Register");
                    }

                    var user = new User
                    {
                        UserName = registerViewModel.UserName,
                        Email = registerViewModel.Email,
                        Nationality = "Ethiopia",
                        Name = registerViewModel.Name,
                        EmailConfirmed = true,
                        Status = "Active"
                    };

                    var result = await userManager.CreateAsync(user, registerViewModel.Password);

                    if (result.Succeeded)
                    {
                        var u = _gebiyaContext.Users.Find(user.Id);

                        Seller newseller = new Seller
                        {
                            Address = registerViewModel.Address,
                            Ratting = 0,
                            U_ID = u.Id
                        };
                        Buyer newbuyer = new Buyer
                        {
                            U_ID = u.Id
                        };

                        _gebiyaContext.Sellers.Add(newseller);
                        _gebiyaContext.Buyers.Add(newbuyer);
                        _gebiyaContext.SaveChanges();

                        UserRole userRole = new UserRole
                        {
                            Name = "User"
                        };
                        IdentityResult r = await roleManager.CreateAsync(userRole);
                        await userManager.AddToRoleAsync(user, userRole.Name);

                        await signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
             
            }

            return View(registerViewModel);
        }


        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {


            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"The Email{email} aleready In Use");
            }


        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            User user = _gebiyaContext.Users.SingleOrDefault(o => o.UserName == model.UserName);

            if (ModelState.IsValid)
            {
                if (user.Status == "Active")
                {
                    var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        if (User.IsInRole("Admin"))
                        {
                            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                            {
                                return Redirect(returnUrl);
                            }
                            else
                            {
                                return RedirectToAction("Dashboard", "Administrator");
                            }
                        }
                        else 
                        {
                            return RedirectToAction("index", "home");

                        }
                    }
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                }
            }
            else
            {
                return View("AccessDenied");
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null && await userManager.IsEmailConfirmedAsync(user))
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);
                    var passwordResetLink = Url.Action("ResetPassword", "Account", new { email = model.Email, token }, Request.Scheme);
                    logger.Log(LogLevel.Warning, passwordResetLink);
                    return View("ForgotPasswordConfirmation");
                }
                return View("ForgotPasswordConfirmation");
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            if (token == null || email == null)
            {
                ModelState.AddModelError("", "Invalid password reset token");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }
                return View("Login");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
    }
}
