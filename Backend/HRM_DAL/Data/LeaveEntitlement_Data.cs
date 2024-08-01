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
    public class LeaveEntitlement_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnLeaveEntitlementModelHead> get_LeaveEntitlements_single(LeaveEntitlement model)//ok
        {
            List<ReturnLeaveEntitlementModelHead> objLeaveEntitlementHeadList = new List<ReturnLeaveEntitlementModelHead>();
            ReturnLeaveEntitlementModelHead objLeaveEntitlementHead = new ReturnLeaveEntitlementModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objLeaveEntitlementHead.resp = false;
                objLeaveEntitlementHead.IsAuthenticated = false;
                objLeaveEntitlementHeadList.Add(objLeaveEntitlementHead);
                return objLeaveEntitlementHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_LeaveEntitlements_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@LVE_LeaveEntitlementID", model.LVE_LeaveEntitlementID);
                        cmd.Parameters["@LVE_LeaveEntitlementID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnLeaveEntitlementModel objLeaveEntitlement = new ReturnLeaveEntitlementModel();

                                objLeaveEntitlementHead.resp = true;
                                objLeaveEntitlementHead.msg = "Get LeaveEntitlement";

                                objLeaveEntitlement.LVE_LeaveEntitlementID = Convert.ToInt16(rdr["LVE_LeaveEntitlementID"].ToString());
                                objLeaveEntitlement.LVE_LeaveAlotment = Convert.ToInt16(rdr["LVE_LeaveAlotment"].ToString());
                                objLeaveEntitlement.LVE_LeaveType = rdr["LVE_LeaveType"].ToString();
                                objLeaveEntitlement.LVE_LeaveTypeID = rdr["LVE_LeaveTypeID"].ToString();
                                objLeaveEntitlement.LVE_EmployeeID = rdr["LVE_EmployeeID"].ToString();
                                objLeaveEntitlement.LVE_Status = Convert.ToBoolean(rdr["LVE_Status"].ToString());

                                if (objLeaveEntitlementHead.LeaveEntitlement == null)
                                {
                                    objLeaveEntitlementHead.LeaveEntitlement = new List<ReturnLeaveEntitlementModel>();
                                }

                                objLeaveEntitlementHead.LeaveEntitlement.Add(objLeaveEntitlement);

                                objLeaveEntitlementHeadList.Add(objLeaveEntitlementHead);
                            }

                        }
                        else
                        {
                            ReturnLeaveEntitlementModel objLeaveEntitlement = new ReturnLeaveEntitlementModel();
                            objLeaveEntitlementHead.resp = true;
                            objLeaveEntitlementHead.msg = "";
                            objLeaveEntitlementHeadList.Add(objLeaveEntitlementHead);


                        }


                    }
                    return objLeaveEntitlementHeadList;

                }
            }
            catch (Exception ex)
            {
                objLeaveEntitlementHead = new ReturnLeaveEntitlementModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objLeaveEntitlementHeadList.Add(objLeaveEntitlementHead);

                objError.WriteLog(0, "LeaveEntitlement_Data", "get_LeaveEntitlements_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveEntitlement_Data", "get_LeaveEntitlements_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveEntitlement_Data", "get_LeaveEntitlements_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveEntitlement_Data", "get_LeaveEntitlements_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objLeaveEntitlementHeadList;

        }

        public static List<ReturnLeaveEntitlementModelHead> get_LeaveEntitlement_all(LeaveEntitlementSearchModel model)//ok
        {
            List<ReturnLeaveEntitlementModelHead> objLeaveEntitlementHeadList = new List<ReturnLeaveEntitlementModelHead>();
            ReturnLeaveEntitlementModelHead objLeaveEntitlementHead = new ReturnLeaveEntitlementModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objLeaveEntitlementHead.resp = false;
                objLeaveEntitlementHead.IsAuthenticated = false;
                objLeaveEntitlementHeadList.Add(objLeaveEntitlementHead);
                return objLeaveEntitlementHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "get_LeaveEntitlement_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@LVE_LeaveEntitlementID", model.LVE_LeaveEntitlementID);
                        cmd.Parameters["@LVE_LeaveEntitlementID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnLeaveEntitlementModel objLeaveEntitlement = new ReturnLeaveEntitlementModel();

                                objLeaveEntitlementHead.resp = true;
                                objLeaveEntitlementHead.msg = "Get LeaveEntitlement";

                                objLeaveEntitlement.LVE_LeaveEntitlementID = Convert.ToInt16(rdr["LVE_LeaveEntitlementID"].ToString());
                                objLeaveEntitlement.LVE_LeaveAlotment = Convert.ToInt16(rdr["LVE_LeaveAlotment"].ToString());
                                objLeaveEntitlement.LVE_LeaveType = rdr["LVE_LeaveType"].ToString();
                                objLeaveEntitlement.LVE_LeaveTypeID = rdr["LVE_LeaveTypeID"].ToString();
                                objLeaveEntitlement.LVE_EmployeeID = rdr["LVE_EmployeeID"].ToString();
                                objLeaveEntitlement.LVE_Status = Convert.ToBoolean(rdr["LVE_Status"].ToString());

                                if (objLeaveEntitlementHead.LeaveEntitlement == null)
                                {
                                    objLeaveEntitlementHead.LeaveEntitlement = new List<ReturnLeaveEntitlementModel>();
                                }

                                objLeaveEntitlementHead.LeaveEntitlement.Add(objLeaveEntitlement);

                                objLeaveEntitlementHeadList.Add(objLeaveEntitlementHead);
                            }

                        }
                        else
                        {
                            ReturnLeaveEntitlementModel objLeaveEntitlement = new ReturnLeaveEntitlementModel();
                            objLeaveEntitlementHead.resp = true;
                            objLeaveEntitlementHead.msg = "";
                            objLeaveEntitlementHeadList.Add(objLeaveEntitlementHead);


                        }


                    }
                    return objLeaveEntitlementHeadList;

                }
            }
            catch (Exception ex)
            {
                objLeaveEntitlementHead = new ReturnLeaveEntitlementModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objLeaveEntitlementHeadList.Add(objLeaveEntitlementHead);

                objError.WriteLog(0, "LeaveEntitlement_Data", "get_LeaveEntitlement_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveEntitlement_Data", "get_LeaveEntitlement_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveEntitlement_Data", "get_LeaveEntitlement_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveEntitlement_Data", "get_LeaveEntitlement_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objLeaveEntitlementHeadList;

        }

        public static List<ReturncustResponse> add_new_LeaveEntitlement(LeaveEntitlementModel item)//ok
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


                        cmd.CommandText = "sp_insert_LeaveEntitlement";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@LVE_LeaveEntitlementID", item.LVE_LeaveEntitlementID);
                        cmd.Parameters["@LVE_LeaveEntitlementID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "LeaveEntitlement_Data", "add_new_LeaveEntitlement", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveEntitlement_Data", "add_new_LeaveEntitlement", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveEntitlement_Data", "add_new_LeaveEntitlement", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveEntitlement_Data", "add_new_LeaveEntitlement", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturncustResponse> modify_LeaveEntitlement(LeaveEntitlementModel item)//ok
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


                        cmd.CommandText = "sp_modify_LeaveEntitlement";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@LVE_LeaveEntitlementID", item.LVE_LeaveEntitlementID);
                        cmd.Parameters["@LVE_LeaveEntitlementID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "LeaveEntitlement_Data", "add_new_LeaveEntitlement", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveEntitlement_Data", "add_new_LeaveEntitlement", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveEntitlement_Data", "add_new_LeaveEntitlement", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveEntitlement_Data", "add_new_LeaveEntitlement", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> inactivate_LeaveEntitlement(InactiveLVEModel item)//ok
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



                        cmd.CommandText = "sp_del_LeaveEntitlement";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@LVE_LeaveEntitlementID", item.LVE_LeaveEntitlementID);
                        cmd.Parameters["@LVE_LeaveEntitlementID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "LeaveEntitlement_Data", "inactivate_LeaveEntitlement", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveEntitlement_Data", "inactivate_LeaveEntitlement", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveEntitlement_Data", "inactivate_LeaveEntitlement", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveEntitlement_Data", "inactivate_LeaveEntitlement", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }



        }
    }

}

