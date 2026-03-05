using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Models;

public partial class Exam
{
    public int ExamId { get; set; }

    public int ExamTypeId { get; set; }

    public int ExamClassId { get; set; }

    public DateTime ExamStartDateTime { get; set; }

    public int ExamSubjectId { get; set; }

    public virtual Classroom ExamClass { get; set; } = null!;

    public virtual ICollection<ExamResult> ExamResults { get; set; } = new List<ExamResult>();

    public virtual Subject ExamSubject { get; set; } = null!;

    public virtual ExamType ExamType { get; set; } = null!;
}
