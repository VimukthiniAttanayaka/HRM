using System.Collections.Generic;

namespace HRM_DAL.Models
{
    public class DepartmentRequestDto
    {
        public int isCompleteList { get; set; }
        public string customerId { get; set; }
        public List<DepartmentData> departments { get; set; }
    }
}
