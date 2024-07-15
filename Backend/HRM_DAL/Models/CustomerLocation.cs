using System.Collections.Generic;

namespace HRM_DAL.Models
{
    public class CustomerLocation
    {
        public string customerId { get; set; }
        public List<Location> locations { get; set; }
    }
}
