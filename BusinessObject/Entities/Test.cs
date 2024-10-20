using System;
using System.Collections.Generic;

namespace BusinessObject.Entities;

public partial class Test
{
    public int TesId { get; set; }

    public string TestName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Duration { get; set; }

    public DateTime CreateAt { get; set; }

    public int? LessonId { get; set; }

    public virtual Lesson? Lesson { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();
}
