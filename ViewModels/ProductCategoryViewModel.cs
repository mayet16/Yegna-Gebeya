using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YegnaGebiyaSystem.Models;

namespace YegnaGebiyaSystem.ViewModels
{
    public class ProductCategoryViewModel
    {
        public IEnumerable<SelectListItem> Categories { set; get; }
        public int SelectedCategory { set; get; }

        public List<Product> Products { get; set; }
        public SelectList Category { get; set; }
        public string ProductCategory { get; set; }
        public string SearchString { get; set; }

    }
}
