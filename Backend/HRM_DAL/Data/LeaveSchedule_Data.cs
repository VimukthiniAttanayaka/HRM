using error_handler;
using HRM_DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_DAL.Data
{
    public class LeaveSchedule_Data
    {
        private static LogError objError = new LogError();

        public static List<LeaveSubmitResponceModel> applyleave(LeaveSubmitModel model)
        {
            List<LeaveSubmitResponceModel> objLeaveHeadList = new List<LeaveSubmitResponceModel>();
            LeaveSubmitResponceModel objLeaveHead = new LeaveSubmitResponceModel();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objLeaveHead.resp = false;
                objLeaveHead.IsAuthenticated = false;
                objLeaveHeadList.Add(objLeaveHead);
                return objLeaveHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_applyleave";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BatchNo", model.LV_LeaveID);
                        cmd.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_ID", item.CUS_ID);
                        //cmd.Parameters["@CUS_ID"].Direction = ParameterDirection.Input;

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
                                    objLeaveHead.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                    objLeaveHead.msg = rdr["RTN_MSG"].ToString();
                                }
                                else
                                {
                                    DateTime enddate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["LV_LeaveEndDate"].ToString(), out enddate);
                                    DateTime startdate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["LV_LeaveStartDate"].ToString(), out startdate);
                                    DateTime approveddate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["LV_ApprovedDate"].ToString(), out approveddate);

                                    objLeaveHead.resp = true;
                                    objLeaveHead.msg = "Leave";

                                    LeaveResponceModel objLeaveDetail = new LeaveResponceModel()
                                    {
                                        LV_LeaveID = Convert.ToInt32(rdr["LV_LeaveID"].ToString()),
                                        LV_LeaveEndDate = enddate,
                                        LV_LeaveStartDate = startdate,
                                        LV_StaffID = rdr["LV_StaffID"].ToString(),
                                        LV_LeaveTypeID = rdr["LV_LeaveTypeID"].ToString(),
                                        LV_Approve = Convert.ToBoolean(rdr["LV_Approve"].ToString()),
                                        LV_ApprovedBy = rdr["LV_ApprovedBy"].ToString(),
                                        LV_ApprovedDate = approveddate,
                                        LV_Status = Convert.ToBoolean(rdr["LV_Status"].ToString()),
                                    };
                                    objLeaveHead.obj = objLeaveDetail;
                                }

                            }
                            objLeaveHeadList.Add(objLeaveHead);
                        }
                        else
                        {
                            objLeaveHead.resp = true;
                            objLeaveHead.msg = "";
                            objLeaveHeadList.Add(objLeaveHead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objLeaveHead.resp = false;
                objLeaveHead.msg = ex.Message.ToString();

                objLeaveHeadList.Add(objLeaveHead);

                objError.WriteLog(0, "LeaveSchedule_Data", "get_leave_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveSchedule_Data", "get_leave_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveSchedule_Data", "get_leave_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveSchedule_Data", "get_leave_details", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objLeaveHeadList;
        }

        public static List<LeaveSubmitResponceModel> cancelleave(LeaveCancelSubmitModel model)
        {
            List<LeaveSubmitResponceModel> objLeaveHeadList = new List<LeaveSubmitResponceModel>();
            LeaveSubmitResponceModel objLeaveHead = new LeaveSubmitResponceModel();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objLeaveHead.resp = false;
                objLeaveHead.IsAuthenticated = false;
                objLeaveHeadList.Add(objLeaveHead);
                return objLeaveHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_cancelleave";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@LV_LeaveID", model.LV_LeaveID);
                        cmd.Parameters["@LV_LeaveID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@LV_Reject", model.LV_Reject);
                        cmd.Parameters["@LV_Reject"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@LV_RejectBy", model.LV_RejectBy);
                        cmd.Parameters["@LV_RejectBy"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@LV_RejectDate", model.LV_RejectDate);
                        cmd.Parameters["@LV_RejectDate"].Direction = ParameterDirection.Input;

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
                                    objLeaveHead.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                    objLeaveHead.msg = rdr["RTN_MSG"].ToString();
                                }
                                else
                                {
                                    DateTime enddate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["LV_LeaveEndDate"].ToString(), out enddate);
                                    DateTime startdate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["LV_LeaveStartDate"].ToString(), out startdate);
                                    DateTime approveddate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["LV_ApprovedDate"].ToString(), out approveddate);

                                    objLeaveHead.resp = true;
                                    objLeaveHead.msg = "Leave";

                                    LeaveResponceModel objLeaveDetail = new LeaveResponceModel()
                                    {
                                        LV_LeaveID = Convert.ToInt32(rdr["LV_LeaveID"].ToString()),
                                        LV_LeaveEndDate = enddate,
                                        LV_LeaveStartDate = startdate,
                                        LV_StaffID = rdr["LV_StaffID"].ToString(),
                                        LV_LeaveTypeID = rdr["LV_LeaveTypeID"].ToString(),
                                        LV_Approve = Convert.ToBoolean(rdr["LV_Approve"].ToString()),
                                        LV_ApprovedBy = rdr["LV_ApprovedBy"].ToString(),
                                        LV_ApprovedDate = approveddate,
                                        LV_Status = Convert.ToBoolean(rdr["LV_Status"].ToString()),
                                    };
                                    objLeaveHead.obj = objLeaveDetail;
                                }

                            }
                            objLeaveHeadList.Add(objLeaveHead);
                        }
                        else
                        {
                            objLeaveHead.resp = true;
                            objLeaveHead.msg = "";
                            objLeaveHeadList.Add(objLeaveHead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objLeaveHead.resp = false;
                objLeaveHead.msg = ex.Message.ToString();

                objLeaveHeadList.Add(objLeaveHead);

                objError.WriteLog(0, "LeaveSchedule_Data", "get_leave_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveSchedule_Data", "get_leave_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveSchedule_Data", "get_leave_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveSchedule_Data", "get_leave_details", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objLeaveHeadList;
        }

        public static List<LeaveSubmitResponceModel> approveleave(LeaveApproveSubmitModel model)
        {
            List<LeaveSubmitResponceModel> objLeaveHeadList = new List<LeaveSubmitResponceModel>();
            LeaveSubmitResponceModel objLeaveHead = new LeaveSubmitResponceModel();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objLeaveHead.resp = false;
                objLeaveHead.IsAuthenticated = false;
                objLeaveHeadList.Add(objLeaveHead);
                return objLeaveHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_approveleave";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@LV_LeaveID", model.LV_LeaveID);
                        cmd.Parameters["@LV_LeaveID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@LV_Approve", model.LV_Approve);
                        cmd.Parameters["@LV_Approve"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@LV_ApprovedBy", model.LV_ApprovedBy);
                        cmd.Parameters["@LV_ApprovedBy"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@LV_ApprovedDate", model.LV_ApprovedDate);
                        cmd.Parameters["@LV_ApprovedDate"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        string RC = "";

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                if (Ds.Tables[0].Columns.Contains("RTN_RESP"))
                                {
                                    objLeaveHead.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                    objLeaveHead.msg = rdr["RTN_MSG"].ToString();
                                }
                                else
                                {
                                    DateTime enddate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["LV_LeaveEndDate"].ToString(), out enddate);
                                    DateTime startdate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["LV_LeaveStartDate"].ToString(), out startdate);
                                    DateTime approveddate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["LV_ApprovedDate"].ToString(), out approveddate);

                                    objLeaveHead.resp = true;
                                    objLeaveHead.msg = "Leave";

                                    LeaveResponceModel objLeaveDetail = new LeaveResponceModel()
                                    {
                                        LV_LeaveID = Convert.ToInt32(rdr["LV_LeaveID"].ToString()),
                                        LV_LeaveEndDate = enddate,
                                        LV_LeaveStartDate = startdate,
                                        LV_StaffID = rdr["LV_StaffID"].ToString(),
                                        LV_LeaveTypeID = rdr["LV_LeaveTypeID"].ToString(),
                                        LV_Approve = Convert.ToBoolean(rdr["LV_Approve"].ToString()),
                                        LV_ApprovedBy = rdr["LV_ApprovedBy"].ToString(),
                                        LV_ApprovedDate = approveddate,
                                        LV_Status = Convert.ToBoolean(rdr["LV_Status"].ToString()),
                                    };
                                    objLeaveHead.obj = objLeaveDetail;
                                }

                            }
                            objLeaveHeadList.Add(objLeaveHead);
                        }
                        else
                        {
                            objLeaveHead.resp = true;
                            objLeaveHead.msg = "";
                            objLeaveHeadList.Add(objLeaveHead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objLeaveHead.resp = false;
                objLeaveHead.msg = ex.Message.ToString();

                objLeaveHeadList.Add(objLeaveHead);

                objError.WriteLog(0, "LeaveSchedule_Data", "get_leave_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveSchedule_Data", "get_leave_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveSchedule_Data", "get_leave_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveSchedule_Data", "get_leave_details", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objLeaveHeadList;
        }

        public static List<LeaveHeaderResponceModel> get_leave_details(LeaveRequestModel item)
        {
            List<LeaveHeaderResponceModel> objLeaveHeadList = new List<LeaveHeaderResponceModel>();
            LeaveHeaderResponceModel objLeaveHead = new LeaveHeaderResponceModel();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objLeaveHead.resp = false;
                objLeaveHead.IsAuthenticated = false;
                objLeaveHeadList.Add(objLeaveHead);
                return objLeaveHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_leave_details";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BatchNo", item.LV_LeaveID);
                        cmd.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

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
                                    objLeaveHead.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                    objLeaveHead.msg = rdr["RTN_MSG"].ToString();
                                }
                                else
                                {
                                    DateTime enddate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["LV_LeaveEndDate"].ToString(), out enddate);
                                    DateTime startdate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["LV_LeaveStartDate"].ToString(), out startdate);
                                    DateTime approveddate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["LV_ApprovedDate"].ToString(), out approveddate);

                                    objLeaveHead.resp = true;
                                    objLeaveHead.msg = "Leave";

                                    LeaveResponceModel objLeaveDetail = new LeaveResponceModel()
                                    {
                                        LV_LeaveID = Convert.ToInt32(rdr["LV_LeaveID"].ToString()),
                                        LV_LeaveEndDate = enddate,
                                        LV_LeaveStartDate = startdate,
                                        LV_StaffID = rdr["LV_StaffID"].ToString(),
                                        LV_LeaveTypeID = rdr["LV_LeaveTypeID"].ToString(),
                                        LV_Approve = Convert.ToBoolean(rdr["LV_Approve"].ToString()),
                                        LV_ApprovedBy = rdr["LV_ApprovedBy"].ToString(),
                                        LV_ApprovedDate = approveddate,
                                        LV_Status = Convert.ToBoolean(rdr["LV_Status"].ToString()),
                                    };
                                    objLeaveHead.LeaveResponceModelList.Add(objLeaveDetail);
                                }

                            }
                            objLeaveHeadList.Add(objLeaveHead);
                        }
                        else
                        {
                            objLeaveHead.resp = true;
                            objLeaveHead.msg = "";
                            objLeaveHeadList.Add(objLeaveHead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objLeaveHead.resp = false;
                objLeaveHead.msg = ex.Message.ToString();

                objLeaveHeadList.Add(objLeaveHead);

                objError.WriteLog(0, "LeaveSchedule_Data", "get_leave_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveSchedule_Data", "get_leave_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveSchedule_Data", "get_leave_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveSchedule_Data", "get_leave_details", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objLeaveHeadList;
        }

        public static List<LeaveGridViewHeaderModel> get_leave_grid_details(LeaveGridRequestModel item)
        {
            List<LeaveGridViewHeaderModel> objLeaveHeadList = new List<LeaveGridViewHeaderModel>();
            LeaveGridViewHeaderModel objLeaveHead = new LeaveGridViewHeaderModel();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objLeaveHead.resp = false;
                objLeaveHead.IsAuthenticated = false;
                objLeaveHeadList.Add(objLeaveHead);
                return objLeaveHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_leave_grid_details";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAGE_NO", item.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", item.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        string RC = "";

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                if (Ds.Tables[0].Columns.Contains("RTN_RESP"))
                                {
                                    objLeaveHead.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                    objLeaveHead.msg = rdr["RTN_MSG"].ToString();
                                }
                                else
                                {
                                    DateTime enddate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["LV_LeaveEndDate"].ToString(), out enddate);
                                    DateTime startdate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["LV_LeaveStartDate"].ToString(), out startdate);
                                    DateTime approveddate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["LV_ApprovedDate"].ToString(), out approveddate);

                                    objLeaveHead.resp = true;
                                    objLeaveHead.msg = "Leave";

                                    LeaveGridViewModel objLeaveDetail = new LeaveGridViewModel()
                                    {
                                        LV_LeaveID = Convert.ToInt32(rdr["LV_LeaveID"].ToString()),
                                        LV_LeaveEndDate = enddate,
                                        LV_LeaveStartDate = startdate,
                                        LV_StaffID = rdr["LV_StaffID"].ToString(),
                                        LV_LeaveTypeID = rdr["LV_LeaveTypeID"].ToString(),
                                        LV_Approve = Convert.ToBoolean(rdr["LV_Approve"].ToString()),
                                        LV_ApprovedBy = rdr["LV_ApprovedBy"].ToString(),
                                        LV_ApprovedDate = approveddate,
                                        LV_Status = Convert.ToBoolean(rdr["LV_Status"].ToString()),
                                        RC = RC,
                                    };
                                    objLeaveHead.LeaveGridViewModelList.Add(objLeaveDetail);
                                }

                            }
                            objLeaveHeadList.Add(objLeaveHead);
                        }
                        else
                        {
                            objLeaveHead.resp = true;
                            objLeaveHead.msg = "";
                            objLeaveHeadList.Add(objLeaveHead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objLeaveHead.resp = false;
                objLeaveHead.msg = ex.Message.ToString();

                objLeaveHeadList.Add(objLeaveHead);

                objError.WriteLog(0, "LeaveSchedule_Data", "get_leave_grid_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveSchedule_Data", "get_leave_grid_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveSchedule_Data", "get_leave_grid_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveSchedule_Data", "get_leave_grid_details", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objLeaveHeadList;
        }
    }
}