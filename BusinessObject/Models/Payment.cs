using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public string UserId { get; set; } = null!;

    public double Money { get; set; }

    public DateTime Date { get; set; }

    public string? Title { get; set; }

    public virtual User User { get; set; } = null!;
}
