using System;
using System.Collections.Generic;

namespace School_Management_System.Models;

public partial class Attendance
{
    public int AStdId { get; set; }

    public string? ARemarks { get; set; }

    public string AStatus { get; set; } = null!;

    public DateTime ADate { get; set; }

    public virtual Student AStd { get; set; } = null!;
}
