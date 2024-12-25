using DataContainer.Interfaces;
using Dignus.Log;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.APIControllers
{
    [Route("[controller]")]
    public abstract class APIController<T> : ControllerBase where T : IAPIRequest
    {
        protected abstract Task<IAPIResponse> Process(T request);

        [HttpPost]
        public async Task<JsonResult> PostAsync([FromBody] T request)
        {
            LogHelper.Info($"{HttpContext.Request.Path}");
            if (request == null)
            {
                return new JsonResult(new ErrorMessageResponse($"invalid request"));
            }

            var response = await Process(request);
            return new JsonResult(response);
        }
    }
}
