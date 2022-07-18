using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YegnaGebiyaSystem.Models;

namespace YegnaGebiyaSystem.ViewModels
{
    public class orderListViewModel
    {
        public OrderDetails order_List { get; set; }
        public Buyer buyer { get; set; }
        public Seller seller { get; set; }
        public Product product { get; set; }
        public User user { get; set; }
        

    }
}
