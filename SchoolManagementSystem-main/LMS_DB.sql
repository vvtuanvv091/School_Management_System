USE [master];
GO

-- 1. Tạo Database mới (Nếu chưa có)
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'LMS_DB')
BEGIN
    CREATE DATABASE [LMS_DB];
END
GO

USE [LMS_DB];
GO

-- =============================================
-- PHẦN 1: TẠO CÁC BẢNG (TABLES)
-- =============================================

-- Bảng Admin
CREATE TABLE [Admin] (
    [Admin_ID] INT IDENTITY(1,1) NOT NULL,
    [Admin_Name] NVARCHAR(50) NOT NULL,
    [Admin_Email] VARCHAR(50) NOT NULL,
    [Admin_Pass] VARCHAR(100) NOT NULL, -- Nên lưu Hash, không lưu Plain text
    CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED ([Admin_ID] ASC)
);
GO

-- Bảng Role (Vai trò)
CREATE TABLE [Role] (
    [Role_ID] INT IDENTITY(1,1) NOT NULL,
    [Role_Name] NVARCHAR(50) NOT NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([Role_ID] ASC),
    CONSTRAINT [UQ_Role_Name] UNIQUE ([Role_Name])
);
GO

-- Bảng Employee (Nhân viên/Giáo viên)
CREATE TABLE [Employee] (
    [E_ID] INT IDENTITY(1,1) NOT NULL,
    [E_Fname] NVARCHAR(30) NOT NULL,
    [E_Lname] NVARCHAR(30) NOT NULL,
    [E_Email] VARCHAR(50) NOT NULL,
    [E_Pass] VARCHAR(100) NOT NULL,
    [E_DOB] DATE NOT NULL,
    [E_TelNo] VARCHAR(20) DEFAULT 'Not Provided',
    [E_MobileNo] VARCHAR(20) NOT NULL,
    [E_DOJ] DATE NOT NULL, -- Date of Joining
    [E_Status] NVARCHAR(30) NOT NULL,
    [E_Gender] NVARCHAR(10) NOT NULL,
    [E_RoleID] INT NOT NULL,
    [E_Salary] DECIMAL(18, 0) NOT NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([E_ID] ASC),
    CONSTRAINT [UQ_Employee_Mobile] UNIQUE ([E_MobileNo])
);
GO

-- Bảng Guardian (Phụ huynh)
CREATE TABLE [Guardian] (
    [Gr_Id] INT IDENTITY(1,1) NOT NULL,
    [Gr_Fname] NVARCHAR(30) NOT NULL,
    [Gr_Lname] NVARCHAR(30) NOT NULL,
    [Gr_Email] VARCHAR(50) NOT NULL,
    [Gr_Pass] VARCHAR(100) NOT NULL,
    [Gr_CNIC] VARCHAR(20) NOT NULL, -- CMND/CCCD
    [Gr_TelNo] VARCHAR(20) NULL,
    [Gr_MobileNo] VARCHAR(20) NOT NULL,
    [Gr_Address] NVARCHAR(100) NOT NULL,
    [Gr_Relationship] NVARCHAR(100) NOT NULL,
    CONSTRAINT [PK_Guardian] PRIMARY KEY CLUSTERED ([Gr_Id] ASC),
    CONSTRAINT [UQ_Guardian_Email] UNIQUE ([Gr_Email]),
    CONSTRAINT [UQ_Guardian_CNIC] UNIQUE ([Gr_CNIC]),
    CONSTRAINT [UQ_Guardian_Mobile] UNIQUE ([Gr_MobileNo])
);
GO

-- Bảng ClassRoom (Lớp học)
CREATE TABLE [Classroom] (
    [Class_ID] INT IDENTITY(1,1) NOT NULL,
    [Class_Description] NVARCHAR(200) DEFAULT N'NoDescription',
    CONSTRAINT [PK_Classroom] PRIMARY KEY CLUSTERED ([Class_ID] ASC)
);
GO

-- Bảng Section (Học phần/Nhóm lớp)
CREATE TABLE [Section] (
    [Section_ID] INT IDENTITY(1,1) NOT NULL,
    [Section_ClassID] INT NOT NULL,
    [Section_UnderObservation] INT NOT NULL, -- Giáo viên chủ nhiệm (FK Employee)
    [Section_Name] NVARCHAR(45) NOT NULL,
    CONSTRAINT [PK_Section] PRIMARY KEY CLUSTERED ([Section_ID] ASC)
);
GO

-- Bảng Student (Học sinh)
CREATE TABLE [Student] (
    [Std_Id] INT IDENTITY(1,1) NOT NULL,
    [Std_Fname] NVARCHAR(30) NOT NULL,
    [Std_Lname] NVARCHAR(30) NOT NULL,
    [Std_Email] VARCHAR(50) NOT NULL,
    [Std_Pass] VARCHAR(100) NOT NULL,
    [Std_DOB] DATE NOT NULL,
    [Std_TelNo] VARCHAR(20) DEFAULT 'Not Provided',
    [Std_MobileNo] VARCHAR(20) DEFAULT 'Not Provided',
    [Std_DOA] DATE NOT NULL, -- Date of Admission
    [Std_Status] NVARCHAR(30) NOT NULL,
    [Std_Gender] NVARCHAR(10) NOT NULL,
    [Std_ClassID] INT NULL,
    [Std_SectionID] INT NULL,
    [Std_GuardianID] INT NULL,
    CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED ([Std_Id] ASC)
);
GO

-- Bảng Attendance (Điểm danh)
CREATE TABLE [Attendance] (
    [A_StdID] INT NOT NULL,
    [A_Remarks] NVARCHAR(50) DEFAULT N'Not Provided',
    [A_Status] NVARCHAR(20) NOT NULL,
    [A_Date] DATETIME NOT NULL
    -- Lưu ý: Bảng này trong MySQL không có Primary Key riêng, nên xem xét thêm ID tự tăng hoặc dùng Composite Key
);
GO
-- Tạo Index cho Attendance để query nhanh hơn
CREATE NONCLUSTERED INDEX [IX_Attendance_StdID] ON [Attendance]([A_StdID]);
GO

-- Bảng Subjects (Môn học)
CREATE TABLE [Subjects] (
    [Subject_ID] INT IDENTITY(1,1) NOT NULL,
    [Subject_Name] NVARCHAR(50) NOT NULL,
    [Subject_ClassID] INT NOT NULL,
    [Subject_Description] NVARCHAR(100) DEFAULT N'Not Provided',
    CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED ([Subject_ID] ASC),
    CONSTRAINT [UQ_Subject_Name] UNIQUE ([Subject_Name])
);
GO

-- Bảng SubjectTeaches (Phân công giảng dạy)
CREATE TABLE [SubjectTeaches] (
    [idSubjectTeaches] INT IDENTITY(1,1) NOT NULL,
    [SubjectTeachesBy] INT NOT NULL, -- FK Employee
    [SubjectTeachesClassID] INT NOT NULL, -- FK Classroom
    [SubjectTeachesStartDate] DATE NOT NULL,
    [SubjectTeachesEndDate] DATE NULL,
    [SubjectTeachesDropStatus] NVARCHAR(45) DEFAULT N'Not Provided',
    [SubjectTeachesOutCome] NVARCHAR(70) DEFAULT N'Not Provided',
    [SubjectTeaches_SubjectID] INT NOT NULL, -- FK Subject
    CONSTRAINT [PK_SubjectTeaches] PRIMARY KEY CLUSTERED ([idSubjectTeaches] ASC)
);
GO

-- Bảng Exam_Type (Loại kỳ thi: Quiz, Midterm...)
CREATE TABLE [Exam_Type] (
    [Exam_TypeID] INT IDENTITY(1,1) NOT NULL,
    [Exam_Name] NVARCHAR(50) NOT NULL,
    [Description] NVARCHAR(100) DEFAULT N'Not Provided',
    CONSTRAINT [PK_Exam_Type] PRIMARY KEY CLUSTERED ([Exam_TypeID] ASC),
    CONSTRAINT [UQ_Exam_Type_Name] UNIQUE ([Exam_Name])
);
GO

-- Bảng Exam (Kỳ thi cụ thể)
CREATE TABLE [Exam] (
    [Exam_ID] INT IDENTITY(1,1) NOT NULL,
    [Exam_TypeID] INT NOT NULL,
    [Exam_ClassID] INT NOT NULL,
    [Exam_Start_DateTime] DATETIME NOT NULL,
    [Exam_SubjectID] INT NOT NULL,
    CONSTRAINT [PK_Exam] PRIMARY KEY CLUSTERED ([Exam_ID] ASC)
);
GO

-- Bảng Exam_Result (Kết quả thi - Bảng này có vẻ dư thừa so với bảng Result bên dưới, nhưng tôi vẫn giữ theo thiết kế gốc)
CREATE TABLE [Exam_Result] (
    [ExamResult_ID] INT IDENTITY(1,1) NOT NULL,
    [Exam_ID] INT NOT NULL,
    [Exam_StdID] INT NOT NULL,
    [Exam_TotalMarks] DECIMAL(10, 0) NOT NULL,
    [Exam_Grade] NVARCHAR(10) NOT NULL,
    [Exam_ObtainMarks] DECIMAL(10, 0) NOT NULL,
    CONSTRAINT [PK_Exam_Result] PRIMARY KEY CLUSTERED ([ExamResult_ID] ASC)
);
GO

-- Bảng Result (Bảng kết quả tổng hợp)
CREATE TABLE [Result] (
    [Result_ID] INT IDENTITY(1,1) NOT NULL,
    [Result_ExamTypeID] INT NOT NULL,
    [Result_TotalMarks] DECIMAL(10, 0) NOT NULL,
    [Result_ObtainMarks] DECIMAL(10, 0) NOT NULL,
    [Result_Grade] NVARCHAR(45) NOT NULL,
    [Result_Percentage] DECIMAL(10, 3) NOT NULL,
    [Result_StdID] INT NOT NULL,
    CONSTRAINT [PK_Result] PRIMARY KEY CLUSTERED ([Result_ID] ASC)
);
GO

-- Bảng Fees (Học phí)
CREATE TABLE [Fees] (
    [Fees_ID] INT IDENTITY(1,1) NOT NULL,
    [Fees_StdID] INT NOT NULL,
    [Fees_PreviousCharges] DECIMAL(10, 0) NOT NULL,
    [Fees_IssueDateTime] DATETIME NOT NULL,
    [Fees_DueDateTime] DATETIME NOT NULL,
    [Fees_Discount] DECIMAL(10, 2) NULL,
    [Fees_DiscountReason] NVARCHAR(70) NULL,
    [FeesStatus] NVARCHAR(45) NOT NULL,
    [Fees_Amount] DECIMAL(10, 2) NOT NULL,
    [Fees_AdditionalCharges] DECIMAL(10, 0) NULL,
    [Fees_PaidDate] DATE NULL,
    CONSTRAINT [PK_Fees] PRIMARY KEY CLUSTERED ([Fees_ID] ASC)
);
GO

-- Bảng TimeTable (Thời khóa biểu)
CREATE TABLE [TimeTable] (
    [TT_ID] INT IDENTITY(1,1) NOT NULL,
    [TT_SectionID] INT NOT NULL,
    [TT_Day] NVARCHAR(15) NOT NULL, -- Monday, Tuesday...
    [TT_StartTime] TIME(7) NOT NULL,
    [TT_Description] NVARCHAR(60) NULL,
    [TT_SubjectID] INT NOT NULL,
    [TT_EndTime] TIME(7) NOT NULL,
    CONSTRAINT [PK_TimeTable] PRIMARY KEY CLUSTERED ([TT_ID] ASC)
);
GO

-- =============================================
-- PHẦN 2: TẠO CÁC BẢNG LOG (AUDIT TABLES)
-- (Giữ nguyên cấu trúc để lưu lịch sử thay đổi)
-- =============================================

CREATE TABLE [EventOnEmployee] (
    [E_ID] INT NULL,
    [E_Fname] NVARCHAR(30) NULL,
    [E_Lname] NVARCHAR(30) NULL,
    [E_Email] VARCHAR(50) NULL,
    [E_Pass] VARCHAR(100) NULL,
    [E_DOB] DATE NULL,
    [E_TelNo] VARCHAR(20) NULL,
    [E_MobileNo] VARCHAR(20) NULL,
    [E_DOJ] DATE NULL,
    [E_Status] NVARCHAR(30) NULL,
    [E_Gender] NVARCHAR(10) NULL,
    [E_RoleID] INT NULL,
    [E_Salary] DECIMAL(18, 0) NULL,
    [operation_perform] NVARCHAR(50) NULL,
    [change_time] DATETIME DEFAULT GETDATE()
);
GO

-- (Bạn có thể thêm các bảng EventOnGuardian, EventOnStudent tương tự nếu cần)

-- =============================================
-- PHẦN 3: TẠO KHÓA NGOẠI (FOREIGN KEYS)
-- =============================================

-- Employee -> Role
ALTER TABLE [Employee] ADD CONSTRAINT [FK_Employee_Role] 
FOREIGN KEY ([E_RoleID]) REFERENCES [Role] ([Role_ID]);

-- Section -> Classroom
ALTER TABLE [Section] ADD CONSTRAINT [FK_Section_Classroom] 
FOREIGN KEY ([Section_ClassID]) REFERENCES [Classroom] ([Class_ID]);

-- Section -> Employee (Giáo viên chủ nhiệm)
ALTER TABLE [Section] ADD CONSTRAINT [FK_Section_Employee] 
FOREIGN KEY ([Section_UnderObservation]) REFERENCES [Employee] ([E_ID]);

-- Student -> Classroom
ALTER TABLE [Student] ADD CONSTRAINT [FK_Student_Classroom] 
FOREIGN KEY ([Std_ClassID]) REFERENCES [Classroom] ([Class_ID]);

-- Student -> Section
ALTER TABLE [Student] ADD CONSTRAINT [FK_Student_Section] 
FOREIGN KEY ([Std_SectionID]) REFERENCES [Section] ([Section_ID]);

-- Student -> Guardian
ALTER TABLE [Student] ADD CONSTRAINT [FK_Student_Guardian] 
FOREIGN KEY ([Std_GuardianID]) REFERENCES [Guardian] ([Gr_Id]);

-- Attendance -> Student
ALTER TABLE [Attendance] ADD CONSTRAINT [FK_Attendance_Student] 
FOREIGN KEY ([A_StdID]) REFERENCES [Student] ([Std_Id]);

-- Subjects -> Classroom
ALTER TABLE [Subjects] ADD CONSTRAINT [FK_Subjects_Classroom] 
FOREIGN KEY ([Subject_ClassID]) REFERENCES [Classroom] ([Class_ID]);

-- SubjectTeaches -> Employee
ALTER TABLE [SubjectTeaches] ADD CONSTRAINT [FK_SubjectTeaches_Employee] 
FOREIGN KEY ([SubjectTeachesBy]) REFERENCES [Employee] ([E_ID]);

-- SubjectTeaches -> Classroom
ALTER TABLE [SubjectTeaches] ADD CONSTRAINT [FK_SubjectTeaches_Classroom] 
FOREIGN KEY ([SubjectTeachesClassID]) REFERENCES [Classroom] ([Class_ID]);

-- SubjectTeaches -> Subjects
ALTER TABLE [SubjectTeaches] ADD CONSTRAINT [FK_SubjectTeaches_Subject] 
FOREIGN KEY ([SubjectTeaches_SubjectID]) REFERENCES [Subjects] ([Subject_ID]);

-- Exam -> Exam_Type
ALTER TABLE [Exam] ADD CONSTRAINT [FK_Exam_Type] 
FOREIGN KEY ([Exam_TypeID]) REFERENCES [Exam_Type] ([Exam_TypeID]);

-- Exam -> Classroom
ALTER TABLE [Exam] ADD CONSTRAINT [FK_Exam_Classroom] 
FOREIGN KEY ([Exam_ClassID]) REFERENCES [Classroom] ([Class_ID]);

-- Exam -> Subjects
ALTER TABLE [Exam] ADD CONSTRAINT [FK_Exam_Subjects] 
FOREIGN KEY ([Exam_SubjectID]) REFERENCES [Subjects] ([Subject_ID]);

-- Exam_Result -> Exam
ALTER TABLE [Exam_Result] ADD CONSTRAINT [FK_ExamResult_Exam] 
FOREIGN KEY ([Exam_ID]) REFERENCES [Exam] ([Exam_ID]);

-- Exam_Result -> Student
ALTER TABLE [Exam_Result] ADD CONSTRAINT [FK_ExamResult_Student] 
FOREIGN KEY ([Exam_StdID]) REFERENCES [Student] ([Std_Id]);

-- Fees -> Student
ALTER TABLE [Fees] ADD CONSTRAINT [FK_Fees_Student] 
FOREIGN KEY ([Fees_StdID]) REFERENCES [Student] ([Std_Id]);

-- TimeTable -> Section
ALTER TABLE [TimeTable] ADD CONSTRAINT [FK_TimeTable_Section] 
FOREIGN KEY ([TT_SectionID]) REFERENCES [Section] ([Section_ID]);

-- TimeTable -> Subjects
ALTER TABLE [TimeTable] ADD CONSTRAINT [FK_TimeTable_Subjects] 
FOREIGN KEY ([TT_SubjectID]) REFERENCES [Subjects] ([Subject_ID]);
GO

-- =============================================
-- PHẦN 4: VÍ DỤ TRIGGER AUDIT (CHUYỂN TỪ MYSQL)
-- =============================================

-- Trigger log lại lịch sử thay đổi thông tin nhân viên
CREATE TRIGGER [trg_Employee_Audit_Update]
ON [Employee]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO [EventOnEmployee] (
        [E_ID], [E_Fname], [E_Lname], [E_Email], [E_Pass], 
        [E_DOB], [E_TelNo], [E_MobileNo], [E_DOJ], 
        [E_Status], [E_Gender], [E_RoleID], [E_Salary], 
        [operation_perform], [change_time]
    )
    SELECT 
        d.[E_ID], d.[E_Fname], d.[E_Lname], d.[E_Email], d.[E_Pass],
        d.[E_DOB], d.[E_TelNo], d.[E_MobileNo], d.[E_DOJ],
        d.[E_Status], d.[E_Gender], d.[E_RoleID], d.[E_Salary],
        'UPDATE', GETDATE()
    FROM deleted d; -- Bảng 'deleted' chứa dữ liệu cũ trước khi update
END
GO