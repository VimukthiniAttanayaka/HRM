using System;
using System.Collections.Generic;

namespace HRM_DAL.Models.RequestModels
{
    #region department related - start
    public class SetDepartment_ResponceModel : ReturnResponse
    {
        public int isCompleteList { get; set; } = 0;
        public string customerId { get; set; }
        public List<Department_RequestModel> departments { get; set; }
        public string reqTransReferenceId { get; set; }
    }
    public class SetDepartment_RequestModel
    {
        public int isCompleteList { get; set; } = 0;
        public string customerId { get; set; }
        public List<Department_RequestModel> departments { get; set; }
    }

    public class Department_RequestModel
    {
        public string deptId { get; set; }
        public string deptName { get; set; }
        public Address_RequestModel address { get; set; }
        public string cpCode { get; set; }
        public string activeStatus { get; set; }
        public string createdDateTime { get; set; }
        public string lastModifiedDateTime { get; set; }
    }

    public class Address_RequestModel
    {
        public string blockNo { get; set; }
        public string streetName { get; set; }
        public string unitNo { get; set; }
        public string buildingName { get; set; }
        public string City { get; set; }
        public string CountryId { get; set; }
        public string postalCode { get; set; }
    }
    #endregion department related - end

}
