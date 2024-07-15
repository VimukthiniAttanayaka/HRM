using System;

namespace HRM_DAL.Models
{
    public class Location
    {
        public string locationId { get; set; }
        public string locationName { get; set; }
        public string activeStatus { get; set; }
        public DateTime createdDateTime { get; set; }
        public DateTime? lastModifiedDateTime { get; set; }
    }
}
