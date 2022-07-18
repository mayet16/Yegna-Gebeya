using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YegnaGebiyaSystem.Models;

namespace YegnaGebiyaSystem.ViewModels
{
    public class AdminDashboardViewModel
    {
        public int UserNumber { get; set; }
        public int ProductNumber { get; set; }
        public int OrderNumber { get; set; }
        public int SoldItemNumber { get; set; }
        public double TotalCost { get; set; }
        public Product Product { get; set; }
        public OrderDetails order_List { get; set; }
        public Buyer buyer { get; set; }
        public Seller seller { get; set; }
        public Product product { get; set; }
        public User user { get; set; }
    }
}
