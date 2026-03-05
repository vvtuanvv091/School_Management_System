using System;
using System.Collections.Generic;

namespace School_Management_System.Models;

public partial class Student
{
    public int StdId { get; set; }

    public string StdFname { get; set; } = null!;

    public string StdLname { get; set; } = null!;

    public string StdEmail { get; set; } = null!;

    public string StdPass { get; set; } = null!;

    public DateOnly StdDob { get; set; }

    public string? StdTelNo { get; set; }

    public string? StdMobileNo { get; set; }

    public DateOnly StdDoa { get; set; }

    public string StdStatus { get; set; } = null!;

    public string StdGender { get; set; } = null!;

    public int? StdClassId { get; set; }

    public int? StdSectionId { get; set; }

    public int? StdGuardianId { get; set; }

    public virtual ICollection<ExamResult> ExamResults { get; set; } = new List<ExamResult>();

    public virtual ICollection<Fee> Fees { get; set; } = new List<Fee>();

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();

    public virtual ClassRoom? StdClass { get; set; }

    public virtual Guardian? StdGuardian { get; set; }

    public virtual Section? StdSection { get; set; }
}
