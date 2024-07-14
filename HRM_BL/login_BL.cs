using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using System;

namespace HRM_BL
{
    public class login_BL 
    {
        public static List<ReturnUserModelHead> login(LogdataModel logdata)
        {
            return HRM_DAL.Data.login_Data.login(logdata);
        }
               
        public static List<ReturnLoadCustomerModelHead> load_customer(LoadCustomerModel LoadCust)
        {
            return HRM_DAL.Data.login_Data.load_customer(LoadCust);
        }

        public static List<ReturnUserAccessModelHead> LoadUserAccessList(RequestUserAccessModel logdata)
        {
            return HRM_DAL.Data.login_Data.LoadUserAccessList(logdata);
        }
    }

}

