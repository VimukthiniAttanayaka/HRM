using HRM_DAL.Models;
using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_DAL.Data
{
    public class DropDown_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnCustomersDropDownModelHead> get_customers_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            List<ReturnCustomersDropDownModelHead> objHeadList = new List<ReturnCustomersDropDownModelHead>();
            List<ReturnCustomersDropdownModel> objUserSList = new List<ReturnCustomersDropdownModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_customers_dropdown_by_user";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@USER_ID", getuserdrop.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        ReturnCustomersDropDownModelHead objHead = new ReturnCustomersDropDownModelHead
                        {
                            resp = true,
                            msg = "Get Dropdown"
                        };

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnCustomersDropdownModel objUserdrop = new ReturnCustomersDropdownModel
                                {
                                    CUS_ID = rdr["CUS_ID"].ToString(),
                                    CUS_CompanyName = rdr["CUS_CompanyName"].ToString()
                                };

                                objUserSList.Add(objUserdrop);

                                if (objHead.customersdrop == null)
                                {
                                    objHead.customersdrop = new List<ReturnCustomersDropdownModel>();
                                }
                                objHead.customersdrop.Add(objUserdrop);

                                objHeadList.Add(objHead);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                ReturnCustomersDropDownModelHead objHead = new ReturnCustomersDropDownModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DropDown_Data", "get_customers_dropdown_by_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DropDown_Data", "get_customers_dropdown_by_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DropDown_Data", "get_customers_dropdown_by_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DropDown_Data", "get_customers_dropdown_by_user", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objHeadList;
        }

        public static List<ReturnUserDeliveryCourierCompanyModelHead> get_user_delivery_courier_company_dropdown_by_user(DCCUserIdModel getuserdrop)
        {
            List<ReturnUserDeliveryCourierCompanyModelHead> objHeadList = new List<ReturnUserDeliveryCourierCompanyModelHead>();
            List<ReturnUserDeliveryCourierCompanyDropdownModel> objUserSList = new List<ReturnUserDeliveryCourierCompanyDropdownModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_delivery_courier_company_dropdown_by_user";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@USER_ID", getuserdrop.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DCC_Is_Local", getuserdrop.DCC_Is_Local);
                        cmd.Parameters["@DCC_Is_Local"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DCC_Is_Overseas", getuserdrop.DCC_Is_Overseas);
                        cmd.Parameters["@DCC_Is_Overseas"].Direction = ParameterDirection.Input;

                        ReturnUserDeliveryCourierCompanyModelHead objHead = new ReturnUserDeliveryCourierCompanyModelHead
                        {
                            resp = true,
                            msg = "Get Dropdown"
                        };

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnUserDeliveryCourierCompanyDropdownModel objUserdrop = new ReturnUserDeliveryCourierCompanyDropdownModel
                                {
                                    DCC_ID = rdr["DCC_ID"].ToString(),
                                    DCC_Name = rdr["DCC_Name"].ToString(),
                                    DCC_Is_Local = rdr["DCC_Is_Local"].ToString(),
                                    DCC_Is_Overseas = rdr["DCC_Is_Overseas"].ToString(),
                                    DCC_Status = rdr["DCC_Status"].ToString(),
                                };

                                objUserSList.Add(objUserdrop);

                                if (objHead.delivercompany == null)
                                {
                                    objHead.delivercompany = new List<ReturnUserDeliveryCourierCompanyDropdownModel>();
                                }
                                objHead.delivercompany.Add(objUserdrop);

                                objHeadList.Add(objHead);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                ReturnUserDeliveryCourierCompanyModelHead objHead = new ReturnUserDeliveryCourierCompanyModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DropDown_Data", "get_user_delivery_courier_company_dropdown_by_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DropDown_Data", "get_user_delivery_courier_company_dropdown_by_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DropDown_Data", "get_user_delivery_courier_company_dropdown_by_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DropDown_Data", "get_user_delivery_courier_company_dropdown_by_user", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objHeadList;
        }

        public static List<ReturnCustomersDropDownModelHead> get_customers_dropdown_by_user_reports(UserIdModel getuserdrop)//ok
        {
            List<ReturnCustomersDropDownModelHead> objHeadList = new List<ReturnCustomersDropDownModelHead>();
            List<ReturnCustomersDropdownModel> objUserSList = new List<ReturnCustomersDropdownModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "get_customers_dropdown_by_user_reports";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@USER_ID", getuserdrop.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@GroupID", getuserdrop.USERGROUP_ID);
                        cmd.Parameters["@GroupID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        ReturnCustomersDropDownModelHead objHead = new ReturnCustomersDropDownModelHead
                        {
                            resp = true,
                            msg = "Get Dropdown"
                        };

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            if (objHead.customersdrop == null)
                            {
                                objHead.customersdrop = new List<ReturnCustomersDropdownModel>();
                            }
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnCustomersDropdownModel objUserdrop = new ReturnCustomersDropdownModel
                                {
                                    CUS_ID = rdr["CUS_ID"].ToString(),
                                    CUS_CompanyName = rdr["CUS_CompanyName"].ToString()
                                };

                                //objUserSList.Add(objUserdrop);
                                objHead.customersdrop.Add(objUserdrop);
                            }

                            objHeadList.Add(objHead);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                ReturnCustomersDropDownModelHead objHead = new ReturnCustomersDropDownModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DropDown_Data", "get_customers_dropdown_by_user_reports", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DropDown_Data", "get_customers_dropdown_by_user_reports", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DropDown_Data", "get_customers_dropdown_by_user_reports", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DropDown_Data", "get_customers_dropdown_by_user_reports", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objHeadList;
        }

        public static List<ReturnBUDropDownModelHead> get_business_unit_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            List<ReturnBUDropDownModelHead> objHeadList = new List<ReturnBUDropDownModelHead>();
            List<ReturnBUDropdownModel> objList = new List<ReturnBUDropdownModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_business_unit_dropdown_by_user";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@USER_ID", getuserdrop.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        ReturnBUDropDownModelHead objHead = new ReturnBUDropDownModelHead
                        {
                            resp = true,
                            msg = "Get Dropdown"
                        };

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnBUDropdownModel objdrop = new ReturnBUDropdownModel
                                {
                                    BU_ID = rdr["BU_ID"].ToString(),
                                    BU_CompanyName = rdr["BU_CompanyName"].ToString()
                                };

                                objList.Add(objdrop);

                                if (objHead.businessunit == null)
                                {
                                    objHead.businessunit = new List<ReturnBUDropdownModel>();
                                }
                                objHead.businessunit.Add(objdrop);

                            }
                            objHeadList.Add(objHead);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                ReturnBUDropDownModelHead objHead = new ReturnBUDropDownModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DropDown_Data", "get_business_unit_dropdown_by_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DropDown_Data", "get_business_unit_dropdown_by_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DropDown_Data", "get_business_unit_dropdown_by_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DropDown_Data", "get_business_unit_dropdown_by_user", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objHeadList;
        }

        public static List<ReturnDepartmentDropDownModelHead> get_department_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            List<ReturnDepartmentDropDownModelHead> objHeadList = new List<ReturnDepartmentDropDownModelHead>();
            List<ReturnDepartmentDropdownModel> objList = new List<ReturnDepartmentDropdownModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_department_dropdown_by_user";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@USER_ID", getuserdrop.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        ReturnDepartmentDropDownModelHead objHead = new ReturnDepartmentDropDownModelHead
                        {
                            resp = true,
                            msg = "Get Dropdown"
                        };


                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnDepartmentDropdownModel objdrop = new ReturnDepartmentDropdownModel
                                {
                                    DPT_ID = rdr["DPT_ID"].ToString(),
                                    DPT_Name = rdr["DPT_Name"].ToString()
                                };

                                objList.Add(objdrop);

                                if (objHead.department == null)
                                {
                                    objHead.department = new List<ReturnDepartmentDropdownModel>();
                                }
                                objHead.department.Add(objdrop);

                            }
                            objHeadList.Add(objHead);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                ReturnDepartmentDropDownModelHead objHead = new ReturnDepartmentDropDownModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DropDown_Data", "get_department_dropdown_by_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DropDown_Data", "get_department_dropdown_by_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DropDown_Data", "get_department_dropdown_by_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DropDown_Data", "get_department_dropdown_by_user", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objHeadList;
        }

        public static List<ReturnlocationDropDownModelHead> get_location_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            List<ReturnlocationDropDownModelHead> objHeadList = new List<ReturnlocationDropDownModelHead>();
            List<ReturnlocationDropdownModel> objList = new List<ReturnlocationDropdownModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_location_dropdown_by_user";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@USER_ID", getuserdrop.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        ReturnlocationDropDownModelHead objHead = new ReturnlocationDropDownModelHead
                        {
                            resp = true,
                            msg = "Get Dropdown"
                        };

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnlocationDropdownModel objdrop = new ReturnlocationDropdownModel
                                {
                                    LOC_ID = rdr["LOC_ID"].ToString(),
                                    LOC_Name = rdr["LOC_Name"].ToString()
                                };

                                objList.Add(objdrop);

                                if (objHead.location == null)
                                {
                                    objHead.location = new List<ReturnlocationDropdownModel>();
                                }
                                objHead.location.Add(objdrop);

                            }
                            objHeadList.Add(objHead);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                ReturnlocationDropDownModelHead objHead = new ReturnlocationDropDownModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DropDown_Data", "get_location_dropdown_by_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DropDown_Data", "get_location_dropdown_by_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DropDown_Data", "get_location_dropdown_by_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DropDown_Data", "get_location_dropdown_by_user", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objHeadList;
        }

        public static List<ReturnVendorDropDownModelHead> get_vendor_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            List<ReturnVendorDropDownModelHead> objHeadList = new List<ReturnVendorDropDownModelHead>();
            List<ReturnVendorDropdownModel> objList = new List<ReturnVendorDropdownModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_kiosk_vendor_dropdown_by_user";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@USER_ID", getuserdrop.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        ReturnVendorDropDownModelHead objHead = new ReturnVendorDropDownModelHead
                        {
                            resp = true,
                            msg = "Get Dropdown"
                        };


                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnVendorDropdownModel objdrop = new ReturnVendorDropdownModel
                                {
                                    KV_ID = rdr["KV_ID"].ToString(),
                                    KV_CompanyName = rdr["KV_CompanyName"].ToString()
                                };

                                objList.Add(objdrop);

                                if (objHead.vendor == null)
                                {
                                    objHead.vendor = new List<ReturnVendorDropdownModel>();
                                }
                                objHead.vendor.Add(objdrop);

                            }
                            objHeadList.Add(objHead);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                ReturnVendorDropDownModelHead objHead = new ReturnVendorDropDownModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DropDown_Data", "get_vendor_dropdown_by_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DropDown_Data", "get_vendor_dropdown_by_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DropDown_Data", "get_vendor_dropdown_by_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DropDown_Data", "get_vendor_dropdown_by_user", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objHeadList;
        }

        public static List<ReturnContainerDPTypeModelHead> get_Containerdptype_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            List<ReturnContainerDPTypeModelHead> objHeadList = new List<ReturnContainerDPTypeModelHead>();
            List<ReturnContainerDPTypeDropdownModel> objList = new List<ReturnContainerDPTypeDropdownModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_container_dispatch_type_dropdowan_by_user";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@USER_ID", getuserdrop.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        ReturnContainerDPTypeModelHead objHead = new ReturnContainerDPTypeModelHead
                        {
                            resp = true,
                            msg = "Get Dropdown"
                        };

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnContainerDPTypeDropdownModel objdrop = new ReturnContainerDPTypeDropdownModel
                                {
                                    CT_ID = rdr["CT_ID"].ToString(),
                                    CT_Name = rdr["CT_Name"].ToString()
                                };

                                objList.Add(objdrop);

                                if (objHead.containerDPType == null)
                                {
                                    objHead.containerDPType = new List<ReturnContainerDPTypeDropdownModel>();
                                }
                                objHead.containerDPType.Add(objdrop);
                            }
                            objHeadList.Add(objHead);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                ReturnContainerDPTypeModelHead objHead = new ReturnContainerDPTypeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DropDown_Data", "get_Containerdptype_dropdown_by_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DropDown_Data", "get_Containerdptype_dropdown_by_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DropDown_Data", "get_Containerdptype_dropdown_by_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DropDown_Data", "get_Containerdptype_dropdown_by_user", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objHeadList;
        }

        public static List<ReturnUserTGroupsModelHead> get_user_transnational_groups_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            List<ReturnUserTGroupsModelHead> objHeadList = new List<ReturnUserTGroupsModelHead>();
            List<ReturnUserTGroupsDropdownModel> objList = new List<ReturnUserTGroupsDropdownModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_user_transnational_groups_dropdown_by_user";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@USER_ID", getuserdrop.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        ReturnUserTGroupsModelHead objHead = new ReturnUserTGroupsModelHead
                        {
                            resp = true,
                            msg = "Get Dropdown"
                        };

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnUserTGroupsDropdownModel objdrop = new ReturnUserTGroupsDropdownModel
                                {
                                    UGM_ID = rdr["UGM_ID"].ToString(),
                                    UGM_Name = rdr["UGM_Name"].ToString()
                                };

                                objList.Add(objdrop);

                                if (objHead.Usertgroups == null)
                                {
                                    objHead.Usertgroups = new List<ReturnUserTGroupsDropdownModel>();
                                }
                                objHead.Usertgroups.Add(objdrop);

                            }
                            objHeadList.Add(objHead);

                        }
                    }

                }
            }
            catch (Exception ex)
            {

                ReturnUserTGroupsModelHead objHead = new ReturnUserTGroupsModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DropDown_Data", "get_user_transnational_groups_dropdown_by_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DropDown_Data", "get_user_transnational_groups_dropdown_by_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DropDown_Data", "get_user_transnational_groups_dropdown_by_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DropDown_Data", "get_user_transnational_groups_dropdown_by_user", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objHeadList;
        }

        public static List<ReturnUserCustomerGroupsModelHead> get_user_customer_groups_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            List<ReturnUserCustomerGroupsModelHead> objHeadList = new List<ReturnUserCustomerGroupsModelHead>();
            List<ReturnUserCustomerGroupsDropdownModel> objList = new List<ReturnUserCustomerGroupsDropdownModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_user_customer_groups_dropdown_by_user";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@USER_ID", getuserdrop.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        ReturnUserCustomerGroupsModelHead objHead = new ReturnUserCustomerGroupsModelHead
                        {
                            resp = true,
                            msg = "Get Dropdown"
                        };

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnUserCustomerGroupsDropdownModel objdrop = new ReturnUserCustomerGroupsDropdownModel
                                {
                                    UGM_ID = rdr["UGM_ID"].ToString(),
                                    UGM_Name = rdr["UGM_Name"].ToString()
                                };

                                objList.Add(objdrop);

                                if (objHead.Usercgroups == null)
                                {
                                    objHead.Usercgroups = new List<ReturnUserCustomerGroupsDropdownModel>();
                                }
                                objHead.Usercgroups.Add(objdrop);

                            }
                            objHeadList.Add(objHead);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                ReturnUserCustomerGroupsModelHead objHead = new ReturnUserCustomerGroupsModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DropDown_Data", "get_user_customer_groups_dropdown_by_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DropDown_Data", "get_user_customer_groups_dropdown_by_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DropDown_Data", "get_user_customer_groups_dropdown_by_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DropDown_Data", "get_user_customer_groups_dropdown_by_user", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objHeadList;
        }

        public static List<ReturnDeviceIDDropDownModelHead> get_deviceid_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            List<ReturnDeviceIDDropDownModelHead> objHeadList = new List<ReturnDeviceIDDropDownModelHead>();
            List<ReturnDeviceIDDropdownModel> objList = new List<ReturnDeviceIDDropdownModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_deviceid_dropdown_by_user";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@USER_ID", getuserdrop.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        ReturnDeviceIDDropDownModelHead objHead = new ReturnDeviceIDDropDownModelHead
                        {
                            resp = true,
                            msg = "Get Dropdown"
                        };

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnDeviceIDDropdownModel objdrop = new ReturnDeviceIDDropdownModel
                                {
                                    DeviceNo = rdr["DeviceNo"].ToString(),
                                    //LOC_Name = rdr["LOC_Name"].ToString()
                                };

                                objList.Add(objdrop);

                                if (objHead.DeviceIDs == null)
                                {
                                    objHead.DeviceIDs = new List<ReturnDeviceIDDropdownModel>();
                                }
                                objHead.DeviceIDs.Add(objdrop);

                            }
                            objHeadList.Add(objHead);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                ReturnDeviceIDDropDownModelHead objHead = new ReturnDeviceIDDropDownModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DropDown_Data", "get_deviceid_dropdown_by_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DropDown_Data", "get_deviceid_dropdown_by_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DropDown_Data", "get_deviceid_dropdown_by_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DropDown_Data", "get_deviceid_dropdown_by_user", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objHeadList;
        }

        public static List<ReturnCPCodeDropDownModelHead> get_cpcode_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            List<ReturnCPCodeDropDownModelHead> objHeadList = new List<ReturnCPCodeDropDownModelHead>();
            List<ReturnCPCodeDropdownModel> objList = new List<ReturnCPCodeDropdownModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_cpcode_dropdown_by_user";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@USER_ID", getuserdrop.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        ReturnCPCodeDropDownModelHead objHead = new ReturnCPCodeDropDownModelHead
                        {
                            resp = true,
                            msg = "Get Dropdown"
                        };

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnCPCodeDropdownModel objdrop = new ReturnCPCodeDropdownModel
                                {
                                    DPT_CPCode = rdr["DPT_CPCode"].ToString(),
                                    //LOC_Name = rdr["LOC_Name"].ToString()
                                };

                                objList.Add(objdrop);

                                if (objHead.CPCodes == null)
                                {
                                    objHead.CPCodes = new List<ReturnCPCodeDropdownModel>();
                                }
                                objHead.CPCodes.Add(objdrop);

                            }
                            objHeadList.Add(objHead);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                ReturnCPCodeDropDownModelHead objHead = new ReturnCPCodeDropDownModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DropDown_Data", "get_cpcode_dropdown_by_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DropDown_Data", "get_cpcode_dropdown_by_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DropDown_Data", "get_cpcode_dropdown_by_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DropDown_Data", "get_cpcode_dropdown_by_user", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objHeadList;
        }

        public static List<ReturnThresholdsDropDownModelHead> get_Thresholds_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            List<ReturnThresholdsDropDownModelHead> objHeadList = new List<ReturnThresholdsDropDownModelHead>();
            //List<ReturnThresholdsDropdownModel> objList = new List<ReturnThresholdsDropdownModel>();

            //List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                ReturnThresholdsDropDownModelHead objHead = new ReturnThresholdsDropDownModelHead
                {
                    resp = true,
                    msg = "Get Dropdown"
                };

                if (objHead.Thresholds == null)
                {
                    objHead.Thresholds = new List<ReturnThresholdsDropdownModel>();
                }

                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_Thresholds_dropdown_by_user";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@USER_ID", getuserdrop.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;


                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnThresholdsDropdownModel objdrop = new ReturnThresholdsDropdownModel
                                {
                                    Code = rdr["Code"].ToString(),
                                    Value = rdr["Value"].ToString(),
                                    IsDefault = rdr["IsDefault"].ToString(),
                                };
                                objHead.Thresholds.Add(objdrop);
                            }

                        }
                    }

                }
                objHeadList.Add(objHead);
            }
            catch (Exception ex)
            {

                ReturnThresholdsDropDownModelHead objHead = new ReturnThresholdsDropDownModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DropDown_Data", "get_Thresholds_dropdown_by_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DropDown_Data", "get_Thresholds_dropdown_by_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DropDown_Data", "get_Thresholds_dropdown_by_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DropDown_Data", "get_Thresholds_dropdown_by_user", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objHeadList;
        }
       
    }
}








