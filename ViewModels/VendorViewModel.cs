using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YegnaGebiyaSystem.Models;

namespace YegnaGebiyaSystem.ViewModels
{
    public class VendorViewModel
    {
     public Seller Sellers { get; set; }
     public IEnumerable<Product> Products { get; set; }
    } 
}
