using System;
using System.Collections.Generic;

namespace School_Management_System.Models;

public partial class EventonEmployee
{
    public int? EId { get; set; }

    public string? EFname { get; set; }

    public string? ELname { get; set; }

    public string? EEmail { get; set; }

    public string? EPass { get; set; }

    public DateOnly? EDob { get; set; }

    public string? ETelNo { get; set; }

    public string? EMobileNo { get; set; }

    public DateOnly? EDoj { get; set; }

    public string? EStatus { get; set; }

    public string? EGender { get; set; }

    public int? ERoleId { get; set; }

    public decimal? ESalary { get; set; }

    public string? OperationPerform { get; set; }

    public TimeOnly? ChangeTime { get; set; }
}
