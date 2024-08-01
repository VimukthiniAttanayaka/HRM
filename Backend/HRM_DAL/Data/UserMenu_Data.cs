using HRM_DAL.Models;
using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using Newtonsoft.Json;

namespace HRM_DAL.Data
{
    public class UserMenu_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnUserMenuModelHead> get_UserMenus_single(UserMenu model)//ok
        {
            List<ReturnUserMenuModelHead> objUserMenuHeadList = new List<ReturnUserMenuModelHead>();
            ReturnUserMenuModelHead objUserMenuHead = new ReturnUserMenuModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objUserMenuHead.resp = false;
                objUserMenuHead.IsAuthenticated = false;
                objUserMenuHeadList.Add(objUserMenuHead);
                return objUserMenuHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_UserMenus_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UUM_UserMenuID", model.UUM_UserMenuID);
                        cmd.Parameters["@UUM_UserMenuID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnUserMenuModel objUserMenu = new ReturnUserMenuModel();

                                objUserMenuHead.resp = true;
                                objUserMenuHead.msg = "Get UserMenu";

                                //objUserMenu.UUM_UserMenuID = rdr["UUM_UserMenuID"].ToString();
                                //objUserMenu.UUM_LeaveAlotment = Convert.ToInt16(rdr["UUM_LeaveAlotment"].ToString());
                                //objUserMenu.UUM_UserMenu = rdr["UUM_UserMenu"].ToString();
                                //objUserMenu.UUM_Status = Convert.ToBoolean(rdr["UUM_Status"].ToString());

                                if (objUserMenuHead.UserMenu == null)
                                {
                                    objUserMenuHead.UserMenu = new List<ReturnUserMenuModel>();
                                }

                                objUserMenuHead.UserMenu.Add(objUserMenu);

                                objUserMenuHeadList.Add(objUserMenuHead);
                            }

                        }
                        else
                        {
                            ReturnUserMenuModel objUserMenu = new ReturnUserMenuModel();
                            objUserMenuHead.resp = true;
                            objUserMenuHead.msg = "";
                            objUserMenuHeadList.Add(objUserMenuHead);


                        }


                    }
                    return objUserMenuHeadList;

                }
            }
            catch (Exception ex)
            {
                objUserMenuHead = new ReturnUserMenuModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserMenuHeadList.Add(objUserMenuHead);

                objError.WriteLog(0, "UserMenu_Data", "get_UserMenus_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserMenu_Data", "get_UserMenus_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserMenu_Data", "get_UserMenus_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserMenu_Data", "get_UserMenus_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objUserMenuHeadList;

        }

        public static List<ReturnUserMenuModelHead> get_UserMenu_all(UserMenuSearchModel model)//ok
        {
            List<ReturnUserMenuModelHead> objUserMenuHeadList = new List<ReturnUserMenuModelHead>();
            ReturnUserMenuModelHead objUserMenuHead = new ReturnUserMenuModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objUserMenuHead.resp = false;
                objUserMenuHead.IsAuthenticated = false;
                objUserMenuHeadList.Add(objUserMenuHead);
                return objUserMenuHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "get_UserMenu_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UUM_UserMenuID", model.UUM_UserMenuID);
                        cmd.Parameters["@UUM_UserMenuID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnUserMenuModel objUserMenu = new ReturnUserMenuModel();

                                objUserMenuHead.resp = true;
                                objUserMenuHead.msg = "Get UserMenu";

                                //objUserMenu.UUM_UserMenuID = rdr["UUM_UserMenuID"].ToString();
                                //objUserMenu.UUM_LeaveAlotment = Convert.ToInt16(rdr["UUM_LeaveAlotment"].ToString());
                                //objUserMenu.UUM_UserMenu = rdr["UUM_UserMenu"].ToString();
                                //objUserMenu.UUM_Status = Convert.ToBoolean(rdr["UUM_Status"].ToString());

                                if (objUserMenuHead.UserMenu == null)
                                {
                                    objUserMenuHead.UserMenu = new List<ReturnUserMenuModel>();
                                }

                                objUserMenuHead.UserMenu.Add(objUserMenu);

                                objUserMenuHeadList.Add(objUserMenuHead);
                            }

                        }
                        else
                        {
                            ReturnUserMenuModel objUserMenu = new ReturnUserMenuModel();
                            objUserMenuHead.resp = true;
                            objUserMenuHead.msg = "";
                            objUserMenuHeadList.Add(objUserMenuHead);


                        }


                    }
                    return objUserMenuHeadList;

                }
            }
            catch (Exception ex)
            {
                objUserMenuHead = new ReturnUserMenuModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserMenuHeadList.Add(objUserMenuHead);

                objError.WriteLog(0, "UserMenu_Data", "get_UserMenu_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserMenu_Data", "get_UserMenu_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserMenu_Data", "get_UserMenu_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserMenu_Data", "get_UserMenu_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objUserMenuHeadList;

        }

        public static List<ReturncustResponse> add_new_UserMenu(UserMenuModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();
            ReturncustResponse objCustHead = new ReturncustResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objCustHead.resp = false;
                objCustHead.IsAuthenticated = false;
                objCustHeadList.Add(objCustHead);
                return objCustHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_insert_UserMenu";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UUM_UserMenuID", item.UUM_UserMenuID);
                        cmd.Parameters["@UUM_UserMenuID"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_CompanyName", item.CUS_CompanyName);
                        //cmd.Parameters["@CUS_CompanyName"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_BlockBuildingNo", item.CUS_Adrs_BlockBuildingNo);
                        //cmd.Parameters["@CUS_Adrs_BlockBuildingNo"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_BuildingName", item.CUS_Adrs_BuildingName);
                        //cmd.Parameters["@CUS_Adrs_BuildingName"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_UnitNumber", item.CUS_Adrs_UnitNumber);
                        //cmd.Parameters["@CUS_Adrs_UnitNumber"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_StreetName", item.CUS_Adrs_StreetName);
                        //cmd.Parameters["@CUS_Adrs_StreetName"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_City", item.CUS_Adrs_City);
                        //cmd.Parameters["@CUS_Adrs_City"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_CountryCode", item.CUS_Adrs_CountryCode);
                        //cmd.Parameters["@CUS_Adrs_CountryCode"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_PostalCode", item.CUS_Adrs_PostalCode);
                        //cmd.Parameters["@CUS_Adrs_PostalCode"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_ContactPerson", item.CUS_ContactPerson);
                        //cmd.Parameters["@CUS_ContactPerson"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_ContactNumber", item.CUS_ContactNumber);
                        //cmd.Parameters["@CUS_ContactNumber"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_PinOrPwd", item.CUS_PinOrPwd);
                        //cmd.Parameters["@CUS_PinOrPwd"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_OTP_By_SMS", item.CUS_OTP_By_SMS);
                        //cmd.Parameters["@CUS_OTP_By_SMS"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_OTP_By_Email", item.CUS_OTP_By_Email);
                        //cmd.Parameters["@CUS_OTP_By_Email"].Direction = ParameterDirection.Input;

                        string mailtypes = "";

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                objCustHead = new ReturncustResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objCustHeadList.Add(objCustHead);

                            }
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                objCustHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objCustHead);

                objError.WriteLog(0, "UserMenu_Data", "add_new_UserMenu", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserMenu_Data", "add_new_UserMenu", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserMenu_Data", "add_new_UserMenu", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserMenu_Data", "add_new_UserMenu", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturncustResponse> modify_UserMenu(UserMenuModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();
            ReturncustResponse objCustHead = new ReturncustResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objCustHead.resp = false;
                objCustHead.IsAuthenticated = false;
                objCustHeadList.Add(objCustHead);
                return objCustHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_modify_UserMenu";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UUM_UserMenuID", item.UUM_UserMenuID);
                        cmd.Parameters["@UUM_UserMenuID"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_CompanyName", item.CUS_CompanyName);
                        //cmd.Parameters["@CUS_CompanyName"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_BlockBuildingNo", item.CUS_Adrs_BlockBuildingNo);
                        //cmd.Parameters["@CUS_Adrs_BlockBuildingNo"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_BuildingName", item.CUS_Adrs_BuildingName);
                        //cmd.Parameters["@CUS_Adrs_BuildingName"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_UnitNumber", item.CUS_Adrs_UnitNumber);
                        //cmd.Parameters["@CUS_Adrs_UnitNumber"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_StreetName", item.CUS_Adrs_StreetName);
                        //cmd.Parameters["@CUS_Adrs_StreetName"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_City", item.CUS_Adrs_City);
                        //cmd.Parameters["@CUS_Adrs_City"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_CountryCode", item.CUS_Adrs_CountryCode);
                        //cmd.Parameters["@CUS_Adrs_CountryCode"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_PostalCode", item.CUS_Adrs_PostalCode);
                        //cmd.Parameters["@CUS_Adrs_PostalCode"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_ContactPerson", item.CUS_ContactPerson);
                        //cmd.Parameters["@CUS_ContactPerson"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_ContactNumber", item.CUS_ContactNumber);
                        //cmd.Parameters["@CUS_ContactNumber"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_PinOrPwd", item.CUS_PinOrPwd);
                        //cmd.Parameters["@CUS_PinOrPwd"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_OTP_By_SMS", item.CUS_OTP_By_SMS);
                        //cmd.Parameters["@CUS_OTP_By_SMS"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_OTP_By_Email", item.CUS_OTP_By_Email);
                        //cmd.Parameters["@CUS_OTP_By_Email"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Status", item.CUS_Status);
                        //cmd.Parameters["@CUS_Status"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                objCustHead = new ReturncustResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objCustHeadList.Add(objCustHead);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objCustHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objCustHead);

                objError.WriteLog(0, "UserMenu_Data", "add_new_UserMenu", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserMenu_Data", "add_new_UserMenu", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserMenu_Data", "add_new_UserMenu", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserMenu_Data", "add_new_UserMenu", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> inactivate_UserMenu(InactiveUUMModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            ReturnResponse objUserHead = new ReturnResponse();
            List<SPResponse> objResponseList = new List<SPResponse>();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objUserHead.resp = false;
                objUserHead.IsAuthenticated = false;
                objUserHeadList.Add(objUserHead);
                return objUserHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;



                        cmd.CommandText = "sp_del_UserMenu";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UUM_UserMenuID", item.UUM_UserMenuID);
                        cmd.Parameters["@UUM_UserMenuID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;



                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                objUserHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objUserHeadList.Add(objUserHead);

                            }
                        }
                        return objUserHeadList;
                    }
                    return objUserHeadList;
                }
            }
            catch (Exception ex)
            {
                objUserHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "UserMenu_Data", "inactivate_UserMenu", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserMenu_Data", "inactivate_UserMenu", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserMenu_Data", "inactivate_UserMenu", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserMenu_Data", "inactivate_UserMenu", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }



        }
    }

}

