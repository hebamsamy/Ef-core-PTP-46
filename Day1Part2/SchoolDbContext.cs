using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Day1Part2;

public partial class SchoolDbContext : DbContext
{
    public SchoolDbContext()
    {
    }

    public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<SalaryAudit> SalaryAudits { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentAttendance> StudentAttendances { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<VCousreTecher> VCousreTechers { get; set; }

    public virtual DbSet<VTeacheofDeptOne> VTeacheofDeptOnes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=SchoolDB;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Courses__C92D7187EA688907");

            entity.HasIndex(e => e.TeacherId, "IX_Courses_TeacherID");

            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CourseName).HasMaxLength(100);
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Courses)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Courses_Teachers");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCDE629CC58");

            entity.HasIndex(e => e.DepartmentName, "UQ__Departme__D949CC34856624AE").IsUnique();

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(255);
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("PK__Enrollme__7F6877FB1653967D");

            entity.HasIndex(e => e.StudentId, "IX_Enrollments_StudentID");

            entity.HasIndex(e => new { e.StudentId, e.CourseId }, "UQ_Student_Course").IsUnique();

            entity.Property(e => e.EnrollmentId).HasColumnName("EnrollmentID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.Grade).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Course).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enrollments_Courses");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enrollments_Students");
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Exam");

            entity.HasIndex(e => e.Decsrption, "desindex");

            entity.HasIndex(e => e.Name, "nameindex");

            entity.HasIndex(e => e.ExamNo, "pindex").IsClustered();

            entity.Property(e => e.Decsrption).HasMaxLength(1000);
            entity.Property(e => e.ExamNo).HasColumnName("ExamNO");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<SalaryAudit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SalaryAu__3213E83F1B5CBAAD");

            entity.ToTable("SalaryAudit");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.NewSalary).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.OldSalary).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52A791BAC0EB6");

            entity.HasIndex(e => e.DepartmentId, "IX_Students_DepartmentID");

            entity.HasIndex(e => e.Email, "UQ__Students__A9D105344AD2DFF3").IsUnique();

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);

            entity.HasOne(d => d.Department).WithMany(p => p.Students)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_Departments");
        });

        modelBuilder.Entity<StudentAttendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__StudentA__8B69263C0D3E5AB3");

            entity.ToTable("StudentAttendance");

            entity.HasIndex(e => e.StudentId, "IX_Attendance_StudentID");

            entity.HasIndex(e => new { e.StudentId, e.CourseId, e.AttendanceDate }, "UQ_Attendance").IsUnique();

            entity.Property(e => e.AttendanceId).HasColumnName("AttendanceID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.Status).HasMaxLength(10);
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Course).WithMany(p => p.StudentAttendances)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendance_Courses");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentAttendances)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendance_Students");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teachers__EDF25944E2E5528B");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("TeacherSalaryChange");
                    tb.HasTrigger("TeacherSoftDelete");
                });

            entity.HasIndex(e => e.DepartmentId, "IX_Teachers_DepartmentID");

            entity.HasIndex(e => e.Email, "UQ__Teachers__A9D10534AD4A1AF4").IsUnique();

            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.Salary)
                .HasDefaultValue(6000m, "DF_Teachers_Salary")
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Test)
                .HasDefaultValue(0)
                .HasColumnName("test");

            entity.HasOne(d => d.Department).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teachers_Departments");
        });

        modelBuilder.Entity<VCousreTecher>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CousreTechers");

            entity.Property(e => e.CourseName).HasMaxLength(100);
            entity.Property(e => e.DepartmentName).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(101);
        });

        modelBuilder.Entity<VTeacheofDeptOne>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_TeacheofDeptOne");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TeacherId)
                .ValueGeneratedOnAdd()
                .HasColumnName("TeacherID");
        });
        modelBuilder.HasSequence("inc").StartsAt(17L);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
