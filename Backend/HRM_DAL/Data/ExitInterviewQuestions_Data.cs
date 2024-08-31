using error_handler;
using ExcelDataReader;
using HRM_DAL.Models;
using HRM_DAL.Models.RequestModels;
using HRM_DAL.Models.ResponceModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using utility_handler.Data;

namespace HRM_DAL.Data
{
    public partial class ExitInterviewQuestions_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnResponse> add_new_ExitInterviewQuestions(ExitInterviewQuestionsModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();
            ReturnResponse objHead = new ReturnResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objHead.resp = false;
                objHead.IsAuthenticated = false;
                objHeadList.Add(objHead);
                return objHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_insert_ExitInterviewQuestions";
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@EIEIQ_ExitInterviewQuestionsID", item.EIEIQ_ExitInterviewQuestionsID);
                        //cmd.Parameters["@EIEIQ_ExitInterviewQuestionsID"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@EIEIQ_ExitInterviewQuestions", item.EIEIQ_ExitInterviewQuestions);
                        //cmd.Parameters["@EIEIQ_ExitInterviewQuestions"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@EIEIQ_LocationID", item.EIEIQ_LocationID);
                        //cmd.Parameters["@EIEIQ_LocationID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EIEIQ_Status", item.EIEIQ_Status);
                        cmd.Parameters["@EIEIQ_Status"].Direction = ParameterDirection.Input;

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
                                objHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                              
                                objHeadList.Add(objHead);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "ExitInterviewQuestions_Data", "add_new_ExitInterviewQuestions", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ExitInterviewQuestions_Data", "add_new_ExitInterviewQuestions", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ExitInterviewQuestions_Data", "add_new_ExitInterviewQuestions", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ExitInterviewQuestions_Data", "add_new_ExitInterviewQuestions", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        public static List<ReturnResponse> modify_ExitInterviewQuestions(ExitInterviewQuestionsModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();
            List<SPResponse> objResponseList = new List<SPResponse>();
            ReturnResponse objHead = new ReturnResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objHead.resp = false;
                objHead.IsAuthenticated = false;
                objHeadList.Add(objHead);
                return objHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_modify_ExitInterviewQuestions";
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@EIEIQ_ExitInterviewQuestionsID", item.EIEIQ_ExitInterviewQuestionsID);
                        //cmd.Parameters["@EIEIQ_ExitInterviewQuestionsID"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@EIEIQ_ExitInterviewQuestions", item.EIEIQ_ExitInterviewQuestions);
                        //cmd.Parameters["@EIEIQ_ExitInterviewQuestions"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@EIEIQ_LocationID", item.EIEIQ_LocationID);
                        //cmd.Parameters["@EIEIQ_LocationID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EIEIQ_Status", item.EIEIQ_Status);
                        cmd.Parameters["@EIEIQ_Status"].Direction = ParameterDirection.Input;

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
                                objHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                             
                                objHeadList.Add(objHead);


                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "ExitInterviewQuestions_Data", "modify_ExitInterviewQuestions", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ExitInterviewQuestions_Data", "modify_ExitInterviewQuestions", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ExitInterviewQuestions_Data", "modify_ExitInterviewQuestions", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ExitInterviewQuestions_Data", "modify_ExitInterviewQuestions", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        public static List<ReturnResponse> inactivate_ExitInterviewQuestions(InactiveExitInterviewQuestionsModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();
            ReturnResponse objHead = new ReturnResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objHead.resp = false;
                objHead.IsAuthenticated = false;
                objHeadList.Add(objHead);
                return objHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_del_ExitInterviewQuestions";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EIEIQ_ID", item.EIEIQ_ID);
                        cmd.Parameters["@EIEIQ_ID"].Direction = ParameterDirection.Input;

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
                                objHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                             
                                objHeadList.Add(objHead);
                            }

                        }
                    }
                    return objHeadList;
                }
            }
            catch (Exception ex)
            {
                objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "ExitInterviewQuestions_Data", "inactivate_ExitInterviewQuestions", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ExitInterviewQuestions_Data", "inactivate_ExitInterviewQuestions", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ExitInterviewQuestions_Data", "inactivate_ExitInterviewQuestions", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ExitInterviewQuestions_Data", "inactivate_ExitInterviewQuestions", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objHeadList;
            }
        }

        public static List<ReturExitInterviewQuestionsModelHead> get_ExitInterviewQuestions_all(GetExitInterviewQuestionsAllModel item)//ok
        {
            List<ReturExitInterviewQuestionsModelHead> objHeadList = new List<ReturExitInterviewQuestionsModelHead>();
            ReturExitInterviewQuestionsModelHead objHead = new ReturExitInterviewQuestionsModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objHead.resp = false;
                objHead.IsAuthenticated = false;
                objHeadList.Add(objHead);
                return objHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_ExitInterviewQuestions_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@PAGE_NO", item.PAGE_NO);
                        //cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", item.PAGE_RECORDS_COUNT);
                        //cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnExitInterviewQuestionsModel objData = new ReturnExitInterviewQuestionsModel();

                                objHead.resp = true;
                                objHead.msg = "ExitInterviewQuestions";

                                objData.EIEIQ_ID = Convert.ToInt32(rdr["EIEIQ_ID"].ToString());
                                objData.EIEIQ_Description = rdr["EIEIQ_Description"].ToString();
                                objData.EIEIQ_EntryType = rdr["EIEIQ_EntryType"].ToString();
                                objData.EIEIQ_Status = Convert.ToBoolean(rdr["EIEIQ_Status"].ToString());

                                if (objHead.ExitInterviewQuestions == null)
                                {
                                    objHead.ExitInterviewQuestions = new List<ReturnExitInterviewQuestionsModel>();
                                }

                                objHead.ExitInterviewQuestions.Add(objData);

                            }
                            objHeadList.Add(objHead);

                        }
                        else
                        {
                            objHead.resp = true;
                            objHead.msg = "";
                            objHeadList.Add(objHead);
                        }


                    }
                    return objHeadList;
                }
            }
            catch (Exception ex)
            {

                objHead = new ReturExitInterviewQuestionsModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "ExitInterviewQuestions_Data", "get_ExitInterviewQuestions_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ExitInterviewQuestions_Data", "get_ExitInterviewQuestions_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ExitInterviewQuestions_Data", "get_ExitInterviewQuestions_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ExitInterviewQuestions_Data", "get_ExitInterviewQuestions_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        public static List<ReturExitInterviewQuestionsModelHead> get_ExitInterviewQuestions_single(GetExitInterviewQuestionsSingleModel item)
        {
            List<ReturExitInterviewQuestionsModelHead> objHeadList = new List<ReturExitInterviewQuestionsModelHead>();
            ReturExitInterviewQuestionsModelHead objHead = new ReturExitInterviewQuestionsModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objHead.resp = false;
                objHead.IsAuthenticated = false;
                objHeadList.Add(objHead);
                return objHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_ExitInterviewQuestions_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EIEIQ_ID", item.EIEIQ_ID);
                        cmd.Parameters["@EIEIQ_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnExitInterviewQuestionsModel objData = new ReturnExitInterviewQuestionsModel();


                                objHead.resp = true;
                                objHead.msg = "ExitInterviewQuestions";

                                objData.EIEIQ_ID = Convert.ToInt32(rdr["EIEIQ_ID"].ToString());
                                objData.EIEIQ_Description = rdr["EIEIQ_Description"].ToString();
                                objData.EIEIQ_EntryType = rdr["EIEIQ_EntryType"].ToString();
                                objData.EIEIQ_Status = Convert.ToBoolean(rdr["EIEIQ_Status"].ToString());

                                if (objHead.ExitInterviewQuestions == null)
                                {
                                    objHead.ExitInterviewQuestions = new List<ReturnExitInterviewQuestionsModel>();
                                }

                                objHead.ExitInterviewQuestions.Add(objData);
                            }
                            objHeadList.Add(objHead);

                        }
                        else
                        {
                            objHead.resp = true;
                            objHead.msg = "";
                            objHeadList.Add(objHead);


                        }

                    }

                    return objHeadList;
                }
            }
            catch (Exception ex)
            {
                objHead = new ReturExitInterviewQuestionsModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "ExitInterviewQuestions_Data", "get_ExitInterviewQuestions_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ExitInterviewQuestions_Data", "get_ExitInterviewQuestions_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ExitInterviewQuestions_Data", "get_ExitInterviewQuestions_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ExitInterviewQuestions_Data", "get_ExitInterviewQuestions_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

    }
}








