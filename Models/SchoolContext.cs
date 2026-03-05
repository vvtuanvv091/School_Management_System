using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace School_Management_System.Models;

public partial class SchoolContext : DbContext
{
    public SchoolContext()
    {
    }

    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<ClassRoom> ClassRooms { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EventonEmployee> EventonEmployees { get; set; }

    public virtual DbSet<EventonGuardian> EventonGuardians { get; set; }

    public virtual DbSet<EventonResult> EventonResults { get; set; }

    public virtual DbSet<EventonStudent> EventonStudents { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<ExamResult> ExamResults { get; set; }

    public virtual DbSet<ExamType> ExamTypes { get; set; }

    public virtual DbSet<Fee> Fees { get; set; }

    public virtual DbSet<Guardian> Guardians { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<School> Schools { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SubjectTeach> SubjectTeaches { get; set; }

    public virtual DbSet<TimeTable> TimeTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SchoolManagementDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__4A30011745087DBE");

            entity.ToTable("Admin");

            entity.Property(e => e.AdminId).HasColumnName("Admin_ID");
            entity.Property(e => e.AdminEmail)
                .HasMaxLength(30)
                .HasColumnName("Admin_Email");
            entity.Property(e => e.AdminName)
                .HasMaxLength(25)
                .HasColumnName("Admin_Name");
            entity.Property(e => e.AdminPass)
                .HasMaxLength(20)
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
                .HasMaxLength(20)
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

        modelBuilder.Entity<ClassRoom>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__ClassRoo__B097055756C306B6");

            entity.ToTable("ClassRoom");

            entity.Property(e => e.ClassId).HasColumnName("Class_ID");
            entity.Property(e => e.ClassDescription)
                .HasMaxLength(200)
                .HasDefaultValue("NoDescription")
                .HasColumnName("Class_Description");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EId).HasName("PK__Employee__D730AF54BBB2BE3A");

            entity.ToTable("Employee");

            entity.HasIndex(e => e.EMobileNo, "UQ__Employee__7668414956EFC237").IsUnique();

            entity.Property(e => e.EId).HasColumnName("E_ID");
            entity.Property(e => e.EDob).HasColumnName("E_DOB");
            entity.Property(e => e.EDoj).HasColumnName("E_DOJ");
            entity.Property(e => e.EEmail)
                .HasMaxLength(30)
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
                .HasColumnName("E_MobileNo");
            entity.Property(e => e.EPass)
                .HasMaxLength(30)
                .HasColumnName("E_Pass");
            entity.Property(e => e.ERoleId).HasColumnName("E_RoleID");
            entity.Property(e => e.ESalary)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("E_Salary");
            entity.Property(e => e.EStatus)
                .HasMaxLength(30)
                .HasColumnName("E_Status");
            entity.Property(e => e.ETelNo)
                .HasMaxLength(20)
                .HasDefaultValue("Not Provided")
                .HasColumnName("E_TelNo");

            entity.HasOne(d => d.ERole).WithMany(p => p.Employees)
                .HasForeignKey(d => d.ERoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Role");
        });

        modelBuilder.Entity<EventonEmployee>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("eventonEmployee");

            entity.Property(e => e.ChangeTime).HasColumnName("change_time");
            entity.Property(e => e.EDob).HasColumnName("E_DOB");
            entity.Property(e => e.EDoj).HasColumnName("E_DOJ");
            entity.Property(e => e.EEmail)
                .HasMaxLength(30)
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
                .HasColumnName("E_MobileNo");
            entity.Property(e => e.EPass)
                .HasMaxLength(30)
                .HasColumnName("E_Pass");
            entity.Property(e => e.ERoleId).HasColumnName("E_RoleID");
            entity.Property(e => e.ESalary)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("E_Salary");
            entity.Property(e => e.EStatus)
                .HasMaxLength(30)
                .HasColumnName("E_Status");
            entity.Property(e => e.ETelNo)
                .HasMaxLength(20)
                .HasColumnName("E_TelNo");
            entity.Property(e => e.OperationPerform)
                .HasMaxLength(45)
                .HasColumnName("operation_perform");
        });

        modelBuilder.Entity<EventonGuardian>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("eventonGuardian");

            entity.Property(e => e.ChangeTime).HasColumnName("change_time");
            entity.Property(e => e.GrAddress)
                .HasMaxLength(100)
                .HasColumnName("Gr_Address");
            entity.Property(e => e.GrCnic)
                .HasMaxLength(20)
                .HasColumnName("Gr_CNIC");
            entity.Property(e => e.GrEmail)
                .HasMaxLength(30)
                .HasColumnName("Gr_Email");
            entity.Property(e => e.GrFname)
                .HasMaxLength(30)
                .HasColumnName("Gr_Fname");
            entity.Property(e => e.GrId).HasColumnName("Gr_ID");
            entity.Property(e => e.GrLname)
                .HasMaxLength(30)
                .HasColumnName("Gr_Lname");
            entity.Property(e => e.GrMobileNo)
                .HasMaxLength(20)
                .HasColumnName("Gr_MobileNo");
            entity.Property(e => e.GrPass)
                .HasMaxLength(30)
                .HasColumnName("Gr_Pass");
            entity.Property(e => e.GrRelationship)
                .HasMaxLength(100)
                .HasColumnName("Gr_Relationship");
            entity.Property(e => e.GrTelNo)
                .HasMaxLength(20)
                .HasColumnName("Gr_TelNo");
            entity.Property(e => e.OperationPerform)
                .HasMaxLength(45)
                .HasColumnName("operation_perform");
        });

        modelBuilder.Entity<EventonResult>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("eventonResult");

            entity.Property(e => e.ChangeTime).HasColumnName("change_time");
            entity.Property(e => e.OperationPerform)
                .HasMaxLength(45)
                .HasColumnName("operation_perform");
            entity.Property(e => e.RExamTypeId).HasColumnName("R_ExamType_ID");
            entity.Property(e => e.RGrade)
                .HasMaxLength(45)
                .HasColumnName("R_grade");
            entity.Property(e => e.RId).HasColumnName("R_id");
            entity.Property(e => e.RObtainMarks)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("R_ObtainMarks");
            entity.Property(e => e.RPercent)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("R_percent");
            entity.Property(e => e.RStdId).HasColumnName("R_stdId");
            entity.Property(e => e.RTotalmarks)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("R_Totalmarks");
        });

        modelBuilder.Entity<EventonStudent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("eventonStudent");

            entity.Property(e => e.ChangeTime).HasColumnName("change_time");
            entity.Property(e => e.OperationPerform)
                .HasMaxLength(50)
                .HasColumnName("operation_perform");
            entity.Property(e => e.StdClassid).HasColumnName("std_classid");
            entity.Property(e => e.StdDoa).HasColumnName("std_doa");
            entity.Property(e => e.StdDob).HasColumnName("std_dob");
            entity.Property(e => e.StdEmail)
                .HasMaxLength(30)
                .HasColumnName("std_email");
            entity.Property(e => e.StdFname)
                .HasMaxLength(30)
                .HasColumnName("std_fname");
            entity.Property(e => e.StdGender)
                .HasMaxLength(10)
                .HasColumnName("std_gender");
            entity.Property(e => e.StdGid).HasColumnName("std_gid");
            entity.Property(e => e.StdId).HasColumnName("std_id");
            entity.Property(e => e.StdLname)
                .HasMaxLength(30)
                .HasColumnName("std_lname");
            entity.Property(e => e.StdMobileno)
                .HasMaxLength(20)
                .HasColumnName("std_mobileno");
            entity.Property(e => e.StdPass)
                .HasMaxLength(30)
                .HasColumnName("std_pass");
            entity.Property(e => e.StdSecid).HasColumnName("std_secid");
            entity.Property(e => e.StdStatus)
                .HasMaxLength(30)
                .HasColumnName("std_status");
            entity.Property(e => e.StdTelno)
                .HasMaxLength(20)
                .HasColumnName("std_Telno");
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.ExamId).HasName("PK__Exam__C782CA795164A1F4");

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
                .HasConstraintName("FK_Exam_Class");

            entity.HasOne(d => d.ExamSubject).WithMany(p => p.Exams)
                .HasForeignKey(d => d.ExamSubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Exam_Subject");

            entity.HasOne(d => d.ExamType).WithMany(p => p.Exams)
                .HasForeignKey(d => d.ExamTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Exam_Type");
        });

        modelBuilder.Entity<ExamResult>(entity =>
        {
            entity.HasKey(e => e.ExamResultId).HasName("PK__Exam_Res__BB747C8DECCB6482");

            entity.ToTable("Exam_Result");

            entity.Property(e => e.ExamResultId).HasColumnName("ExamResult_ID");
            entity.Property(e => e.ExamGrade)
                .HasMaxLength(45)
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
            entity.HasKey(e => e.ExamTypeId).HasName("PK__Exam_Typ__DC3DEFF4D9DE89A8");

            entity.ToTable("Exam_Type");

            entity.HasIndex(e => e.ExamName, "UQ__Exam_Typ__BCBBD37229FDC0B4").IsUnique();

            entity.Property(e => e.ExamTypeId).HasColumnName("Exam_TypeID");
            entity.Property(e => e.Description)
                .HasMaxLength(20)
                .HasDefaultValue("Not Provided");
            entity.Property(e => e.ExamName)
                .HasMaxLength(20)
                .HasColumnName("Exam_Name");
        });

        modelBuilder.Entity<Fee>(entity =>
        {
            entity.HasKey(e => e.FeesId).HasName("PK__Fees__24E61E9B3D65A782");

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
            entity.HasKey(e => e.GrId).HasName("PK__Guardian__DF89DCA43DD09DCE");

            entity.ToTable("Guardian");

            entity.HasIndex(e => e.GrEmail, "UQ__Guardian__0AA6860700C8CB86").IsUnique();

            entity.HasIndex(e => e.GrMobileNo, "UQ__Guardian__5DDFC491F4B6E370").IsUnique();

            entity.HasIndex(e => e.GrCnic, "UQ__Guardian__B0AA3DE066EC4FB3").IsUnique();

            entity.Property(e => e.GrId).HasColumnName("Gr_Id");
            entity.Property(e => e.GrAddress)
                .HasMaxLength(100)
                .HasColumnName("Gr_Address");
            entity.Property(e => e.GrCnic)
                .HasMaxLength(20)
                .HasColumnName("Gr_CNIC");
            entity.Property(e => e.GrEmail)
                .HasMaxLength(30)
                .HasColumnName("Gr_Email");
            entity.Property(e => e.GrFname)
                .HasMaxLength(30)
                .HasColumnName("Gr_Fname");
            entity.Property(e => e.GrLname)
                .HasMaxLength(30)
                .HasColumnName("Gr_Lname");
            entity.Property(e => e.GrMobileNo)
                .HasMaxLength(20)
                .HasColumnName("Gr_MobileNo");
            entity.Property(e => e.GrPass)
                .HasMaxLength(30)
                .HasColumnName("Gr_Pass");
            entity.Property(e => e.GrRelationship)
                .HasMaxLength(100)
                .HasColumnName("Gr_Relationship");
            entity.Property(e => e.GrTelNo)
                .HasMaxLength(20)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("Gr_TelNo");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => e.ResultId).HasName("PK__Result__5E08F5435289E0C5");

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

            entity.HasOne(d => d.ResultExamType).WithMany(p => p.Results)
                .HasForeignKey(d => d.ResultExamTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Result_ExamType");

            entity.HasOne(d => d.ResultStd).WithMany(p => p.Results)
                .HasForeignKey(d => d.ResultStdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Result_Student");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__D80AB49BC59B6D70");

            entity.ToTable("Role");

            entity.HasIndex(e => e.RoleName, "UQ__Role__035DB74974AAA7E6").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("Role_ID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("Role_Name");
        });

        modelBuilder.Entity<School>(entity =>
        {
            entity.HasKey(e => e.SchoolId).HasName("PK__School__DF2813428D7D7F37");

            entity.ToTable("School");

            entity.Property(e => e.SchoolId).HasColumnName("School_ID");
            entity.Property(e => e.SchoolAddress).HasMaxLength(200);
            entity.Property(e => e.SchoolEmail).HasMaxLength(45);
            entity.Property(e => e.SchoolName).HasMaxLength(150);
            entity.Property(e => e.SchoolPhoneNumber).HasMaxLength(45);

            entity.HasOne(d => d.SchoolAdminNavigation).WithMany(p => p.Schools)
                .HasForeignKey(d => d.SchoolAdmin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_School_Admin");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.SectionId).HasName("PK__Section__3B326FF777204CC5");

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
                .HasConstraintName("FK_Section_Class");

            entity.HasOne(d => d.SectionUnderObservationNavigation).WithMany(p => p.Sections)
                .HasForeignKey(d => d.SectionUnderObservation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Section_Teacher");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StdId).HasName("PK__Student__FE2B448E8829EA05");

            entity.ToTable("Student");

            entity.Property(e => e.StdId).HasColumnName("Std_Id");
            entity.Property(e => e.StdClassId).HasColumnName("Std_ClassID");
            entity.Property(e => e.StdDoa).HasColumnName("Std_DOA");
            entity.Property(e => e.StdDob).HasColumnName("Std_DOB");
            entity.Property(e => e.StdEmail)
                .HasMaxLength(30)
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
                .HasDefaultValue("Not Provided")
                .HasColumnName("Std_MobileNo");
            entity.Property(e => e.StdPass)
                .HasMaxLength(30)
                .HasColumnName("Std_Pass");
            entity.Property(e => e.StdSectionId).HasColumnName("Std_SectionID");
            entity.Property(e => e.StdStatus)
                .HasMaxLength(30)
                .HasColumnName("Std_Status");
            entity.Property(e => e.StdTelNo)
                .HasMaxLength(20)
                .HasDefaultValue("Not Provided")
                .HasColumnName("Std_TelNo");

            entity.HasOne(d => d.StdClass).WithMany(p => p.Students)
                .HasForeignKey(d => d.StdClassId)
                .HasConstraintName("FK_Student_Class");

            entity.HasOne(d => d.StdGuardian).WithMany(p => p.Students)
                .HasForeignKey(d => d.StdGuardianId)
                .HasConstraintName("FK_Student_Guardian");

            entity.HasOne(d => d.StdSection).WithMany(p => p.Students)
                .HasForeignKey(d => d.StdSectionId)
                .HasConstraintName("FK_Student_Section");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subjects__D98F54D6BBD30A1C");

            entity.HasIndex(e => e.SubjectName, "UQ__Subjects__4400317CEDBF1A41").IsUnique();

            entity.Property(e => e.SubjectId).HasColumnName("Subject_ID");
            entity.Property(e => e.SubjectClassId).HasColumnName("Subject_ClassID");
            entity.Property(e => e.SubjectDescription)
                .HasMaxLength(60)
                .HasDefaultValue("Not Provided")
                .HasColumnName("Subject_Description");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(50)
                .HasColumnName("Subject_Name");

            entity.HasOne(d => d.SubjectClass).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.SubjectClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subject_Class");
        });

        modelBuilder.Entity<SubjectTeach>(entity =>
        {
            entity.HasKey(e => e.IdSubjectTeaches).HasName("PK__SubjectT__DC2CE0A4A4BCCC4D");

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
                .HasConstraintName("FK_SubjectTeaches_Emp");

            entity.HasOne(d => d.SubjectTeachesClass).WithMany(p => p.SubjectTeaches)
                .HasForeignKey(d => d.SubjectTeachesClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubjectTeaches_Class");

            entity.HasOne(d => d.SubjectTeachesSubject).WithMany(p => p.SubjectTeaches)
                .HasForeignKey(d => d.SubjectTeachesSubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubjectTeaches_Sub");
        });

        modelBuilder.Entity<TimeTable>(entity =>
        {
            entity.HasKey(e => e.TtId).HasName("PK__TimeTabl__E9D60397A995F673");

            entity.ToTable("TimeTable");

            entity.Property(e => e.TtId).HasColumnName("TT_ID");
            entity.Property(e => e.TtDay)
                .HasMaxLength(10)
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
                .HasConstraintName("FK_TimeTable_Subject");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
