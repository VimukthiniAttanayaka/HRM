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
    }
}








