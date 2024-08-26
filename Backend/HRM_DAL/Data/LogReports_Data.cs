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
    public class LogReports_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnUserLogReportsModelHead> get_UserLogReport(RequestUserLog model)//ok
        {
            List<ReturnUserLogReportsModelHead> objMenuAccessHeadList = new List<ReturnUserLogReportsModelHead>();
            ReturnUserLogReportsModelHead objMenuAccessHead = new ReturnUserLogReportsModelHead();

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

                        cmd.CommandText = "sp_get_UserLogReport";
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@UMA_MenuAccessID", model.UMA_MenuAccessID);
                        //cmd.Parameters["@UMA_MenuAccessID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                UserLogModel objMenuAccess = new UserLogModel();

                                objMenuAccessHead.resp = true;
                                objMenuAccessHead.msg = "Get UserLog";

                                objMenuAccess.UserID = rdr["UserID"].ToString();
                                objMenuAccess.UserName = rdr["UserName"].ToString();
                                objMenuAccess.LoggedDateTime = rdr["LoggedDateTime"].ToString();
                                objMenuAccess.UserLogId = rdr["UserLogId"].ToString();
                                objMenuAccess.UserLogOffTime = rdr["UserLogOffTime"].ToString();

                                if (objMenuAccessHead.UserLog == null)
                                {
                                    objMenuAccessHead.UserLog = new List<UserLogModel>();
                                }

                                objMenuAccessHead.UserLog.Add(objMenuAccess);

                                objMenuAccessHeadList.Add(objMenuAccessHead);
                            }

                        }
                        else
                        {
                            UserLogModel objMenuAccess = new UserLogModel();
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
                objMenuAccessHead = new ReturnUserLogReportsModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objMenuAccessHeadList.Add(objMenuAccessHead);

                objError.WriteLog(0, "LogReports_Data", "get_UserLogReport", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LogReports_Data", "get_UserLogReport", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LogReports_Data", "get_UserLogReport", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LogReports_Data", "get_UserLogReport", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objMenuAccessHeadList;

        }

        public static List<ReturnErrorLogReportsModelHead> get_ErrorLogReport(RequestErrorLog model)//ok
        {
            List<ReturnErrorLogReportsModelHead> objMenuAccessHeadList = new List<ReturnErrorLogReportsModelHead>();
            ReturnErrorLogReportsModelHead objMenuAccessHead = new ReturnErrorLogReportsModelHead();

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

                        cmd.CommandText = "sp_get_UserLogReport";
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@UMA_MenuAccessID", model.UMA_MenuAccessID);
                        //cmd.Parameters["@UMA_MenuAccessID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ErrorLogModel objMenuAccess = new ErrorLogModel();

                                objMenuAccessHead.resp = true;
                                objMenuAccessHead.msg = "Get Errorlog";

                                objMenuAccess.ErrorLogId = rdr["ErrorLogId"].ToString();
                                objMenuAccess.ErrorDescription = rdr["ErrorDescription"].ToString();
                                objMenuAccess.ErrorUserId = rdr["ErrorUserId"].ToString();
                                objMenuAccess.ErrorDatetime = rdr["ErrorDatetime"].ToString();
                                objMenuAccess.ErrorLoggedIp = rdr["ErrorLoggedIp"].ToString();
                                objMenuAccess.ErrorRef = rdr["ErrorRef"].ToString();
                                objMenuAccess.ErrorPage = rdr["ErrorPage"].ToString();

                                if (objMenuAccessHead.ErrorLog == null)
                                {
                                    objMenuAccessHead.ErrorLog = new List<ErrorLogModel>();
                                }

                                objMenuAccessHead.ErrorLog.Add(objMenuAccess);

                                objMenuAccessHeadList.Add(objMenuAccessHead);
                            }

                        }
                        else
                        {
                            ErrorLogModel objMenuAccess = new ErrorLogModel();
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
                objMenuAccessHead = new ReturnErrorLogReportsModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objMenuAccessHeadList.Add(objMenuAccessHead);

                objError.WriteLog(0, "LogReports_Data", "get_ErrorLogReport", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LogReports_Data", "get_ErrorLogReport", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LogReports_Data", "get_ErrorLogReport", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LogReports_Data", "get_ErrorLogReport", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objMenuAccessHeadList;
        }

        public static List<ReturnAuditLogReportsModelHead> get_AuditLogReport(RequestAuditLog model)//ok
        {
            List<ReturnAuditLogReportsModelHead> objMenuAccessHeadList = new List<ReturnAuditLogReportsModelHead>();
            ReturnAuditLogReportsModelHead objMenuAccessHead = new ReturnAuditLogReportsModelHead();

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

                        cmd.CommandText = "sp_get_AuditLogReport";
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@UMA_MenuAccessID", model.UMA_MenuAccessID);
                        //cmd.Parameters["@UMA_MenuAccessID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                AuditLogModel objMenuAccess = new AuditLogModel();

                                objMenuAccessHead.resp = true;
                                objMenuAccessHead.msg = "Get AuditLog";

                                objMenuAccess.Action = rdr["Action"].ToString();
                                objMenuAccess.Description = rdr["Description"].ToString();
                                objMenuAccess.CreatedBy = rdr["CreatedBy"].ToString();
                                objMenuAccess.ClientIP = rdr["ClientIP"].ToString();
                                objMenuAccess.CreatedDateTime = rdr["CreatedDateTime"].ToString();
                                objMenuAccess.SequenceNo = rdr["SequenceNo"].ToString();
                                objMenuAccess.Module = rdr["Module"].ToString();
                                objMenuAccess.Controler = rdr["Controler"].ToString();
                                objMenuAccess.ActionType = rdr["ActionType"].ToString();
                                objMenuAccess.ActionMap_ID = rdr["ActionMap_ID"].ToString();

                                if (objMenuAccessHead.AuditLog == null)
                                {
                                    objMenuAccessHead.AuditLog = new List<AuditLogModel>();
                                }

                                objMenuAccessHead.AuditLog.Add(objMenuAccess);

                                objMenuAccessHeadList.Add(objMenuAccessHead);
                            }

                        }
                        else
                        {
                            AuditLogModel objMenuAccess = new AuditLogModel();
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
                objMenuAccessHead = new ReturnAuditLogReportsModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objMenuAccessHeadList.Add(objMenuAccessHead);

                objError.WriteLog(0, "LogReports_Data", "get_AuditLogReport", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LogReports_Data", "get_AuditLogReport", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LogReports_Data", "get_AuditLogReport", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LogReports_Data", "get_AuditLogReport", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objMenuAccessHeadList;
        }
    }
}
