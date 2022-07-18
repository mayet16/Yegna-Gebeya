using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YegnaGebiyaSystem.Models
{
    public class Car
    {
        [Key]
        public int C_ID { get; set; }
        public string Model { get; set; }
        public string fueltype { get; set; }
        public string Transmission { get; set; }
        public string Airbag { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }

        // Foreign key   
        [Display(Name = "Product")]
        public virtual int P_ID { get; set; }
        [ForeignKey("P_ID")]
        public virtual Product Products { get; set; }

    }
}
