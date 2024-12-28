using DataContainer.Interfaces;
using Dignus.Log;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApp.Models;

namespace WebApp.APIControllers
{
    [Route("{area:exists}/{controller}")]
    [Route("[controller]")]
    public abstract class APIController<T> : ControllerBase where T : IAPIRequest
    {
        protected abstract Task<IAPIResponse> Process(T request);

        [HttpPost]
        public async Task<JsonResult> PostAsync([FromBody] T request)
        {
            var clientIp = HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();

            if (string.IsNullOrEmpty(clientIp))
            {
                clientIp = HttpContext.Connection.RemoteIpAddress?.ToString();
            }

            LogHelper.Info($"[{clientIp}][{HttpContext.Request.Path}] - {JsonSerializer.Serialize(request)}");
            if (request == null)
            {
                return new JsonResult(new ErrorMessageResponse($"invalid request"));
            }

            var response = await Process(request);
            return new JsonResult(response);
        }
    }
}
