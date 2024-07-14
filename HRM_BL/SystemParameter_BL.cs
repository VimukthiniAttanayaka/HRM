using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using System;

namespace HRM_BL
{
    public class SystemParameter_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturSystemPMModelHead> get_system_parameter_all(GetSystemPMAllModel SPMall)//ok
        {
            return HRM_DAL.Data.SystemParameter_Data.get_system_parameter_all(SPMall);
        }

        public static List<ReturSystemPMModelHead> get_system_parameter_single(GetSystemPMSingleModel SPMsingle)//ok
        {
            return HRM_DAL.Data.SystemParameter_Data.get_system_parameter_single(SPMsingle);
        }

        public static List<ReturnResponse> modify_system_parameter(SystemPMModel item)//ok
        {
            return HRM_DAL.Data.SystemParameter_Data.modify_system_parameter(item);
        }

    }

}






