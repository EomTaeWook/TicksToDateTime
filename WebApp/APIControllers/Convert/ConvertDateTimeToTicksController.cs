using Protocols;
using Protocols.Interfaces;

namespace WebApp.APIControllers.Convert
{
    public class ConvertDateTimeToTicksController : APIController<ConvertDateTimeToTicks>
    {
        protected override Task<IAPIResponse> Process(ConvertDateTimeToTicks request)
        {
            return Task.FromResult<IAPIResponse>(new ConvertDateTimeToTicksResponse()
            {
                Ok = true,
                Ticks = request.DateTime.Ticks,
            });
        }
    }
}
