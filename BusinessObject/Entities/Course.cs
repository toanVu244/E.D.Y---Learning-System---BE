using System;
using System.Collections.Generic;

namespace BusinessObject.Entities;

public partial class Course
{
    public int CourseId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string CreateBy { get; set; } = null!;

    public int TimeLearning { get; set; }

    public int? CateId { get; set; }

    public string? Picture { get; set; }

    public double? Money { get; set; }

    public virtual Category? Cate { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual ICollection<UserCourse> UserCourses { get; set; } = new List<UserCourse>();
}
