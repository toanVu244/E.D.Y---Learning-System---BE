using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Lesson
{
    public int LessonId { get; set; }

    public int CourseId { get; set; }

    public string Detail { get; set; } = null!;

    public string Picture { get; set; } = null!;
}
