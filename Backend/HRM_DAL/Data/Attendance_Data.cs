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

                        cmd.Parameters.AddWithValue("@InTime", item.InTime);
                        cmd.Parameters["@InTime"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@OutTime", item.OutTime);
                        cmd.Parameters["@OutTime"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EndDate", item.EndDate);
                        cmd.Parameters["@EndDate"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@AttendanceDate", item.AttendanceDate);
                        cmd.Parameters["@AttendanceDate"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@StartDate", item.StartDate);
                        cmd.Parameters["@StartDate"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Total", item.Total);
                        cmd.Parameters["@Total"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Reason", item.Reason);
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

                        cmd.CommandText = "sp_upate_Attendance";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@AttendanceDate", item.AttendanceDate);
                        cmd.Parameters["@AttendanceDate"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Location", item.Location);
                        cmd.Parameters["@Location"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UD_StaffID", item.UD_StaffID);
                        cmd.Parameters["@UD_StaffID"].Direction = ParameterDirection.Input;

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

                        cmd.CommandText = "sp_upate_Attendance";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@AttendanceDate", item.AttendanceDate);
                        cmd.Parameters["@AttendanceDate"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Location", item.Location);
                        cmd.Parameters["@Location"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UD_StaffID", item.UD_StaffID);
                        cmd.Parameters["@UD_StaffID"].Direction = ParameterDirection.Input;

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
        public static List<AttendanceSubmitResponceModel> get_Attendance_details(AttendanceRequestModel item)
        {
            List<AttendanceSubmitResponceModel> objAttendanceHeadList = new List<AttendanceSubmitResponceModel>();
            AttendanceSubmitResponceModel objAttendanceHead = new AttendanceSubmitResponceModel();
            objAttendanceHead.AttendanceGridViewModelList = new List<AttendanceGridViewModel>();

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

                        cmd.CommandText = "sp_get_Attendance_details";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_StaffID", item.UD_StaffID);
                        cmd.Parameters["@UD_StaffID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@AttendanceDate", item.AttendanceDate);
                        cmd.Parameters["@AttendanceDate"].Direction = ParameterDirection.Input;

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

                                    DateTime trdate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["TransactionDate"].ToString(), out trdate);

                                    decimal decQty = 0;
                                    decimal.TryParse(rdr["Quantity"].ToString(), out decQty);

                                    decimal recQty = 0;
                                    decimal.TryParse(rdr["PostageTotal"].ToString(), out recQty);

                                    TimeSpan OutTime = TimeSpan.MinValue;
                                    TimeSpan.TryParse(rdr["OutTime"].ToString(), out OutTime);

                                    TimeSpan InTime = TimeSpan.MinValue;
                                    TimeSpan.TryParse(rdr["InTime"].ToString(), out InTime);

                                    decimal Total = 0;

                                    DateTime AttendanceDate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["AttendanceDate"].ToString(), out AttendanceDate);

                                    DateTime StartDate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["StartDate"].ToString(), out StartDate);

                                    DateTime EndDate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["EndDate"].ToString(), out EndDate);

                                    objAttendanceHead.resp = true;
                                    objAttendanceHead.msg = "Attendance";

                                    AttendanceGridViewModel objAttendanceDetail = new AttendanceGridViewModel()
                                    {
                                        InTime = InTime,
                                        OutTime = OutTime,
                                        Reason = rdr["Reason"].ToString(),
                                        EndDate = EndDate,
                                        Total = Total,
                                        DateString = rdr["DateString"].ToString(),
                                        AttendanceDate = AttendanceDate,
                                        StartDate = StartDate
                                        //RC = RC,
                                    };

                                    objAttendanceHead.AttendanceGridViewModelList.Add(objAttendanceDetail);
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

                objError.WriteLog(0, "Attendance_Data", "get_Attendance_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Attendance_Data", "get_Attendance_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Attendance_Data", "get_Attendance_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Attendance_Data", "get_Attendance_details", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objAttendanceHeadList;
        }

        public static List<AttendanceGridViewHeaderModel> get_Attendance_grid_details(AttendanceGridRequestModel item)
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

                        cmd.CommandText = "sp_get_Attendance_grid_details";
                        cmd.CommandType = CommandType.StoredProcedure;



                        cmd.Parameters.AddWithValue("@DateFrom", item.DateFrom);
                        cmd.Parameters["@DateFrom"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DateTo", item.DateTo);
                        cmd.Parameters["@DateTo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_NO", item.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", item.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UD_StaffID", item.UD_StaffID);
                        cmd.Parameters["@UD_StaffID"].Direction = ParameterDirection.Input;



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
                                    TimeSpan.TryParse(rdr["OutTime"].ToString(), out OutTime);

                                    TimeSpan InTime = TimeSpan.MinValue;
                                    TimeSpan.TryParse(rdr["InTime"].ToString(), out InTime);

                                    decimal Total = 0;

                                    DateTime AttendanceDate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["AttendanceDate"].ToString(), out AttendanceDate);

                                    DateTime StartDate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["StartDate"].ToString(), out StartDate);

                                    DateTime EndDate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["EndDate"].ToString(), out EndDate);

                                    objAttendanceHead.resp = true;
                                    objAttendanceHead.msg = "Attendance";

                                    AttendanceGridViewModel objAttendanceDetail = new AttendanceGridViewModel()
                                    {
                                        InTime = InTime,
                                        OutTime = OutTime,
                                        Reason = rdr["Reason"].ToString(),
                                        EndDate = EndDate,
                                        Total = Total,
                                        DateString = rdr["DateString"].ToString(),
                                        AttendanceDate = AttendanceDate,
                                        StartDate = StartDate
                                        //RC = RC,
                                    };
                                    objAttendanceHead.AttendanceGridViewModelList.Add(objAttendanceDetail);
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

                objError.WriteLog(0, "Attendance_Data", "get_Attendance_grid_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Attendance_Data", "get_Attendance_grid_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Attendance_Data", "get_Attendance_grid_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Attendance_Data", "get_Attendance_grid_details", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objAttendanceHeadList;
        }
    }
}