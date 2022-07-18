using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YegnaGebiyaSystem.Models
{
    public class Seller
    {
        [Key]
        public int Seller_ID { get; set; }
        public float Ratting { get; set; }
        public string Address { get; set; }
        public float Balance { get; set; }

        // Foreign key   
        [Display(Name = "User")]
        public virtual int U_ID { get; set; }
        [ForeignKey("U_ID")]
        public virtual User Users { get; set; }
       
        public List<Comment> Comments { get; set; }
        public List<OrderDetails> Order_Lists { get; set; }
        public List<Sold_Items> Sold_Items { get; set; }
    }
}
