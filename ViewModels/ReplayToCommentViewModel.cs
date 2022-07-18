using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YegnaGebiyaSystem.Models;

namespace YegnaGebiyaSystem.ViewModels
{
    public class ReplayToCommentViewModel
    {

        public int Id { get; set; }
        public string Comment_Body { get; set; }
        [Required]
        [MaxLength(50000)]
        public string replay { get; set; }
        public Comment comments { get; set; }

    }
}
