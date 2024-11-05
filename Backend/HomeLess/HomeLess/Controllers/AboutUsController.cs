using HomeLess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeLess.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly AppDBContaxt _context;

        public AboutUsController(AppDBContaxt context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            /*var testimonials = _context.Testimonials
                .Where(t => t.Rating >= 4) 
                .OrderByDescending(t => t.date)
                .ToList();*/
            var testimonials = _context.Testimonials.Include(t => t.User).ToList();
            return View(testimonials);
        }
    }
}
