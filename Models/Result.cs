using System;
using System.Collections.Generic;

namespace School_Management_System.Models;

public partial class Result
{
    public int ResultId { get; set; }

    public int ResultExamTypeId { get; set; }

    public decimal ResultTotalMarks { get; set; }

    public decimal ResultObtainMarks { get; set; }

    public string ResultGrade { get; set; } = null!;

    public decimal ResultPercentage { get; set; }

    public int ResultStdId { get; set; }

    public virtual ExamType ResultExamType { get; set; } = null!;

    public virtual Student ResultStd { get; set; } = null!;
}
