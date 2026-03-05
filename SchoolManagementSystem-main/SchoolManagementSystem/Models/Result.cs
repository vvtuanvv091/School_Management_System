using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Models;

public partial class Result
{
    public int ResultId { get; set; }

    public int ResultExamTypeId { get; set; }

    public decimal ResultTotalMarks { get; set; }

    public decimal ResultObtainMarks { get; set; }

    public string ResultGrade { get; set; } = null!;

    public decimal ResultPercentage { get; set; }

    public int ResultStdId { get; set; }
}
