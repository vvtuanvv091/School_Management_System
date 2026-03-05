using System;
using System.Collections.Generic;

namespace School_Management_System.Models;

public partial class ExamType
{
    public int ExamTypeId { get; set; }

    public string ExamName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
