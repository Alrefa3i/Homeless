using HomeLess.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HomeLess.Controllers
{
    [Authorize(Roles = "User")]
    public class UserInfoController : Controller
    {
		private readonly AppDBContaxt _context;

		public UserInfoController(AppDBContaxt context)
		{
			_context = context;
		}
		public IActionResult Index()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
		[HttpPost]
		public async Task<IActionResult> Edit(User model,string ConfirmPassword, IFormFile imageFile)
		{

			string userId = User.FindFirstValue("UserId");
            int id = int.Parse(userId);
            var user = await _context.Users.FindAsync(id);

			if (user == null)
			{
				return NotFound();
			}

			// Update properties
			if (model.Name != null)
			{
                user.Name = model.Name;

            }
            if (model.Email != null)
            {
				user.Email = model.Email;
            }

            if (model.Password != null && model.Password == ConfirmPassword)
			{
				user.Password = model.Password;
			}

			if (imageFile != null && imageFile.Length > 0)
			{
				// Save the file and update the user's image path
				var imagePath = await SaveImageAsync(imageFile);
				user.Image = imagePath;
			}

			_context.Users.Update(user);
			await _context.SaveChangesAsync();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var claims = new List<Claim>
                {
                    new Claim("UserId", userId),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim("Image", user.Image)
                };

            // Create claims identity
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // Sign in the user with the created claims principal
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));


            return RedirectToAction("Index", "Home");
        }

		private async Task<string> SaveImageAsync(IFormFile imageFile)
		{
			// Implement logic to save the image and return the path.
			// This might involve saving to wwwroot and returning a relative URL.
			// Example:
			var filePath = Path.Combine("wwwroot", "images", "users", imageFile.FileName);
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await imageFile.CopyToAsync(stream);
			}
			return $"/images/users/{imageFile.FileName}";
		}

		private string HashPassword(string password)
		{
			// Implement your password hashing logic here, e.g., using ASP.NET Core Identity's PasswordHasher
			return password; // Placeholder for actual hashing implementation
		}
	}
}
