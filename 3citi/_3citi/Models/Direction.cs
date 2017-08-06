using System.Collections.Generic;

namespace _3citi.Models
{
    public class Direction:BaseDataObject
    {
        public string directionId { get; set; }
        public List<Variant> variants { get; set; }
    }
}
