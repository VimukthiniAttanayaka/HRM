
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{
    public class ReturnLocationModel
    {
        [Key]
        public string LOC_ID { get; set; }
        public string LOC_Name { get; set; }
        public string LOC_CUS_ID { get; set; }
        public string CUS_CompanyName { get; set; }
        public string BU_CompanyName { get; set; }
        public string LOC_Status { get; set; }



    }

    public class ReturnLocationAllModel
    {
        [Key]
        public string LOC_ID { get; set; }
        public string LOC_Name { get; set; }
        public string CUS_CompanyName { get; set; }
        public string BU_CompanyName { get; set; }
        public string LOC_Status { get; set; }
        public string RC { get; set; }

    }



    public class GetLocationAllModel : RequestBaseModel
    {

        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }
        public string LOC_ID { get; set; }
        public string LOC_Name { get; set; }
        public string BU_CompanyName { get; set; }
        public string CUS_CompanyName { get; set; }
        public string LOC_Status { get; set; }

    }

    public class GetLocationSingleModel : RequestBaseModel
    {

        public string LOC_ID { get; set; }

    }

    public class ReturnLocationModelHead : ReturnResponse
    {
        //public bool resp { get; set; }
        //public string msg { get; set; }
        public List<ReturnLocationModel> location { get; set; }


    }
    public class ReturnLocationAllModelHead : ReturnResponse
    {
        //public bool resp { get; set; }
        //public string msg { get; set; }
        public List<ReturnLocationAllModel> locationall { get; set; }


    }






}
