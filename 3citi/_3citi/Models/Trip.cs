namespace _3citi.Models
{
    public class Trip : BaseDataObject
    {
        string tripId = string.Empty;
        public string TripId
        {
            get { return tripId; }
            set { SetProperty(ref tripId, value); }
        }
        string routeId = string.Empty;
        public string RouteId
        {
            get { return routeId; }
            set { SetProperty(ref routeId, value); }
        }
        string tripHeadsign = string.Empty;
        public string TripHeadsign
        {
            get { return tripHeadsign; }
            set { SetProperty(ref tripHeadsign, value); }
        }
        string directionId = string.Empty;
        public string DirectionId
        {
            get { return directionId; }
            set { SetProperty(ref directionId, value); }
        }

        
    }
}
