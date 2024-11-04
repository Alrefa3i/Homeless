using HomeLess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeLess.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly AppDBContaxt _context; // Replace with your actual DbContext

        public RegistrationController(IWebHostEnvironment hostingEnvironment, AppDBContaxt context)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }

        // GET: User
        public IActionResult Index()
        {
            return View();
        }

        // POST: User
        [HttpPost]
        public async Task<IActionResult> Index(string name, string email, string password, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                // Create a new User instance
                var user = new User
                {
                    Name = name,
                    Email = email,
                    Password = password,
                    Role = "User",
                    Image = $"/images/{fileName}"
                };

                _context.Users.Add(user); // Assuming Users is the DbSet for your User model
                await _context.SaveChangesAsync();
                return View("Index","Login");
            }

            return RedirectToAction(nameof(Index)); // Redirect to the Index action after successful registration
        }
    }
}
