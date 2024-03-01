using DataContainer.Interfaces;

namespace DataContainer
{
    public class ConvertTicksToDateTimeResponse : IAPIResponse
    {
        public string DateTime { get; set; }
        public bool Ok { get; set; }
    }
    public class ConvertDateTimeToTicksResponse : IAPIResponse
    {
        public long Ticks { get; set; }
        public bool Ok { get; set; }
    }
}
