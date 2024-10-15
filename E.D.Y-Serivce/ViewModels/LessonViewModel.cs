using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Serivce.ViewModels
{
    public class LessonViewModel
    {
        public int LessonId { get; set; }
        public int CourseId { get; set; }
        public string Detail { get; set; } = null!;
        public string Picture { get; set; } = null!;
    }
}
