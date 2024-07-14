using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using System;

namespace HRM_BL
{
    public class systemssettings_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturCountryModelHead> get_country_all(GetCountryAllModel Coall)//ok
        {
            return HRM_DAL.Data.systemssettings_Data.get_country_all(Coall);
        }

        public static List<ReturCountryModelHead> get_country_single(GetCountrysingleModel Cosingle)//ok
        {
            return HRM_DAL.Data.systemssettings_Data.get_country_single(Cosingle);
        }

        public static List<ReturCurrencyModelHead> get_currency_all(GetCurrencyAllModel Cuall)//ok
        {
            return HRM_DAL.Data.systemssettings_Data.get_currency_all(Cuall);
        }

        public static List<ReturCurrencyModelHead> get_currency_single(GetCurrencyAllModel Cusingle)//ok
        {
            return HRM_DAL.Data.systemssettings_Data.get_currency_single(Cusingle);
        }
    }
}








