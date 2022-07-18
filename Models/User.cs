using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YegnaGebiyaSystem.Models
{
    public class User :IdentityUser<int>
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int U_ID { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "can not exced 50 character")]
        public string Name { get; set; }

        public string Status { get; set; }
        public string Sex { get; set; }
        public string Nationality { get; set; }

        public string Image { get; set; }
        public List<Seller> Sellers { get; set; }
        public List<Buyer> Buyers { get; set; }
        public virtual List<Feedback> Feedbacks { get; set; }

        public List<Comment> Comments { get; set; }
        public List<OrderDetails> Order_Lists { get; set; }
        public List<Sold_Items> Sold_Items { get; set; }

    }
}
