using HRM_DAL.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HRM_DAL.Utility
{
    public class AuditActionMap
    {
        public const string loginController_login = "10001";
        public const string versionController_Get = "10002";
        public const string loginController_load_customer = "10003";

        public const string userController_get_user_by_id = "10004";
        public const string userController_get_user_all = "10005";
        public const string userController_inactivate_user = "10006";
        public const string userController_get_customer_user_by_id = "10007";
        public const string userController_get_customer_user_all = "10008";
        public const string userController_inactivate_customer_user = "10009";
        public const string userController_load_user_data = "10010";
        public const string userController_add_new_t_user = "10011";
        public const string userController_add_new_customer_user = "10012";
        public const string userController_get_transuser_dropdown = "10013";
        public const string userController_change_password = "10014";
        public const string userController_update_notification_token = "10015";
        public const string userController_reset_password = "10016";
        public const string userController_change_password_by_email = "10017";

        public const string businessunitController_add_new_business_unit = "10018";
        public const string businessunitController_modify_business_unit = "10019";
        public const string businessunitController_inactivate_business_unit = "10020";
        public const string businessunitController_get_business_unit_all = "10021";
        public const string businessunitController_get_country_with_select = "10022";
        public const string businessunitController_get_currency_with_select = "10023";
        public const string businessunitController_get_business_unit_single = "10024";

        public const string containerController_add_new_container = "10025";
        public const string containerController_inactivate_container = "10026";
        public const string containerController_get_container_all = "10027";
        public const string containerController_get_container_single = "10028";

        public const string containerdtController_add_new_containerdt = "10029";
        public const string containerdtController_inactivate_containerdt = "10030";
        public const string containerdtController_get_containerdt_all = "10031";
        public const string containerdtController_get_containerdt_single = "10032";

        public const string CustomerController_get_customers_single = "10033";
        public const string CustomerController_get_customers_all = "10034";
        public const string CustomerController_add_new_customer = "10035";
        public const string CustomerController_inactivate_customer = "10036";

        public const string deliverycouriercompanyController_add_new_delivery_courier_company = "10037";
        public const string deliverycouriercompanyController_inactivate_delivery_courier_company = "10038";
        public const string deliverycouriercompanyController_get_delivery_courier_company_all = "10039";
        public const string deliverycouriercompanyController_get_delivery_courier_company_single = "10040";

        public const string departmentController_add_new_department = "10041";
        public const string departmentController_inactivate_department = "10042";
        public const string departmentController_get_department_all = "10043";
        public const string departmentController_get_department_single = "10044";

        public const string departmentdeviceboxController_add_new_departmentdevicebox = "10045";
        public const string departmentdeviceboxController_inactivate_departmentdevicebox = "10046";
        public const string departmentdeviceboxController_get_departmentdevicebox_all = "10047";
        public const string departmentdeviceboxController_get_departmentdevicebox_single = "10048";

        //------

        public const string departmentpaymentchargecodeController_add_new_departmentpcc = "10049";
        public const string departmentpaymentchargecodeController_inactivate_departmentpcc = "10050";
        public const string departmentpaymentchargecodeController_get_departmentpcc_all = "10051";
        public const string departmentpaymentchargecodeController_get_departmentpcc_single = "10052";

        public const string deviceController_add_new_device = "10053";
        public const string deviceController_inactivate_device = "10054";
        public const string deviceController_get_device_all = "10055";
        public const string deviceController_get_device_single = "10056";

        public const string devicetypeController_add_new_device_type = "10057";
        public const string devicetypeController_inactivate_device_type = "10058";
        public const string devicetypeController_get_device_type_single = "10059";
        public const string devicetypeController_get_device_type_all = "10060";

        public const string dropdownController_get_customers_dropdown_by_user = "10061";
        public const string dropdownController_get_business_unit_dropdown_by_user = "10062";
        public const string dropdownController_get_department_dropdown_by_user = "10063";
        public const string dropdownController_get_location_dropdown_by_user = "10064";
        public const string dropdownController_get_vendor_dropdown_by_user = "10065";
        public const string dropdownController_get_Containerdptype_dropdown_by_user = "10066";
        public const string dropdownController_get_user_transnational_groups_dropdown_by_user = "10067";
        public const string dropdownController_get_user_customer_groups_dropdown_by_user = "10068";

        public const string kioskvendormasterController_add_new_kiosk_vendor = "10069";
        public const string kioskvendormasterController_inactivate_kiosk_vendor = "10070";
        public const string kioskvendormasterController_get_kiosk_vendor_all = "10071";
        public const string kioskvendormasterController_get_kiosk_vendor_single = "10072";

        public const string locationController_get_location_all = "10073";
        public const string locationController_get_location_single = "10074";

        public const string mailtypeController_add_new_mailtype = "10075";
        public const string mailtypeController_inactivate_mailtype = "10076";
        public const string mailtypeController_get_mailtype_single = "10077";
        public const string mailtypeController_get_mailtype_all = "10078";

        public const string systemparameterController_get_system_parameter_all = "10079";
        public const string systemparameterController_get_system_parameter_single = "10080";

        public const string systemssettingsController_get_country_all = "10081";
        public const string systemssettingsController_get_country_single = "10082";
        public const string systemssettingsController_get_currency_all = "10083";
        public const string systemssettingsController_get_currency_single = "10084";

        public const string UserOtpController_send_otp_via_sms = "10085";
        public const string UserOtpController_SaveUserOtp = "10086";
        public const string UserOtpController_VerifyOTP = "10087";

        public const string RecieveController_get_batch_details = "10088";
        public const string RecieveController_insert_batch_submit = "10089";
        public const string RecieveController_get_batch_grid_details = "10090";
        public const string RecieveController_create_new_batch = "10091";
        public const string RecieveController_get_receiving_pending = "10102";

        public const string ProcessController_get_batch_details = "10092";
        public const string ProcessController_insert_batch_submit = "10093";
        public const string ProcessController_get_batch_grid_details = "10094";


        public const string ExceptionsController_modify_exceptions = "10095";
        public const string ExceptionsController_get_exceptions_details = "10096";
        public const string ExceptionsController_get_exceptions_grid_details = "10097";
        public const string ExceptionsController_modify_exceptionstatus = "10098";

        public const string EnquiryController_modify_Enquiry = "10099";
        public const string EnquiryController_get_Enquiry_details = "10100";
        public const string EnquiryController_get_Enquiry_grid_details = "10101";

        static Dictionary<string, string> AuditActionMapList = new Dictionary<string, string>();

        public static Dictionary<string, string> GetAuditActionMap_List()
        {
            AuditActionMap map = new AuditActionMap();

            Type type = map.GetType();
            FieldInfo[] props = type.GetFields();

            foreach (var prop in props)
            {
                AuditActionMapList.Add(prop.Name, prop.GetValue(map).ToString());
            }
            return AuditActionMapList;
        }
    }
}