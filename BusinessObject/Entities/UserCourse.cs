using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessObject.Entities;

public partial class UserCourse
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public int CourseId { get; set; }

    public DateTime EnrollDate { get; set; }

    public bool Certificate { get; set; }
    [JsonIgnore]
    public virtual Course Course { get; set; } = null!;
    [JsonIgnore]
    public virtual User User { get; set; } = null!;
}
