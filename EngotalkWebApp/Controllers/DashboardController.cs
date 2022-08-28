using Microsoft.AspNetCore.Mvc;

namespace Engotalk.WebApp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Current = "Dashboard";
            return View();
        }
    }
}
