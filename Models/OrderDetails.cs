using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YegnaGebiyaSystem.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public Order Order { get; set; }

        // Foreign key   
        [Display(Name = "Product")]
        public virtual int? P_ID { get; set; }

        [ForeignKey("P_ID")]
        public virtual Product Products { get; set; }

        // Foreign key   
        [Display(Name = "Seller")]
        public virtual int? S_ID { get; set; }

        [ForeignKey("S_ID")]
        public virtual Seller Sellers { get; set; }

        // Foreign key   
        [Display(Name = "Buyer")]
        public virtual int? B_ID { get; set; }

        [ForeignKey("B_ID")]
        public virtual Buyer Buyers { get; set; }

    }
}
