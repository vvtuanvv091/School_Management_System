using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using School_Management_System.Models;

namespace School_Management_System.Controllers
{
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
            // Lấy số liệu thống kê thực tế từ Database
            // Nếu chưa có dữ liệu, nó sẽ trả về 0
            ViewBag.StudentCount = _context.Students.Count();
            ViewBag.TeacherCount = _context.Employees.Where(e => e.ERoleId == 1).Count();
            ViewBag.ClassCount = _context.ClassRooms.Count();
            ViewBag.UserCount = _context.Admins.Count(); // Hoặc đếm User khác

            return View();
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
