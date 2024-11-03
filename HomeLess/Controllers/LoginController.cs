using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using HomeLess.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeLess.Controllers
{
    public class LoginController: Controller
    {
        private readonly AppDBContaxt _context;
        private readonly IWebHostEnvironment environment;
        public LoginController(AppDBContaxt context, IWebHostEnvironment environment)
        {
            this._context = context;
            this.environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            // Verify if the user exists and if the password is correct
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == user.Email);

            if (existingUser != null && VerifyPassword(user.Password, existingUser.Password))
            {
                // Create claims for the user
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, existingUser.Email),
                    new Claim(ClaimTypes.Name, existingUser.Name)
                    // Add additional claims if needed, such as roles
                };
                if (!string.IsNullOrEmpty(existingUser.Role)) // Assuming User has a Role property
                {
                    claims.Add(new Claim(ClaimTypes.Role, existingUser.Role));
                }

                // Create claims identity
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Sign in the user with the created claims principal
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                // Redirect to home page or desired location after successful login
                return RedirectToAction("Index", "Home");
            }

            // If login fails, show an error message
            ModelState.AddModelError("", "Invalid username or password.");

            return View(user);
        }
        private bool VerifyPassword(string password, string passwordHash)
        {
            // Implement your password verification logic (e.g., hash comparison)
            return password == passwordHash; // Simplified for demonstration
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home"); 
        }
    }
}
