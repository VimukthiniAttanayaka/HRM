using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class Country_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnCountryModelHead> get_Countrys_single(Country model)//ok
        {
            return HRM_DAL.Data.Country_Data.get_Countrys_single(model);
        }
        public static List<ReturnCountryModelHead> get_Country_all(CountrySearchModel model)//ok
        {
            return HRM_DAL.Data.Country_Data.get_Country_all(model);
        }


        public static List<ReturncustResponse> add_new_Country(CountryModel item)//ok
        {
            return HRM_DAL.Data.Country_Data.add_new_Country(item);
        }

        public static List<ReturncustResponse> modify_Country(CountryModel item)//ok
        {
            return HRM_DAL.Data.Country_Data.modify_Country(item);
        }

        public static List<ReturnResponse> inactivate_Country(InactiveMDCTYModel item)//ok
        {
            return HRM_DAL.Data.Country_Data.inactivate_Country(item);
        }


    }

}

