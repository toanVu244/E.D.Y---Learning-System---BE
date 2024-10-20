using System;
using System.Collections.Generic;

namespace BusinessObject.Entities;

public partial class Notification
{
    public int NotifiId { get; set; }

    public string? UserId { get; set; }

    public string? ContentNotifi { get; set; }

    public DateTime? Date { get; set; }

    public virtual User? User { get; set; }
}
