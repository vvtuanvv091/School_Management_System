using System;
using System.Collections.Generic;

namespace School_Management_System.Models;

public partial class Employee
{
    public int EId { get; set; }

    public string EFname { get; set; } = null!;

    public string ELname { get; set; } = null!;

    public string EEmail { get; set; } = null!;

    public string EPass { get; set; } = null!;

    public DateOnly EDob { get; set; }

    public string? ETelNo { get; set; }

    public string EMobileNo { get; set; } = null!;

    public DateOnly EDoj { get; set; }

    public string EStatus { get; set; } = null!;

    public string EGender { get; set; } = null!;

    public int ERoleId { get; set; }

    public decimal ESalary { get; set; }

    public virtual Role ERole { get; set; } = null!;

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();

    public virtual ICollection<SubjectTeach> SubjectTeaches { get; set; } = new List<SubjectTeach>();
}
