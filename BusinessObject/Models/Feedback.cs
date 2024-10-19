using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public string Content { get; set; } = null!;

    public int Rating { get; set; }

    public string UserId { get; set; } = null!;

    public int CourseId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
