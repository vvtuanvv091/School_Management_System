using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace School_Management_System.Controllers
{
    [Authorize(Roles = "Student")] // Chốt chặn: Chỉ Học sinh mới được vào
    public class StudentPortalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}