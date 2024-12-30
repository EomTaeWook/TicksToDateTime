using Protocols.Interfaces;

namespace Protocols
{
    public class ConvertTicksToDateTime : IAPIRequest
    {
        public long Ticks { get; set; }
    }
    public class ConvertDateTimeToTicks : IAPIRequest
    {
        public DateTime DateTime { get; set; }
    }

    public class GetMacroLatestVersion : IAPIRequest
    {
    }
}
