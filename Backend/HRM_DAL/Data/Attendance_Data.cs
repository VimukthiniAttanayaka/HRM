using error_handler;
using HRM_DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_DAL.Data
{
    public class Attendance_Data
    {
        private static LogError objError = new LogError();

        public static List<AttendanceSubmitResponceModel> modify_Attendance(AttendanceGridSubmitModel item)
        {
            List<AttendanceSubmitResponceModel> objAttendanceHeadList = new List<AttendanceSubmitResponceModel>();
            AttendanceSubmitResponceModel objAttendanceHead = new AttendanceSubmitResponceModel();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
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

                        cmd.CommandText = "sp_upate_Attendance";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@InTime", item.EAT_InTime);
                        cmd.Parameters["@InTime"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@OutTime", item.EAT_OutTime);
                        cmd.Parameters["@OutTime"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@EndDate", item.EAT_EndDate);
                        //cmd.Parameters["@EndDate"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@AttendanceDate", item.EAT_AttendanceDate);
                        cmd.Parameters["@AttendanceDate"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@StartDate", item.EAT_StartDate);
                        //cmd.Parameters["@StartDate"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Total", item.EAT_Total);
                        cmd.Parameters["@Total"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Reason", item.EAT_Reason);
                        cmd.Parameters["@Reason"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                if (Ds.Tables[0].Columns.Contains("RTN_RESP"))
                                {
                                    objAttendanceHead.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                    objAttendanceHead.msg = rdr["RTN_MSG"].ToString();
                                }

                            }
                            objAttendanceHeadList.Add(objAttendanceHead);
                        }
                        else
                        {
                            objAttendanceHead.resp = true;
                            objAttendanceHead.msg = "";
                            objAttendanceHeadList.Add(objAttendanceHead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objAttendanceHead.resp = false;
                objAttendanceHead.msg = ex.Message.ToString();

                objAttendanceHeadList.Add(objAttendanceHead);

                objError.WriteLog(0, "Attendance_Data", "modify_Attendance", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Attendance_Data", "modify_Attendance", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Attendance_Data", "modify_Attendance", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Attendance_Data", "modify_Attendance", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objAttendanceHeadList;
        }

        public static List<AttendanceSubmitResponceModel> AttendancePunch_Marker(AttendancePunch_MarkerSubmitModel item)
        {
            List<AttendanceSubmitResponceModel> objAttendanceHeadList = new List<AttendanceSubmitResponceModel>();
            AttendanceSubmitResponceModel objAttendanceHead = new AttendanceSubmitResponceModel();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
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

                        cmd.CommandText = "sp_insert_Attendance";
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@EAT_AttendanceDate", item.EAT_AttendanceDate);
                        //cmd.Parameters["@EAT_AttendanceDate"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EAT_EmployeeID", item.EAT_EmployeeID);
                        cmd.Parameters["@EAT_EmployeeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EAT_Location_latitude", item.EAT_Location_latitude);
                        cmd.Parameters["@EAT_Location_latitude"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EAT_Location_longitude", item.EAT_Location_longitude);
                        cmd.Parameters["@EAT_Location_longitude"].Direction = ParameterDirection.Input;

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
                                if (Ds.Tables[0].Columns.Contains("RTN_RESP"))
                                {
                                    objAttendanceHead.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                    objAttendanceHead.msg = rdr["RTN_MSG"].ToString();
                                }

                            }
                            objAttendanceHeadList.Add(objAttendanceHead);
                        }
                        else
                        {
                            objAttendanceHead.resp = true;
                            objAttendanceHead.msg = "";
                            objAttendanceHeadList.Add(objAttendanceHead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objAttendanceHead.resp = false;
                objAttendanceHead.msg = ex.Message.ToString();

                objAttendanceHeadList.Add(objAttendanceHead);

                objError.WriteLog(0, "Attendance_Data", "AttendancePunch_Marker", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Attendance_Data", "AttendancePunch_Marker", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Attendance_Data", "AttendancePunch_Marker", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Attendance_Data", "AttendancePunch_Marker", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objAttendanceHeadList;
        }

        public static List<AttendanceSubmitResponceModel> AttendancePunch_Mobile(AttendancePunch_MobileSubmitModel item)
        {
            List<AttendanceSubmitResponceModel> objAttendanceHeadList = new List<AttendanceSubmitResponceModel>();
            AttendanceSubmitResponceModel objAttendanceHead = new AttendanceSubmitResponceModel();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
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

                        cmd.CommandText = "sp_insert_Attendance";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@AttendanceDate", item.EAT_AttendanceDate);
                        cmd.Parameters["@AttendanceDate"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EAT_Location_latitude", item.EAT_Location_latitude);
                        cmd.Parameters["@EAT_Location_latitude"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EAT_Location_longitude", item.EAT_Location_longitude);
                        cmd.Parameters["@EAT_Location_longitude"].Direction = ParameterDirection.Input;

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
                                if (Ds.Tables[0].Columns.Contains("RTN_RESP"))
                                {
                                    objAttendanceHead.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                    objAttendanceHead.msg = rdr["RTN_MSG"].ToString();
                                }

                            }
                            objAttendanceHeadList.Add(objAttendanceHead);
                        }
                        else
                        {
                            objAttendanceHead.resp = true;
                            objAttendanceHead.msg = "";
                            objAttendanceHeadList.Add(objAttendanceHead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objAttendanceHead.resp = false;
                objAttendanceHead.msg = ex.Message.ToString();

                objAttendanceHeadList.Add(objAttendanceHead);

                objError.WriteLog(0, "Attendance_Data", "AttendancePunch_Mobile", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Attendance_Data", "AttendancePunch_Mobile", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Attendance_Data", "AttendancePunch_Mobile", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Attendance_Data", "AttendancePunch_Mobile", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objAttendanceHeadList;
        }

        public static List<AttendanceSubmitResponceModel> get_Attendance_single(AttendanceRequestModel item)
        {
            List<AttendanceSubmitResponceModel> objAttendanceHeadList = new List<AttendanceSubmitResponceModel>();
            AttendanceSubmitResponceModel objAttendanceHead = new AttendanceSubmitResponceModel();
            objAttendanceHead.Attendance = new List<AttendanceGridViewModel>();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
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

                        cmd.CommandText = "sp_get_Attendance_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        //cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EAT_ID", item.EAT_ID);
                        cmd.Parameters["@EAT_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {

                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                if (Ds.Tables[0].Columns.Contains("RTN_RESP"))
                                {
                                    objAttendanceHead.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                    objAttendanceHead.msg = rdr["RTN_MSG"].ToString();
                                }
                                else
                                {
                                    objAttendanceHead.resp = true;
                                    objAttendanceHead.msg = "";

                                    TimeSpan OutTime = TimeSpan.MinValue;
                                    TimeSpan.TryParse(rdr["EAT_OutTime"].ToString(), out OutTime);

                                    TimeSpan InTime = TimeSpan.MinValue;
                                    TimeSpan.TryParse(rdr["EAT_InTime"].ToString(), out InTime);

                                    decimal Total = 0;
                                    var temp = OutTime.Subtract(InTime);

                                    DateTime AttendanceDate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["EAT_AttendanceDate"].ToString(), out AttendanceDate);

                                    //DateTime EAT_AttendanceDate = DateTime.MinValue;
                                    //DateTime.TryParse(rdr["EAT_StartDate"].ToString(), out StartDate);

                                    //DateTime EndDate = DateTime.MinValue;
                                    //DateTime.TryParse(rdr["EAT_EndDate"].ToString(), out EndDate);

                                    objAttendanceHead.resp = true;
                                    objAttendanceHead.msg = "Attendance";

                                    AttendanceGridViewModel objAttendanceDetail = new AttendanceGridViewModel()
                                    {
                                        EAT_InTime = InTime,
                                        EAT_OutTime = OutTime,
                                        //EAT_Reason = rdr["EAT_Reason"].ToString(),
                                        //EAT_EndDate = EndDate,
                                        EAT_Total = Total,
                                        EAT_Total_TimeSpan = temp,
                                        //EAT_DateString = rdr["DateString"].ToString(),
                                        EAT_AttendanceDate = AttendanceDate,
                                        //EAT_StartDate = StartDate
                                        //RC = RC,
                                        EAT_Status = Convert.ToBoolean(rdr["EAT_Status"].ToString()),
                                        EAT_ID = Convert.ToInt32(rdr["EAT_ID"].ToString()),
                                        EAT_EmployeeID = rdr["EAT_EmployeeID"].ToString()
                                    };

                                    objAttendanceHead.Attendance.Add(objAttendanceDetail);
                                }

                            }
                            objAttendanceHeadList.Add(objAttendanceHead);
                        }
                        else
                        {
                            objAttendanceHead.resp = true;
                            objAttendanceHead.msg = "";
                            objAttendanceHeadList.Add(objAttendanceHead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objAttendanceHead.resp = false;
                objAttendanceHead.msg = ex.Message.ToString();

                objAttendanceHeadList.Add(objAttendanceHead);

                objError.WriteLog(0, "Attendance_Data", "get_Attendance_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Attendance_Data", "get_Attendance_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Attendance_Data", "get_Attendance_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Attendance_Data", "get_Attendance_single", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objAttendanceHeadList;
        }

        public static List<AttendanceGridViewHeaderModel> get_Attendance_all(AttendanceGridRequestModel item)
        {
            List<AttendanceGridViewHeaderModel> objAttendanceHeadList = new List<AttendanceGridViewHeaderModel>();
            AttendanceGridViewHeaderModel objAttendanceHead = new AttendanceGridViewHeaderModel();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
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

                        cmd.CommandText = "sp_get_Attendance_all";
                        cmd.CommandType = CommandType.StoredProcedure;



                        //cmd.Parameters.AddWithValue("@DateFrom", item.DateFrom);
                        //cmd.Parameters["@DateFrom"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@DateTo", item.DateTo);
                        //cmd.Parameters["@DateTo"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@PAGE_NO", item.PAGE_NO);
                        //cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", item.PAGE_RECORDS_COUNT);
                        //cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        //cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;



                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                if (Ds.Tables[0].Columns.Contains("RTN_RESP"))
                                {
                                    objAttendanceHead.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                    objAttendanceHead.msg = rdr["RTN_MSG"].ToString();
                                }
                                else
                                {
                                    TimeSpan OutTime = TimeSpan.MinValue;
                                    TimeSpan.TryParse(rdr["EAT_OutTime"].ToString(), out OutTime);

                                    TimeSpan InTime = TimeSpan.MinValue;
                                    TimeSpan.TryParse(rdr["EAT_InTime"].ToString(), out InTime);

                                    decimal Total = 0;
                                    var temp = OutTime.Subtract(InTime);

                                    DateTime AttendanceDate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["EAT_AttendanceDate"].ToString(), out AttendanceDate);

                                    //DateTime EAT_AttendanceDate = DateTime.MinValue;
                                    //DateTime.TryParse(rdr["EAT_StartDate"].ToString(), out StartDate);

                                    //DateTime EndDate = DateTime.MinValue;
                                    //DateTime.TryParse(rdr["EAT_EndDate"].ToString(), out EndDate);

                                    objAttendanceHead.resp = true;
                                    objAttendanceHead.msg = "Attendance";

                                    AttendanceGridViewModel objAttendanceDetail = new AttendanceGridViewModel()
                                    {
                                        EAT_InTime = InTime,
                                        EAT_OutTime = OutTime,
                                        //EAT_Reason = rdr["EAT_Reason"].ToString(),
                                        //EAT_EndDate = EndDate,
                                        EAT_Total = Total,
                                        EAT_Total_TimeSpan = temp,
                                        //EAT_DateString = rdr["DateString"].ToString(),
                                        EAT_AttendanceDate = AttendanceDate,
                                        //EAT_StartDate = StartDate
                                        //RC = RC,
                                        EAT_Status = Convert.ToBoolean(rdr["EAT_Status"].ToString()),
                                        EAT_ID = Convert.ToInt32(rdr["EAT_ID"].ToString()),
                                        EAT_EmployeeID = rdr["EAT_EmployeeID"].ToString()
                                    };
                                    objAttendanceHead.Attendance.Add(objAttendanceDetail);
                                }

                            }
                            objAttendanceHeadList.Add(objAttendanceHead);
                        }
                        else
                        {
                            objAttendanceHead.resp = true;
                            objAttendanceHead.msg = "";
                            objAttendanceHeadList.Add(objAttendanceHead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objAttendanceHead.resp = false;
                objAttendanceHead.msg = ex.Message.ToString();

                objAttendanceHeadList.Add(objAttendanceHead);

                objError.WriteLog(0, "Attendance_Data", "get_Attendance_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Attendance_Data", "get_Attendance_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Attendance_Data", "get_Attendance_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Attendance_Data", "get_Attendance_all", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objAttendanceHeadList;
        }
    }
}