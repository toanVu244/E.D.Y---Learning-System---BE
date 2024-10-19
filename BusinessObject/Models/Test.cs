using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Test
{
    public int TesId { get; set; }

    public string TestName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Duration { get; set; }

    public DateTime CreateAt { get; set; }

    public int? LessonId { get; set; }
}
