using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YegnaGebiyaSystem.Models
{
    public class Category
    {
        [Key]
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }
        public string Desceiption { get; set; }
        public List<Product> Products { get; set; }
        public List<SubCatagory> subCatagories { get; set; }
    }
}
