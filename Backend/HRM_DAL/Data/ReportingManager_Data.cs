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
    public class ReportingManager_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnReportingManagerModelHead> get_ReportingManager_single(ReportingManager model)//ok
        {
            List<ReturnReportingManagerModelHead> objReportingManagerHeadList = new List<ReturnReportingManagerModelHead>();
            ReturnReportingManagerModelHead objReportingManagerHead = new ReturnReportingManagerModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objReportingManagerHead.resp = false;
                objReportingManagerHead.IsAuthenticated = false;
                objReportingManagerHeadList.Add(objReportingManagerHead);
                return objReportingManagerHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_ReportingManager_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@RM_ID", model.RM_ID);
                        cmd.Parameters["@RM_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnReportingManagerModel objReportingManager = new ReturnReportingManagerModel();

                                objReportingManagerHead.resp = true;
                                objReportingManagerHead.msg = "Get ReportingManager";

                                //objReportingManager.USR_ReportingManagerID = rdr["USR_ReportingManagerID"].ToString();
                                //objReportingManager.USR_CustomerID = rdr["USR_CustomerID"].ToString();
                                //objReportingManager.USR_DepartmentID = rdr["USR_DepartmentID"].ToString();
                                //objReportingManager.USR_FirstName = rdr["USR_FirstName"].ToString();
                                //objReportingManager.USR_LastName = rdr["USR_LastName"].ToString();
                                //objReportingManager.USR_PrefferedName = rdr["USR_PrefferedName"].ToString();
                                //objReportingManager.USR_OrgStructuralLevel1 = rdr["USR_OrgStructuralLevel1"].ToString();
                                //objReportingManager.USR_OrgStructuralLevel2 = rdr["USR_OrgStructuralLevel2"].ToString();
                                //objReportingManager.USR_DepartmentDetail1 = rdr["USR_DepartmentDetail1"].ToString();
                                //objReportingManager.USR_DepartmentDetail2 = rdr["USR_DepartmentDetail2"].ToString();
                                //objReportingManager.USR_DepartmentDetail3 = rdr["USR_DepartmentDetail3"].ToString();
                                //objReportingManager.USR_JobCodeDescription = rdr["USR_JobCodeDescription"].ToString();
                                //objReportingManager.USR_Address = rdr["USR_Address"].ToString();
                                //objReportingManager.USR_EmailAddress = rdr["USR_EmailAddress"].ToString();
                                //objReportingManager.USR_MobileNumber = rdr["USR_MobileNumber"].ToString();
                                //objReportingManager.USR_PhoneNumber1 = rdr["USR_PhoneNumber1"].ToString();
                                //objReportingManager.USR_PhoneNumber2 = rdr["USR_PhoneNumber2"].ToString();
                                //objReportingManager.USR_RankDescription = rdr["USR_RankDescription"].ToString();
                                //objReportingManager.USR_StaffLocation = rdr["USR_StaffLocation"].ToString();
                                //objReportingManager.USR_Remarks = rdr["USR_Remarks"].ToString();
                                //objReportingManager.USR_Pwd = rdr["USR_Pwd"].ToString();
                                //objReportingManager.USR_LastResetDateTime = rdr["USR_LastResetDateTime"].ToString();
                                //objReportingManager.USR_SyncedDateTime = rdr["USR_SyncedDateTime"].ToString();
                                //objReportingManager.USR_ActiveFrom = rdr["USR_ActiveFrom"].ToString();
                                //objReportingManager.USR_ActiveTo = rdr["USR_ActiveTo"].ToString();
                                //objReportingManager.USR_Status = Convert.ToBoolean(rdr["USR_Status"].ToString());

                                if (objReportingManagerHead.ReportingManager == null)
                                {
                                    objReportingManagerHead.ReportingManager = new List<ReturnReportingManagerModel>();
                                }

                                objReportingManagerHead.ReportingManager.Add(objReportingManager);

                                objReportingManagerHeadList.Add(objReportingManagerHead);
                            }

                        }
                        else
                        {
                            ReturnReportingManagerModel objReportingManager = new ReturnReportingManagerModel();
                            objReportingManagerHead.resp = true;
                            objReportingManagerHead.msg = "";
                            objReportingManagerHeadList.Add(objReportingManagerHead);


                        }


                    }
                    return objReportingManagerHeadList;

                }
            }
            catch (Exception ex)
            {
                objReportingManagerHead = new ReturnReportingManagerModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objReportingManagerHeadList.Add(objReportingManagerHead);

                objError.WriteLog(0, "ReportingManager_Data", "get_ReportingManager_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ReportingManager_Data", "get_ReportingManager_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ReportingManager_Data", "get_ReportingManager_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ReportingManager_Data", "get_ReportingManager_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
           }

            return objReportingManagerHeadList;

        }

        public static List<ReturnReportingManagerModelHead> get_ReportingManager_all(ReportingManagerSearchModel model)//ok
        {
            List<ReturnReportingManagerModelHead> objReportingManagerHeadList = new List<ReturnReportingManagerModelHead>();
            ReturnReportingManagerModelHead objReportingManagerHead = new ReturnReportingManagerModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objReportingManagerHead.resp = false;
                objReportingManagerHead.IsAuthenticated = false;
                objReportingManagerHeadList.Add(objReportingManagerHead);
                return objReportingManagerHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "get_ReportingManager_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@RM_ID", model.RM_ID);
                        cmd.Parameters["@RM_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnReportingManagerModel objReportingManager = new ReturnReportingManagerModel();

                                objReportingManagerHead.resp = true;
                                objReportingManagerHead.msg = "Get ReportingManager";

                                //objReportingManager.USR_ReportingManagerID = rdr["USR_ReportingManagerID"].ToString();
                                //objReportingManager.USR_CustomerID = rdr["USR_CustomerID"].ToString();
                                //objReportingManager.USR_DepartmentID = rdr["USR_DepartmentID"].ToString();
                                //objReportingManager.USR_FirstName = rdr["USR_FirstName"].ToString();
                                //objReportingManager.USR_LastName = rdr["USR_LastName"].ToString();
                                //objReportingManager.USR_PrefferedName = rdr["USR_PrefferedName"].ToString();
                                //objReportingManager.USR_OrgStructuralLevel1 = rdr["USR_OrgStructuralLevel1"].ToString();
                                //objReportingManager.USR_OrgStructuralLevel2 = rdr["USR_OrgStructuralLevel2"].ToString();
                                //objReportingManager.USR_DepartmentDetail1 = rdr["USR_DepartmentDetail1"].ToString();
                                //objReportingManager.USR_DepartmentDetail2 = rdr["USR_DepartmentDetail2"].ToString();
                                //objReportingManager.USR_DepartmentDetail3 = rdr["USR_DepartmentDetail3"].ToString();
                                //objReportingManager.USR_JobCodeDescription = rdr["USR_JobCodeDescription"].ToString();
                                //objReportingManager.USR_Address = rdr["USR_Address"].ToString();
                                //objReportingManager.USR_EmailAddress = rdr["USR_EmailAddress"].ToString();
                                //objReportingManager.USR_MobileNumber = rdr["USR_MobileNumber"].ToString();
                                //objReportingManager.USR_PhoneNumber1 = rdr["USR_PhoneNumber1"].ToString();
                                //objReportingManager.USR_PhoneNumber2 = rdr["USR_PhoneNumber2"].ToString();
                                //objReportingManager.USR_RankDescription = rdr["USR_RankDescription"].ToString();
                                //objReportingManager.USR_StaffLocation = rdr["USR_StaffLocation"].ToString();
                                //objReportingManager.USR_Remarks = rdr["USR_Remarks"].ToString();
                                //objReportingManager.USR_Pwd = rdr["USR_Pwd"].ToString();
                                ////objReportingManager.USR_LastResetDateTime = rdr["USR_LastResetDateTime"].ToString();
                                ////objReportingManager.USR_SyncedDateTime = rdr["USR_SyncedDateTime"].ToString();
                                ////objReportingManager.USR_ActiveFrom = rdr["USR_ActiveFrom"].ToString();
                                ////objReportingManager.USR_ActiveTo = rdr["USR_ActiveTo"].ToString();
                                //objReportingManager.USR_Status = Convert.ToBoolean(rdr["USR_Status"].ToString());

                                if (objReportingManagerHead.ReportingManager == null)
                                {
                                    objReportingManagerHead.ReportingManager = new List<ReturnReportingManagerModel>();
                                }

                                objReportingManagerHead.ReportingManager.Add(objReportingManager);

                                objReportingManagerHeadList.Add(objReportingManagerHead);
                            }

                        }
                        else
                        {
                            ReturnReportingManagerModel objReportingManager = new ReturnReportingManagerModel();
                            objReportingManagerHead.resp = true;
                            objReportingManagerHead.msg = "";
                            objReportingManagerHeadList.Add(objReportingManagerHead);


                        }


                    }
                    return objReportingManagerHeadList;

                }
            }
            catch (Exception ex)
            {
                objReportingManagerHead = new ReturnReportingManagerModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objReportingManagerHeadList.Add(objReportingManagerHead);

                objError.WriteLog(0, "ReportingManager_Data", "get_ReportingManager_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ReportingManager_Data", "get_ReportingManager_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ReportingManager_Data", "get_ReportingManager_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ReportingManager_Data", "get_ReportingManager_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objReportingManagerHeadList;

        }

        public static List<ReturncustResponse> add_new_ReportingManager(ReportingManagerModel item)//ok
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


                        cmd.CommandText = "sp_insert_ReportingManager";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@USR_ReportingManagerID", item.USR_ReportingManagerID);
                        //cmd.Parameters["@USR_ReportingManagerID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "ReportingManager_Data", "add_new_ReportingManager", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ReportingManager_Data", "add_new_ReportingManager", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ReportingManager_Data", "add_new_ReportingManager", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ReportingManager_Data", "add_new_ReportingManager", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturncustResponse> modify_ReportingManager(ReportingManagerModel item)//ok
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


                        cmd.CommandText = "sp_modify_ReportingManager";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@USR_ReportingManagerID", item.USR_ReportingManagerID);
                        //cmd.Parameters["@USR_ReportingManagerID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "ReportingManager_Data", "add_new_ReportingManager", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ReportingManager_Data", "add_new_ReportingManager", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ReportingManager_Data", "add_new_ReportingManager", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ReportingManager_Data", "add_new_ReportingManager", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> inactivate_ReportingManager(InactiveRMModel item)//ok
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



                        cmd.CommandText = "sp_del_ReportingManager";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@RM_ID", item.RM_ID);
                        cmd.Parameters["@RM_ID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "ReportingManager_Data", "inactivate_ReportingManager", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ReportingManager_Data", "inactivate_ReportingManager", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ReportingManager_Data", "inactivate_ReportingManager", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ReportingManager_Data", "inactivate_ReportingManager", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }



        }
    }

}

