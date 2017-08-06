namespace _3citi.Models
{
    class StopsInTrip : BaseDataObject
    {
        public int routeId { get; set; }
        public int tripId { get; set; }
        public int stopId { get; set; }
        public int stopSequence { get; set; }
        public int agencyId { get; set; }
        public int topologyVersionId { get; set; }
        public string tripActivationDate { get; set; }
        public string stopActivationDate { get; set; }
    }
}
