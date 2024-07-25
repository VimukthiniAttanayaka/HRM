using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{
    public class ReturnCurrencyModelHead : ReturnResponse
    {
        public List<ReturnCurrencyModel> Currency { get; set; }
    }

    public class CurrencyModel : RequestBaseModel
    {
        public string MDCCY_CurrencyID { get; set; }
        public string MDCCY_Currency { get; set; }
        public int MDCCY_LeaveAlotment { get; set; }
        public bool MDCCY_Status { get; set; }
        public string MDCCY_CreatedBy { get; set; }
        public DateTime MDCCY_CreatedDateTime { get; set; }
        public string MDCCY_ModifiedBy { get; set; }
        public DateTime MDCCY_ModifiedDateTime { get; set; }
    }

    public class ReturnCurrencyModel
    {
        [Key]
        public string MDCCY_CurrencyID { get; set; }
        public string MDCCY_Currency { get; set; }
        public int MDCCY_LeaveAlotment { get; set; }
        public bool MDCCY_Status { get; set; }
        public string MDCCY_CreatedBy { get; set; }
        public DateTime MDCCY_CreatedDateTime { get; set; }
        public string MDCCY_ModifiedBy { get; set; }
        public DateTime MDCCY_ModifiedDateTime { get; set; }
    }

    public class ReturnCurrencyAllModel
    {
        [Key]

        public string MDCCY_CurrencyID { get; set; }
        public string RC { get; set; }
    }


    public class Currency : RequestBaseModel
    {
        public string MDCCY_CurrencyID { get; set; }


    }

    public class ReturnCurrencyAllModelHead : ReturnResponse
    {
        public List<ReturnCurrencyAllModel> Currencyall { get; set; }


    }

    public class CurrencySearchModel : RequestBaseModel
    {
        public string MDCCY_CurrencyID { get; set; }
    }

    public class ReturnCurrencySelectModel
    {
        public string MDCCY_CurrencyID { get; set; }

    }

    public class InactiveMDCCYModel : RequestBaseModel
    {
        public string MDCCY_CurrencyID { get; set; }

    }
}
