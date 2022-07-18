using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YegnaGebiyaSystem.Models
{
    public class Book
    {
        [Key]
        public int B_ID { get; set; }
        public string ISBN { get; set; }
        public int No_page { get; set; }
        public string Type { get; set; }
        public string Author { get; set; }

        // Foreign key   
        [Display(Name = "Product")]
        public virtual int P_ID { get; set; }
        [ForeignKey("P_ID")]
        public virtual Product Products { get; set; }
    }
}
