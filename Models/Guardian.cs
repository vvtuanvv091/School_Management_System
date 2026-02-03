using System;
using System.Collections.Generic;

namespace School_Management_System.Models;

public partial class Guardian
{
    public int GrId { get; set; }

    public string GrFname { get; set; } = null!;

    public string GrLname { get; set; } = null!;

    public string GrEmail { get; set; } = null!;

    public string GrPass { get; set; } = null!;

    public string GrCnic { get; set; } = null!;

    public string? GrTelNo { get; set; }

    public string GrMobileNo { get; set; } = null!;

    public string GrAddress { get; set; } = null!;

    public string GrRelationship { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
