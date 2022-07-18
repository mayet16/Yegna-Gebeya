using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YegnaGebiyaSystem.Models;

namespace YegnaGebiyaSystem.ViewModels
{
    public class AdministratorProfileViewModel
    {
        public User User { get; set; }
        public string ExistingPhotoPath { get; set; }
        public string PageTitle { get; set; }
    }
}
