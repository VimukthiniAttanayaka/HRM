using System;
using System.Collections.Generic;

namespace HRM_DAL.Models
{
    public class Department
    {
        public string deptId { get; set; }
        public string deptName { get; set; }
        public string cpCode { get; set; }
        public string deviceNo { get; set; }
        public string deviceTypeId { get; set; } // nullable
        public string vendorId { get; set; }    // nullable
        public List<string> boxNos { get; set; }
        public string activeStatus { get; set; }
        public DateTime? createdDateTime { get; set; }
        public DateTime? lastModifiedDateTime { get; set; }
    }
}
