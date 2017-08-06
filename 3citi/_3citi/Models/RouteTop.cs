using System.Collections.Generic;

namespace _3citi.Models
{
    class RouteTop : BaseDataObject
    {
        public string lastUpdate { get; set; }
        public List<Route> routes { get; set; }
    }
}
