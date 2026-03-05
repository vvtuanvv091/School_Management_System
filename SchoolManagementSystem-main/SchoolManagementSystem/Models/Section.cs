using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Models;

public partial class Section
{
    public int SectionId { get; set; }

    public int SectionClassId { get; set; }

    public int SectionUnderObservation { get; set; }

    public string SectionName { get; set; } = null!;

    public virtual Classroom SectionClass { get; set; } = null!;

    public virtual Employee SectionUnderObservationNavigation { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<TimeTable> TimeTables { get; set; } = new List<TimeTable>();
}
