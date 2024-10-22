using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Serivce.ViewModels
{
    public class FeedbackViewModel
    {
        public int FeedbackId { get; set; }

        public string Content { get; set; } = null!;

        public int Rating { get; set; }

        public string UserId { get; set; } = null!;

        public int CourseId { get; set; }
    }
}
