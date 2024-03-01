using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class Ticks2DateTimeController : Controller
    {
        public Ticks2DateTimeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
