
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{
    public class LocationModel : RequestBaseModel
    {
        [Key]
        public string MDL_LocationID { get; set; }
        public string MDL_Location { get; set; }
        public string MDL_Status { get; set; }
    }

    public class ReturnLocationModel
    {
        [Key]
        public string MDL_LocationID { get; set; }
        public string MDL_Location { get; set; }
        public string MDL_Status { get; set; }
    }

    public class ReturnLocationAllModel
    {
        [Key]
        public string MDL_LocationID { get; set; }
        public string MDL_Location { get; set; }
        public string MDL_Status { get; set; }

    }



    public class GetLocationAllModel : RequestBaseModel
    {

        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }
        public string MDL_LocationID { get; set; }
        public string MDL_Location { get; set; }
        public string MDL_Status { get; set; }

    }

    public class GetLocationSingleModel : RequestBaseModel
    {

        public string MDL_LocationID { get; set; }

    }

    public class ReturnLocationModelHead : ReturnResponse
    {
        public List<ReturnLocationModel> location { get; set; }


    }
    public class ReturnLocationAllModelHead : ReturnResponse
    {
        public List<ReturnLocationAllModel> location { get; set; }
    }

    public class InactiveMDLModel : RequestBaseModel
    {
        public string MDL_LocationID { get; set; }

    }
}
