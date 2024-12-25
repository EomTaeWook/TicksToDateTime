using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AdController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
