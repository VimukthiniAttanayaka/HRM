using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class deliverycouriercompany_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnResponse> add_new_delivery_courier_company(DeliveryCourierCompanyModel item)//ok
        {
            return HRM_DAL.Data.DeliveryCourierCompany_Data.add_new_delivery_courier_company(item);
        }

        public static List<ReturnResponse> modify_delivery_courier_company(DeliveryCourierCompanyModel item)//ok
        {
            return HRM_DAL.Data.DeliveryCourierCompany_Data.modify_delivery_courier_company(item);
        }

        public static List<ReturnResponse> inactivate_delivery_courier_company(InactiveDCCompanyModel item)//ok
        {
            return HRM_DAL.Data.DeliveryCourierCompany_Data.inactivate_delivery_courier_company(item);
        }

        public static List<ReturDCCompanyModelHead> get_delivery_courier_company_all(GetDCCompanyAllModel Dccall)//ok
        {
            return HRM_DAL.Data.DeliveryCourierCompany_Data.get_delivery_courier_company_all(Dccall);
        }

        public static List<ReturDCCompanyModelHead> get_delivery_courier_company_single(GetDCCompanyModel DCCsingle)
        {
            return HRM_DAL.Data.DeliveryCourierCompany_Data.get_delivery_courier_company_single(DCCsingle);
        }



    }








}








