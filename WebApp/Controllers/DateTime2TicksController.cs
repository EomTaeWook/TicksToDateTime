using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class DateTime2TicksController : Controller
    {
        public DateTime2TicksController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
