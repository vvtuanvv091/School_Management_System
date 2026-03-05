using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Admin_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Admin_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Admin_Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Admin_Pass = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Admin_ID);
                });

            migrationBuilder.CreateTable(
                name: "Classroom",
                columns: table => new
                {
                    Class_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class_Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, defaultValue: "NoDescription")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classroom", x => x.Class_ID);
                });

            migrationBuilder.CreateTable(
                name: "EventOnEmployee",
                columns: table => new
                {
                    E_ID = table.Column<int>(type: "int", nullable: true),
                    E_Fname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    E_Lname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    E_Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    E_Pass = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    E_DOB = table.Column<DateOnly>(type: "date", nullable: true),
                    E_TelNo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    E_MobileNo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    E_DOJ = table.Column<DateOnly>(type: "date", nullable: true),
                    E_Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    E_Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    E_RoleID = table.Column<int>(type: "int", nullable: true),
                    E_Salary = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    operation_perform = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    change_time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Exam_Type",
                columns: table => new
                {
                    Exam_TypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Exam_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, defaultValue: "Not Provided")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam_Type", x => x.Exam_TypeID);
                });

            migrationBuilder.CreateTable(
                name: "Guardian",
                columns: table => new
                {
                    Gr_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gr_Fname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Gr_Lname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Gr_Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Gr_Pass = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Gr_CNIC = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Gr_TelNo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Gr_MobileNo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Gr_Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gr_Relationship = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guardian", x => x.Gr_Id);
                });

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    Result_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Result_ExamTypeID = table.Column<int>(type: "int", nullable: false),
                    Result_TotalMarks = table.Column<decimal>(type: "decimal(10,0)", nullable: false),
                    Result_ObtainMarks = table.Column<decimal>(type: "decimal(10,0)", nullable: false),
                    Result_Grade = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Result_Percentage = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    Result_StdID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.Result_ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Role_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Role_ID);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Subject_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Subject_ClassID = table.Column<int>(type: "int", nullable: false),
                    Subject_Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, defaultValue: "Not Provided")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Subject_ID);
                    table.ForeignKey(
                        name: "FK_Subjects_Classroom",
                        column: x => x.Subject_ClassID,
                        principalTable: "Classroom",
                        principalColumn: "Class_ID");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    E_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_Fname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    E_Lname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    E_Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    E_Pass = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    E_DOB = table.Column<DateOnly>(type: "date", nullable: false),
                    E_TelNo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, defaultValue: "Not Provided"),
                    E_MobileNo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    E_DOJ = table.Column<DateOnly>(type: "date", nullable: false),
                    E_Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    E_Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    E_RoleID = table.Column<int>(type: "int", nullable: false),
                    E_Salary = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.E_ID);
                    table.ForeignKey(
                        name: "FK_Employee_Role",
                        column: x => x.E_RoleID,
                        principalTable: "Role",
                        principalColumn: "Role_ID");
                });

            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    Exam_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Exam_TypeID = table.Column<int>(type: "int", nullable: false),
                    Exam_ClassID = table.Column<int>(type: "int", nullable: false),
                    Exam_Start_DateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Exam_SubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.Exam_ID);
                    table.ForeignKey(
                        name: "FK_Exam_Classroom",
                        column: x => x.Exam_ClassID,
                        principalTable: "Classroom",
                        principalColumn: "Class_ID");
                    table.ForeignKey(
                        name: "FK_Exam_Subjects",
                        column: x => x.Exam_SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "Subject_ID");
                    table.ForeignKey(
                        name: "FK_Exam_Type",
                        column: x => x.Exam_TypeID,
                        principalTable: "Exam_Type",
                        principalColumn: "Exam_TypeID");
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    Section_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Section_ClassID = table.Column<int>(type: "int", nullable: false),
                    Section_UnderObservation = table.Column<int>(type: "int", nullable: false),
                    Section_Name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.Section_ID);
                    table.ForeignKey(
                        name: "FK_Section_Classroom",
                        column: x => x.Section_ClassID,
                        principalTable: "Classroom",
                        principalColumn: "Class_ID");
                    table.ForeignKey(
                        name: "FK_Section_Employee",
                        column: x => x.Section_UnderObservation,
                        principalTable: "Employee",
                        principalColumn: "E_ID");
                });

            migrationBuilder.CreateTable(
                name: "SubjectTeaches",
                columns: table => new
                {
                    idSubjectTeaches = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectTeachesBy = table.Column<int>(type: "int", nullable: false),
                    SubjectTeachesClassID = table.Column<int>(type: "int", nullable: false),
                    SubjectTeachesStartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SubjectTeachesEndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    SubjectTeachesDropStatus = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true, defaultValue: "Not Provided"),
                    SubjectTeachesOutCome = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true, defaultValue: "Not Provided"),
                    SubjectTeaches_SubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTeaches", x => x.idSubjectTeaches);
                    table.ForeignKey(
                        name: "FK_SubjectTeaches_Classroom",
                        column: x => x.SubjectTeachesClassID,
                        principalTable: "Classroom",
                        principalColumn: "Class_ID");
                    table.ForeignKey(
                        name: "FK_SubjectTeaches_Employee",
                        column: x => x.SubjectTeachesBy,
                        principalTable: "Employee",
                        principalColumn: "E_ID");
                    table.ForeignKey(
                        name: "FK_SubjectTeaches_Subject",
                        column: x => x.SubjectTeaches_SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "Subject_ID");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Std_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Std_Fname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Std_Lname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Std_Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Std_Pass = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Std_DOB = table.Column<DateOnly>(type: "date", nullable: false),
                    Std_TelNo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, defaultValue: "Not Provided"),
                    Std_MobileNo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, defaultValue: "Not Provided"),
                    Std_DOA = table.Column<DateOnly>(type: "date", nullable: false),
                    Std_Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Std_Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Std_ClassID = table.Column<int>(type: "int", nullable: true),
                    Std_SectionID = table.Column<int>(type: "int", nullable: true),
                    Std_GuardianID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Std_Id);
                    table.ForeignKey(
                        name: "FK_Student_Classroom",
                        column: x => x.Std_ClassID,
                        principalTable: "Classroom",
                        principalColumn: "Class_ID");
                    table.ForeignKey(
                        name: "FK_Student_Guardian",
                        column: x => x.Std_GuardianID,
                        principalTable: "Guardian",
                        principalColumn: "Gr_Id");
                    table.ForeignKey(
                        name: "FK_Student_Section",
                        column: x => x.Std_SectionID,
                        principalTable: "Section",
                        principalColumn: "Section_ID");
                });

            migrationBuilder.CreateTable(
                name: "TimeTable",
                columns: table => new
                {
                    TT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TT_SectionID = table.Column<int>(type: "int", nullable: false),
                    TT_Day = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    TT_StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    TT_Description = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    TT_SubjectID = table.Column<int>(type: "int", nullable: false),
                    TT_EndTime = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTable", x => x.TT_ID);
                    table.ForeignKey(
                        name: "FK_TimeTable_Section",
                        column: x => x.TT_SectionID,
                        principalTable: "Section",
                        principalColumn: "Section_ID");
                    table.ForeignKey(
                        name: "FK_TimeTable_Subjects",
                        column: x => x.TT_SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "Subject_ID");
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    A_StdID = table.Column<int>(type: "int", nullable: false),
                    A_Remarks = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "Not Provided"),
                    A_Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    A_Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Attendance_Student",
                        column: x => x.A_StdID,
                        principalTable: "Student",
                        principalColumn: "Std_Id");
                });

            migrationBuilder.CreateTable(
                name: "Exam_Result",
                columns: table => new
                {
                    ExamResult_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Exam_ID = table.Column<int>(type: "int", nullable: false),
                    Exam_StdID = table.Column<int>(type: "int", nullable: false),
                    Exam_TotalMarks = table.Column<decimal>(type: "decimal(10,0)", nullable: false),
                    Exam_Grade = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Exam_ObtainMarks = table.Column<decimal>(type: "decimal(10,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam_Result", x => x.ExamResult_ID);
                    table.ForeignKey(
                        name: "FK_ExamResult_Exam",
                        column: x => x.Exam_ID,
                        principalTable: "Exam",
                        principalColumn: "Exam_ID");
                    table.ForeignKey(
                        name: "FK_ExamResult_Student",
                        column: x => x.Exam_StdID,
                        principalTable: "Student",
                        principalColumn: "Std_Id");
                });

            migrationBuilder.CreateTable(
                name: "Fees",
                columns: table => new
                {
                    Fees_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fees_StdID = table.Column<int>(type: "int", nullable: false),
                    Fees_PreviousCharges = table.Column<decimal>(type: "decimal(10,0)", nullable: false),
                    Fees_IssueDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Fees_DueDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Fees_Discount = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Fees_DiscountReason = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    FeesStatus = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Fees_Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Fees_AdditionalCharges = table.Column<decimal>(type: "decimal(10,0)", nullable: true),
                    Fees_PaidDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fees", x => x.Fees_ID);
                    table.ForeignKey(
                        name: "FK_Fees_Student",
                        column: x => x.Fees_StdID,
                        principalTable: "Student",
                        principalColumn: "Std_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_StdID",
                table: "Attendance",
                column: "A_StdID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_E_RoleID",
                table: "Employee",
                column: "E_RoleID");

            migrationBuilder.CreateIndex(
                name: "UQ_Employee_Mobile",
                table: "Employee",
                column: "E_MobileNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exam_Exam_ClassID",
                table: "Exam",
                column: "Exam_ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_Exam_SubjectID",
                table: "Exam",
                column: "Exam_SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_Exam_TypeID",
                table: "Exam",
                column: "Exam_TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_Result_Exam_ID",
                table: "Exam_Result",
                column: "Exam_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_Result_Exam_StdID",
                table: "Exam_Result",
                column: "Exam_StdID");

            migrationBuilder.CreateIndex(
                name: "UQ_Exam_Type_Name",
                table: "Exam_Type",
                column: "Exam_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fees_Fees_StdID",
                table: "Fees",
                column: "Fees_StdID");

            migrationBuilder.CreateIndex(
                name: "UQ_Guardian_CNIC",
                table: "Guardian",
                column: "Gr_CNIC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Guardian_Email",
                table: "Guardian",
                column: "Gr_Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Guardian_Mobile",
                table: "Guardian",
                column: "Gr_MobileNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Role_Name",
                table: "Role",
                column: "Role_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Section_Section_ClassID",
                table: "Section",
                column: "Section_ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Section_Section_UnderObservation",
                table: "Section",
                column: "Section_UnderObservation");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Std_ClassID",
                table: "Student",
                column: "Std_ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Std_GuardianID",
                table: "Student",
                column: "Std_GuardianID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Std_SectionID",
                table: "Student",
                column: "Std_SectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_Subject_ClassID",
                table: "Subjects",
                column: "Subject_ClassID");

            migrationBuilder.CreateIndex(
                name: "UQ_Subject_Name",
                table: "Subjects",
                column: "Subject_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeaches_SubjectTeaches_SubjectID",
                table: "SubjectTeaches",
                column: "SubjectTeaches_SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeaches_SubjectTeachesBy",
                table: "SubjectTeaches",
                column: "SubjectTeachesBy");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeaches_SubjectTeachesClassID",
                table: "SubjectTeaches",
                column: "SubjectTeachesClassID");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTable_TT_SectionID",
                table: "TimeTable",
                column: "TT_SectionID");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTable_TT_SubjectID",
                table: "TimeTable",
                column: "TT_SubjectID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "EventOnEmployee");

            migrationBuilder.DropTable(
                name: "Exam_Result");

            migrationBuilder.DropTable(
                name: "Fees");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropTable(
                name: "SubjectTeaches");

            migrationBuilder.DropTable(
                name: "TimeTable");

            migrationBuilder.DropTable(
                name: "Exam");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Exam_Type");

            migrationBuilder.DropTable(
                name: "Guardian");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "Classroom");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
