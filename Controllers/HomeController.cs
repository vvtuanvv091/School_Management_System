using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School_Management_System.Models;
using School_Management_System.ViewModels; // Chứa DashboardViewModel vừa tạo
using System.Diagnostics;
using System.Linq;

namespace School_Management_System.Controllers
{
    [Authorize]
    public class HomeController : Controller

    {

        private readonly ILogger<HomeController> _logger;
        private readonly SchoolContext _context; // Khai báo Context
        public HomeController(ILogger<HomeController> logger, SchoolContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var dashboardData = new DashboardViewModel
            {
                // Các con số thống kê tổng (Giữ nguyên logic cũ của bạn)
                StudentCount = _context.Students.Count(),
                TeacherCount = _context.Employees.Count(e => e.ERoleId == 1),
                ClassCount = _context.ClassRooms.Count(),
                UserCount = _context.Admins.Count(),

                // Lấy dữ liệu cho biểu đồ: Chọn 5 lớp đầu tiên
                // Sử dụng ClassDescription làm tên nhãn (Label)
                ChartLabels = _context.ClassRooms
                                       .Where(c => c.ClassDescription != null) // Tránh lỗi nếu tên lớp bị null
                                       .Select(c => c.ClassDescription)
                                       .Take(5).ToList(),

                // Đếm số lượng học sinh trong từng lớp đó thông qua navigation property 'Students'
                ChartData = _context.ClassRooms
                                     .Select(c => c.Students.Count())
                                     .Take(5).ToList()
            };

            return View(dashboardData);
        }
    


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
