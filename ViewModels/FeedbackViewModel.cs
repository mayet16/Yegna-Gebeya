using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YegnaGebiyaSystem.Models;

namespace YegnaGebiyaSystem.ViewModels
{
    public class FeedbackViewModel
    {
        public int ID { get; set; }
        public string Replay { get; set; }
        public string FeedbackBody { get; set; }
        public Feedback feedback { get; set; }
        public User user { get; set; }
    }
}
