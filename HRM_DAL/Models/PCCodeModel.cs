
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{
    public class PCCodeModel
    {
        public string PCC_ID { get; set; }
        public string PCC_Name { get; set; }
        public string PCC_Description { get; set; }
        public string PCC_Status { get; set; }
        public string USER_ID { get; set; }
    }

    public class ReturnPCCodeModel
    {
        public string PCC_ID { get; set; }
        public string PCC_Status { get; set; }
        public string RC { get; set; }
    }

    public class ReturnPCCodeDistinctModel
    {
        public string PCC_ID { get; set; }
        public string RC { get; set; }
    }

    public class ReturnPCCodeAllModel
    {
        public string PCC_ID { get; set; }
        public string PCC_Name { get; set; }
        public string PCC_Description { get; set; }
        public string PCC_Status { get; set; }
        public string RC { get; set; }

    }

    public class GetPCCodeAllModel : RequestGridBaseModel
    {
        public string DEPT_ID { get;  set; }
        public string PCCode { get;  set; }
        public string Status { get;  set; }
    }

    public class GetPCCodeSingleModel : RequestBaseModel
    {
        public string PCC_ID { get; set; }
        public string PCC_Name { get; set; }
        public string PCC_Description { get; set; }
        public string PCC_Status { get; set; }

    }

    public class GetPCCodeDepartmentModel : RequestGridBaseModel
    {
        public string DPT_ID { get; set; }
    }

    public class ReturPCCodeModelHead : ReturnResponse
    {
        public List<ReturnPCCodeModel> PCCode { get; set; }


    }
    public class ReturPCCodeDistinctModelHead : ReturnResponse
    {
        public List<ReturnPCCodeDistinctModel> PCCode { get; set; }


    }
    public class ReturPCCodeAllModelHead : ReturnResponse
    {
        //public bool resp { get; set; }
        //public string msg { get; set; }
        public List<ReturnPCCodeAllModel> PCCodeall { get; set; }


    }







}
