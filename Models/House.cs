using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YegnaGebiyaSystem.Models
{
    public class House
    {
        [Key]
        public int ID { get; set; }
        public string Type { get; set; }
        public int Num_bedroom { get; set; }
        public string Location { get; set; }
        public int Num_Bathroom { get; set; }
        public int Total_room { get; set; }

        // Foreign key   
        [Display(Name = "Product")]
        public virtual int P_ID { get; set; }
        [ForeignKey("P_ID")]
        public virtual Product Products { get; set; }

    }
}
