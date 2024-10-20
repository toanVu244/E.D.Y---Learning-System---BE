using System;
using System.Collections.Generic;

namespace BusinessObject.Entities;

public partial class Achivement
{
    public int AchiveId { get; set; }

    public string? Name { get; set; }

    public string? Condition { get; set; }

    public virtual ICollection<UserAchivement> UserAchivements { get; set; } = new List<UserAchivement>();
}
