using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{
    public class ReturnCountryModelHead : ReturnResponse
    {
        public List<ReturnCountryModel> Country { get; set; }
    }

    public class CountryModel : RequestBaseModel
    {
        public string MDCTY_CountryID { get; set; }
        public string MDCTY_Country { get; set; }
        public bool MDCTY_Status { get; set; }
        public string MDCTY_CreatedBy { get; set; }
        public DateTime MDCTY_CreatedDateTime { get; set; }
        public string MDCTY_ModifiedBy { get; set; }
        public DateTime MDCTY_ModifiedDateTime { get; set; }
    }

    public class ReturnCountryModel
    {
        [Key]
        public string MDCTY_CountryID { get; set; }
        public string MDCTY_Country { get; set; }
        public bool MDCTY_Status { get; set; }
        public string MDCTY_CreatedBy { get; set; }
        public DateTime MDCTY_CreatedDateTime { get; set; }
        public string MDCTY_ModifiedBy { get; set; }
        public DateTime MDCTY_ModifiedDateTime { get; set; }
    }

    public class ReturnCountryAllModel
    {
        [Key]

        public string MDCTY_CountryID { get; set; }
        public string RC { get; set; }
    }


    public class Country : RequestBaseModel
    {
        public string MDCTY_CountryID { get; set; }


    }

    public class ReturnCountryAllModelHead : ReturnResponse
    {
        public List<ReturnCountryAllModel> Countryall { get; set; }


    }

    public class CountrySearchModel : RequestBaseModel
    {
        public string MDCTY_CountryID { get; set; }
    }

    public class ReturnCountrySelectModel
    {
        public string MDCTY_CountryID { get; set; }

    }

    public class InactiveMDCTYModel : RequestBaseModel
    {
        public string MDCTY_CountryID { get; set; }

    }
}
