/* ========================================================================
   DỰ ÁN: SCHOOL MANAGEMENT SYSTEM
   DATABASE: SQL SERVER (T-SQL)
   PHIÊN BẢN: FINAL COMPLETE (VIETNAMESE DATA)
========================================================================
*/

USE master;
GO

-- 1. TẠO DATABASE (Xóa cũ nếu có để làm mới)
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'SchoolManagementDB')
BEGIN
    ALTER DATABASE [SchoolManagementDB] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [SchoolManagementDB];
END
GO

CREATE DATABASE [SchoolManagementDB];
GO

USE [SchoolManagementDB];
GO

-- ========================================================
-- 2. TẠO BẢNG (TABLES)
-- ========================================================

-- Bảng Admin
CREATE TABLE [Admin] (
  [Admin_ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  [Admin_Name] NVARCHAR(50) NOT NULL,
  [Admin_Email] NVARCHAR(50) NOT NULL,
  [Admin_Pass] NVARCHAR(50) NOT NULL
);
GO

-- Bảng Role (Vai trò)
CREATE TABLE [Role] (
  [Role_ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  [Role_Name] NVARCHAR(50) NOT NULL UNIQUE
);
GO

-- Bảng School (Thông tin trường - Đã thêm PK)
CREATE TABLE [School] (
  [School_ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  [SchoolName] NVARCHAR(150) NOT NULL,
  [SchoolAddress] NVARCHAR(200) NOT NULL,
  [SchoolEmail] NVARCHAR(45) NOT NULL,
  [SchoolPhoneNumber] NVARCHAR(45) NOT NULL,
  [SchoolAdmin] INT NOT NULL,
  CONSTRAINT [FK_School_Admin] FOREIGN KEY ([SchoolAdmin]) REFERENCES [Admin] ([Admin_ID])
);
GO

-- Bảng ClassRoom (Đóng vai trò là KHỐI: 10, 11, 12)
CREATE TABLE [ClassRoom] (
  [Class_ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  [Class_Description] NVARCHAR(200) DEFAULT 'NoDescription' -- Lưu tên khối: "10", "11"
);
GO

-- Bảng Employee (Giáo viên & Nhân viên)
CREATE TABLE [Employee] (
  [E_ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  [E_Fname] NVARCHAR(30) NOT NULL,
  [E_Lname] NVARCHAR(30) NOT NULL,
  [E_Email] NVARCHAR(50) NOT NULL,
  [E_Pass] NVARCHAR(50) NOT NULL,
  [E_DOB] DATE NOT NULL,
  [E_TelNo] NVARCHAR(20) DEFAULT 'Not Provided',
  [E_MobileNo] NVARCHAR(20) NOT NULL UNIQUE,
  [E_DOJ] DATE NOT NULL,
  [E_Status] NVARCHAR(30) NOT NULL,
  [E_Gender] NVARCHAR(10) NOT NULL,
  [E_RoleID] INT NOT NULL,
  [E_Salary] DECIMAL(10,0) NOT NULL,
  CONSTRAINT [FK_Employee_Role] FOREIGN KEY ([E_RoleID]) REFERENCES [Role] ([Role_ID])
);
GO

-- Bảng Section (Đóng vai trò là LỚP CỤ THỂ: A1, B2...)
CREATE TABLE [Section] (
  [Section_ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  [Section_ClassID] INT NOT NULL,           -- Thuộc Khối nào
  [Section_UnderObservation] INT NOT NULL,  -- GVCN là ai
  [Section_Name] NVARCHAR(45) NOT NULL,     -- Tên lớp (A1, A2...)
  CONSTRAINT [FK_Section_Class] FOREIGN KEY ([Section_ClassID]) REFERENCES [ClassRoom] ([Class_ID]),
  CONSTRAINT [FK_Section_Teacher] FOREIGN KEY ([Section_UnderObservation]) REFERENCES [Employee] ([E_ID])
);
GO

-- Bảng Guardian (Phụ huynh)
CREATE TABLE [Guardian] (
  [Gr_Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  [Gr_Fname] NVARCHAR(30) NOT NULL,
  [Gr_Lname] NVARCHAR(30) NOT NULL,
  [Gr_Email] NVARCHAR(50) NOT NULL UNIQUE,
  [Gr_Pass] NVARCHAR(50) NOT NULL,
  [Gr_CNIC] NVARCHAR(20) NOT NULL UNIQUE, -- CMND/CCCD
  [Gr_TelNo] NVARCHAR(20) DEFAULT NULL,
  [Gr_MobileNo] NVARCHAR(20) NOT NULL UNIQUE,
  [Gr_Address] NVARCHAR(100) NOT NULL,
  [Gr_Relationship] NVARCHAR(100) NOT NULL
);
GO

-- Bảng Student (Học sinh)
CREATE TABLE [Student] (
  [Std_Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  [Std_Fname] NVARCHAR(30) NOT NULL,
  [Std_Lname] NVARCHAR(30) NOT NULL,
  [Std_Email] NVARCHAR(50) NOT NULL,
  [Std_Pass] NVARCHAR(50) NOT NULL,
  [Std_DOB] DATE NOT NULL,
  [Std_TelNo] NVARCHAR(20) DEFAULT 'Not Provided',
  [Std_MobileNo] NVARCHAR(20) DEFAULT 'Not Provided',
  [Std_DOA] DATE NOT NULL, -- Ngày nhập học
  [Std_Status] NVARCHAR(30) NOT NULL,
  [Std_Gender] NVARCHAR(10) NOT NULL,
  [Std_ClassID] INT NULL,
  [Std_SectionID] INT NULL,
  [Std_GuardianID] INT NULL,
  CONSTRAINT [FK_Student_Class] FOREIGN KEY ([Std_ClassID]) REFERENCES [ClassRoom] ([Class_ID]),
  CONSTRAINT [FK_Student_Section] FOREIGN KEY ([Std_SectionID]) REFERENCES [Section] ([Section_ID]),
  CONSTRAINT [FK_Student_Guardian] FOREIGN KEY ([Std_GuardianID]) REFERENCES [Guardian] ([Gr_Id])
);
GO

-- Bảng Attendance (Điểm danh)
CREATE TABLE [Attendance] (
  [A_StdID] INT NOT NULL,
  [A_Remarks] NVARCHAR(50) DEFAULT 'Not Provided',
  [A_Status] NVARCHAR(20) NOT NULL,
  [A_Date] DATETIME NOT NULL,
  CONSTRAINT [FK_Attendance_Student] FOREIGN KEY ([A_StdID]) REFERENCES [Student] ([Std_Id])
);
GO
CREATE INDEX [IX_Attendance_StdID] ON [Attendance]([A_StdID]);
GO

-- Bảng Subjects (Môn học)
CREATE TABLE [Subjects] (
  [Subject_ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  [Subject_Name] NVARCHAR(50) NOT NULL UNIQUE,
  [Subject_ClassID] INT NOT NULL,
  [Subject_Description] NVARCHAR(60) DEFAULT 'Not Provided',
  CONSTRAINT [FK_Subject_Class] FOREIGN KEY ([Subject_ClassID]) REFERENCES [ClassRoom] ([Class_ID])
);
GO

-- Bảng Exam_Type (Loại kỳ thi: 15p, 1 tiết...)
CREATE TABLE [Exam_Type] (
  [Exam_TypeID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  [Exam_Name] NVARCHAR(50) NOT NULL UNIQUE,
  [Description] NVARCHAR(100) DEFAULT 'Not Provided'
);
GO

-- Bảng Exam (Lịch thi)
CREATE TABLE [Exam] (
  [Exam_ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  [Exam_TypeID] INT NOT NULL,
  [Exam_ClassID] INT NOT NULL, -- Thi theo Khối
  [Exam_Start_DateTime] DATETIME NOT NULL,
  [Exam_SubjectID] INT NOT NULL,
  CONSTRAINT [FK_Exam_Type] FOREIGN KEY ([Exam_TypeID]) REFERENCES [Exam_Type] ([Exam_TypeID]),
  CONSTRAINT [FK_Exam_Class] FOREIGN KEY ([Exam_ClassID]) REFERENCES [ClassRoom] ([Class_ID]),
  CONSTRAINT [FK_Exam_Subject] FOREIGN KEY ([Exam_SubjectID]) REFERENCES [Subjects] ([Subject_ID])
);
GO

-- Bảng Exam_Result (Kết quả thi chi tiết)
CREATE TABLE [Exam_Result] (
  [ExamResult_ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  [Exam_ID] INT NOT NULL,
  [Exam_StdID] INT NOT NULL,
  [Exam_TotalMarks] DECIMAL(10,0) NOT NULL,
  [Exam_Grade] NVARCHAR(45) NOT NULL,
  [Exam_ObtainMarks] DECIMAL(10,0) NOT NULL,
  CONSTRAINT [FK_ExamResult_Exam] FOREIGN KEY ([Exam_ID]) REFERENCES [Exam] ([Exam_ID]),
  CONSTRAINT [FK_ExamResult_Student] FOREIGN KEY ([Exam_StdID]) REFERENCES [Student] ([Std_Id])
);
GO

-- Bảng Result (Kết quả tổng kết)
CREATE TABLE [Result] (
  [Result_ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  [Result_ExamTypeID] INT NOT NULL,
  [Result_TotalMarks] DECIMAL(10,0) NOT NULL,
  [Result_ObtainMarks] DECIMAL(10,0) NOT NULL,
  [Result_Grade] NVARCHAR(45) NOT NULL,
  [Result_Percentage] DECIMAL(10,3) NOT NULL,
  [Result_StdID] INT NOT NULL,
  CONSTRAINT [FK_Result_ExamType] FOREIGN KEY ([Result_ExamTypeID]) REFERENCES [Exam_Type] ([Exam_TypeID]),
  CONSTRAINT [FK_Result_Student] FOREIGN KEY ([Result_StdID]) REFERENCES [Student] ([Std_Id])
);
GO

-- Bảng Fees (Học phí)
CREATE TABLE [Fees] (
  [Fees_ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  [Fees_StdID] INT NOT NULL,
  [Fees_PreviousCharges] DECIMAL(10,0) NOT NULL,
  [Fees_IssueDateTime] DATETIME NOT NULL,
  [Fees_DueDateTime] DATETIME NOT NULL,
  [Fees_Discount] DECIMAL(10,2) NULL,
  [Fees_DiscountReason] NVARCHAR(70) NULL,
  [FeesStatus] NVARCHAR(45) NOT NULL,
  [Fees_Amount] DECIMAL(10,2) NOT NULL,
  [Fees_AdditionalCharges] DECIMAL(10,0) NULL,
  [Fees_PaidDate] DATE NULL,
  CONSTRAINT [FK_Fees_Student] FOREIGN KEY ([Fees_StdID]) REFERENCES [Student] ([Std_Id])
);
GO

-- Bảng TimeTable (Thời khóa biểu)
CREATE TABLE [TimeTable] (
  [TT_ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  [TT_SectionID] INT NOT NULL,
  [TT_Day] NVARCHAR(20) NOT NULL,
  [TT_StartTime] TIME NOT NULL,
  [TT_Description] NVARCHAR(60) NULL,
  [TT_SubjectID] INT NOT NULL,
  [TT_EndTime] TIME NOT NULL,
  CONSTRAINT [FK_TimeTable_Section] FOREIGN KEY ([TT_SectionID]) REFERENCES [Section] ([Section_ID]),
  CONSTRAINT [FK_TimeTable_Subject] FOREIGN KEY ([TT_SubjectID]) REFERENCES [Subjects] ([Subject_ID])
);
GO

-- Bảng SubjectTeaches (Phân công giảng dạy)
CREATE TABLE [SubjectTeaches] (
  [idSubjectTeaches] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  [SubjectTeachesBy] INT NOT NULL,
  [SubjectTeachesClassID] INT NOT NULL,
  [SubjectTeachesStartDate] DATE NOT NULL,
  [SubjectTeachesEndDate] DATE NULL,
  [SubjectTeachesDropStatus] NVARCHAR(45) DEFAULT 'Not Provided' NOT NULL,
  [SubjectTeachesOutCome] NVARCHAR(70) DEFAULT 'Not Provided' NOT NULL,
  [SubjectTeaches_SubjectID] INT NOT NULL,
  CONSTRAINT [FK_SubjectTeaches_Emp] FOREIGN KEY ([SubjectTeachesBy]) REFERENCES [Employee] ([E_ID]),
  CONSTRAINT [FK_SubjectTeaches_Class] FOREIGN KEY ([SubjectTeachesClassID]) REFERENCES [ClassRoom] ([Class_ID]),
  CONSTRAINT [FK_SubjectTeaches_Sub] FOREIGN KEY ([SubjectTeaches_SubjectID]) REFERENCES [Subjects] ([Subject_ID])
);
GO

-- Các bảng Log (Audit)
CREATE TABLE [eventonEmployee] (
  [E_ID] INT NULL, [E_Fname] NVARCHAR(30) NULL, [E_Lname] NVARCHAR(30) NULL, [E_Email] NVARCHAR(50) NULL,
  [E_Pass] NVARCHAR(50) NULL, [E_DOB] DATE NULL, [E_TelNo] NVARCHAR(20) NULL, [E_MobileNo] NVARCHAR(20) NULL,
  [E_DOJ] DATE NULL, [E_Status] NVARCHAR(30) NULL, [E_Gender] NVARCHAR(10) NULL, [E_RoleID] INT NULL,
  [E_Salary] DECIMAL(10,0) NULL, [operation_perform] NVARCHAR(45) NULL, [change_time] TIME NULL
);
GO
CREATE TABLE [eventonStudent] (
  [std_id] INT NULL, [std_fname] NVARCHAR(30) NULL, [std_lname] NVARCHAR(30) NULL, [std_email] NVARCHAR(50) NULL,
  [std_pass] NVARCHAR(50) NULL, [std_dob] DATE NULL, [std_Telno] NVARCHAR(20) NULL, [std_mobileno] NVARCHAR(20) NULL,
  [std_doa] DATE NULL, [std_status] NVARCHAR(30) NULL, [std_gender] NVARCHAR(10) NULL, [std_classid] INT NULL,
  [std_secid] INT NULL, [std_gid] INT NULL, [operation_perform] NVARCHAR(50) NULL, [change_time] TIME NULL
);
GO

-- ========================================================
-- 3. INSERT DỮ LIỆU MẪU (TIẾNG VIỆT)
-- ========================================================

-- Insert Admin
INSERT INTO [Admin] ([Admin_Name], [Admin_Email], [Admin_Pass]) VALUES ('Admin', 'admin@school.edu.vn', 'admin123');
GO

-- Insert Role
SET IDENTITY_INSERT [Role] ON;
INSERT INTO [Role] ([Role_ID], [Role_Name]) VALUES (1, N'Giáo viên'), (2, N'Kế toán'), (3, N'Tiếp tân');
SET IDENTITY_INSERT [Role] OFF;
GO

-- Insert Employee
SET IDENTITY_INSERT [Employee] ON;
INSERT INTO [Employee] ([E_ID], [E_Fname], [E_Lname], [E_Email], [E_Pass], [E_DOB], [E_TelNo], [E_MobileNo], [E_DOJ], [E_Status], [E_Gender], [E_RoleID], [E_Salary]) VALUES
(1, N'Thành', N'Nguyễn Văn', 'thanhnv@school.edu.vn', 'Pass123', '1990-05-15', '02838123456', '0909111222', '2020-09-05', N'Đang làm việc', N'Nam', 1, 15000000),
(2, N'Hương', N'Trần Thị', 'huongtt@school.edu.vn', 'Pass123', '1992-08-20', '02838123457', '0909333444', '2021-01-10', N'Đang làm việc', N'Nữ', 1, 14000000),
(3, N'Dũng', N'Lê Tuấn', 'dunglt@school.edu.vn', 'Pass123', '1988-12-01', '', '0912555666', '2019-09-05', N'Đang làm việc', N'Nam', 1, 16000000),
(4, N'Mai', N'Phạm Ngọc', 'maipn@school.edu.vn', 'Pass123', '1995-02-14', '', '0988777888', '2022-03-01', N'Đang làm việc', N'Nữ', 2, 12000000);
SET IDENTITY_INSERT [Employee] OFF;
GO

-- Insert ClassRoom (KHỐI)
SET IDENTITY_INSERT [ClassRoom] ON;
INSERT INTO [ClassRoom] ([Class_ID], [Class_Description]) VALUES (1, '10'), (2, '11'), (3, '12');
SET IDENTITY_INSERT [ClassRoom] OFF;
GO

-- Insert Section (LỚP CỤ THỂ)
SET IDENTITY_INSERT [Section] ON;
INSERT INTO [Section] ([Section_ID], [Section_ClassID], [Section_UnderObservation], [Section_Name]) VALUES
(1, 1, 1, N'A1'), -- 10A1 (Thầy Thành)
(2, 1, 2, N'A2'), -- 10A2 (Cô Hương)
(3, 2, 3, N'B1'), -- 11B1 (Thầy Dũng)
(4, 3, 1, N'C1'); -- 12C1 (Thầy Thành)
SET IDENTITY_INSERT [Section] OFF;
GO

-- Insert Guardian
SET IDENTITY_INSERT [Guardian] ON;
INSERT INTO [Guardian] ([Gr_Id], [Gr_Fname], [Gr_Lname], [Gr_Email], [Gr_Pass], [Gr_CNIC], [Gr_TelNo], [Gr_MobileNo], [Gr_Address], [Gr_Relationship]) VALUES
(1, N'Hùng', N'Phạm Văn', 'hungpv@gmail.com', '123456', '0790900001', '', '0913111222', N'123 Lê Lợi, Q1, TP.HCM', N'Bố'),
(2, N'Lan', N'Nguyễn Thị', 'lannth@gmail.com', '123456', '0790900002', '', '0913333444', N'456 Nguyễn Trãi, Q5, TP.HCM', N'Mẹ'),
(3, N'Tâm', N'Trần Thanh', 'tamtt@yahoo.com', '123456', '0790900003', '', '0903555666', N'789 Điện Biên Phủ, Bình Thạnh', N'Bố');
SET IDENTITY_INSERT [Guardian] OFF;
GO

-- Insert Student
SET IDENTITY_INSERT [Student] ON;
INSERT INTO [Student] ([Std_Id], [Std_Fname], [Std_Lname], [Std_Email], [Std_Pass], [Std_DOB], [Std_TelNo], [Std_MobileNo], [Std_DOA], [Std_Status], [Std_Gender], [Std_ClassID], [Std_SectionID], [Std_GuardianID]) VALUES
(1, N'Minh', N'Phạm Nhật', 'minhpn@student.school.edu', '123', '2008-05-10', '', '0368111222', '2023-09-05', N'Đang học', N'Nam', 1, 1, 1),
(2, N'Linh', N'Nguyễn Thùy', 'linhnt@student.school.edu', '123', '2008-08-20', '', '0368333444', '2023-09-05', N'Đang học', N'Nữ', 1, 1, 2),
(3, N'Khánh', N'Trần Nam', 'khanhtn@student.school.edu', '123', '2007-02-15', '', '0368555666', '2022-09-05', N'Đang học', N'Nam', 2, 3, 3);
SET IDENTITY_INSERT [Student] OFF;
GO

-- Insert Subjects
SET IDENTITY_INSERT [Subjects] ON;
INSERT INTO [Subjects] ([Subject_ID], [Subject_Name], [Subject_ClassID], [Subject_Description]) VALUES
(1, N'Toán Học', 1, N'Đại số và Hình học 10'),
(2, N'Ngữ Văn', 1, N'Văn học dân gian & Trung đại'),
(3, N'Tiếng Anh', 1, N'English Grade 10'),
(4, N'Vật Lý', 2, N'Cơ học & Nhiệt học 11');
SET IDENTITY_INSERT [Subjects] OFF;
GO

-- Insert Exam_Type (Danh mục chuẩn)
SET IDENTITY_INSERT [Exam_Type] ON;
INSERT INTO [Exam_Type] ([Exam_TypeID], [Exam_Name], [Description]) VALUES
(1, N'Kiểm tra miệng', N'Kiểm tra bài cũ đầu giờ (Hệ số 1)'),
(2, N'Kiểm tra 15 phút', N'Bài kiểm tra viết ngắn (Hệ số 1)'),
(3, N'Kiểm tra 1 tiết', N'Bài kiểm tra định kỳ 45 phút (Hệ số 2)'),
(4, N'Thi Giữa Kỳ', N'Đánh giá chất lượng giữa học kỳ (Hệ số 2)'),
(5, N'Thi Cuối Kỳ', N'Đánh giá tổng kết học kỳ (Hệ số 3)');
SET IDENTITY_INSERT [Exam_Type] OFF;
GO

-- Insert Exam (Lịch thi - Sử dụng ID Khối 1, 2, 3)
INSERT INTO [Exam] ([Exam_TypeID], [Exam_ClassID], [Exam_Start_DateTime], [Exam_SubjectID]) VALUES
(2, 1, '2023-09-15 08:00:00', 1), -- KT 15p Toán Khối 10
(3, 1, '2023-10-05 09:00:00', 1), -- KT 1 Tiết Toán Khối 10
(2, 2, '2023-09-10 07:00:00', 4), -- KT 15p Lý Khối 11
(5, 1, '2023-12-20 07:30:00', 1); -- Thi Cuối Kỳ Toán Khối 10
GO

-- Insert Attendance
INSERT INTO [Attendance] ([A_StdID], [A_Remarks], [A_Status], [A_Date]) VALUES
(1, N'', N'Present', GETDATE()),
(2, N'Bệnh', N'Absent', GETDATE());
GO

-- Insert School
INSERT INTO [School] ([SchoolName], [SchoolAddress], [SchoolEmail], [SchoolPhoneNumber], [SchoolAdmin]) VALUES
(N'Trường THPT Chuyên Nguyễn Du', N'100 Đường Hùng Vương, TP.HCM', N'contact@nguyendu.edu.vn', N'028-3999-8888', 1);
GO

-- ========================================================
-- 4. TẠO VIEWS (ĐÃ TỐI ƯU HIỂN THỊ)
-- ========================================================

-- View Class (Ghép 10 + A1 = 10A1)
GO
CREATE VIEW [viewclass] AS
SELECT 
    c.Class_ID,
    s.Section_ID,
    (c.Class_Description + s.Section_Name) AS ClassName, 
    c.Class_Description AS Grade,
    s.Section_Name AS ClassGroup,
    (e.E_Fname + ' ' + e.E_Lname) AS Teacher
FROM ClassRoom c
JOIN Section s ON s.Section_ClassID = c.Class_ID
JOIN Employee e ON e.E_ID = s.Section_UnderObservation;
GO

-- View Student (Thông tin đầy đủ)
CREATE VIEW [viewstudent] AS
SELECT 
    s.Std_Id, 
    (s.Std_Fname + ' ' + s.Std_Lname) AS StudentName,
    s.Std_Email,
    s.Std_DOB,
    s.Std_Gender,
    (c.Class_Description + sec.Section_Name) AS ClassName,
    (g.Gr_Fname + ' ' + g.Gr_Lname) AS GuardianName
FROM Student s
JOIN ClassRoom c ON s.Std_ClassID = c.Class_ID
JOIN Section sec ON s.Std_SectionID = sec.Section_ID
JOIN Guardian g ON s.Std_GuardianID = g.Gr_Id;
GO

-- View Attendance (Kèm tên học sinh)
CREATE VIEW [viewattendance] AS
SELECT 
    a.A_StdID,
    (s.Std_Fname + ' ' + s.Std_Lname) AS StudentName,
    a.A_Status,
    a.A_Remarks,
    a.A_Date
FROM Attendance a
JOIN Student s ON a.A_StdID = s.Std_Id;
GO

-- ========================================================
-- 5. TẠO STORED PROCEDURES (VÍ DỤ MẪU)
-- ========================================================

-- AddStudent Procedure
CREATE PROCEDURE [AddStudent] 
    @std_Fname NVARCHAR(30), 
    @std_Lname NVARCHAR(30), 
    @std_Email NVARCHAR(50), 
    @std_Pass NVARCHAR(50), 
    @std_DOB DATE, 
    @std_telno NVARCHAR(20), 
    @std_Mobno NVARCHAR(20), 
    @std_DOA DATE, 
    @std_Status NVARCHAR(30), 
    @std_gender NVARCHAR(10), 
    @std_cid INT, 
    @std_secid INT, 
    @std_guardianid INT
AS
BEGIN
    INSERT INTO Student (Std_Fname, Std_Lname, Std_Email, Std_Pass, Std_DOB, Std_TelNo, Std_MobileNo, Std_DOA, Std_Status, Std_Gender, Std_ClassID, Std_SectionID, Std_GuardianID) 
    VALUES(@std_Fname, @std_Lname, @std_Email, @std_Pass, @std_DOB, @std_telno, @std_Mobno, @std_DOA, @std_Status, @std_gender, @std_cid, @std_secid, @std_guardianid);
END;
GO

-- Trigger Update Student
CREATE TRIGGER [trg_student_update] ON [Student]
AFTER UPDATE
AS
BEGIN
    INSERT INTO [eventonStudent] (
        [std_id], [std_fname], [std_lname], [std_email], [std_pass], [std_dob],
        [std_Telno], [std_mobileno], [std_doa], [std_status], [std_gender],
        [std_classid], [std_secid], [std_gid], [operation_perform], [change_time]
    )
    SELECT
        d.[Std_Id], d.[Std_Fname], d.[Std_Lname], d.[Std_Email], d.[Std_Pass], d.[Std_DOB],
        d.[Std_TelNo], d.[Std_MobileNo], d.[Std_DOA], d.[Std_Status], d.[Std_Gender],
        d.[Std_ClassID], d.[Std_SectionID], d.[Std_GuardianID], 'Update', CAST(GETDATE() AS TIME)
    FROM deleted d;
END;
GO