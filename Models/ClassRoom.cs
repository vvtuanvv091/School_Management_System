using System;
using System.Collections.Generic;

namespace School_Management_System.Models;

public partial class ClassRoom
{
    public int ClassId { get; set; }

    public string? ClassDescription { get; set; }

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<SubjectTeach> SubjectTeaches { get; set; } = new List<SubjectTeach>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
