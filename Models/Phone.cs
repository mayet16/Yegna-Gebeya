using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YegnaGebiyaSystem.Models
{
    public class Phone
    {
        [Key]
        public int ID { get; set; }
        public string Model { get; set; }
        public int Storage { get; set; }
        public int SIM_NO { get; set; }
        public float Display { get; set; }
        public string Resolution { get; set; }
        public string OS { get; set; }
        public string Card_Slot { get; set; }
        public int Main_Camera { get; set; }
        public int Front_Camera { get; set; }
        public string Finger_Print { get; set; }

        // Foreign key   
        [Display(Name = "Product")]
        public virtual int P_ID { get; set; }
        [ForeignKey("P_ID")]
        public virtual Product Products { get; set; }
    }
}
