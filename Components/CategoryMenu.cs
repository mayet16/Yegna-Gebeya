using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YegnaGebiyaSystem.Models;

namespace YegnaGebiyaSystem.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly GebiyaContext _gebiyaContext;
        public CategoryMenu(GebiyaContext gebiyaContext)
        {
            _gebiyaContext = gebiyaContext;
        }
        public IViewComponentResult Invoke()
        {
            var categories = _gebiyaContext.Categories.OrderBy(c => c.Category_Name);
            return View(categories);
        }
    }
}
