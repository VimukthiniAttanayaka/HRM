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
    public class PerformanceAppriasalAnswers_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnPerformanceAppriasalAnswersModelHead> get_PerformanceAppriasalAnswers_single(PerformanceAppriasalAnswers model)//ok
        {
            List<ReturnPerformanceAppriasalAnswersModelHead> objPerformanceAppriasalAnswerHeadList = new List<ReturnPerformanceAppriasalAnswersModelHead>();
            ReturnPerformanceAppriasalAnswersModelHead objPerformanceAppriasalAnswerHead = new ReturnPerformanceAppriasalAnswersModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objPerformanceAppriasalAnswerHead.resp = false;
                objPerformanceAppriasalAnswerHead.IsAuthenticated = false;
                objPerformanceAppriasalAnswerHeadList.Add(objPerformanceAppriasalAnswerHead);
                return objPerformanceAppriasalAnswerHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_PerformanceAppriasalAnswers_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAAN_ID", model.PAAN_ID);
                        cmd.Parameters["@PAAN_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnPerformanceAppriasalAnswersModel objPerformanceAppriasalAnswer = new ReturnPerformanceAppriasalAnswersModel();

                                objPerformanceAppriasalAnswerHead.resp = true;
                                objPerformanceAppriasalAnswerHead.msg = "Get PerformanceAppriasalAnswer";

                                //objPerformanceAppriasalAnswer.PAAN_ID = rdr["PAAN_ID"].ToString();
                                //objPerformanceAppriasalAnswer.PAAN_LeaveAlotment = Convert.ToInt16(rdr["PAAN_LeaveAlotment"].ToString());
                                //objPerformanceAppriasalAnswer.PAAN_PerformanceAppriasalAnswer = rdr["PAAN_PerformanceAppriasalAnswer"].ToString();
                                //objPerformanceAppriasalAnswer.PAAN_Status = Convert.ToBoolean(rdr["PAAN_Status"].ToString());

                                if (objPerformanceAppriasalAnswerHead.PerformanceAppriasalAnswers == null)
                                {
                                    objPerformanceAppriasalAnswerHead.PerformanceAppriasalAnswers = new List<ReturnPerformanceAppriasalAnswersModel>();
                                }

                                objPerformanceAppriasalAnswerHead.PerformanceAppriasalAnswers.Add(objPerformanceAppriasalAnswer);

                                objPerformanceAppriasalAnswerHeadList.Add(objPerformanceAppriasalAnswerHead);
                            }

                        }
                        else
                        {
                            ReturnPerformanceAppriasalAnswersModel objPerformanceAppriasalAnswer = new ReturnPerformanceAppriasalAnswersModel();
                            objPerformanceAppriasalAnswerHead.resp = true;
                            objPerformanceAppriasalAnswerHead.msg = "";
                            objPerformanceAppriasalAnswerHeadList.Add(objPerformanceAppriasalAnswerHead);


                        }


                    }
                    return objPerformanceAppriasalAnswerHeadList;

                }
            }
            catch (Exception ex)
            {
                objPerformanceAppriasalAnswerHead = new ReturnPerformanceAppriasalAnswersModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objPerformanceAppriasalAnswerHeadList.Add(objPerformanceAppriasalAnswerHead);

                objError.WriteLog(0, "PerformanceAppriasalAnswer_Data", "get_PerformanceAppriasalAnswers_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PerformanceAppriasalAnswer_Data", "get_PerformanceAppriasalAnswers_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PerformanceAppriasalAnswer_Data", "get_PerformanceAppriasalAnswers_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PerformanceAppriasalAnswer_Data", "get_PerformanceAppriasalAnswers_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objPerformanceAppriasalAnswerHeadList;

        }

        public static List<ReturnPerformanceAppriasalAnswersModelHead> get_PerformanceAppriasalAnswers_all(PerformanceAppriasalAnswersSearchModel model)//ok
        {
            List<ReturnPerformanceAppriasalAnswersModelHead> objPerformanceAppriasalAnswerHeadList = new List<ReturnPerformanceAppriasalAnswersModelHead>();
            ReturnPerformanceAppriasalAnswersModelHead objPerformanceAppriasalAnswerHead = new ReturnPerformanceAppriasalAnswersModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objPerformanceAppriasalAnswerHead.resp = false;
                objPerformanceAppriasalAnswerHead.IsAuthenticated = false;
                objPerformanceAppriasalAnswerHeadList.Add(objPerformanceAppriasalAnswerHead);
                return objPerformanceAppriasalAnswerHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "get_PerformanceAppriasalAnswer_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAAN_ID", model.PAAN_ID);
                        cmd.Parameters["@PAAN_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnPerformanceAppriasalAnswersModel objPerformanceAppriasalAnswer = new ReturnPerformanceAppriasalAnswersModel();

                                objPerformanceAppriasalAnswerHead.resp = true;
                                objPerformanceAppriasalAnswerHead.msg = "Get PerformanceAppriasalAnswer";

                                objPerformanceAppriasalAnswer.PAAN_ID = rdr["PAAN_ID"].ToString();
                                //objPerformanceAppriasalAnswer.PAAN_LeaveAlotment = Convert.ToInt16(rdr["PAAN_LeaveAlotment"].ToString());
                                //objPerformanceAppriasalAnswer.PAAN_PerformanceAppriasalAnswer = rdr["PAAN_PerformanceAppriasalAnswer"].ToString();
                                objPerformanceAppriasalAnswer.PAAN_Status = Convert.ToBoolean(rdr["PAAN_Status"].ToString());

                                if (objPerformanceAppriasalAnswerHead.PerformanceAppriasalAnswers == null)
                                {
                                    objPerformanceAppriasalAnswerHead.PerformanceAppriasalAnswers = new List<ReturnPerformanceAppriasalAnswersModel>();
                                }

                                objPerformanceAppriasalAnswerHead.PerformanceAppriasalAnswers.Add(objPerformanceAppriasalAnswer);

                                objPerformanceAppriasalAnswerHeadList.Add(objPerformanceAppriasalAnswerHead);
                            }

                        }
                        else
                        {
                            ReturnPerformanceAppriasalAnswersModel objPerformanceAppriasalAnswer = new ReturnPerformanceAppriasalAnswersModel();
                            objPerformanceAppriasalAnswerHead.resp = true;
                            objPerformanceAppriasalAnswerHead.msg = "";
                            objPerformanceAppriasalAnswerHeadList.Add(objPerformanceAppriasalAnswerHead);


                        }


                    }
                    return objPerformanceAppriasalAnswerHeadList;

                }
            }
            catch (Exception ex)
            {
                objPerformanceAppriasalAnswerHead = new ReturnPerformanceAppriasalAnswersModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objPerformanceAppriasalAnswerHeadList.Add(objPerformanceAppriasalAnswerHead);

                objError.WriteLog(0, "PerformanceAppriasalAnswer_Data", "get_PerformanceAppriasalAnswer_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PerformanceAppriasalAnswer_Data", "get_PerformanceAppriasalAnswer_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PerformanceAppriasalAnswer_Data", "get_PerformanceAppriasalAnswer_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PerformanceAppriasalAnswer_Data", "get_PerformanceAppriasalAnswer_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objPerformanceAppriasalAnswerHeadList;

        }

        public static List<ReturnResponse> add_new_PerformanceAppriasalAnswers(PerformanceAppriasalAnswersModel item)//ok
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


                        cmd.CommandText = "sp_insert_PerformanceAppriasalAnswer";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAAN_ID", item.PAAN_ID);
                        cmd.Parameters["@PAAN_ID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "PerformanceAppriasalAnswer_Data", "add_new_PerformanceAppriasalAnswer", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PerformanceAppriasalAnswer_Data", "add_new_PerformanceAppriasalAnswer", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PerformanceAppriasalAnswer_Data", "add_new_PerformanceAppriasalAnswer", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PerformanceAppriasalAnswer_Data", "add_new_PerformanceAppriasalAnswer", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> modify_PerformanceAppriasalAnswers(PerformanceAppriasalAnswersModel item)//ok
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


                        cmd.CommandText = "sp_modify_PerformanceAppriasalAnswer";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAAN_ID", item.PAAN_ID);
                        cmd.Parameters["@PAAN_ID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "PerformanceAppriasalAnswer_Data", "add_new_PerformanceAppriasalAnswer", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PerformanceAppriasalAnswer_Data", "add_new_PerformanceAppriasalAnswer", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PerformanceAppriasalAnswer_Data", "add_new_PerformanceAppriasalAnswer", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PerformanceAppriasalAnswer_Data", "add_new_PerformanceAppriasalAnswer", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> inactivate_PerformanceAppriasalAnswers(InactivePAANModel item)//ok
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



                        cmd.CommandText = "sp_del_PerformanceAppriasalAnswer";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAAN_ID", item.PAAN_ID);
                        cmd.Parameters["@PAAN_ID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "PerformanceAppriasalAnswer_Data", "inactivate_PerformanceAppriasalAnswer", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PerformanceAppriasalAnswer_Data", "inactivate_PerformanceAppriasalAnswer", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PerformanceAppriasalAnswer_Data", "inactivate_PerformanceAppriasalAnswer", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PerformanceAppriasalAnswer_Data", "inactivate_PerformanceAppriasalAnswer", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }



        }
    }

}

