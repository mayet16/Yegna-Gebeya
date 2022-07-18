using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YegnaGebiyaSystem.ViewModels
{
    public class AdministratoViewUserViewModel
    {
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public long Account_Number { get; set; }
    }
}
