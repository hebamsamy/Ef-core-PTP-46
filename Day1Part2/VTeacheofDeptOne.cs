using System;
using System.Collections.Generic;

namespace Day1Part2;

public partial class VTeacheofDeptOne
{
    public int TeacherId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int DepartmentId { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public decimal Salary { get; set; }
}
