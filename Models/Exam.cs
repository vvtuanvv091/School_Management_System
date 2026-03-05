using System;
using System.Collections.Generic;

namespace School_Management_System.Models;

public partial class Exam
{
    public int ExamId { get; set; }

    public int ExamTypeId { get; set; }

    public int ExamClassId { get; set; }

    public DateTime ExamStartDateTime { get; set; }

    public int ExamSubjectId { get; set; }

    public virtual ClassRoom ExamClass { get; set; } = null!;

    public virtual ICollection<ExamResult> ExamResults { get; set; } = new List<ExamResult>();

    public virtual Subject ExamSubject { get; set; } = null!;

    public virtual ExamType ExamType { get; set; } = null!;
}
