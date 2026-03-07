using System;
using System.Collections.Generic;

namespace Day1Part2;

public partial class StudentAttendance
{
    public int AttendanceId { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public DateOnly AttendanceDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
