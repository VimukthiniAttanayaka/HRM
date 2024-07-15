using System.Collections.Generic;

namespace HRM_DAL.Models
{
    public class CustomerDepartment
    {
        public string customerId { get; set; }
        public List<Department> departments { get; set; }
    }
}
