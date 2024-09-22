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
    public class PerformanceAppriasalApproval_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnPerformanceAppriasalApprovalModelHead> get_PerformanceAppriasalApprovals_single(PerformanceAppriasalApproval model)//ok
        {
            List<ReturnPerformanceAppriasalApprovalModelHead> objPerformanceAppriasalApprovalHeadList = new List<ReturnPerformanceAppriasalApprovalModelHead>();
            ReturnPerformanceAppriasalApprovalModelHead objPerformanceAppriasalApprovalHead = new ReturnPerformanceAppriasalApprovalModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objPerformanceAppriasalApprovalHead.resp = false;
                objPerformanceAppriasalApprovalHead.IsAuthenticated = false;
                objPerformanceAppriasalApprovalHeadList.Add(objPerformanceAppriasalApprovalHead);
                return objPerformanceAppriasalApprovalHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_PerformanceAppriasalApprovals_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAAP_ID", model.PAAP_ID);
                        cmd.Parameters["@PAAP_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnPerformanceAppriasalApprovalModel objPerformanceAppriasalApproval = new ReturnPerformanceAppriasalApprovalModel();

                                objPerformanceAppriasalApprovalHead.resp = true;
                                objPerformanceAppriasalApprovalHead.msg = "Get PerformanceAppriasalApproval";

                                //objPerformanceAppriasalApproval.PAAP_PerformanceAppriasalApprovalID = rdr["PAAP_PerformanceAppriasalApprovalID"].ToString();
                                //objPerformanceAppriasalApproval.PAAP_LeaveAlotment = Convert.ToInt16(rdr["PAAP_LeaveAlotment"].ToString());
                                //objPerformanceAppriasalApproval.PAAP_PerformanceAppriasalApproval = rdr["PAAP_PerformanceAppriasalApproval"].ToString();
                                //objPerformanceAppriasalApproval.PAAP_Status = Convert.ToBoolean(rdr["PAAP_Status"].ToString());

                                if (objPerformanceAppriasalApprovalHead.PerformanceAppriasalApproval == null)
                                {
                                    objPerformanceAppriasalApprovalHead.PerformanceAppriasalApproval = new List<ReturnPerformanceAppriasalApprovalModel>();
                                }

                                objPerformanceAppriasalApprovalHead.PerformanceAppriasalApproval.Add(objPerformanceAppriasalApproval);

                                objPerformanceAppriasalApprovalHeadList.Add(objPerformanceAppriasalApprovalHead);
                            }

                        }
                        else
                        {
                            ReturnPerformanceAppriasalApprovalModel objPerformanceAppriasalApproval = new ReturnPerformanceAppriasalApprovalModel();
                            objPerformanceAppriasalApprovalHead.resp = true;
                            objPerformanceAppriasalApprovalHead.msg = "";
                            objPerformanceAppriasalApprovalHeadList.Add(objPerformanceAppriasalApprovalHead);


                        }


                    }
                    return objPerformanceAppriasalApprovalHeadList;

                }
            }
            catch (Exception ex)
            {
                objPerformanceAppriasalApprovalHead = new ReturnPerformanceAppriasalApprovalModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objPerformanceAppriasalApprovalHeadList.Add(objPerformanceAppriasalApprovalHead);

                objError.WriteLog(0, "PerformanceAppriasalApproval_Data", "get_PerformanceAppriasalApprovals_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PerformanceAppriasalApproval_Data", "get_PerformanceAppriasalApprovals_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PerformanceAppriasalApproval_Data", "get_PerformanceAppriasalApprovals_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PerformanceAppriasalApproval_Data", "get_PerformanceAppriasalApprovals_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objPerformanceAppriasalApprovalHeadList;

        }

        public static List<ReturnPerformanceAppriasalApprovalModelHead> get_PerformanceAppriasalApproval_all(PerformanceAppriasalApprovalSearchModel model)//ok
        {
            List<ReturnPerformanceAppriasalApprovalModelHead> objPerformanceAppriasalApprovalHeadList = new List<ReturnPerformanceAppriasalApprovalModelHead>();
            ReturnPerformanceAppriasalApprovalModelHead objPerformanceAppriasalApprovalHead = new ReturnPerformanceAppriasalApprovalModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objPerformanceAppriasalApprovalHead.resp = false;
                objPerformanceAppriasalApprovalHead.IsAuthenticated = false;
                objPerformanceAppriasalApprovalHeadList.Add(objPerformanceAppriasalApprovalHead);
                return objPerformanceAppriasalApprovalHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "get_PerformanceAppriasalApproval_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAAP_ID", model.PAAP_ID);
                        cmd.Parameters["@PAAP_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnPerformanceAppriasalApprovalModel objPerformanceAppriasalApproval = new ReturnPerformanceAppriasalApprovalModel();

                                objPerformanceAppriasalApprovalHead.resp = true;
                                objPerformanceAppriasalApprovalHead.msg = "Get PerformanceAppriasalApproval";

                                objPerformanceAppriasalApproval.PAAP_ID = rdr["PAAP_ID"].ToString();
                                //objPerformanceAppriasalApproval.PAAP_LeaveAlotment = Convert.ToInt16(rdr["PAAP_LeaveAlotment"].ToString());
                                //objPerformanceAppriasalApproval.PAAP_PerformanceAppriasalApproval = rdr["PAAP_PerformanceAppriasalApproval"].ToString();
                                objPerformanceAppriasalApproval.PAAP_Status = Convert.ToBoolean(rdr["PAAP_Status"].ToString());

                                if (objPerformanceAppriasalApprovalHead.PerformanceAppriasalApproval == null)
                                {
                                    objPerformanceAppriasalApprovalHead.PerformanceAppriasalApproval = new List<ReturnPerformanceAppriasalApprovalModel>();
                                }

                                objPerformanceAppriasalApprovalHead.PerformanceAppriasalApproval.Add(objPerformanceAppriasalApproval);

                                objPerformanceAppriasalApprovalHeadList.Add(objPerformanceAppriasalApprovalHead);
                            }

                        }
                        else
                        {
                            ReturnPerformanceAppriasalApprovalModel objPerformanceAppriasalApproval = new ReturnPerformanceAppriasalApprovalModel();
                            objPerformanceAppriasalApprovalHead.resp = true;
                            objPerformanceAppriasalApprovalHead.msg = "";
                            objPerformanceAppriasalApprovalHeadList.Add(objPerformanceAppriasalApprovalHead);


                        }


                    }
                    return objPerformanceAppriasalApprovalHeadList;

                }
            }
            catch (Exception ex)
            {
                objPerformanceAppriasalApprovalHead = new ReturnPerformanceAppriasalApprovalModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objPerformanceAppriasalApprovalHeadList.Add(objPerformanceAppriasalApprovalHead);

                objError.WriteLog(0, "PerformanceAppriasalApproval_Data", "get_PerformanceAppriasalApproval_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PerformanceAppriasalApproval_Data", "get_PerformanceAppriasalApproval_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PerformanceAppriasalApproval_Data", "get_PerformanceAppriasalApproval_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PerformanceAppriasalApproval_Data", "get_PerformanceAppriasalApproval_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objPerformanceAppriasalApprovalHeadList;

        }

        public static List<ReturnResponse> add_new_PerformanceAppriasalApproval(PerformanceAppriasalApprovalModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();
            ReturnResponse objCustHead = new ReturnResponse();

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


                        cmd.CommandText = "sp_insert_PerformanceAppriasalApproval";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAAP_ID", item.PAAP_ID);
                        cmd.Parameters["@PAAP_ID"].Direction = ParameterDirection.Input;

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
                                objCustHead = new ReturnResponse
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
                objCustHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objCustHead);

                objError.WriteLog(0, "PerformanceAppriasalApproval_Data", "add_new_PerformanceAppriasalApproval", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PerformanceAppriasalApproval_Data", "add_new_PerformanceAppriasalApproval", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PerformanceAppriasalApproval_Data", "add_new_PerformanceAppriasalApproval", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PerformanceAppriasalApproval_Data", "add_new_PerformanceAppriasalApproval", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> modify_PerformanceAppriasalApproval(PerformanceAppriasalApprovalModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();
            ReturnResponse objCustHead = new ReturnResponse();

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


                        cmd.CommandText = "sp_modify_PerformanceAppriasalApproval";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAAP_ID", item.PAAP_ID);
                        cmd.Parameters["@PAAP_ID"].Direction = ParameterDirection.Input;

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
                                objCustHead = new ReturnResponse
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
                objCustHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objCustHead);

                objError.WriteLog(0, "PerformanceAppriasalApproval_Data", "add_new_PerformanceAppriasalApproval", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PerformanceAppriasalApproval_Data", "add_new_PerformanceAppriasalApproval", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PerformanceAppriasalApproval_Data", "add_new_PerformanceAppriasalApproval", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PerformanceAppriasalApproval_Data", "add_new_PerformanceAppriasalApproval", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> inactivate_PerformanceAppriasalApproval(InactivePAAPModel item)//ok
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



                        cmd.CommandText = "sp_del_PerformanceAppriasalApproval";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAAP_ID", item.PAAP_ID);
                        cmd.Parameters["@PAAP_ID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "PerformanceAppriasalApproval_Data", "inactivate_PerformanceAppriasalApproval", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PerformanceAppriasalApproval_Data", "inactivate_PerformanceAppriasalApproval", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PerformanceAppriasalApproval_Data", "inactivate_PerformanceAppriasalApproval", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PerformanceAppriasalApproval_Data", "inactivate_PerformanceAppriasalApproval", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }



        }
    }

}

