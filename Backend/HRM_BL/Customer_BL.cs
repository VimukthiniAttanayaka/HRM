using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class Customer_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnCustomerModelHead> get_customers_single(Customer CUS_ID)//ok
        {
            return HRM_DAL.Data.Customer_Data.get_customers_single(CUS_ID);
        }
        public static List<ReturnCustomerModelHead> get_customer_all(CustomerSearchModel model)//ok
        {
            return HRM_DAL.Data.Customer_Data.get_customer_all(model);
        }
        public static List<ReturnResponse> add_new_customer(CustomerModel item)//ok
        {
            return HRM_DAL.Data.Customer_Data.add_new_customer(item);
        }

        public static List<ReturnResponse> modify_customer(CustomerModel item)//ok
        {
            return HRM_DAL.Data.Customer_Data.modify_customer(item);
        }

        public static List<ReturnResponse> inactivate_customer(InactiveCusModel item)//ok
        {
            return HRM_DAL.Data.Customer_Data.inactivate_customer(item);
        }


    }

}

