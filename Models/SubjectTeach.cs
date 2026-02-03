using System;
using System.Collections.Generic;

namespace School_Management_System.Models;

public partial class SubjectTeach
{
    public int IdSubjectTeaches { get; set; }

    public int SubjectTeachesBy { get; set; }

    public int SubjectTeachesClassId { get; set; }

    public DateOnly SubjectTeachesStartDate { get; set; }

    public DateOnly? SubjectTeachesEndDate { get; set; }

    public string SubjectTeachesDropStatus { get; set; } = null!;

    public string SubjectTeachesOutCome { get; set; } = null!;

    public int SubjectTeachesSubjectId { get; set; }

    public virtual Employee SubjectTeachesByNavigation { get; set; } = null!;

    public virtual ClassRoom SubjectTeachesClass { get; set; } = null!;

    public virtual Subject SubjectTeachesSubject { get; set; } = null!;
}
