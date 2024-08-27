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
    public class Reports_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnAttendanceReportsModelHead> get_AttendanceReport(RequestAttendance model)//ok
        {
            List<ReturnAttendanceReportsModelHead> objAttendanceHeadList = new List<ReturnAttendanceReportsModelHead>();
            ReturnAttendanceReportsModelHead objAttendanceHead = new ReturnAttendanceReportsModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objAttendanceHead.resp = false;
                objAttendanceHead.IsAuthenticated = false;
                objAttendanceHeadList.Add(objAttendanceHead);
                return objAttendanceHeadList;
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

                        //cmd.Parameters.AddWithValue("@UMA_AttendanceID", model.UMA_AttendanceID);
                        //cmd.Parameters["@UMA_AttendanceID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                AttendanceReportModel objAttendance = new AttendanceReportModel();

                                objAttendanceHead.resp = true;
                                objAttendanceHead.msg = "Get Attendance";

                                //objAttendance.UserID = rdr["UserID"].ToString();
                                //objAttendance.UserName = rdr["UserName"].ToString();
                                //objAttendance.LoggedDateTime = rdr["LoggedDateTime"].ToString();
                                //objAttendance.UserLogId = rdr["UserLogId"].ToString();
                                //objAttendance.UserLogOffTime = rdr["UserLogOffTime"].ToString();

                                if (objAttendanceHead.Attendance == null)
                                {
                                    objAttendanceHead.Attendance = new List<AttendanceReportModel>();
                                }

                                objAttendanceHead.Attendance.Add(objAttendance);

                                objAttendanceHeadList.Add(objAttendanceHead);
                            }

                        }
                        else
                        {
                            UserLogModel objAttendance = new UserLogModel();
                            objAttendanceHead.resp = true;
                            objAttendanceHead.msg = "";
                            objAttendanceHeadList.Add(objAttendanceHead);


                        }


                    }
                    return objAttendanceHeadList;

                }
            }
            catch (Exception ex)
            {
                objAttendanceHead = new ReturnAttendanceReportsModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objAttendanceHeadList.Add(objAttendanceHead);

                objError.WriteLog(0, "Reports_Data", "get_AttendanceReport", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Reports_Data", "get_AttendanceReport", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Reports_Data", "get_AttendanceReport", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Reports_Data", "get_AttendanceReport", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objAttendanceHeadList;

        }

        public static List<ReturnBirthdayReportsModelHead> get_BirthdayReport(RequestBirthday model)//ok
        {
            List<ReturnBirthdayReportsModelHead> objBirthdayHeadList = new List<ReturnBirthdayReportsModelHead>();
            ReturnBirthdayReportsModelHead objBirthdayHead = new ReturnBirthdayReportsModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objBirthdayHead.resp = false;
                objBirthdayHead.IsAuthenticated = false;
                objBirthdayHeadList.Add(objBirthdayHead);
                return objBirthdayHeadList;
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

                        //cmd.Parameters.AddWithValue("@UMA_BirthdayID", model.UMA_BirthdayID);
                        //cmd.Parameters["@UMA_BirthdayID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                BirthdayReportModel objBirthday = new BirthdayReportModel();

                                objBirthdayHead.resp = true;
                                objBirthdayHead.msg = "Get Birthday";

                                //objBirthday.ErrorLogId = rdr["ErrorLogId"].ToString();
                                //objBirthday.ErrorDescription = rdr["ErrorDescription"].ToString();
                                //objBirthday.ErrorUserId = rdr["ErrorUserId"].ToString();
                                //objBirthday.ErrorDatetime = rdr["ErrorDatetime"].ToString();
                                //objBirthday.ErrorLoggedIp = rdr["ErrorLoggedIp"].ToString();
                                //objBirthday.ErrorRef = rdr["ErrorRef"].ToString();
                                //objBirthday.ErrorPage = rdr["ErrorPage"].ToString();

                                if (objBirthdayHead.Birthday == null)
                                {
                                    objBirthdayHead.Birthday = new List<BirthdayReportModel>();
                                }

                                objBirthdayHead.Birthday.Add(objBirthday);

                                objBirthdayHeadList.Add(objBirthdayHead);
                            }

                        }
                        else
                        {
                            ErrorLogModel objBirthday = new ErrorLogModel();
                            objBirthdayHead.resp = true;
                            objBirthdayHead.msg = "";
                            objBirthdayHeadList.Add(objBirthdayHead);


                        }


                    }
                    return objBirthdayHeadList;

                }
            }
            catch (Exception ex)
            {
                objBirthdayHead = new ReturnBirthdayReportsModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objBirthdayHeadList.Add(objBirthdayHead);

                objError.WriteLog(0, "Reports_Data", "get_BirthdayReport", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Reports_Data", "get_BirthdayReport", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Reports_Data", "get_BirthdayReport", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Reports_Data", "get_BirthdayReport", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objBirthdayHeadList;
        }
    }
}
