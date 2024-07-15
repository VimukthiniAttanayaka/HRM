using System;

namespace HRM_DAL.Models
{
    public class DepartmentData
    {
        // table: tbl_department
        public string deptId { get; set; }
        public string deptName { get; set; }
        public Address address { get; set; }
        public string cpCode { get; set; }
        public string activeStatus { get; set; }
        public DateTime? createdDateTime { get; set; }
        public DateTime? lastModifiedDateTime { get; set; }
    }
}
