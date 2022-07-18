using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YegnaGebiyaSystem.Models
{
    public class Sold_Items
    {
        [Key]
        public int S_i_ID { get; set; }
        // Foreign key   
        [Display(Name = "Seller")]
        public virtual Nullable<int> S_ID { get; set; }

        [ForeignKey("S_ID")]
        public virtual Seller Sellers { get; set; }

        // Foreign key   
        [Display(Name = "Buyer")]
        public virtual Nullable<int> B_ID { get; set; }

        [ForeignKey("B_ID")]
        public virtual Buyer Buyers { get; set; }

        // Foreign key   
        [Display(Name = "Product")]
        public virtual Nullable<int> P_ID { get; set; }
        [ForeignKey("P_ID")]
        public virtual Product Products { get; set; }
        public DateTime S_Date { get; set; }
    }
}
