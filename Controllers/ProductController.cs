using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YegnaGebiyaSystem.Models;

using YegnaGebiyaSystem.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YegnaGebiyaSystem.Controllers
{
    [Authorize(Policy = "User")]
    public class ProductController : Controller
    {
        private readonly GebiyaContext _gebiyaContext;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly SignInManager<User> signInManager;

        public ProductController(GebiyaContext gebiyaContext, IWebHostEnvironment hostingEnvironment
            , SignInManager<User> signInManager)
        {
            _gebiyaContext = gebiyaContext;
            this.hostingEnvironment = hostingEnvironment;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(string sortOrder,
                                                 string currentFilter,
                                                 string searchString,
                                                 int? pageNumber)
        {

            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DatedesSortParm"] = "date_desc";
            ViewData["DateSortParm"] = "Date";
            ViewData["PriceSortParm"] = "price_Ass";
            ViewData["PriceDesSortParm"] = "price_desc";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            var products = from s in _gebiyaContext.Products.Where(p => p.Status.Equals("avaliable"))
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString)
                                    || s.Name.StartsWith(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    products = products.OrderBy(s => s.AddtDate);
                    break;
                case "date_desc":
                    products = products.OrderByDescending(s => s.AddtDate);
                    break;
                case "price_Ass":
                    products = products.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(s => s.Price);
                    break;
                default:
                    products = products.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 6;
            return View(await PaginatedList<Product>.CreateAsync(products.AsNoTracking(), pageNumber ?? 1,
            pageSize));
        }
        [AllowAnonymous]
        public JsonResult getProduct(string term)
        {
            List<string> items;
            items = _gebiyaContext.Products.Where(x => x.Name.StartsWith(term))
                   .Select(y => y.Name).ToList();
            // return Json(items, JsonRequestBehavior.AllowGet);
            return Json(items);
        }
        // GET: Products/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await _gebiyaContext.Products.Include(p => p.Sellers).ThenInclude(s=>s.Users)
                             .Include(p=>p.Books).Include(p => p.Cars).Include(p => p.Cloths).Include(p => p.Computers)
                             .Include(p => p.Houses).Include(p => p.Phones).Include(p => p.Shoes).Include(p => p.Comments)
                             .ThenInclude(c=>c.Buyers).ThenInclude(b=>b.Users)
                             .Where(p=>p.S_ID==p.Sellers.Seller_ID)
                          .FirstOrDefaultAsync(p => p.ID == id);

            ProductViewModel productViewModel = new ProductViewModel()
            {
                Product = item
            };
            if (productViewModel == null)
            {
                return NotFound();
            }
            return View(productViewModel);
        }

        [AllowAnonymous]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Product> products=null;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                products = _gebiyaContext.Products.OrderByDescending(n => n.AddtDate);
                currentCategory = "All Products";
            }
            else
            {
                if (string.Equals("Electronics", _category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _gebiyaContext.Products.Where(p => p.Category.Category_Name.Equals("Electronics") && p.Status.Equals("avaliable"))
                        .OrderBy(p => p.Name);
                    currentCategory = _category;
                }
                else if (string.Equals("House", _category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _gebiyaContext.Products.Where(p => p.Category.Category_Name.Equals("House") && p.Status.Equals("avaliable")).OrderBy(p => p.Name);
                    currentCategory = _category;
                }
                else if (string.Equals("Fasion", _category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _gebiyaContext.Products.Where(p => p.Category.Category_Name.Equals("Fasion") && p.Status.Equals("avaliable")).OrderBy(p => p.Name);
                    currentCategory = _category;
                }
                else if (string.Equals("Car", _category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _gebiyaContext.Products.Where(p => p.Category.Category_Name.Equals("Car") && p.Status.Equals("avaliable")).OrderBy(p => p.Name);
                    currentCategory = _category;
                }
                else if (string.Equals("Book", _category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _gebiyaContext.Products.Where(p => p.Category.Category_Name.Equals("Book") && p.Status.Equals("avaliable")).OrderBy(p => p.Name);
                    currentCategory = _category;
                }
            }
            var productListViewModel = new ProductViewModel
            {
                currentCategory = currentCategory,
                Products = products

            };
            return View(productListViewModel);
        }

        [HttpGet]
        public IActionResult SendComment()
        {
           
            return View();
        }
      
        [HttpPost]
        [Authorize(Policy = "User")]
        public IActionResult SendComment(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                try {
                    string username = User.Identity.Name;

                    var buyer = _gebiyaContext.Buyers.Include(b => b.Users)
                    .FirstOrDefault(s => s.Users.UserName == username);
                    var comment = new Comment()
                    {
                        CommentBody = productViewModel.CommentBody,
                        Sent_Date = DateTime.Today,
                        Buyer_ID = buyer.B_ID,
                        Item_ID = productViewModel.PId,
                       // Name = buyer.Users.Name
                };

                    _gebiyaContext.Comments.Add(comment);
                    _gebiyaContext.SaveChanges();
                }catch(Exception e)
                {
                    e.Message.Contains("You Can't give a comment for a product! please login");
                }
            }
            return RedirectToAction("Details","Product",new {id= productViewModel.PId});
        }

        [HttpGet]
        [Authorize]
        public ViewResult ProductList()
        {
            string Logedinname = null;
            if (signInManager.IsSignedIn(User))
            {
                Logedinname = User.Identity.Name;
            }
            User loginuser = _gebiyaContext.Users.SingleOrDefault(user => user.UserName == Logedinname);
            Seller loginseller = _gebiyaContext.Sellers.SingleOrDefault(seller => seller.U_ID == loginuser.Id);
            List<Product> productsList = _gebiyaContext.Products.Where(p => p.S_ID == loginseller.Seller_ID).ToList();


            List<Comment> Comment_List = _gebiyaContext.Comments.ToList();
            List<Buyer> buyersList = _gebiyaContext.Buyers.ToList();
            var productlist = from p in productsList
                              join c in Comment_List on p.ID equals c.Item_ID into table1
                              select new SellerOrderListViewModel
                              {
                                  products = p,
                                  commentcount = table1.Count()

                              };
            return View(productlist);

            //IEnumerable<Product> products = _context.Products.FromSqlRaw($"Select * from Products where Status = 'avaliable' and S_ID={loginseller.Seller_ID}");
            ////OR   
            ////List<Product> products = _context.Products.FromSqlRaw($"Select * from Products where Status = 'avaliable'and S_ID={loginseller.Seller_ID}").ToList();
            //if (products.Count() == 0)
            //{
            //    ViewBag.ErrorMessage = "You Do Not Have Product For Sale";
            //    return View("ProductList");
            //}
            //return View(products);

        }


        [HttpGet]
        [Authorize]
        public ViewResult CatagoryList(string errorpleaseselect)
        {

            List<Category> categoryList = new List<Category>();
            categoryList = (from catagory in _gebiyaContext.Categories select catagory).ToList();
            categoryList.Insert(0, new Category { Category_ID = 0, Category_Name = "Select", Desceiption = "no book" });
            ViewBag.ListofCategory = categoryList;
            if (errorpleaseselect != null)
            {
                ViewBag.PleaseSelect = "Please Select the Catagory to Add A Product";
            }



            return View();
        }

        [HttpGet]
        public JsonResult GetSubCatagoryList(int Category_ID)
        {
            if (Category_ID == 0)
            {
                return Json("NoCatagory");
            }
            var citylist = new SelectList(_gebiyaContext.SubCatagories.Where(c => c.C_ID == Category_ID), "Id", "SubcatagoryName");

            return Json(citylist);

        }
        [HttpGet]
        public async Task<ViewResult> Productdetails(int id)
        {
            var item = await _gebiyaContext.Products
                             .Include(p => p.Books).Include(p => p.Cars).Include(p => p.Cloths).Include(p => p.Computers)
                             .Include(p => p.Houses).Include(p => p.Phones).Include(p => p.Shoes)
                          .FirstOrDefaultAsync(p => p.ID == id);
            ProductViewModel productViewModel = new ProductViewModel()
            {
                Product = item
            };


            return View(productViewModel);
        }


        [HttpGet]
        public ViewResult EditProduct(int id)
        {

            Product product = _gebiyaContext.Products.Find(id);
            var EditedBook = _gebiyaContext.Books.SingleOrDefault(b => b.P_ID == id);
            var EditedComputer = _gebiyaContext.Computers.SingleOrDefault(computer => computer.P_ID == id);
            var EditedPhone = _gebiyaContext.Phones.SingleOrDefault(phone => phone.P_ID == id);
            var EditedCar = _gebiyaContext.Cars.SingleOrDefault(car => car.P_ID == id);
            var EditedHouse = _gebiyaContext.Houses.SingleOrDefault(house => house.P_ID == id);
            var EditedCloth = _gebiyaContext.Cloths.SingleOrDefault(cloth => cloth.P_ID == id);
            var EditedShose = _gebiyaContext.Shoes.SingleOrDefault(shose => shose.P_ID == id);
            ProductViewModel productViewModel = new ProductViewModel
            {
                Product = product,
                Book = EditedBook,
                Computer = EditedComputer,
                Phone = EditedPhone,
                Car = EditedCar,
                House = EditedHouse,
                Cloth = EditedCloth,
                Shoes = EditedShose
            };
            return View(productViewModel);

        }


        [HttpPost]
        public IActionResult EditProduct(ProductViewModel modeledit)
        {

            if (ModelState.IsValid)
            {
                Product producttoedit = _gebiyaContext.Products.Find(modeledit.Product.ID);
                producttoedit.Name = modeledit.Product.Name;
                producttoedit.Quantity = modeledit.Product.Quantity;
                producttoedit.Price = modeledit.Product.Price;
                producttoedit.Services = modeledit.Product.Services;
                if (modeledit.photo != null)
                {
                    if (modeledit.Product.Image != null)
                    {
                        string filepath = Path.Combine(hostingEnvironment.WebRootPath, "images", modeledit.Product.Image);
                        System.IO.File.Delete(filepath);
                    }
                    producttoedit.Image = ProcessUploadedFile(modeledit);
                }

                Book booktoedit = _gebiyaContext.Books.SingleOrDefault(book => book.P_ID == producttoedit.ID);
                {
                    if (booktoedit != null)
                    {
                        booktoedit.ISBN = modeledit.Book.ISBN;
                        booktoedit.Type = modeledit.Book.Type;
                        booktoedit.No_page = modeledit.Book.No_page;
                        booktoedit.Author = modeledit.Book.Author;
                    }
                }
                Computer computertoedit = _gebiyaContext.Computers.SingleOrDefault(computer => computer.P_ID == producttoedit.ID);
                {
                    if (computertoedit != null)
                    {
                        computertoedit.Model = modeledit.Computer.Model;
                        computertoedit.Core = modeledit.Computer.Core;
                        computertoedit.CPU = modeledit.Computer.CPU;
                        computertoedit.RAM = modeledit.Computer.RAM;
                        computertoedit.Procesor_Speed = modeledit.Computer.Procesor_Speed;
                        computertoedit.Processor_Type = modeledit.Computer.Processor_Type;
                        computertoedit.Hard_Disk = modeledit.Computer.Hard_Disk;
                        computertoedit.OS = modeledit.Computer.OS;
                        computertoedit.Size = modeledit.Computer.Size;
                        computertoedit.Resolution = modeledit.Computer.Resolution;
                    }
                }
                Phone phonetoedit = _gebiyaContext.Phones.SingleOrDefault(i => i.P_ID == producttoedit.ID);
                {
                    if (phonetoedit != null)
                    {
                        phonetoedit.Model = modeledit.Phone.Model;
                        phonetoedit.Storage = modeledit.Phone.Storage;
                        phonetoedit.SIM_NO = modeledit.Phone.SIM_NO;
                        phonetoedit.Display = modeledit.Phone.Display;
                        phonetoedit.Resolution = modeledit.Phone.Resolution;
                        phonetoedit.OS = modeledit.Phone.OS;
                        phonetoedit.Card_Slot = modeledit.Phone.Card_Slot;
                        phonetoedit.Main_Camera = modeledit.Phone.Main_Camera;
                        phonetoedit.Main_Camera = modeledit.Phone.Front_Camera;
                        phonetoedit.Finger_Print = modeledit.Phone.Finger_Print;
                    }
                }
                Car cartoedit = _gebiyaContext.Cars.SingleOrDefault(car => car.P_ID == producttoedit.ID);
                {
                    if (cartoedit != null)
                    {
                        cartoedit.Model = modeledit.Car.Model;
                        cartoedit.fueltype = modeledit.Car.fueltype;
                        cartoedit.Transmission = modeledit.Car.Transmission;
                        cartoedit.Airbag = modeledit.Car.Airbag;
                        cartoedit.Type = modeledit.Car.Type;
                        cartoedit.Capacity = modeledit.Car.Capacity;
                    }
                }
                House housetoedit = _gebiyaContext.Houses.SingleOrDefault(house => house.P_ID == producttoedit.ID);
                {
                    if (housetoedit != null)
                    {
                        housetoedit.Type = modeledit.House.Type;
                        housetoedit.Num_bedroom = modeledit.House.Num_bedroom;
                        housetoedit.Location = modeledit.House.Location;
                        housetoedit.Num_Bathroom = modeledit.House.Num_Bathroom;
                        housetoedit.Total_room = modeledit.House.Total_room;
                    }
                }
                Cloth clothtoedit = _gebiyaContext.Cloths.SingleOrDefault(cloth => cloth.P_ID == producttoedit.ID);
                {
                    if (clothtoedit != null)
                    {
                        clothtoedit.Brand = modeledit.Cloth.Brand;
                        clothtoedit.Size = modeledit.Cloth.Size;
                        clothtoedit.Color = modeledit.Cloth.Color;
                        clothtoedit.Type = modeledit.Cloth.Type;
                    }
                }
                Shoes shoestoedit = _gebiyaContext.Shoes.SingleOrDefault(cloth => cloth.P_ID == producttoedit.ID);
                {
                    if (shoestoedit != null)
                    {
                        shoestoedit.Brand = modeledit.Shoes.Brand;
                        shoestoedit.Size = modeledit.Shoes.Size;
                        shoestoedit.Color = modeledit.Shoes.Color;
                    }
                }

                _gebiyaContext.Products.Update(producttoedit);
                if (booktoedit != null)
                    _gebiyaContext.Books.Update(booktoedit);
                if (computertoedit != null)
                    _gebiyaContext.Computers.Update(computertoedit);
                if (phonetoedit != null)
                    _gebiyaContext.Phones.Update(phonetoedit);
                if (clothtoedit != null)
                    _gebiyaContext.Cloths.Update(clothtoedit);
                if (housetoedit != null)
                    _gebiyaContext.Houses.Update(housetoedit);
                if (cartoedit != null)
                    _gebiyaContext.Cars.Update(cartoedit);
                if (shoestoedit != null)
                    _gebiyaContext.Shoes.Update(shoestoedit);
                if (clothtoedit != null)
                    _gebiyaContext.Cloths.Update(clothtoedit);
                _gebiyaContext.SaveChanges();
                return RedirectToAction("Productdetails", new { id = producttoedit.ID });

            }
            return View();
        }


        private string ProcessUploadedFile(ProductViewModel model)
        {
            string uniqueFileName = null;
            if (model.photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + "_" + model.photo.FileName;
                string filepath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var filestream = new FileStream(filepath, FileMode.Create))
                {
                    model.photo.CopyTo(filestream);
                }
            }

            return uniqueFileName;
        }
        
        [HttpPost]
         [HttpGet]
        public IActionResult Addproduct(ProductViewModel productViewModel)
        {


            SubCatagory subcatagories = _gebiyaContext.SubCatagories.FirstOrDefault(p => p.Id == productViewModel.subCatagoryId);

            if (productViewModel.subCatagoryId == 0)
            {
                return RedirectToAction("CatagoryList", new { errorpleaseselect = "select" });
            }
            ProductViewModel _productViewModel1 = new ProductViewModel()
            {
                SubCatagory = subcatagories,
                SubCatagoryName = subcatagories.SubcatagoryName,
                C_id = subcatagories.C_ID,
            };


            return View(_productViewModel1);
        }



        [HttpPost]

        public IActionResult InsertProduct(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {

                string uniqueFileName = ProcessUploadedFile(productViewModel);
                string Logedinname = null;
                if (signInManager.IsSignedIn(User))
                {
                    Logedinname = User.Identity.Name;
                }
                User loginuser = _gebiyaContext.Users.SingleOrDefault(user => user.UserName == Logedinname);
                Seller seller = _gebiyaContext.Sellers.SingleOrDefault(seller => seller.U_ID == loginuser.Id);
                int sellerid = seller.Seller_ID;

                Product newproduct = new Product
                {
                    Cat_ID = productViewModel.C_id,
                    Name = productViewModel.Product.Name,
                    Price = productViewModel.Product.Price,
                    Image = uniqueFileName,
                    Quantity = productViewModel.Product.Quantity,
                    Services = productViewModel.Product.Services,
                    Status = "avaliable",
                    AddtDate = DateTime.Today,
                    S_ID = sellerid
                };
                _gebiyaContext.Products.Add(newproduct);
                _gebiyaContext.SaveChanges();
                var p = _gebiyaContext.Products.Find(newproduct.ID);
                int productkeyid = p.ID;
                if (productViewModel.Book != null)
                {
                    Book newbook = new Book()
                    {
                        ISBN = productViewModel.Book.ISBN,
                        No_page = productViewModel.Book.No_page,
                        Type = productViewModel.Book.Type,
                        Author = productViewModel.Book.Author,
                        P_ID = productkeyid
                    };

                    _gebiyaContext.Books.Add(newbook);
                    _gebiyaContext.SaveChanges();
                    return RedirectToAction("Productdetails", new { id = newproduct.ID });
                }
                if (productViewModel.Computer != null)
                {
                    Computer newcomputer = new Computer
                    {
                        Model = productViewModel.Computer.Model,
                        Core = productViewModel.Computer.Core,
                        CPU = productViewModel.Computer.CPU,
                        RAM = productViewModel.Computer.RAM,
                        Procesor_Speed = productViewModel.Computer.Procesor_Speed,
                        Processor_Type = productViewModel.Computer.Processor_Type,
                        OS = productViewModel.Computer.OS,
                        Hard_Disk = productViewModel.Computer.Hard_Disk,
                        Resolution = productViewModel.Computer.Resolution,
                        Size = productViewModel.Computer.Size,
                        P_ID = productkeyid
                    };

                    _gebiyaContext.Computers.Add(newcomputer);
                    _gebiyaContext.SaveChanges();
                    return RedirectToAction("Productdetails", new { id = newproduct.ID });
                }
                if (productViewModel.Phone != null)
                {
                    Phone newphone = new Phone
                    {
                        Model = productViewModel.Phone.Model,
                        Storage = productViewModel.Phone.Storage,
                        SIM_NO = productViewModel.Phone.SIM_NO,
                        Display = productViewModel.Phone.Display,
                        Resolution = productViewModel.Phone.Resolution,
                        Card_Slot = productViewModel.Phone.Card_Slot,
                        OS = productViewModel.Phone.OS,
                        Main_Camera = productViewModel.Phone.Main_Camera,
                        Front_Camera = productViewModel.Phone.Front_Camera,
                        Finger_Print = productViewModel.Phone.Finger_Print,
                        P_ID = productkeyid
                    };
                    _gebiyaContext.Phones.Add(newphone);
                    _gebiyaContext.SaveChanges();
                    return RedirectToAction("Productdetails", new { id = newproduct.ID });
                }
                if (productViewModel.Car != null)
                {
                    Car newcar = new Car
                    {
                        Model = productViewModel.Car.Model,
                        fueltype = productViewModel.Car.fueltype,
                        Transmission = productViewModel.Car.Transmission,
                        Airbag = productViewModel.Car.Airbag,
                        Type = productViewModel.Car.Type,
                        Capacity = productViewModel.Car.Capacity,

                        P_ID = productkeyid
                    };
                    _gebiyaContext.Cars.Add(newcar);
                    _gebiyaContext.SaveChanges();
                    return RedirectToAction("Productdetails", new { id = newproduct.ID });
                }
                if (productViewModel.House != null)
                {
                    House newhouse = new House
                    {

                        Num_bedroom = productViewModel.House.Num_bedroom,
                        Location = productViewModel.House.Location,
                        Num_Bathroom = productViewModel.House.Num_Bathroom,
                        Total_room = productViewModel.House.Total_room,
                        Type = productViewModel.House.Type,
                        P_ID = productkeyid

                    };
                    _gebiyaContext.Houses.Add(newhouse);
                    _gebiyaContext.SaveChanges();
                    return RedirectToAction("Productdetails", new { id = newproduct.ID });
                }
                if (productViewModel.Cloth != null)
                {
                    Cloth newcloth = new Cloth
                    {
                        Brand = productViewModel.Cloth.Brand,
                        Size = productViewModel.Cloth.Size,
                        Color = productViewModel.Cloth.Color,
                        Type = productViewModel.Cloth.Type,
                        P_ID = productkeyid
                    };
                    _gebiyaContext.Cloths.Add(newcloth);
                    _gebiyaContext.SaveChanges();
                    return RedirectToAction("Productdetails", new { id = newproduct.ID });
                }
                if (productViewModel.Shoes != null)
                {
                    Shoes newshose = new Shoes
                    {
                        Brand = productViewModel.Shoes.Brand,
                        Size = productViewModel.Shoes.Size,
                        Color = productViewModel.Shoes.Color,
                        P_ID = productkeyid
                    };
                    _gebiyaContext.Shoes.Add(newshose);
                    _gebiyaContext.SaveChanges();
                    return RedirectToAction("Productdetails", new { id = newproduct.ID });
                }

            }
            return View();
        }
        public IActionResult DeleteProduct(int id)
        {
            _gebiyaContext.Products.Remove(_gebiyaContext.Products.Find(id));
            _gebiyaContext.SaveChanges();
            return RedirectToAction("ProductList");

        }
        [HttpGet]
        public IActionResult ViewOrderedProduct()
        {
            string Logedinname = null;
            if (signInManager.IsSignedIn(User))
            {
                Logedinname = User.Identity.Name;
            }
            User loginuser = _gebiyaContext.Users.SingleOrDefault(user => user.UserName == Logedinname);

            Seller loginseller = _gebiyaContext.Sellers.SingleOrDefault(seller => seller.U_ID == loginuser.Id);
            List<OrderDetails> order_Lists = _gebiyaContext.OrderDetails.Where(ol => ol.S_ID == loginseller.Seller_ID).ToList();
            List<Product> productsList = _gebiyaContext.Products.ToList();
            List<Buyer> buyersList = _gebiyaContext.Buyers.ToList();
            List<User> usersList = _gebiyaContext.Users.ToList();
            var orderlistRecord = from o in order_Lists
                                  join p in productsList on o.P_ID equals p.ID into table1
                                  from p in table1.ToList()
                                  join b in buyersList on o.B_ID equals b.B_ID into table2
                                  from b in table2.ToList()
                                  join u in usersList on b.U_ID equals u.Id into table3
                                  from u in table3.ToList()
                                  select new SellerOrderListViewModel
                                  {
                                      order_List = o,
                                      products = p,
                                      buyers = b,
                                      users = u
                                  };
            return View(orderlistRecord);
        }
        [HttpGet]
     
        public IActionResult ViewSellerHistory()
        {

            string Logedinname = null;
            if (signInManager.IsSignedIn(User))
            {
                Logedinname = User.Identity.Name;
            }
            User loginuser = _gebiyaContext.Users.SingleOrDefault(user => user.UserName == Logedinname);
            Seller loginseller = _gebiyaContext.Sellers.SingleOrDefault(seller => seller.U_ID == loginuser.Id);
            List<Sold_Items> soldItem_Lists = _gebiyaContext.Sold_Items.Where(so => so.S_ID == loginseller.Seller_ID).ToList();
            List<Product> productsList = _gebiyaContext.Products.ToList();
            List<Buyer> buyersList = _gebiyaContext.Buyers.ToList();
            List<User> usersList = _gebiyaContext.Users.ToList();
            var orderlistRecord = from s in soldItem_Lists
                                  join p in productsList on s.P_ID equals p.ID into table1
                                  from p in table1.ToList()
                                  join b in buyersList on s.B_ID equals b.B_ID into table2
                                  from b in table2.ToList()
                                  join u in usersList on b.U_ID equals u.Id into table3
                                  from u in table3.ToList()
                                  select new SellerOrderListViewModel
                                  {
                                      sold_Items = s,
                                      products = p,
                                      buyers = b,
                                      users = u
                                  };
            return View(orderlistRecord);
        }

        public IActionResult ViewComment(int id)
        {

            List<Comment> Comment_List = _gebiyaContext.Comments.Where(co => co.Item_ID == id).ToList();

            List<Buyer> buyersList = _gebiyaContext.Buyers.ToList();
            List<Product> productsList = _gebiyaContext.Products.ToList();
            List<User> usersList = _gebiyaContext.Users.ToList();
            var commentRecord = from c in Comment_List
                                join p in productsList on c.Item_ID equals p.ID into table1
                                from p in table1.ToList()
                                join b in buyersList on c.Buyer_ID equals b.B_ID into table2
                                from b in table2.ToList()
                                join u in usersList on b.U_ID equals u.Id into table3
                                from u in table3.ToList()
                                select new SellerOrderListViewModel
                                {
                                    comments = c,
                                    products = p,
                                    buyers = b,
                                    users = u
                                };
            return View(commentRecord);
        }
        [HttpGet]
        public IActionResult ReplayToComment(int id)
        {

            Comment comment = _gebiyaContext.Comments.Find(id);
            ReplayToCommentViewModel replayToComment = new ReplayToCommentViewModel
            {
                replay = comment.Replay
            };
            return View(replayToComment);
        }
        [HttpPost]
        public IActionResult ReplayToComment(ReplayToCommentViewModel replayToComment)
        {
            Comment comment = _gebiyaContext.Comments.Find(replayToComment.Id);

            comment.Replay = replayToComment.replay;
            _gebiyaContext.Comments.Update(comment);
            _gebiyaContext.SaveChanges();


            return RedirectToAction("ViewComment", new { id = comment.Item_ID }); ;
        }
    }
}

