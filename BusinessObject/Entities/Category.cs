﻿using System;
using System.Collections.Generic;

namespace BusinessObject.Entities;

public partial class Category
{
    public int Idcategory { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
