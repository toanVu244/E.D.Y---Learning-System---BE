using System;
using System.Collections.Generic;

namespace BusinessObject.Entities;

public partial class Question
{
    public int QuestionId { get; set; }

    public int TestId { get; set; }

    public string Question1 { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string AnswareTrue { get; set; } = null!;

    public string? Answare1 { get; set; }

    public string? Answare2 { get; set; }

    public string? Answare3 { get; set; }

    public virtual ICollection<DetailScore> DetailScores { get; set; } = new List<DetailScore>();

    public virtual Test Test { get; set; } = null!;
}
