using System;
using System.Collections.Generic;

namespace School_Management_System.Models;

public partial class EventonStudent
{
    public int? StdId { get; set; }

    public string? StdFname { get; set; }

    public string? StdLname { get; set; }

    public string? StdEmail { get; set; }

    public string? StdPass { get; set; }

    public DateOnly? StdDob { get; set; }

    public string? StdTelno { get; set; }

    public string? StdMobileno { get; set; }

    public DateOnly? StdDoa { get; set; }

    public string? StdStatus { get; set; }

    public string? StdGender { get; set; }

    public int? StdClassid { get; set; }

    public int? StdSecid { get; set; }

    public int? StdGid { get; set; }

    public string? OperationPerform { get; set; }

    public TimeOnly? ChangeTime { get; set; }
}
