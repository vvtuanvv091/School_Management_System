using System;
using System.Collections.Generic;

namespace School_Management_System.Models;

public partial class Subject
{
    public int SubjectId { get; set; }

    public string SubjectName { get; set; } = null!;

    public int SubjectClassId { get; set; }

    public string? SubjectDescription { get; set; }

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual ClassRoom SubjectClass { get; set; } = null!;

    public virtual ICollection<SubjectTeach> SubjectTeaches { get; set; } = new List<SubjectTeach>();

    public virtual ICollection<TimeTable> TimeTables { get; set; } = new List<TimeTable>();
}
