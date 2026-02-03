using System;
using System.Collections.Generic;

namespace School_Management_System.Models;

public partial class School
{
    public int SchoolId { get; set; }

    public string SchoolName { get; set; } = null!;

    public string SchoolAddress { get; set; } = null!;

    public string SchoolEmail { get; set; } = null!;

    public string SchoolPhoneNumber { get; set; } = null!;

    public int SchoolAdmin { get; set; }

    public virtual Admin SchoolAdminNavigation { get; set; } = null!;
}
