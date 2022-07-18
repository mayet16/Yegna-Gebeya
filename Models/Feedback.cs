using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YegnaGebiyaSystem.Models
{
    public class Feedback
    {
        [Key]
        public int ID { get; set; }
        public string FeedbackBody { get; set; }

        // Foreign key   
        [Display(Name = "User")]
        public virtual int Sender_ID { get; set; }

        public int Replayer_Id { get; set; }

       // [ForeignKey("Sender_ID")]
        public virtual User Users { get; set; }
     //   public virtual User Replayer { get; set; }

        public DateTime Sent_Date { get; set; }
        public string Replay { get; set; }
    }
}
