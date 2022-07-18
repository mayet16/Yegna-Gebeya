using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YegnaGebiyaSystem.ViewModels
{
    public class AdministratorAdminEditViewModel
    {
        public int Id { get; set; }

        [Required]
        public string name { get; set; }
        [Required]
        public string UserName { get; set; }
        public IFormFile Photo { get; set; }
        public string ExistingPhotoPath { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string State { get; set; }
    }
}
