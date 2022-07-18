using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YegnaGebiyaSystem.Controllers;

namespace YegnaGebiyaSystem.ViewModels
{
    public class ProfileViewModel 
    {
        public int Id { get; set; }
        public string ExistingImage { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        //  [Remote(action: "IsEmailInUse", controller: "Account")]
        [ValidEmailDomian(allowedDomain: "gmail.com", ErrorMessage = "Email Domian Must Be @gmail.com")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Sex { get; set; }
        public string Nationality { get; set; }
        public string Status { get; set; }
        public IFormFile Photo { get; set; }
        public int Account_Number { get; set; }
    }
}
