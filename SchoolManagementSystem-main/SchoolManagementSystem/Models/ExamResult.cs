using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Models;

public partial class ExamResult
{
    public int ExamResultId { get; set; }

    public int ExamId { get; set; }

    public int ExamStdId { get; set; }

    public decimal ExamTotalMarks { get; set; }

    public string ExamGrade { get; set; } = null!;

    public decimal ExamObtainMarks { get; set; }

    public virtual Exam Exam { get; set; } = null!;

    public virtual Student ExamStd { get; set; } = null!;
}
