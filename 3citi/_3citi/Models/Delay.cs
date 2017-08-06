namespace _3citi.Models
{
    public class Delay : BaseDataObject
    {
        string id = string.Empty;
        public string IdDelay
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }
        string delayInSeconds = string.Empty;
        public string DelayInSeconds
        {
            get { return delayInSeconds; }
            set { SetProperty(ref delayInSeconds, value); }
        }
        string estimatedTime = string.Empty;
        public string EstimatedTime
        {
            get { return estimatedTime; }
            set { SetProperty(ref estimatedTime, value); }
        }
        string headsign = string.Empty;
        public string Headsign
        {
            get { return headsign; }
            set { SetProperty(ref headsign, value); }
        }
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
        string status = string.Empty;
        public string Status
        {
            get { return status; }
            set { SetProperty(ref status, value); }
        }
        string theoreticalTime = string.Empty;
        public string TheoreticalTime
        {
            get { return theoreticalTime; }
            set { SetProperty(ref theoreticalTime, value); }
        }
        string timestamp = string.Empty;
        public string Timestamp
        {
            get { return timestamp; }
            set { SetProperty(ref timestamp, value); }
        }
        string trip = string.Empty;
        public string Trip
        {
            get { return trip; }
            set { SetProperty(ref trip, value); }
        }
        string vehicleCode = string.Empty;
        public string VehicleCode
        {
            get { return vehicleCode; }
            set { SetProperty(ref vehicleCode, value); }
        }
        string vehicleId = string.Empty;
        public string VehicleId
        {
            get { return vehicleId; }
            set { SetProperty(ref vehicleId, value); }
        }
        string routeShortName = string.Empty;
        public string RouteShortName
        {
            get { return routeShortName; }
            set { SetProperty(ref routeShortName, value); }
        }
        string routeLongName = string.Empty;
        public string RouteLongName
        {
            get { return routeLongName; }
            set { SetProperty(ref routeLongName, value); }
        }
    }
}