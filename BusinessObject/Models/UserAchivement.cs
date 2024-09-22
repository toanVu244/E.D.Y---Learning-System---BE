using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class UserAchivement
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public int? AchiveId { get; set; }

    public DateTime? Date { get; set; }

    public virtual Achivement? Achive { get; set; }

    public virtual User? User { get; set; }
}
