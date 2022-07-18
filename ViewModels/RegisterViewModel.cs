using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YegnaGebiyaSystem.Controllers;

namespace YegnaGebiyaSystem.ViewModels
{
    public class RegisterViewModel : ProfileViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password",ErrorMessage ="Password And Confirmition Password Do not Match")]
        [Required]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
        public float Rating { get; set; }

    }
}
