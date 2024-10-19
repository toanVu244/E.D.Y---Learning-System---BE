using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

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
}
