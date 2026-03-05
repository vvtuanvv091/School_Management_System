using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace School_Management_System.Controllers
{
    [Authorize(Roles = "Employee")] // Chốt chặn: Chỉ Nhân viên mới được vào
    public class EmployeePortalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}