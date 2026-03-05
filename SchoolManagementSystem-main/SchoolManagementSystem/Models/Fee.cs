using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Models;

public partial class Fee
{
    public int FeesId { get; set; }

    public int FeesStdId { get; set; }

    public decimal FeesPreviousCharges { get; set; }

    public DateTime FeesIssueDateTime { get; set; }

    public DateTime FeesDueDateTime { get; set; }

    public decimal? FeesDiscount { get; set; }

    public string? FeesDiscountReason { get; set; }

    public string FeesStatus { get; set; } = null!;

    public decimal FeesAmount { get; set; }

    public decimal? FeesAdditionalCharges { get; set; }

    public DateOnly? FeesPaidDate { get; set; }

    public virtual Student FeesStd { get; set; } = null!;
}
