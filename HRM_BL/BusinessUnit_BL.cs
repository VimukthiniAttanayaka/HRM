using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class BusinessUnit_BL
    {
        private static LogError objError = new LogError();


        public static List<ReturnResponse> add_new_business_unit(BusinessUnitModel item)
        {
            return HRM_DAL.Data.BusinessUnit_Data.add_new_business_unit(item);
        }

        public static List<ReturnResponse> modify_business_unit(BusinessUnitModel item)
        {
            return HRM_DAL.Data.BusinessUnit_Data.modify_business_unit(item);
        }

        public static List<ReturnResponse> inactivate_business_unit(InactiveModel item)
        {
            return HRM_DAL.Data.BusinessUnit_Data.inactivate_business_unit(item);
        }


        public static List<ReturnBusinessUnitModelHead> get_business_unit_all(GetBuAllModel Buall)
        {
            return HRM_DAL.Data.BusinessUnit_Data.get_business_unit_all(Buall);
        }

        public static List<ReturnCountryModelHead> get_country_with_select()
        {
            return HRM_DAL.Data.BusinessUnit_Data.get_country_with_select();
        }

        public static List<ReturnCurrencyModelHead> get_currency_with_select()
        {
            return HRM_DAL.Data.BusinessUnit_Data.get_currency_with_select();
        }

        public static List<ReturnBusinessUnitModelHead> get_business_unit_single(GetBusingleModel Busingle)
        {
            return HRM_DAL.Data.BusinessUnit_Data.get_business_unit_single(Busingle);
        }



    }
}