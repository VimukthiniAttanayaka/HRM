using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class Currency_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnCurrencyModelHead> get_Currencys_single(Currency model)//ok
        {
            return HRM_DAL.Data.Currency_Data.get_Currencys_single(model);
        }
        public static List<ReturnCurrencyModelHead> get_Currency_all(CurrencySearchModel model)//ok
        {
            return HRM_DAL.Data.Currency_Data.get_Currency_all(model);
        }


        public static List<ReturncustResponse> add_new_Currency(CurrencyModel item)//ok
        {
            return HRM_DAL.Data.Currency_Data.add_new_Currency(item);
        }

        public static List<ReturncustResponse> modify_Currency(CurrencyModel item)//ok
        {
            return HRM_DAL.Data.Currency_Data.modify_Currency(item);
        }

        public static List<ReturnResponse> inactivate_Currency(InactiveMDCCYModel item)//ok
        {
            return HRM_DAL.Data.Currency_Data.inactivate_Currency(item);
        }


    }

}

