using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YegnaGebiyaSystem.Models;

namespace YegnaGebiyaSystem.ViewModels
{
    public class ProductDisplayViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Category category { get; set; }
        public SubCatagory subCatagory { get; set; }
        public Seller seller { get; set; }
        public Product product { get; set; }
        public User user { get; set; }



    }
}
