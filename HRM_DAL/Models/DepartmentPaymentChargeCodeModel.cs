
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{
    public class DepartmentPCCModel : RequestBaseModel
    {
        //[Key]
        public string DPCC_CustomerID { get; set; }
        public string DPCC_DepartmentID { get; set; }
        public string DPCC_PCCode { get; set; }
        public string DPCC_PCCode_Old { get; set; }
        public string USER_ID { get; set; }
        public bool DPCC_Status { get; set; }
    }
    public class ReturnDepartmentPCCModel
    {
        [Key]
        public string DPCC_CustomerID { get; set; }
        public string CUS_CompanyName { get; set; }
        public string DPCC_DepartmentID { get; set; }
        public string DPT_Name { get; set; }
        public string DPCC_PCCode { get; set; }
        public string DPCC_Status { get; set; }
        public string DPCC_CreatedBy { get; set; }
        public string DPCC_CreatedDateTime { get; set; }
        public string DPCC_ModifiedBy { get; set; }
        public string DPCC_ModifiedDateTime { get; set; }
        public string RC { get; set; }
    }

    public class ReturnDepartmentPCCAllModel
    {
        [Key]
        public string DPCC_DepartmentID { get; set; }
        public string DPT_Name { get; set; }
        public string DPCC_CustomerID { get; set; }
        public string CUS_CompanyName { get; set; }
        public string BU_CompanyName { get; set; }
        public string DPCC_PCCode { get; set; }
        public string DPCC_Status { get; set; }
        public string RC { get; set; }

    }

    public class InactiveDepartmentPCCModel : RequestBaseModel
    {

        public string DPCC_CustomerID { get; set; }
        public string DPCC_DepartmentID { get; set; }
        public string DPCC_PCCode { get; set; }
        public string USER_ID { get; set; }
    }

    public class GetDepartmentPCCAllModel : RequestBaseModel
    {

        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }

        public string DPCC_CustomerID { get; set; }
        public string DPT_ID { get; set; }
        public string DPT_Name { get; set; }
        public string DPT_CPCode { get; set; }
        public string BU_CompanyName { get; set; }
        public string CUS_CompanyName { get; set; }
        public string DPT_Status { get; set; }



    }
    public class GetDepartmentPCCSingleModel : RequestBaseModel
    {

        public string DPCC_CustomerID { get; set; }
        public string DPCC_DepartmentID { get; set; }
        public string DPCC_PCCode { get; set; }

    }

    public class ReturDepartmentPCCModelHead:ReturnResponse
    {
        //public bool resp { get; set; }
        //public string msg { get; set; }
        public List<ReturnDepartmentPCCModel> DepartmentPCC { get; set; }


    }
    public class ReturDepartmentPCCAllModelHead
    {
        public bool resp { get; set; }
        public string msg { get; set; }

        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<ReturnDepartmentPCCAllModel> departmentpccall { get; set; }


    }







}
