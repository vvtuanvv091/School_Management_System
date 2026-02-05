# 🏫 School Management System (Hệ thống Quản lý Trường học)

![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-8.0-purple)
![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-red)
![Entity Framework](https://img.shields.io/badge/ORM-EF%20Core-blue)
![UI](https://img.shields.io/badge/UI-AdminLTE%203-green)

Một hệ thống quản lý trường học toàn diện được xây dựng trên nền tảng **ASP.NET Core 8.0** theo mô hình MVC, sử dụng **SQL Server** và giao diện quản trị chuyên nghiệp **AdminLTE 3**.

## 🌟 Tính năng chính (Features)

Hiện tại, dự án đang trong giai đoạn phát triển Module Admin với các chức năng:

* **📊 Dashboard (Bảng điều khiển):** Thống kê tổng quan số lượng học sinh, giáo viên, lớp học và tài khoản hệ thống.
* **👨‍🎓 Quản lý Học sinh:**
    * Xem danh sách học sinh với **DataTables** (Tìm kiếm, Sắp xếp, Phân trang, Xuất Excel/PDF).
    * Thêm mới hồ sơ học sinh (Form chia cột, Validation chặt chẽ).
    * Cập nhật thông tin và xếp lớp.
* **🏫 Cấu trúc Lớp học logic:** Phân chia theo Khối (Grade) và Lớp chi tiết (Section) để dễ dàng quản lý.

*(Các tính năng đang phát triển: Phân quyền, Module Giáo viên, Nhập điểm, Điểm danh...)*

## 🛠️ Công nghệ sử dụng (Tech Stack)

* **Backend:** C#, ASP.NET Core 8.0 MVC.
* **Database:** SQL Server (T-SQL), Entity Framework Core (Database First).
* **Frontend:** HTML5, CSS3, JavaScript, jQuery.
* **Theme:** AdminLTE 3 (Bootstrap 4).
* **Tools:** Visual Studio 2022, SSMS.

## 🚀 Hướng dẫn Cài đặt (Installation)

Để chạy dự án này trên máy cục bộ, vui lòng làm theo các bước sau:

### 1. Yêu cầu hệ thống
* .NET SDK 8.0 trở lên.
* SQL Server (2014 trở lên).
* Visual Studio 2022 (khuyên dùng).

### 2. Thiết lập Cơ sở dữ liệu
1.  Mở **SQL Server Management Studio (SSMS)**.
2.  Mở file script `Database/SchoolManagementDB_Full_Script.sql` (bạn hãy lưu file query SQL hoàn chỉnh vào thư mục Database trong dự án).
3.  Chạy toàn bộ script để tạo Database `SchoolManagementDB` và dữ liệu mẫu (Tiếng Việt).

### 3. Cấu hình kết nối
Mở file `appsettings.json` và cập nhật chuỗi kết nối phù hợp với máy của bạn:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=SchoolManagementDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
### 4. Chạy ứng dụng
Mở dự án bằng Visual Studio, nhấn F5 hoặc dùng lệnh:

Bash
dotnet run
Truy cập: https://localhost:7000/ (Port có thể thay đổi tùy cấu hình máy bạn).

📂 Cấu trúc Dự án
Plaintext
School_Management_System/
├── Controllers/       # Xử lý logic (HomeController, StudentsController...)
├── Models/            # Entity Framework Classes (Student.cs, SchoolContext.cs...)
├── Views/             # Giao diện người dùng (.cshtml)
│   ├── Shared/        # LayoutAdmin, Navbar, Sidebar
│   ├── Students/      # Các view CRUD Học sinh
├── wwwroot/           # File tĩnh
│   ├── Themes/        # AdminLTE (dist, plugins)
└── Program.cs         # Cấu hình Dependency Injection & Pipeline
📸 Hình ảnh Demo

🤝 Đóng góp
Dự án này được xây dựng cho mục đích học tập và phát triển kỹ năng lập trình ASP.NET Core. Mọi đóng góp (Pull Request) hoặc báo lỗi (Issues) đều được hoan nghênh.

📄 License
Dự án này thuộc bản quyền của .
