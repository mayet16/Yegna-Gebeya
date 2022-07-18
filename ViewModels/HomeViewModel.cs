using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YegnaGebiyaSystem.Models;

namespace YegnaGebiyaSystem.ViewModels
{
    public class HomeViewModel
    {
        public Feedback Feedback { get; set; }
       public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Feedback> Feedbacks { get; set; }
        public int ID { get; set; }
    }
}
