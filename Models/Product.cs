using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YegnaGebiyaSystem.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public Double Price { get; set; }
        public string Services { get; set; }
        public long Quantity { get; set; }

        // Foreign key   
        [Display(Name = "Category")]
        public virtual int Cat_ID { get; set; }

        [ForeignKey("Cat_ID")]
        public virtual Category Category { get; set; }
        // Foreign key   
        [Display(Name = "Seller")]
        public int S_ID { get; set; }

        [ForeignKey("S_ID")]
        public virtual Seller Sellers { get; set; }
        public DateTime AddtDate { get; internal set; }
        public List<Book> Books { get; set; }
        public List<Car>Cars { get; set; }
        public List<Cloth> Cloths { get; set; }
        public List<Computer> Computers { get; set; }
        public List<House> Houses { get; set; }
        public List<Phone> Phones { get; set; }
        public List<Shoes> Shoes { get; set; }
        public List<Comment> Comments { get; set; }
        public List<OrderDetails> Order_Lists { get; set; }
        public List<Sold_Items> Sold_Items { get; set; }
    }
}
