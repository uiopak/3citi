using System.Collections.Generic;

namespace _3citi.Models
{
    public class RouteDay : BaseDataObject
    {
        public List<Route> routes { get; set; }
        public string Day { get; set; }
        public int index { get; set; }
        public int i { get; set; }
    }
}