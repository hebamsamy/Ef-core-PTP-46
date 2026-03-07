using System;
using System.Collections.Generic;

namespace Day1Part2;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public int DepartmentId { get; set; }

    public decimal Salary { get; set; }

    public int? Test { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Department Department { get; set; } = null!;
}
