using System;
using System.Collections.Generic;

namespace BusinessObject.Entities;

public partial class UserCourse
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public int CourseId { get; set; }

    public DateTime EnrollDate { get; set; }

    public bool Certificate { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
