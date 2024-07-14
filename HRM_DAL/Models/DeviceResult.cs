using System.Collections.Generic;

namespace HRM_DAL.Models
{
    public class DeviceResult
    {
        public List<DeviceActivity> deviceActivities { get; set; }
        public string reqTransReferenceId { get; set; }
    }
}
