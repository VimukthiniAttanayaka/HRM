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
    public class MenuAccess_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnMenuAccessModelHead> get_MenuAccesss_single(MenuAccess model)//ok
        {
            List<ReturnMenuAccessModelHead> objMenuAccessHeadList = new List<ReturnMenuAccessModelHead>();
            ReturnMenuAccessModelHead objMenuAccessHead = new ReturnMenuAccessModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objMenuAccessHead.resp = false;
                objMenuAccessHead.IsAuthenticated = false;
                objMenuAccessHeadList.Add(objMenuAccessHead);
                return objMenuAccessHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_MenuAccesss_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UMA_MenuAccessID", model.UMA_MenuAccessID);
                        cmd.Parameters["@UMA_MenuAccessID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnMenuAccessModel objMenuAccess = new ReturnMenuAccessModel();

                                objMenuAccessHead.resp = true;
                                objMenuAccessHead.msg = "Get MenuAccess";

                                //objMenuAccess.UMA_MenuAccessID = rdr["UMA_MenuAccessID"].ToString();
                                //objMenuAccess.UMA_LeaveAlotment = Convert.ToInt16(rdr["UMA_LeaveAlotment"].ToString());
                                //objMenuAccess.UMA_MenuAccess = rdr["UMA_MenuAccess"].ToString();
                                //objMenuAccess.UMA_Status = Convert.ToBoolean(rdr["UMA_Status"].ToString());

                                if (objMenuAccessHead.MenuAccessGroup == null)
                                {
                                    objMenuAccessHead.MenuAccessGroup = new List<ReturnMenuAccessModel>();
                                }

                                objMenuAccessHead.MenuAccessGroup.Add(objMenuAccess);

                                objMenuAccessHeadList.Add(objMenuAccessHead);
                            }

                        }
                        else
                        {
                            ReturnMenuAccessModel objMenuAccess = new ReturnMenuAccessModel();
                            objMenuAccessHead.resp = true;
                            objMenuAccessHead.msg = "";
                            objMenuAccessHeadList.Add(objMenuAccessHead);


                        }


                    }
                    return objMenuAccessHeadList;

                }
            }
            catch (Exception ex)
            {
                objMenuAccessHead = new ReturnMenuAccessModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objMenuAccessHeadList.Add(objMenuAccessHead);

                objError.WriteLog(0, "MenuAccess_Data", "get_MenuAccesss_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "MenuAccess_Data", "get_MenuAccesss_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "MenuAccess_Data", "get_MenuAccesss_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "MenuAccess_Data", "get_MenuAccesss_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objMenuAccessHeadList;

        }

        public static List<ReturnMenuAccessModelHead> get_MenuAccess_all(MenuAccessSearchModel model)//ok
        {
            List<ReturnMenuAccessModelHead> objMenuAccessHeadList = new List<ReturnMenuAccessModelHead>();
            ReturnMenuAccessModelHead objMenuAccessHead = new ReturnMenuAccessModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objMenuAccessHead.resp = false;
                objMenuAccessHead.IsAuthenticated = false;
                objMenuAccessHeadList.Add(objMenuAccessHead);
                return objMenuAccessHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "get_MenuAccess_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UMA_MenuAccessID", model.UMA_MenuAccessID);
                        cmd.Parameters["@UMA_MenuAccessID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnMenuAccessModel objMenuAccess = new ReturnMenuAccessModel();

                                objMenuAccessHead.resp = true;
                                objMenuAccessHead.msg = "Get MenuAccess";

                                //objMenuAccess.UMA_MenuAccessID = rdr["UMA_MenuAccessID"].ToString();
                                //objMenuAccess.UMA_LeaveAlotment = Convert.ToInt16(rdr["UMA_LeaveAlotment"].ToString());
                                //objMenuAccess.UMA_MenuAccess = rdr["UMA_MenuAccess"].ToString();
                                //objMenuAccess.UMA_Status = Convert.ToBoolean(rdr["UMA_Status"].ToString());

                                if (objMenuAccessHead.MenuAccessGroup == null)
                                {
                                    objMenuAccessHead.MenuAccessGroup = new List<ReturnMenuAccessModel>();
                                }

                                objMenuAccessHead.MenuAccessGroup.Add(objMenuAccess);

                                objMenuAccessHeadList.Add(objMenuAccessHead);
                            }

                        }
                        else
                        {
                            ReturnMenuAccessModel objMenuAccess = new ReturnMenuAccessModel();
                            objMenuAccessHead.resp = true;
                            objMenuAccessHead.msg = "";
                            objMenuAccessHeadList.Add(objMenuAccessHead);


                        }


                    }
                    return objMenuAccessHeadList;

                }
            }
            catch (Exception ex)
            {
                objMenuAccessHead = new ReturnMenuAccessModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objMenuAccessHeadList.Add(objMenuAccessHead);

                objError.WriteLog(0, "MenuAccess_Data", "get_MenuAccess_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "MenuAccess_Data", "get_MenuAccess_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "MenuAccess_Data", "get_MenuAccess_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "MenuAccess_Data", "get_MenuAccess_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objMenuAccessHeadList;

        }

        public static List<ReturncustResponse> add_new_MenuAccess(MenuAccessModel item)//ok
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


                        cmd.CommandText = "sp_insert_MenuAccess";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UMA_MenuAccessID", item.UMA_MenuAccessID);
                        cmd.Parameters["@UMA_MenuAccessID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "MenuAccess_Data", "add_new_MenuAccess", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "MenuAccess_Data", "add_new_MenuAccess", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "MenuAccess_Data", "add_new_MenuAccess", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "MenuAccess_Data", "add_new_MenuAccess", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturncustResponse> modify_MenuAccess(MenuAccessModel item)//ok
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


                        cmd.CommandText = "sp_modify_MenuAccess";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UMA_MenuAccessID", item.UMA_MenuAccessID);
                        cmd.Parameters["@UMA_MenuAccessID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "MenuAccess_Data", "add_new_MenuAccess", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "MenuAccess_Data", "add_new_MenuAccess", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "MenuAccess_Data", "add_new_MenuAccess", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "MenuAccess_Data", "add_new_MenuAccess", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> inactivate_MenuAccess(InactiveUMAModel item)//ok
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



                        cmd.CommandText = "sp_del_MenuAccess";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UMA_MenuAccessID", item.UMA_MenuAccessID);
                        cmd.Parameters["@UMA_MenuAccessID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "MenuAccess_Data", "inactivate_MenuAccess", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "MenuAccess_Data", "inactivate_MenuAccess", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "MenuAccess_Data", "inactivate_MenuAccess", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "MenuAccess_Data", "inactivate_MenuAccess", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }



        }
    }

}

