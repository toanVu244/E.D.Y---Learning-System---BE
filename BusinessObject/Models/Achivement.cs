using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Achivement
{
    public int AchiveId { get; set; }

    public string? Name { get; set; }

    public string? Condition { get; set; }
}
