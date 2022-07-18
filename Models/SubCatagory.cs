using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YegnaGebiyaSystem.Models
{
    public class SubCatagory
    {
        public int Id { get; set; }
        public string SubcatagoryName { get; set; }

        // Foreign key   
        [Display(Name = "C_ID")]
        public virtual int C_ID { get; set; }

        [ForeignKey("C_ID")]
        public virtual Category Category { get; set; }

    }
}
