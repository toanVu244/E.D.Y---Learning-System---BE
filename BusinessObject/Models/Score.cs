using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Score
{
    public int ScoreId { get; set; }

    public string UserId { get; set; } = null!;

    public int TestId { get; set; }

    public decimal Score1 { get; set; }

    public DateTime CompleteTime { get; set; }

    public virtual ICollection<DetailScore> DetailScores { get; set; } = new List<DetailScore>();

    public virtual Test Test { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
