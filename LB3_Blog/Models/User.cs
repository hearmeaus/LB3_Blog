﻿using System;
using System.Collections.Generic;

namespace LB3_Blog.Models;

public partial class User
{
    public int Id { get; set; }

    public string Nicknamet { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public DateOnly? Birthday { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
