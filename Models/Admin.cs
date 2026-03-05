using System;
using System.Collections.Generic;

namespace School_Management_System.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string AdminName { get; set; } = null!;

    public string AdminEmail { get; set; } = null!;

    public string AdminPass { get; set; } = null!;

    public virtual ICollection<School> Schools { get; set; } = new List<School>();
}
