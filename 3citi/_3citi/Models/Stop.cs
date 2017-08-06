namespace _3citi.Models
{
    public class Stop : BaseDataObject
    {
       
        string stopId = string.Empty;
        public string StopId
        {
            get { return stopId; }
            set { SetProperty(ref stopId, value); }
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
        string stopLat = string.Empty;
        public string StopLat
        {
            get { return stopLat; }
            set { SetProperty(ref stopLat, value); }
        }
        string stopLon = string.Empty;
        public string StopLon
        {
            get { return stopLon; }
            set { SetProperty(ref stopLon, value); }
        }
        string zoneId = string.Empty;
        public string ZoneId
        {
            get { return zoneId; }
            set { SetProperty(ref zoneId, value); }
        }
        string zoneName = string.Empty;
        public string ZoneName
        {
            get { return zoneName; }
            set { SetProperty(ref zoneName, value); }
        }
        string depot = string.Empty;
        public string Depot
        {
            get { return depot; }
            set { SetProperty(ref depot, value); }
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
    }
}
