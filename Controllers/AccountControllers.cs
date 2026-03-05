using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using School_Management_System.Models;
using School_Management_System.ViewModels;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace School_Management_System.Controllers
{
    public class AccountController : Controller
    {
        private readonly SchoolContext _context;

        public AccountController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                // 1. DÒ TÌM TRONG BẢNG ADMIN
                var admin = _context.Admins.FirstOrDefault(a =>
                    (a.AdminEmail == model.Username || a.AdminName == model.Username) &&
                    a.AdminPass == model.Password);

                if (admin != null)
                {
                    await SignInUser(admin.AdminName, admin.AdminEmail, "Admin", model.RememberMe);
                    return RedirectToLocal(returnUrl, "Home"); // Admin về Dashboard tổng
                }

                // 2. DÒ TÌM TRONG BẢNG EMPLOYEE (Giáo viên / Nhân viên)
                var employee = _context.Employees.FirstOrDefault(e =>
                    (e.EEmail == model.Username || e.EMobileNo == model.Username) &&
                    e.EPass == model.Password);

                if (employee != null)
                {
                    string role = "Employee";
                    string fullName = $"{employee.EFname} {employee.ELname}";
                    await SignInUser(fullName, employee.EEmail, role, model.RememberMe);

                    return RedirectToLocal(returnUrl, "EmployeePortal"); // Bẻ lái về nhà Nhân viên
                }

                // 3. DÒ TÌM TRONG BẢNG STUDENT (Học sinh)
                var student = _context.Students.FirstOrDefault(s =>
                    (s.StdEmail == model.Username || s.StdMobileNo == model.Username) &&
                    s.StdPass == model.Password);

                if (student != null)
                {
                    string fullName = $"{student.StdFname} {student.StdLname}";
                    await SignInUser(fullName, student.StdEmail, "Student", model.RememberMe);

                    return RedirectToLocal(returnUrl, "StudentPortal"); // Bẻ lái về nhà Học sinh
                }

                // Nếu dò cả 3 bảng đều không có
                ModelState.AddModelError(string.Empty, "Tài khoản hoặc mật khẩu không chính xác.");
            }
            return View(model);
        }
        // Hàm phụ trợ
        private async Task SignInUser(string name, string email, string role, bool rememberMe)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties { IsPersistent = rememberMe };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
        }

        private IActionResult RedirectToLocal(string? returnUrl, string defaultController)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", defaultController);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}