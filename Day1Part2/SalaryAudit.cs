using System;
using System.Collections.Generic;

namespace Day1Part2;

public partial class SalaryAudit
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public int? TeacherId { get; set; }

    public string? UserName { get; set; }

    public decimal? OldSalary { get; set; }

    public decimal? NewSalary { get; set; }
}
