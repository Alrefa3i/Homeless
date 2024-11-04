using Microsoft.AspNetCore.Mvc;

namespace HomeLess.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
