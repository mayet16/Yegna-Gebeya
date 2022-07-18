using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YegnaGebiyaSystem.Models;

namespace YegnaGebiyaSystem.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public IEnumerable<Sold_Items> history_item { get; set; }
        public IEnumerable<OrderDetails> Orderdetail { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Seller> Sellers { get; set; }
        public double OrderTotal { get; set; }
    }
}
