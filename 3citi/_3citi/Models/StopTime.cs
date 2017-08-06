namespace _3citi.Models
{
    public class StopTime : BaseDataObject
    {
        string routeId = string.Empty;
        public string RouteId
        {
            get { return routeId; }
            set { SetProperty(ref routeId, value); }
        }
        string tripId = string.Empty;
        public string TripId
        {
            get { return tripId; }
            set { SetProperty(ref tripId, value); }
        }
        string agencyId = string.Empty;
        public string AgencyId
        {
            get { return agencyId; }
            set { SetProperty(ref agencyId, value); }
        }
        string topologyVersionId = string.Empty;
        public string TopologyVersionId
        {
            get { return topologyVersionId; }
            set { SetProperty(ref topologyVersionId, value); }
        }
        string arrivalTime = string.Empty;
        public string ArrivalTime
        {
            get { return arrivalTime; }
            set { SetProperty(ref arrivalTime, value); }
        }
        string departureTime = string.Empty;
        public string DepartureTime
        {
            get { return departureTime; }
            set { SetProperty(ref departureTime, value); }
        }
        string stopId = string.Empty;
        public string StopId
        {
            get { return stopId; }
            set { SetProperty(ref stopId, value); }
        }
        string stopSequence = string.Empty;
        public string StopSequence
        {
            get { return stopSequence; }
            set { SetProperty(ref stopSequence, value); }
        }
        string stopHeadsign = string.Empty;
        public string StopHeadsign
        {
            get { return stopHeadsign; }
            set { SetProperty(ref stopHeadsign, value); }
        }
        string date = string.Empty;
        public string Date
        {
            get { return date; }
            set { SetProperty(ref date, value); }
        }
        string pickupType = string.Empty;
        public string PickupType
        {
            get { return pickupType; }
            set { SetProperty(ref pickupType, value); }
        }
        string dropOffType = string.Empty;
        public string DropOffType
        {
            get { return dropOffType; }
            set { SetProperty(ref dropOffType, value); }
        }
        string shapeDistTraveled = string.Empty;
        public string ShapeDistTraveled
        {
            get { return shapeDistTraveled; }
            set { SetProperty(ref shapeDistTraveled, value); }
        }
        string timepoint = string.Empty;
        public string Timepoint
        {
            get { return timepoint; }
            set { SetProperty(ref timepoint, value); }
        }
        string variantId = string.Empty;
        public string VariantId
        {
            get { return variantId; }
            set { SetProperty(ref variantId, value); }
        }
        string noteSymbol = string.Empty;
        public string NoteSymbol
        {
            get { return noteSymbol; }
            set { SetProperty(ref noteSymbol, value); }
        }
        string noteDescription = string.Empty;
        public string NoteDescription
        {
            get { return noteDescription; }
            set { SetProperty(ref noteDescription, value); }
        }
        string busServiceName = string.Empty;
        public string BusServiceName
        {
            get { return busServiceName; }
            set { SetProperty(ref busServiceName, value); }
        }
        string order = string.Empty;
        public string Order
        {
            get { return order; }
            set { SetProperty(ref order, value); }
        }
        string nonpassenger = string.Empty;
        public string Nonpassenger
        {
            get { return nonpassenger; }
            set { SetProperty(ref nonpassenger, value); }
        }
        string ticketZoneBorder = string.Empty;
        public string TicketZoneBorder
        {
            get { return ticketZoneBorder; }
            set { SetProperty(ref ticketZoneBorder, value); }
        }
        string onDemand = string.Empty;
        public string OnDemand
        {
            get { return onDemand; }
            set { SetProperty(ref onDemand, value); }
        }
        string virtualId = string.Empty;
        public string VirtualId
        {
            get { return virtualId; }
            set { SetProperty(ref virtualId, value); }
        }
        string islupek = string.Empty;
        public string Islupek
        {
            get { return islupek; }
            set { SetProperty(ref islupek, value); }
        }
        string wheelchairAccessible = string.Empty;
        public string WheelchairAccessible
        {
            get { return wheelchairAccessible; }
            set { SetProperty(ref wheelchairAccessible, value); }
        }
        string stopShortName = string.Empty;
        public string StopShortName
        {
            get { return stopShortName; }
            set { SetProperty(ref stopShortName, value); }
        }
        string stopDesc = string.Empty;
        public string StopDesc
        {
            get { return stopDesc; }
            set { SetProperty(ref stopDesc, value); }
        }
    }
}
