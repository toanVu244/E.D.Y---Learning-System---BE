using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string Name { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string CreateDate { get; set; } = null!;

    public string CreateBy { get; set; } = null!;

    public int TimeLearning { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual ICollection<UserCourse> UserCourses { get; set; } = new List<UserCourse>();
}
