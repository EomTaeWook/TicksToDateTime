using DataContainer;
using DataContainer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

namespace WebApp.APIControllers.Macro
{
    [Area("macro")]
    public class GetMacroLatestVersionController(MacroService macroService) : APIController<GetMacroLatestVersion>
    {
        protected override async Task<IAPIResponse> Process(GetMacroLatestVersion request)
        {
            var versionNote = await macroService.GetLatestVersionAsync();

            if (versionNote == null)
            {
                return new GetMacroLatestVersionResponse()
                {
                    Ok = false,
                };
            }

            return new GetMacroLatestVersionResponse()
            {
                Ok = true,
                VersionNote = versionNote
            };
        }
    }
}
