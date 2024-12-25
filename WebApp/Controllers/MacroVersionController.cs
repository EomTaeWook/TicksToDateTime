using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class MacroVersionController(MacroService macroService) : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            var versionNote = await macroService.GetLatestVersionAsync();

            return View(versionNote);
        }
    }
}
