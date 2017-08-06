using System.Collections.Generic;

namespace _3citi.Models
{
    public class Variant : BaseDataObject
    {
        public List<StopTime> stopTimesTest { get; set; }
        public string tripHeadsign { get; set; }
        public int directionId { get; set; }
        public int tripId { get; set; }
        public List<RouteStopTimes> routeStopTimes { get; set; }
    }
}
