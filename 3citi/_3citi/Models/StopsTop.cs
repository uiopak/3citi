using System.Collections.Generic;

namespace _3citi.Models
{
    class StopsTop : BaseDataObject
    {
        public string lastUpdate { get; set; }
        public List<StopsInTrip> stopsInTrip { get; set; }
    }
}

