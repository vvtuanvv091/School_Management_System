using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementSystem.Models;

public partial class LmsDbContext : DbContext
{
    public LmsDbContext()
    {
    }

    public LmsDbContext(DbContextOptions<LmsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EventOnEmployee> EventOnEmployees { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<ExamResult> ExamResults { get; set; }

    public virtual DbSet<ExamType> ExamTypes { get; set; }

    public virtual DbSet<Fee> Fees { get; set; }

    public virtual DbSet<Guardian> Guardians { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SubjectTeach> SubjectTeaches { get; set; }

    public virtual DbSet<TimeTable> TimeTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LMS_DB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.ToTable("Admin");

            entity.Property(e => e.AdminId).HasColumnName("Admin_ID");
            entity.Property(e => e.AdminEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Admin_Email");
            entity.Property(e => e.AdminName)
                .HasMaxLength(50)
                .HasColumnName("Admin_Name");
            entity.Property(e => e.AdminPass)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Admin_Pass");
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Attendance");

            entity.HasIndex(e => e.AStdId, "IX_Attendance_StdID");

            entity.Property(e => e.ADate)
                .HasColumnType("datetime")
                .HasColumnName("A_Date");
            entity.Property(e => e.ARemarks)
                .HasMaxLength(50)
                .HasDefaultValue("Not Provided")
                .HasColumnName("A_Remarks");
            entity.Property(e => e.AStatus)
                .HasMaxLength(20)
                .HasColumnName("A_Status");
            entity.Property(e => e.AStdId).HasColumnName("A_StdID");

            entity.HasOne(d => d.AStd).WithMany()
                .HasForeignKey(d => d.AStdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendance_Student");
        });

        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasKey(e => e.ClassId);

            entity.ToTable("Classroom");

            entity.Property(e => e.ClassId).HasColumnName("Class_ID");
            entity.Property(e => e.ClassDescription)
                .HasMaxLength(200)
                .HasDefaultValue("NoDescription")
                .HasColumnName("Class_Description");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EId);

            entity.ToTable("Employee", tb => tb.HasTrigger("trg_Employee_Audit_Update"));

            entity.HasIndex(e => e.EMobileNo, "UQ_Employee_Mobile").IsUnique();

            entity.Property(e => e.EId).HasColumnName("E_ID");
            entity.Property(e => e.EDob).HasColumnName("E_DOB");
            entity.Property(e => e.EDoj).HasColumnName("E_DOJ");
            entity.Property(e => e.EEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("E_Email");
            entity.Property(e => e.EFname)
                .HasMaxLength(30)
                .HasColumnName("E_Fname");
            entity.Property(e => e.EGender)
                .HasMaxLength(10)
                .HasColumnName("E_Gender");
            entity.Property(e => e.ELname)
                .HasMaxLength(30)
                .HasColumnName("E_Lname");
            entity.Property(e => e.EMobileNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("E_MobileNo");
            entity.Property(e => e.EPass)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("E_Pass");
            entity.Property(e => e.ERoleId).HasColumnName("E_RoleID");
            entity.Property(e => e.ESalary)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("E_Salary");
            entity.Property(e => e.EStatus)
                .HasMaxLength(30)
                .HasColumnName("E_Status");
            entity.Property(e => e.ETelNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Not Provided")
                .HasColumnName("E_TelNo");

            entity.HasOne(d => d.ERole).WithMany(p => p.Employees)
                .HasForeignKey(d => d.ERoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Role");
        });

        modelBuilder.Entity<EventOnEmployee>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EventOnEmployee");

            entity.Property(e => e.ChangeTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("change_time");
            entity.Property(e => e.EDob).HasColumnName("E_DOB");
            entity.Property(e => e.EDoj).HasColumnName("E_DOJ");
            entity.Property(e => e.EEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("E_Email");
            entity.Property(e => e.EFname)
                .HasMaxLength(30)
                .HasColumnName("E_Fname");
            entity.Property(e => e.EGender)
                .HasMaxLength(10)
                .HasColumnName("E_Gender");
            entity.Property(e => e.EId).HasColumnName("E_ID");
            entity.Property(e => e.ELname)
                .HasMaxLength(30)
                .HasColumnName("E_Lname");
            entity.Property(e => e.EMobileNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("E_MobileNo");
            entity.Property(e => e.EPass)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("E_Pass");
            entity.Property(e => e.ERoleId).HasColumnName("E_RoleID");
            entity.Property(e => e.ESalary)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("E_Salary");
            entity.Property(e => e.EStatus)
                .HasMaxLength(30)
                .HasColumnName("E_Status");
            entity.Property(e => e.ETelNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("E_TelNo");
            entity.Property(e => e.OperationPerform)
                .HasMaxLength(50)
                .HasColumnName("operation_perform");
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.ToTable("Exam");

            entity.Property(e => e.ExamId).HasColumnName("Exam_ID");
            entity.Property(e => e.ExamClassId).HasColumnName("Exam_ClassID");
            entity.Property(e => e.ExamStartDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Exam_Start_DateTime");
            entity.Property(e => e.ExamSubjectId).HasColumnName("Exam_SubjectID");
            entity.Property(e => e.ExamTypeId).HasColumnName("Exam_TypeID");

            entity.HasOne(d => d.ExamClass).WithMany(p => p.Exams)
                .HasForeignKey(d => d.ExamClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Exam_Classroom");

            entity.HasOne(d => d.ExamSubject).WithMany(p => p.Exams)
                .HasForeignKey(d => d.ExamSubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Exam_Subjects");

            entity.HasOne(d => d.ExamType).WithMany(p => p.Exams)
                .HasForeignKey(d => d.ExamTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Exam_Type");
        });

        modelBuilder.Entity<ExamResult>(entity =>
        {
            entity.ToTable("Exam_Result");

            entity.Property(e => e.ExamResultId).HasColumnName("ExamResult_ID");
            entity.Property(e => e.ExamGrade)
                .HasMaxLength(10)
                .HasColumnName("Exam_Grade");
            entity.Property(e => e.ExamId).HasColumnName("Exam_ID");
            entity.Property(e => e.ExamObtainMarks)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Exam_ObtainMarks");
            entity.Property(e => e.ExamStdId).HasColumnName("Exam_StdID");
            entity.Property(e => e.ExamTotalMarks)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Exam_TotalMarks");

            entity.HasOne(d => d.Exam).WithMany(p => p.ExamResults)
                .HasForeignKey(d => d.ExamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExamResult_Exam");

            entity.HasOne(d => d.ExamStd).WithMany(p => p.ExamResults)
                .HasForeignKey(d => d.ExamStdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExamResult_Student");
        });

        modelBuilder.Entity<ExamType>(entity =>
        {
            entity.ToTable("Exam_Type");

            entity.HasIndex(e => e.ExamName, "UQ_Exam_Type_Name").IsUnique();

            entity.Property(e => e.ExamTypeId).HasColumnName("Exam_TypeID");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasDefaultValue("Not Provided");
            entity.Property(e => e.ExamName)
                .HasMaxLength(50)
                .HasColumnName("Exam_Name");
        });

        modelBuilder.Entity<Fee>(entity =>
        {
            entity.HasKey(e => e.FeesId);

            entity.Property(e => e.FeesId).HasColumnName("Fees_ID");
            entity.Property(e => e.FeesAdditionalCharges)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Fees_AdditionalCharges");
            entity.Property(e => e.FeesAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Fees_Amount");
            entity.Property(e => e.FeesDiscount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Fees_Discount");
            entity.Property(e => e.FeesDiscountReason)
                .HasMaxLength(70)
                .HasColumnName("Fees_DiscountReason");
            entity.Property(e => e.FeesDueDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Fees_DueDateTime");
            entity.Property(e => e.FeesIssueDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Fees_IssueDateTime");
            entity.Property(e => e.FeesPaidDate).HasColumnName("Fees_PaidDate");
            entity.Property(e => e.FeesPreviousCharges)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Fees_PreviousCharges");
            entity.Property(e => e.FeesStatus).HasMaxLength(45);
            entity.Property(e => e.FeesStdId).HasColumnName("Fees_StdID");

            entity.HasOne(d => d.FeesStd).WithMany(p => p.Fees)
                .HasForeignKey(d => d.FeesStdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Fees_Student");
        });

        modelBuilder.Entity<Guardian>(entity =>
        {
            entity.HasKey(e => e.GrId);

            entity.ToTable("Guardian");

            entity.HasIndex(e => e.GrCnic, "UQ_Guardian_CNIC").IsUnique();

            entity.HasIndex(e => e.GrEmail, "UQ_Guardian_Email").IsUnique();

            entity.HasIndex(e => e.GrMobileNo, "UQ_Guardian_Mobile").IsUnique();

            entity.Property(e => e.GrId).HasColumnName("Gr_Id");
            entity.Property(e => e.GrAddress)
                .HasMaxLength(100)
                .HasColumnName("Gr_Address");
            entity.Property(e => e.GrCnic)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Gr_CNIC");
            entity.Property(e => e.GrEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Gr_Email");
            entity.Property(e => e.GrFname)
                .HasMaxLength(30)
                .HasColumnName("Gr_Fname");
            entity.Property(e => e.GrLname)
                .HasMaxLength(30)
                .HasColumnName("Gr_Lname");
            entity.Property(e => e.GrMobileNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Gr_MobileNo");
            entity.Property(e => e.GrPass)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Gr_Pass");
            entity.Property(e => e.GrRelationship)
                .HasMaxLength(100)
                .HasColumnName("Gr_Relationship");
            entity.Property(e => e.GrTelNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Gr_TelNo");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.ToTable("Result");

            entity.Property(e => e.ResultId).HasColumnName("Result_ID");
            entity.Property(e => e.ResultExamTypeId).HasColumnName("Result_ExamTypeID");
            entity.Property(e => e.ResultGrade)
                .HasMaxLength(45)
                .HasColumnName("Result_Grade");
            entity.Property(e => e.ResultObtainMarks)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Result_ObtainMarks");
            entity.Property(e => e.ResultPercentage)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("Result_Percentage");
            entity.Property(e => e.ResultStdId).HasColumnName("Result_StdID");
            entity.Property(e => e.ResultTotalMarks)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Result_TotalMarks");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.HasIndex(e => e.RoleName, "UQ_Role_Name").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("Role_ID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("Role_Name");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.ToTable("Section");

            entity.Property(e => e.SectionId).HasColumnName("Section_ID");
            entity.Property(e => e.SectionClassId).HasColumnName("Section_ClassID");
            entity.Property(e => e.SectionName)
                .HasMaxLength(45)
                .HasColumnName("Section_Name");
            entity.Property(e => e.SectionUnderObservation).HasColumnName("Section_UnderObservation");

            entity.HasOne(d => d.SectionClass).WithMany(p => p.Sections)
                .HasForeignKey(d => d.SectionClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Section_Classroom");

            entity.HasOne(d => d.SectionUnderObservationNavigation).WithMany(p => p.Sections)
                .HasForeignKey(d => d.SectionUnderObservation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Section_Employee");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StdId);

            entity.ToTable("Student");

            entity.Property(e => e.StdId).HasColumnName("Std_Id");
            entity.Property(e => e.StdClassId).HasColumnName("Std_ClassID");
            entity.Property(e => e.StdDoa).HasColumnName("Std_DOA");
            entity.Property(e => e.StdDob).HasColumnName("Std_DOB");
            entity.Property(e => e.StdEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Std_Email");
            entity.Property(e => e.StdFname)
                .HasMaxLength(30)
                .HasColumnName("Std_Fname");
            entity.Property(e => e.StdGender)
                .HasMaxLength(10)
                .HasColumnName("Std_Gender");
            entity.Property(e => e.StdGuardianId).HasColumnName("Std_GuardianID");
            entity.Property(e => e.StdLname)
                .HasMaxLength(30)
                .HasColumnName("Std_Lname");
            entity.Property(e => e.StdMobileNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Not Provided")
                .HasColumnName("Std_MobileNo");
            entity.Property(e => e.StdPass)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Std_Pass");
            entity.Property(e => e.StdSectionId).HasColumnName("Std_SectionID");
            entity.Property(e => e.StdStatus)
                .HasMaxLength(30)
                .HasColumnName("Std_Status");
            entity.Property(e => e.StdTelNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Not Provided")
                .HasColumnName("Std_TelNo");

            entity.HasOne(d => d.StdClass).WithMany(p => p.Students)
                .HasForeignKey(d => d.StdClassId)
                .HasConstraintName("FK_Student_Classroom");

            entity.HasOne(d => d.StdGuardian).WithMany(p => p.Students)
                .HasForeignKey(d => d.StdGuardianId)
                .HasConstraintName("FK_Student_Guardian");

            entity.HasOne(d => d.StdSection).WithMany(p => p.Students)
                .HasForeignKey(d => d.StdSectionId)
                .HasConstraintName("FK_Student_Section");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasIndex(e => e.SubjectName, "UQ_Subject_Name").IsUnique();

            entity.Property(e => e.SubjectId).HasColumnName("Subject_ID");
            entity.Property(e => e.SubjectClassId).HasColumnName("Subject_ClassID");
            entity.Property(e => e.SubjectDescription)
                .HasMaxLength(100)
                .HasDefaultValue("Not Provided")
                .HasColumnName("Subject_Description");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(50)
                .HasColumnName("Subject_Name");

            entity.HasOne(d => d.SubjectClass).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.SubjectClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subjects_Classroom");
        });

        modelBuilder.Entity<SubjectTeach>(entity =>
        {
            entity.HasKey(e => e.IdSubjectTeaches);

            entity.Property(e => e.IdSubjectTeaches).HasColumnName("idSubjectTeaches");
            entity.Property(e => e.SubjectTeachesClassId).HasColumnName("SubjectTeachesClassID");
            entity.Property(e => e.SubjectTeachesDropStatus)
                .HasMaxLength(45)
                .HasDefaultValue("Not Provided");
            entity.Property(e => e.SubjectTeachesOutCome)
                .HasMaxLength(70)
                .HasDefaultValue("Not Provided");
            entity.Property(e => e.SubjectTeachesSubjectId).HasColumnName("SubjectTeaches_SubjectID");

            entity.HasOne(d => d.SubjectTeachesByNavigation).WithMany(p => p.SubjectTeaches)
                .HasForeignKey(d => d.SubjectTeachesBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubjectTeaches_Employee");

            entity.HasOne(d => d.SubjectTeachesClass).WithMany(p => p.SubjectTeaches)
                .HasForeignKey(d => d.SubjectTeachesClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubjectTeaches_Classroom");

            entity.HasOne(d => d.SubjectTeachesSubject).WithMany(p => p.SubjectTeaches)
                .HasForeignKey(d => d.SubjectTeachesSubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubjectTeaches_Subject");
        });

        modelBuilder.Entity<TimeTable>(entity =>
        {
            entity.HasKey(e => e.TtId);

            entity.ToTable("TimeTable");

            entity.Property(e => e.TtId).HasColumnName("TT_ID");
            entity.Property(e => e.TtDay)
                .HasMaxLength(15)
                .HasColumnName("TT_Day");
            entity.Property(e => e.TtDescription)
                .HasMaxLength(60)
                .HasColumnName("TT_Description");
            entity.Property(e => e.TtEndTime).HasColumnName("TT_EndTime");
            entity.Property(e => e.TtSectionId).HasColumnName("TT_SectionID");
            entity.Property(e => e.TtStartTime).HasColumnName("TT_StartTime");
            entity.Property(e => e.TtSubjectId).HasColumnName("TT_SubjectID");

            entity.HasOne(d => d.TtSection).WithMany(p => p.TimeTables)
                .HasForeignKey(d => d.TtSectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TimeTable_Section");

            entity.HasOne(d => d.TtSubject).WithMany(p => p.TimeTables)
                .HasForeignKey(d => d.TtSubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TimeTable_Subjects");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
