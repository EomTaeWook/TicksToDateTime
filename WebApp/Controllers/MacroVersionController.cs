using DataContainer.Generated;
using Microsoft.AspNetCore.Mvc;
using TemplateContainers;
using WebApp.Services;
using WebApp.ViewModel;

namespace WebApp.Controllers
{
    public class MacroVersionController(MacroService macroService) : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            var versionNote = await macroService.GetLatestVersionAsync();

            var gitHubRelease = TemplateContainer<ConstantStringTemplate>.Find("GitHubRelease").Value;

            var buyMeaCoffee = TemplateContainer<ConstantStringTemplate>.Find("BuyMeaCoffee").Value;

            return View(new MacroVersionIndexModel()
            {
                VersionNote = versionNote,
                GitHubReleaseUrl = gitHubRelease,
                BuyMeaCoffeeUrl = buyMeaCoffee
            });
        }

        public IActionResult HelpAsync()
        {
            return Redirect(macroService.GetGitHubHelpUrl());
        }
    }
}
