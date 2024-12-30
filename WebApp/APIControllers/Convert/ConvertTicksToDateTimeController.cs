using Protocols;
using Protocols.Interfaces;

namespace WebApp.APIControllers.Convert
{
    public class ConvertTicksToDateTimeController : APIController<ConvertTicksToDateTime>
    {
        protected override Task<IAPIResponse> Process(ConvertTicksToDateTime request)
        {
            var dateTime = DateTime.MinValue;
            if (request.Ticks <= 0)
            {
                return Task.FromResult<IAPIResponse>(new ConvertTicksToDateTimeResponse()
                {
                    DateTime = dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                    Ok = true,
                });
            }

            dateTime = new DateTime(request.Ticks);
            return Task.FromResult<IAPIResponse>(new ConvertTicksToDateTimeResponse()
            {
                DateTime = dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                Ok = true,
            });
        }
    }
}
