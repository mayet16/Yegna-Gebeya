using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YegnaGebiyaSystem.Models
{
    public class Comment
    {
        [Key]
        public int Com_ID { get; set; }
        public string CommentBody { get; set; }

        // Foreign key   
        [Display(Name = "Product")]
        public virtual int? Item_ID { get; set; }
        [ForeignKey("Item_ID")]
        public virtual Product Products { get; set; }

       // Foreign key
       [Display(Name = "Seller")]
        public virtual int? Seller_ID { get; set; }

        [ForeignKey("Seller_ID")]
        public virtual Seller Sellers { get; set; }


        // Foreign key   
        [Display(Name = "Buyer")]
        public virtual int Buyer_ID { get; set; }

        [ForeignKey("Buyer_ID")]
        public virtual Buyer Buyers { get; set; }

        public DateTime Sent_Date { get; set; }
        public string Replay { get; set; }

    }
}
