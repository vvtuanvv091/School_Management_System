using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Models;

public partial class TimeTable
{
    public int TtId { get; set; }

    public int TtSectionId { get; set; }

    public string TtDay { get; set; } = null!;

    public TimeOnly TtStartTime { get; set; }

    public string? TtDescription { get; set; }

    public int TtSubjectId { get; set; }

    public TimeOnly TtEndTime { get; set; }

    public virtual Section TtSection { get; set; } = null!;

    public virtual Subject TtSubject { get; set; } = null!;
}
