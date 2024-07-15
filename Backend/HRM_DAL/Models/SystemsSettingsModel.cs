
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{

    public class ReturnCountryAllModel
    {
        [Key]
        public string COU_Code { get; set; }
        public string COU_Name { get; set; }
        public string COU_ISO_AlphaCode { get; set; }
        public string COU_ISO_NumericCode { get; set; }
        public string RC { get; set; }



    }

    public class ReturCountryModelHead
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnCountryAllModel> country { get; set; }


    }
    public class GetCountryAllModel
    {
        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }
        public string COU_Code { get; set; }
        public string COU_Name { get; set; }



    }
    public class GetCountrysingleModel
    {

        public string COU_Code { get; set; }

    }

    public class ReturnCurrencyAllModel
    {
        [Key]
        public string CUR_Code { get; set; }
        public string CUR_Name { get; set; }
        public string CUR_ISO_Code { get; set; }
        public string RC { get; set; }

    }
    public class GetCurrencyAllModel
    {
        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }
        public string CUR_Code { get; set; }
        public string CUR_Name { get; set; }


    }
    public class ReturCurrencyModelHead
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnCurrencyAllModel> currency { get; set; }


    }





}
