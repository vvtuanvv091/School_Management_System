using System;
using System.Collections.Generic;

namespace School_Management_System.Models;

public partial class EventonGuardian
{
    public int? GrId { get; set; }

    public string? GrFname { get; set; }

    public string? GrLname { get; set; }

    public string? GrEmail { get; set; }

    public string? GrPass { get; set; }

    public string? GrCnic { get; set; }

    public string? GrTelNo { get; set; }

    public string? GrMobileNo { get; set; }

    public string? GrAddress { get; set; }

    public string? GrRelationship { get; set; }

    public string? OperationPerform { get; set; }

    public TimeOnly? ChangeTime { get; set; }
}
