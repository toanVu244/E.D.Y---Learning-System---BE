using System;
using System.Collections.Generic;

namespace BusinessObject.Entities;

public partial class User
{
    public string UserId { get; set; } = null!;

    public string? FullName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public int? Streak { get; set; }

    public string? Password { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? Vip { get; set; }

    public double? Monney { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();

    public virtual ICollection<UserAchivement> UserAchivements { get; set; } = new List<UserAchivement>();

    public virtual ICollection<UserCourse> UserCourses { get; set; } = new List<UserCourse>();
}
