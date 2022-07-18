using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YegnaGebiyaSystem.Models
{
    public class Cloth
    {
        [Key]
        public int C_ID { get; set; }
        public string Brand { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }

        // Foreign key   
        [Display(Name = "Product")]
        public virtual int P_ID { get; set; }
        [ForeignKey("P_ID")]
        public virtual Product Products { get; set; }
    }
}
