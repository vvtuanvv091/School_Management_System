using System;
using System.Collections.Generic;

namespace School_Management_System.Models;

public partial class EventonResult
{
    public int? RId { get; set; }

    public int? RExamTypeId { get; set; }

    public decimal? RTotalmarks { get; set; }

    public decimal? RObtainMarks { get; set; }

    public string? RGrade { get; set; }

    public decimal? RPercent { get; set; }

    public int? RStdId { get; set; }

    public string? OperationPerform { get; set; }

    public TimeOnly? ChangeTime { get; set; }
}
