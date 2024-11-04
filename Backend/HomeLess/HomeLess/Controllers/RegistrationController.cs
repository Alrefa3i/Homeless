using HomeLess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;

namespace HomeLess.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly AppDBContaxt _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public RegistrationController(AppDBContaxt context, IWebHostEnvironment hostingEnvironment)
        {
            this._context = context;
            this._hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index( string Name, string Email, string password, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                var us = new User
                {
                    Name = Name,
                    Email = Email,
                    Password = password,
                    Role = "User",
                    Image = $"/images/{fileName}"
                };
                _context.Users.Add(us);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));

        }

    }
}
