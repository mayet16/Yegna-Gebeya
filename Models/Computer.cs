using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YegnaGebiyaSystem.Models
{
    public class Computer
    {
        [Key]
        public int ID { get; set; }
        public string Model { get; set; }
        public string Core { get; set; }
        public float CPU { get; set; }
        public int RAM { get; set; }
        public float Procesor_Speed { get; set; }
        public string Processor_Type { get; set; }
        public string OS { get; set; }
        public long Hard_Disk { get; set; }
        public string Resolution { get; set; }
        public float Size { get; set; }

        // Foreign key   
        [Display(Name = "Product")]
        public virtual int P_ID { get; set; }
        [ForeignKey("P_ID")]
        public virtual Product Products { get; set; }
    }
}
