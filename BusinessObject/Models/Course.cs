using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string CreateBy { get; set; } = null!;

    public int TimeLearning { get; set; }

    public int? CateId { get; set; }

    public string? Picture { get; set; }
}
