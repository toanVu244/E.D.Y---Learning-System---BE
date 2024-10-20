using BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Serivce.ViewModels
{
    public class UserCourseViewModel
    {
        public int Id { get; set; }

        public string UserId { get; set; } = null!;

        public int CourseId { get; set; }

        public DateTime EnrollDate { get; set; }

        public bool Certificate { get; set; }

        public double? PayMoney { get; set; }
    }
}
