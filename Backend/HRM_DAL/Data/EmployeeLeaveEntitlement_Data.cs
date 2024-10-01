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
    public class EmployeeLeaveEntitlement_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnEmployeeLeaveEntitlementModelHead> get_EmployeeLeaveEntitlement_single(EmployeeLeaveEntitlement model)//ok
        {
            List<ReturnEmployeeLeaveEntitlementModelHead> objEmployeeLeaveEntitlementHeadList = new List<ReturnEmployeeLeaveEntitlementModelHead>();
            ReturnEmployeeLeaveEntitlementModelHead objEmployeeLeaveEntitlementHead = new ReturnEmployeeLeaveEntitlementModelHead();

            if (objEmployeeLeaveEntitlementHead.EmployeeLeaveEntitlement == null)
            {
                objEmployeeLeaveEntitlementHead.EmployeeLeaveEntitlement = new List<ReturnEmployeeLeaveEntitlementModel>();
            }

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objEmployeeLeaveEntitlementHead.resp = false;
                objEmployeeLeaveEntitlementHead.IsAuthenticated = false;
                objEmployeeLeaveEntitlementHeadList.Add(objEmployeeLeaveEntitlementHead);
                return objEmployeeLeaveEntitlementHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_EmployeeLeaveEntitlement_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EELE_ID", model.EELE_ID);
                        cmd.Parameters["@EELE_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnEmployeeLeaveEntitlementModel objEmployeeLeaveEntitlement = new ReturnEmployeeLeaveEntitlementModel();

                                objEmployeeLeaveEntitlementHead.resp = true;
                                objEmployeeLeaveEntitlementHead.msg = "Get EmployeeLeaveEntitlement";

                                objEmployeeLeaveEntitlement.EELE_ID = Convert.ToInt32(rdr["EELE_ID"].ToString());
                                objEmployeeLeaveEntitlement.EELE_EmployeeID = rdr["EELE_EmployeeID"].ToString();
                                objEmployeeLeaveEntitlement.EELE_LeaveTypeID = rdr["EELE_LeaveTypeID"].ToString();
                                objEmployeeLeaveEntitlement.EELE_LeaveAlotment = Convert.ToDecimal(rdr["EELE_LeaveAlotment"].ToString());
                                objEmployeeLeaveEntitlement.EELE_Remain = Convert.ToDecimal(rdr["EELE_Remain"].ToString());
                                objEmployeeLeaveEntitlement.EELE_ActiveFrom = Convert.ToDateTime(rdr["EELE_ActiveFrom"].ToString());
                                objEmployeeLeaveEntitlement.EELE_ActiveTo = Convert.ToDateTime(rdr["EELE_ActiveTo"].ToString());
                                objEmployeeLeaveEntitlement.EELE_Status = Convert.ToBoolean(rdr["EELE_Status"].ToString());

                                objEmployeeLeaveEntitlementHead.EmployeeLeaveEntitlement.Add(objEmployeeLeaveEntitlement);

                                objEmployeeLeaveEntitlementHeadList.Add(objEmployeeLeaveEntitlementHead);
                            }

                        }
                        else
                        {
                            ReturnEmployeeLeaveEntitlementModel objEmployeeLeaveEntitlement = new ReturnEmployeeLeaveEntitlementModel();
                            objEmployeeLeaveEntitlementHead.resp = true;
                            objEmployeeLeaveEntitlementHead.msg = "";
                            objEmployeeLeaveEntitlementHeadList.Add(objEmployeeLeaveEntitlementHead);


                        }


                    }
                    return objEmployeeLeaveEntitlementHeadList;

                }
            }
            catch (Exception ex)
            {
                objEmployeeLeaveEntitlementHead.resp = false;
                objEmployeeLeaveEntitlementHead.msg = ex.Message.ToString();

                objEmployeeLeaveEntitlementHeadList.Add(objEmployeeLeaveEntitlementHead);

                objError.WriteLog(0, "EmployeeLeaveEntitlement_Data", "get_EmployeeLeaveEntitlement_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeLeaveEntitlement_Data", "get_EmployeeLeaveEntitlement_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeLeaveEntitlement_Data", "get_EmployeeLeaveEntitlement_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeLeaveEntitlement_Data", "get_EmployeeLeaveEntitlement_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objEmployeeLeaveEntitlementHeadList;

        }

        public static List<ReturnEmployeeLeaveEntitlementModelHead> get_EmployeeLeaveEntitlement_all(EmployeeLeaveEntitlementSearchModel model)//ok
        {
            List<ReturnEmployeeLeaveEntitlementModelHead> objEmployeeLeaveEntitlementHeadList = new List<ReturnEmployeeLeaveEntitlementModelHead>();
            ReturnEmployeeLeaveEntitlementModelHead objEmployeeLeaveEntitlementHead = new ReturnEmployeeLeaveEntitlementModelHead();

            if (objEmployeeLeaveEntitlementHead.EmployeeLeaveEntitlement == null)
            {
                objEmployeeLeaveEntitlementHead.EmployeeLeaveEntitlement = new List<ReturnEmployeeLeaveEntitlementModel>();
            }

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objEmployeeLeaveEntitlementHead.resp = false;
                objEmployeeLeaveEntitlementHead.IsAuthenticated = false;
                objEmployeeLeaveEntitlementHeadList.Add(objEmployeeLeaveEntitlementHead);
                return objEmployeeLeaveEntitlementHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_EmployeeLeaveEntitlement_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EELE_EmployeeID", model.EELE_EmployeeID);
                        cmd.Parameters["@EELE_EmployeeID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnEmployeeLeaveEntitlementModel objEmployeeLeaveEntitlement = new ReturnEmployeeLeaveEntitlementModel();

                                objEmployeeLeaveEntitlementHead.resp = true;
                                objEmployeeLeaveEntitlementHead.msg = "Get EmployeeLeaveEntitlement";

                                objEmployeeLeaveEntitlement.EELE_ID = Convert.ToInt32(rdr["EELE_ID"].ToString());
                                objEmployeeLeaveEntitlement.EELE_EmployeeID = rdr["EELE_EmployeeID"].ToString();
                                objEmployeeLeaveEntitlement.EELE_LeaveTypeID = rdr["EELE_LeaveTypeID"].ToString();
                                objEmployeeLeaveEntitlement.EELE_LeaveAlotment = Convert.ToDecimal(rdr["EELE_LeaveAlotment"].ToString());
                                objEmployeeLeaveEntitlement.EELE_Remain = Convert.ToDecimal(rdr["EELE_Remain"].ToString());
                                objEmployeeLeaveEntitlement.EELE_ActiveFrom = Convert.ToDateTime(rdr["EELE_ActiveFrom"].ToString());
                                objEmployeeLeaveEntitlement.EELE_ActiveTo = Convert.ToDateTime(rdr["EELE_ActiveTo"].ToString());
                                objEmployeeLeaveEntitlement.EELE_Status = Convert.ToBoolean(rdr["EELE_Status"].ToString());

                                objEmployeeLeaveEntitlementHead.EmployeeLeaveEntitlement.Add(objEmployeeLeaveEntitlement);

                                objEmployeeLeaveEntitlementHeadList.Add(objEmployeeLeaveEntitlementHead);
                            }

                        }
                        else
                        {
                            ReturnEmployeeLeaveEntitlementModel objEmployeeLeaveEntitlement = new ReturnEmployeeLeaveEntitlementModel();
                            objEmployeeLeaveEntitlementHead.resp = true;
                            objEmployeeLeaveEntitlementHead.msg = "";
                            objEmployeeLeaveEntitlementHeadList.Add(objEmployeeLeaveEntitlementHead);


                        }


                    }
                    return objEmployeeLeaveEntitlementHeadList;

                }
            }
            catch (Exception ex)
            {
                objEmployeeLeaveEntitlementHead.resp = false;
                objEmployeeLeaveEntitlementHead.msg = ex.Message.ToString();

                objEmployeeLeaveEntitlementHeadList.Add(objEmployeeLeaveEntitlementHead);

                objError.WriteLog(0, "EmployeeLeaveEntitlement_Data", "get_EmployeeLeaveEntitlement_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeLeaveEntitlement_Data", "get_EmployeeLeaveEntitlement_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeLeaveEntitlement_Data", "get_EmployeeLeaveEntitlement_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeLeaveEntitlement_Data", "get_EmployeeLeaveEntitlement_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objEmployeeLeaveEntitlementHeadList;

        }

        public static List<ReturnResponse> add_new_EmployeeLeaveEntitlement(EmployeeLeaveEntitlementModel item)//ok
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


                        cmd.CommandText = "sp_insert_EmployeeLeaveEntitlement";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@EELE_ID", item.EELE_ID);
                        //cmd.Parameters["@EELE_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EELE_EmployeeID", item.EELE_EmployeeID);
                        cmd.Parameters["@EELE_EmployeeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EELE_LeaveTypeID", item.EELE_LeaveTypeID);
                        cmd.Parameters["@EELE_LeaveTypeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EELE_LeaveAlotment", item.EELE_LeaveAlotment);
                        cmd.Parameters["@EELE_LeaveAlotment"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EELE_ActiveFrom", item.EELE_ActiveFrom);
                        cmd.Parameters["@EELE_ActiveFrom"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EELE_ActiveTo", item.EELE_ActiveTo);
                        cmd.Parameters["@EELE_ActiveTo"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "EmployeeLeaveEntitlement_Data", "add_new_EmployeeLeaveEntitlement", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeLeaveEntitlement_Data", "add_new_EmployeeLeaveEntitlement", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeLeaveEntitlement_Data", "add_new_EmployeeLeaveEntitlement", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeLeaveEntitlement_Data", "add_new_EmployeeLeaveEntitlement", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> modify_EmployeeLeaveEntitlement(EmployeeLeaveEntitlementModel item)//ok
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


                        cmd.CommandText = "sp_modify_EmployeeLeaveEntitlement";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;


                        cmd.Parameters.AddWithValue("@EELE_ID", item.EELE_ID);
                        cmd.Parameters["@EELE_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EELE_EmployeeID", item.EELE_EmployeeID);
                        cmd.Parameters["@EELE_EmployeeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EELE_LeaveTypeID", item.EELE_LeaveTypeID);
                        cmd.Parameters["@EELE_LeaveTypeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EELE_LeaveAlotment", item.EELE_LeaveAlotment);
                        cmd.Parameters["@EELE_LeaveAlotment"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EELE_ActiveFrom", item.EELE_ActiveFrom);
                        cmd.Parameters["@EELE_ActiveFrom"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EELE_ActiveTo", item.EELE_ActiveTo);
                        cmd.Parameters["@EELE_ActiveTo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EELE_Status", item.EELE_Status);
                        cmd.Parameters["@EELE_Status"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "EmployeeLeaveEntitlement_Data", "add_new_EmployeeLeaveEntitlement", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeLeaveEntitlement_Data", "add_new_EmployeeLeaveEntitlement", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeLeaveEntitlement_Data", "add_new_EmployeeLeaveEntitlement", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeLeaveEntitlement_Data", "add_new_EmployeeLeaveEntitlement", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> inactivate_EmployeeLeaveEntitlement(InactiveEELEModel item)//ok
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



                        cmd.CommandText = "sp_del_EmployeeLeaveEntitlement";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EELE_ID", item.EELE_ID);
                        cmd.Parameters["@EELE_ID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "EmployeeLeaveEntitlement_Data", "inactivate_EmployeeLeaveEntitlement", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeLeaveEntitlement_Data", "inactivate_EmployeeLeaveEntitlement", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeLeaveEntitlement_Data", "inactivate_EmployeeLeaveEntitlement", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeLeaveEntitlement_Data", "inactivate_EmployeeLeaveEntitlement", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }



        }
    }

}

