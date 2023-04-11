using ElearnApp.Data;
using ElearnApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElearnApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Course> courses = await _context.Courses
                .Include(c=>c.CourseImages)
                .Include(c=>c.Author)
               .Where(s => !s.SoftDelete)
               .ToListAsync();
              

            return View(courses);
        }
        public async Task<IActionResult> Detail()
        {
          Course course = await _context.Courses
                .Include(c => c.CourseImages)
                .Include(c => c.Author)
               .Where(s => !s.SoftDelete)
               .FirstOrDefaultAsync();


            return View(course);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
