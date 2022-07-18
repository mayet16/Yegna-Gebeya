using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YegnaGebiyaSystem.Models;
using YegnaGebiyaSystem.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YegnaGebiyaSystem.Controllers
{
    [AllowAnonymous]
    public class VendorController : Controller
    {
        private readonly GebiyaContext _gebiyaContext;
        public VendorController(GebiyaContext gebiyaContext)
        {
            _gebiyaContext = gebiyaContext;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _gebiyaContext.Sellers.Include(s => s.Users).ToListAsync());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var seller =  _gebiyaContext.Sellers.Include(s=>s.Users)
            .FirstOrDefault(v => v.Seller_ID == id);

            var products =  _gebiyaContext.Products.Include(p => p.Sellers)
                .Where(s => s.S_ID == id && s.Status.Equals("avaliable"));

            VendorViewModel vendorViewModel = new VendorViewModel()
            {
                Sellers = seller,
                Products = products
            };

            if (vendorViewModel == null)
            {
                return NotFound();
            }
            return View(vendorViewModel);
        }

        public IActionResult SelectedVendor(int? id)
        {

            if (id==null)
            {
                return NotFound();
            }
            var seller = _gebiyaContext.Sellers.Include(s => s.Users)
            .FirstOrDefault(v => v.Seller_ID == id);

            var products = _gebiyaContext.Products.Include(p => p.Sellers)
                .Where(s => s.S_ID == id && s.Status.Equals("avaliable"));

            VendorViewModel vendorViewModel = new VendorViewModel()
            {
                Sellers = seller,
                Products = products
            };

            if (vendorViewModel == null)
            {
                return NotFound();
            }
            return View(vendorViewModel);
        }
    }
}
