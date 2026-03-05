using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School_Management_System.Models;
using Microsoft.AspNetCore.Authorization;

namespace School_Management_System.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StudentsController : Controller
    {
        private readonly SchoolContext _context;

        public StudentsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.Students.Include(s => s.StdClass).Include(s => s.StdGuardian).Include(s => s.StdSection);
            return View(await schoolContext.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.StdClass)
                .Include(s => s.StdGuardian)
                .Include(s => s.StdSection)
                .FirstOrDefaultAsync(m => m.StdId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            // Lưu ý: SelectList tham số thứ 2 là tên trường KHÓA, tham số 3 là tên trường HIỂN THỊ

            // Dropdown Khối (ClassRoom): Id là ClassId, Tên là ClassDescription
            ViewData["StdClassId"] = new SelectList(_context.ClassRooms, "ClassId", "ClassDescription");

            // Dropdown Lớp (Section): Id là SectionId, Tên là SectionName
            ViewData["StdSectionId"] = new SelectList(_context.Sections, "SectionId", "SectionName");

            // Dropdown Phụ huynh (Guardian): Id là GrId, Tên là GrFname
            ViewData["StdGuardianId"] = new SelectList(_context.Guardians, "GrId", "GrFname");

            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StdId,StdFname,StdLname,StdEmail,StdPass,StdDob,StdTelNo,StdMobileNo,StdDoa,StdStatus,StdGender,StdClassId,StdSectionId,StdGuardianId")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StdClassId"] = new SelectList(_context.ClassRooms, "ClassId", "ClassId", student.StdClassId);
            ViewData["StdGuardianId"] = new SelectList(_context.Guardians, "GrId", "GrId", student.StdGuardianId);
            ViewData["StdSectionId"] = new SelectList(_context.Sections, "SectionId", "SectionId", student.StdSectionId);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            // 1. Khối lớp: Chọn hiển thị cột 'ClassDescription' (Ví dụ: 10, 11)
            // Tham số: (Nguồn dữ liệu, Cột giá trị lấy, Cột tên hiển thị, Giá trị đang chọn)
            ViewData["StdClassId"] = new SelectList(_context.ClassRooms, "ClassId", "ClassDescription", student.StdClassId);

            // 2. Lớp chi tiết: Chọn hiển thị cột 'SectionName' (Ví dụ: A1, C2)
            ViewData["StdSectionId"] = new SelectList(_context.Sections, "SectionId", "SectionName", student.StdSectionId);

            // 3. Phụ huynh: Ghép Họ + Tên để hiển thị cho đẹp
            // Chúng ta tạo một danh sách tạm thời (Select) để ghép chuỗi
            var listPhuHuynh = _context.Guardians.Select(g => new {
                GrId = g.GrId,
                FullName = g.GrLname + " " + g.GrFname + " (SĐT: " + g.GrMobileNo + ")" // Hiện cả tên và SĐT
            }).ToList();

            ViewData["StdGuardianId"] = new SelectList(listPhuHuynh, "GrId", "FullName", student.StdGuardianId);

            // --- KẾT THÚC SỬA ---
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StdId,StdFname,StdLname,StdEmail,StdPass,StdDob,StdTelNo,StdMobileNo,StdDoa,StdStatus,StdGender,StdClassId,StdSectionId,StdGuardianId")] Student student)
        {
            if (id != student.StdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StdId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StdClassId"] = new SelectList(_context.ClassRooms, "ClassId", "ClassId", student.StdClassId);
            ViewData["StdGuardianId"] = new SelectList(_context.Guardians, "GrId", "GrId", student.StdGuardianId);
            ViewData["StdSectionId"] = new SelectList(_context.Sections, "SectionId", "SectionId", student.StdSectionId);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.StdClass)
                .Include(s => s.StdGuardian)
                .Include(s => s.StdSection)
                .FirstOrDefaultAsync(m => m.StdId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StdId == id);
        }
    }
}
