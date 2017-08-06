using System.Collections.Generic;

namespace _3citi.Models
{
    public class RouteStopTimes
    {
        public string StopDesc { get; set; }
        public List<StopHoursMinutes> Times { get; set; }
        public List<StopHoursMinutes> TimesTomorrow { get; set; }
        public string RouteId;
        public string TripId;
        public string AgencyId;
        public string TopologyVersionId;
        public string StopId;
        public string StopSequence;
        public string StopHeadsign;
        public string Date;
        public string PickupType;
        public string DropOffType;
        public string ShapeDistTraveled;
        public string Timepoint;
        public string VariantId;
        public string NoteSymbol;
        public string NoteDescription;
        public string BusServiceName;
        public string VirtualId;
        public string TicketZoneBorder;
        public string OnDemand;
        public string Islupek;
        public string WheelchairAccessible;
        public string StopShortName;
    }
}
