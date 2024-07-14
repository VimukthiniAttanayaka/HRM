using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class Enquiry_BL
    {
        private static LogError objError = new LogError();

        public static List<EnquiryHeaderResponceModel> modify_Enquiry(EnquirySubmitModel item)
        {
            return HRM_DAL.Data.Enquiry_Data.modify_Enquiry(item);
        }

        public static List<EnquiryHeaderResponceModel> get_Enquiry_details(EnquiryRequestModel item)
        {
            return HRM_DAL.Data.Enquiry_Data.get_Enquiry_details(item);
        }

        public static List<EnquiryGridViewHeaderModel> get_Enquiry_grid_details(EnquiryGridRequestModel gridmodel)
        {
            return HRM_DAL.Data.Enquiry_Data.get_Enquiry_grid_details(gridmodel);
        }
        public static List<EnquiryMailBagGridViewHeaderModel> get_Enquiry_grid_details_mailbag(MailBagEnquiryGridRequestModel gridmodel)
        {
            return HRM_DAL.Data.Enquiry_Data.get_Enquiry_grid_details_mailbag(gridmodel);
        }
    }
}