using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YegnaGebiyaSystem.Models;

namespace YegnaGebiyaSystem.ViewModels
{
    public class AdministratoViewProductViewModel
    {
        public string Catagory { get; set; }
        public Book Book { get; set; }
        public Car Car { get; set; }
        public Cloth Cloth { get; set; }
        public Computer Computer { get; set; }
        public House House { get; set; }
        public Phone Phone { get; set; }
        public Shoes Shoes { get; set; }
        public string Name { get; set; }
        public Double Price { get; set; }
        public long Quantity { get; set; }
        public Seller SellerName { get; set; }
        public Product Product { get; set; }
    }
}
