using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Models;

public partial class Attendance
{
    public int AStdId { get; set; }

    public string? ARemarks { get; set; }

    public string AStatus { get; set; } = null!;

    public DateTime ADate { get; set; }

    public virtual Student AStd { get; set; } = null!;
}
