using System;
using System.Collections.Generic;

namespace BusinessObject.Entities;

public partial class DetailScore
{
    public int Id { get; set; }

    public int ScoreId { get; set; }

    public int QuestionId { get; set; }

    public bool Result { get; set; }

    public string UserAnsware { get; set; } = null!;

    public virtual Question Question { get; set; } = null!;

    public virtual Score Score { get; set; } = null!;
}
