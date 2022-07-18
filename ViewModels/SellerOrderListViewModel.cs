using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YegnaGebiyaSystem.Models;

namespace YegnaGebiyaSystem.ViewModels
{
    public class SellerOrderListViewModel
    {
        public OrderDetails order_List { get; set; }
        public Product products { get; set; }
        public Buyer buyers { get; set; }
        public User users { get; set; }
        public Sold_Items sold_Items { get; set; }
        public Comment comments { get; set; }
        public int id { get; set; }
        public string ProductName { get; set; }
        public int commentcount { get; set; }
        public int Com_ID { get; set; }
        public Feedback feedback { get; set; }
        public string FeedbackBody { get; set; }
    }
}
