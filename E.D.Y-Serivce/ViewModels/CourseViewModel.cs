using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Serivce.ViewModels
{
    public class CourseViewModel
    {
        public int CourseId { get; set; }

        public string Name { get; set; } = null!;

        public DateTime CreateDate { get; set; }

        public string CreateBy { get; set; } = null!;

        public int TimeLearning { get; set; }
     
        public int? CateId { get; set; }

        public string? Picture { get; set; }
    }
}
