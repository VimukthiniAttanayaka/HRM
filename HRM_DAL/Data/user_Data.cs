using email_sender;
using error_handler;
using ExcelDataReader;
using HRM_DAL.Models;
using HRM_DAL.Models.RequestModels;
using HRM_DAL.Models.ResponceModels;
using HRM_DAL.Utility;
using Newtonsoft.Json;
using sms_core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Claims;
using utility_handler.Data;
using email_sender.Models;

namespace HRM_DAL.Data
{
    public class User_Data
    {
        private static LogError objError = new LogError();
        private static SendMail sendMail = new SendMail();
        //private static SendSMS sendSMS = new SendSMS();

        private static void reset_password_mailtrack(string UserID, string encryptedPW, decimal Salt, string tablename, string CUS_PinOrPwd, ref List<ReturnResponse> objUserHeadList)
        {
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();


                        cmd.CommandText = "reset_password_mailtrack";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@USER_ID", ConfigCaller.HRMUserName);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_STAFFID", UserID);
                        cmd.Parameters["@USR_STAFFID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@SALT", Salt);
                        cmd.Parameters["@SALT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@ENCRYPTEDPW", encryptedPW);
                        cmd.Parameters["@ENCRYPTEDPW"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TABLENAME", tablename);
                        cmd.Parameters["@TABLENAME"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_PINORPWD", CUS_PinOrPwd);
                        cmd.Parameters["@CUS_PINORPWD"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnResponse objUserHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objUserHeadList.Add(objUserHead);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                objError.WriteLog(0, "User_Data", "reset_password_mailtrack", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "User_Data", "reset_password_mailtrack", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "User_Data", "reset_password_mailtrack", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "User_Data", "reset_password_mailtrack", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
        }

        public static List<ReturnCustomerUserModelHead> get_c_user_single(CUser CUser)//ok
        {
            List<ReturnCustomerUserModelHead> objCusUserHeadList = new List<ReturnCustomerUserModelHead>();

            List<ReturnCusUserGroupModel> objGrpSList = new List<ReturnCusUserGroupModel>();
            bool UserHadKIOSKAccess = false;

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    ReturnCustomerUserModelHead objCusUserHead = new ReturnCustomerUserModelHead();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_customer_user";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@USER_ID", CUser.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TABLE", CUser.TABLE);
                        cmd.Parameters["@TABLE"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnCustomerUserModel objCusUserData = new ReturnCustomerUserModel();

                                objCusUserHead.resp = true;
                                objCusUserHead.msg = "Get Customer User";

                                objCusUserData.USR_CustomerID = rdr["USR_CustomerID"].ToString();
                                objCusUserData.CUS_CompanyName = rdr["CUS_CompanyName"].ToString();
                                objCusUserData.USR_DepartmentID = rdr["USR_DepartmentID"].ToString();
                                objCusUserData.DPT_Name = rdr["DPT_Name"].ToString();
                                objCusUserData.USR_StaffID = rdr["USR_StaffID"].ToString();
                                objCusUserData.USR_FirstName = rdr["USR_FirstName"].ToString();
                                objCusUserData.USR_LastName = rdr["USR_LastName"].ToString();
                                objCusUserData.USR_PrefferedName = rdr["USR_PrefferedName"].ToString();
                                objCusUserData.USR_OrgStructuralLevel1 = rdr["USR_OrgStructuralLevel1"].ToString();
                                objCusUserData.USR_OrgStructuralLevel2 = rdr["USR_OrgStructuralLevel2"].ToString();
                                objCusUserData.USR_DepartmentDetail1 = rdr["USR_DepartmentDetail1"].ToString();
                                objCusUserData.USR_DepartmentDetail2 = rdr["USR_DepartmentDetail2"].ToString();
                                objCusUserData.USR_DepartmentDetail3 = rdr["USR_DepartmentDetail3"].ToString();
                                objCusUserData.USR_JobCodeDescription = rdr["USR_JobCodeDescription"].ToString();
                                objCusUserData.USR_Address = rdr["USR_Address"].ToString();
                                objCusUserData.USR_EmailAddress = rdr["USR_EmailAddress"].ToString();
                                objCusUserData.USR_MobileNumber = rdr["USR_MobileNumber"].ToString();
                                objCusUserData.USR_PhoneNumber1 = rdr["USR_PhoneNumber1"].ToString();
                                objCusUserData.USR_PhoneNumber2 = rdr["USR_PhoneNumber2"].ToString();
                                objCusUserData.USR_RankDescription = rdr["USR_RankDescription"].ToString();
                                objCusUserData.USR_StaffLocation = rdr["USR_StaffLocation"].ToString();
                                objCusUserData.USR_PCCode = rdr["USR_PCCode"].ToString();
                                objCusUserData.USR_PCDescription = rdr["USR_PCDescription"].ToString();
                                objCusUserData.USR_Remarks = rdr["USR_Remarks"].ToString();
                                objCusUserData.USR_OutgoingMailFlag = Convert.ToBoolean(rdr["USR_OutgoingMailFlag"]);
                                objCusUserData.USR_HRMAccessFlag = Convert.ToBoolean(rdr["USR_HRMAccessFlag"]);
                                objCusUserData.USR_ChangePCCodeFlag = Convert.ToBoolean(rdr["USR_ChangePCCodeFlag"]);
                                objCusUserData.USR_MailBagCPCode = rdr["USR_MailBagCPCode"].ToString();
                                objCusUserData.USR_OutgoingMailCPCode = rdr["USR_OutgoingMailCPCode"].ToString();
                                objCusUserData.USR_OutgoingMailLocationCode = rdr["USR_OutgoingMailLocationCode"].ToString();
                                objCusUserData.USR_PostageUsageReportFrequency = rdr["USR_PostageUsageReportFrequency"].ToString();
                                objCusUserData.USR_Status = rdr["USR_Status"].ToString();
                                objCusUserData.USR_Pwd = rdr["USR_Pwd"].ToString();
                                objCusUserData.USR_PwdSalt = rdr["USR_PwdSalt"].ToString();
                                objCusUserData.USR_CreatedDateTime = rdr["USR_CreatedDateTime"].ToString();
                                objCusUserData.USR_ModifiedDateTime = rdr["USR_ModifiedDateTime"].ToString();
                                objCusUserData.USR_ActiveFrom = rdr["USR_ActiveFrom"].ToString();
                                objCusUserData.USR_ActiveTo = rdr["USR_ActiveTo"].ToString();
                                objCusUserData.BU_ID = rdr["CUS_BusinessUnit"].ToString();

                                objCusUserData.RC = "1";

                                using (SqlCommand cmdGrp = new SqlCommand())
                                {
                                    cmdGrp.Connection = lconn;

                                    cmdGrp.CommandText = "sp_get_c_user_groups_with_select";
                                    cmdGrp.CommandType = CommandType.StoredProcedure;

                                    cmdGrp.Parameters.AddWithValue("@USER_ID", CUser.USER_ID);
                                    cmdGrp.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                                    cmdGrp.Parameters.AddWithValue("@TABLE", CUser.TABLE);
                                    cmdGrp.Parameters["@TABLE"].Direction = ParameterDirection.Input;

                                    SqlDataAdapter dtaGrp = new SqlDataAdapter();
                                    dtaGrp.SelectCommand = cmdGrp;
                                    DataSet DsGrp = new DataSet();
                                    dtaGrp.Fill(DsGrp);

                                    if (DsGrp != null && DsGrp.Tables.Count > 0 && DsGrp.Tables[0].Rows.Count > 0)
                                    {
                                        foreach (DataRow rdrGrp in DsGrp.Tables[0].Rows)
                                        {
                                            ReturnCusUserGroupModel objGrpData = new ReturnCusUserGroupModel
                                            {
                                                UGM_ID = rdrGrp["UGM_ID"].ToString(),
                                                IndexNo = rdrGrp["IndexNo"].ToString(),
                                                UGM_Name = rdrGrp["UGM_Name"].ToString(),
                                                //UAG_CustomerID = rdrGrp["UGM_Name"].ToString(),
                                                UAG_Select = Convert.ToBoolean(rdrGrp["UAG_Select"])
                                            };



                                            objGrpSList.Add(objGrpData);

                                            if (objCusUserData.cususergroup == null)
                                            {
                                                objCusUserData.cususergroup = new List<ReturnCusUserGroupModel>();
                                            }


                                            objCusUserData.cususergroup.Add(objGrpData);
                                        }

                                    }

                                }

                                using (SqlCommand cmdGrpK = new SqlCommand())
                                {
                                    cmdGrpK.Connection = lconn;

                                    cmdGrpK.CommandText = "sp_get_c_user_groups_with_select_kioski";
                                    cmdGrpK.CommandType = CommandType.StoredProcedure;

                                    cmdGrpK.Parameters.AddWithValue("@USER_ID", CUser.USER_ID);
                                    cmdGrpK.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                                    cmdGrpK.Parameters.AddWithValue("@TABLE", CUser.TABLE);
                                    cmdGrpK.Parameters["@TABLE"].Direction = ParameterDirection.Input;

                                    SqlDataAdapter dtaGrp = new SqlDataAdapter();
                                    dtaGrp.SelectCommand = cmdGrpK;
                                    DataSet DsGrp = new DataSet();
                                    dtaGrp.Fill(DsGrp);

                                    if (DsGrp != null && DsGrp.Tables.Count > 0 && DsGrp.Tables[0].Rows.Count > 0)
                                    {
                                        foreach (DataRow rdrGrp in DsGrp.Tables[0].Rows)
                                        {
                                            ReturnCusUserGroupModel objGrpData = new ReturnCusUserGroupModel
                                            {
                                                UGM_ID = rdrGrp["UGM_ID"].ToString(),
                                                IndexNo = rdrGrp["IndexNo"].ToString(),
                                                UGM_Name = rdrGrp["UGM_Name"].ToString(),
                                                UAG_CustomerID = rdrGrp["UAG_CustomerID"].ToString(),
                                                UAG_Select = Convert.ToBoolean(rdrGrp["UAG_Select"])
                                            };

                                            objGrpSList.Add(objGrpData);

                                            if (objCusUserData.cususergroupKioski == null)
                                            {
                                                objCusUserData.cususergroupKioski = new List<ReturnCusUserGroupModel>();
                                            }


                                            objCusUserData.cususergroupKioski.Add(objGrpData);
                                        }

                                    }

                                }

                                if (objCusUserHead.User == null)
                                {
                                    objCusUserHead.User = new List<ReturnCustomerUserModel>();
                                }

                                objCusUserHead.User.Add(objCusUserData);
                            }


                            objCusUserHeadList.Add(objCusUserHead);
                        }
                        else
                        {
                            objCusUserHead.resp = true;
                            objCusUserHead.msg = "";
                            objCusUserHeadList.Add(objCusUserHead);
                        }
                    }
                    objError.WriteLog(0, "User_Data", "get_c_user_single", "Log Track: " + JsonConvert.SerializeObject(objCusUserHeadList));
                    return objCusUserHeadList;

                }
            }
            catch (Exception ex)
            {

                ReturnCustomerUserModelHead objCusUserHead = new ReturnCustomerUserModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCusUserHeadList.Add(objCusUserHead);

                objError.WriteLog(0, "User_Data", "get_c_user_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "User_Data", "get_c_user_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "User_Data", "get_c_user_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "User_Data", "get_c_user_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCusUserHeadList;

        }

        public static List<ReturnCustomerUserAllModelHead> get_c_user_all(GetCustomerUserAllModel CUserall)//ok
        {
            List<ReturnCustomerUserAllModelHead> objCusUserHeadList = new List<ReturnCustomerUserAllModelHead>();
            List<ReturnCusUserAllModel> objCusUserSList = new List<ReturnCusUserAllModel>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    ReturnCustomerUserAllModelHead objCusUserHead = new ReturnCustomerUserAllModelHead();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_customer_user_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAGE_NO", CUserall.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", CUserall.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_StaffID", CUserall.USR_StaffID);
                        cmd.Parameters["@USR_StaffID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_FirstName", CUserall.USR_FirstName);
                        cmd.Parameters["@USR_FirstName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_LastName", CUserall.USR_LastName);
                        cmd.Parameters["@USR_LastName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UGM_Name", CUserall.UGM_Name);
                        cmd.Parameters["@UGM_Name"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_ID", CUserall.BU_ID);
                        cmd.Parameters["@BU_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_ID", CUserall.CUS_ID);
                        cmd.Parameters["@CUS_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPT_ID", CUserall.DPT_ID);
                        cmd.Parameters["@DPT_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_Status", CUserall.USR_Status);
                        cmd.Parameters["@USR_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TABLE", CUserall.TABLE);
                        cmd.Parameters["@TABLE"].Direction = ParameterDirection.Input;

                        string RC;
                        using (SqlCommand cmdrc = new SqlCommand())
                        {
                            cmdrc.Connection = lconn;

                            cmdrc.CommandText = "sp_get_customer_user_count";
                            cmdrc.CommandType = CommandType.StoredProcedure;

                            cmdrc.Parameters.AddWithValue("@TABLE", CUserall.TABLE);
                            cmdrc.Parameters["@TABLE"].Direction = ParameterDirection.Input;
                            SqlDataReader rdrrc = cmdrc.ExecuteReader();
                            rdrrc.Read();
                            RC = rdrrc["RC"].ToString();
                            rdrrc.Close();
                        }

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnCusUserAllModel objCusUserData = new ReturnCusUserAllModel();

                                objCusUserHead.resp = true;
                                objCusUserHead.msg = "Get Customer User";

                                objCusUserData.USR_StaffID = rdr["USR_StaffID"].ToString();
                                objCusUserData.USR_FirstName = rdr["USR_FirstName"].ToString();
                                objCusUserData.USR_LastName = rdr["USR_LastName"].ToString();
                                objCusUserData.UGM_Name = rdr["UGM_Name"].ToString();
                                objCusUserData.DPT_Name = rdr["DPT_Name"].ToString();
                                objCusUserData.CUS_CompanyName = rdr["CUS_CompanyName"].ToString();
                                objCusUserData.USR_Status = rdr["USR_Status"].ToString();
                                objCusUserData.BU_ID = rdr["CUS_BusinessUnit"].ToString();

                                objCusUserData.RC = RC;

                                //objUserData.UserGroup.Add(objUserHead);

                                objCusUserSList.Add(objCusUserData);

                                if (objCusUserHead.User == null)
                                {
                                    objCusUserHead.User = new List<ReturnCusUserAllModel>();
                                }

                                objCusUserHead.User.Add(objCusUserData);

                            }
                            objCusUserHeadList.Add(objCusUserHead);

                        }
                        else
                        {
                            objCusUserHead.resp = true;
                            objCusUserHead.msg = "";
                            objCusUserHeadList.Add(objCusUserHead);


                        }
                    }
                }

                return objCusUserHeadList;

            }
            catch (Exception ex)
            {

                ReturnCustomerUserAllModelHead objCusUserHead = new ReturnCustomerUserAllModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCusUserHeadList.Add(objCusUserHead);

                objError.WriteLog(0, "User_Data", "get_c_user_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "User_Data", "get_c_user_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "User_Data", "get_c_user_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "User_Data", "get_c_user_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCusUserHeadList;

        }

        public static List<ReturnCustomerUserAllModelHead> get_c_user_all_unique(GetCustomerUserAllModel CUserall)//ok
        {
            List<ReturnCustomerUserAllModelHead> objCusUserHeadList = new List<ReturnCustomerUserAllModelHead>();
            List<ReturnCusUserAllModel> objCusUserSList = new List<ReturnCusUserAllModel>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    ReturnCustomerUserAllModelHead objCusUserHead = new ReturnCustomerUserAllModelHead();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_customer_user_all_unique";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAGE_NO", CUserall.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", CUserall.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_StaffID", CUserall.USR_StaffID);
                        cmd.Parameters["@USR_StaffID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_FirstName", CUserall.USR_FirstName);
                        cmd.Parameters["@USR_FirstName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_LastName", CUserall.USR_LastName);
                        cmd.Parameters["@USR_LastName"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@UGM_Name", CUserall.UGM_Name);
                        //cmd.Parameters["@UGM_Name"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_ID", CUserall.BU_ID);
                        cmd.Parameters["@BU_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_ID", CUserall.CUS_ID);
                        cmd.Parameters["@CUS_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPT_ID", CUserall.DPT_ID);
                        cmd.Parameters["@DPT_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_Status", CUserall.USR_Status);
                        cmd.Parameters["@USR_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TABLE", CUserall.TABLE);
                        cmd.Parameters["@TABLE"].Direction = ParameterDirection.Input;

                        string RC;
                        using (SqlCommand cmdrc = new SqlCommand())
                        {
                            cmdrc.Connection = lconn;

                            cmdrc.CommandText = "sp_get_customer_user_count";
                            cmdrc.CommandType = CommandType.StoredProcedure;

                            cmdrc.Parameters.AddWithValue("@TABLE", CUserall.TABLE);
                            cmdrc.Parameters["@TABLE"].Direction = ParameterDirection.Input;
                            SqlDataReader rdrrc = cmdrc.ExecuteReader();
                            rdrrc.Read();
                            RC = rdrrc["RC"].ToString();
                            rdrrc.Close();
                        }

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnCusUserAllModel objCusUserData = new ReturnCusUserAllModel();

                                objCusUserHead.resp = true;
                                objCusUserHead.msg = "Get Customer User";

                                objCusUserData.USR_StaffID = rdr["USR_StaffID"].ToString();
                                objCusUserData.USR_FirstName = rdr["USR_FirstName"].ToString();
                                objCusUserData.USR_LastName = rdr["USR_LastName"].ToString();
                                //objCusUserData.UGM_Name = rdr["UGM_Name"].ToString();
                                objCusUserData.DPT_Name = rdr["DPT_Name"].ToString();
                                objCusUserData.DPT_ID = rdr["DPT_ID"].ToString();
                                objCusUserData.CUS_CompanyName = rdr["CUS_CompanyName"].ToString();
                                objCusUserData.USR_Status = rdr["USR_Status"].ToString();
                                objCusUserData.BU_ID = rdr["CUS_BusinessUnit"].ToString();

                                objCusUserData.RC = RC;

                                //objUserData.UserGroup.Add(objUserHead);

                                objCusUserSList.Add(objCusUserData);

                                if (objCusUserHead.User == null)
                                {
                                    objCusUserHead.User = new List<ReturnCusUserAllModel>();
                                }

                                objCusUserHead.User.Add(objCusUserData);

                            }
                            objCusUserHeadList.Add(objCusUserHead);

                        }
                        else
                        {
                            objCusUserHead.resp = true;
                            objCusUserHead.msg = "";
                            objCusUserHeadList.Add(objCusUserHead);


                        }
                    }
                }

                return objCusUserHeadList;

            }
            catch (Exception ex)
            {

                ReturnCustomerUserAllModelHead objCusUserHead = new ReturnCustomerUserAllModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCusUserHeadList.Add(objCusUserHead);

                objError.WriteLog(0, "User_Data", "get_c_user_all_unique", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "User_Data", "get_c_user_all_unique", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "User_Data", "get_c_user_all_unique", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "User_Data", "get_c_user_all_unique", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCusUserHeadList;

        }

        public static List<ReturnResponse> inactivate_c_user(InactiveCUserModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_del_customer_user";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@USR_StaffID", item.USR_StaffID);
                        cmd.Parameters["@USR_StaffID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TABLE", item.TABLE);
                        cmd.Parameters["@TABLE"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USER_ID", item.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnResponse objUserHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objUserHeadList.Add(objUserHead);
                            }
                            objError.WriteLog(0, "User_Data", "inactivate_c_user", "Stack Track: " + objUserHeadList + item);

                            return objUserHeadList;
                        }

                        return objUserHeadList;
                    }
                }
            }
            catch (Exception ex)
            {
                ReturnResponse objUserHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "User_Data", "inactivate_c_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "User_Data", "inactivate_c_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "User_Data", "inactivate_c_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "User_Data", "inactivate_c_user", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }




        }

        public static List<ReturnLoadUserDataModel> load_user_data()//ok
        {
            List<ReturnLoadUserDataModel> objUserHeadList = new List<ReturnLoadUserDataModel>();
            List<ReturnLoadUserDataModel> objUserSList = new List<ReturnLoadUserDataModel>();
            List<ReturnUserGroupModel> objGrpSList = new List<ReturnUserGroupModel>();
            List<ReturnUserBuModel> objBUList = new List<ReturnUserBuModel>();
            List<ReturnUserCustModel> objCustList = new List<ReturnUserCustModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    ReturnLoadUserDataModel objUserHead = new ReturnLoadUserDataModel();


                    ReturnLoadUserDataModel objUserData = new ReturnLoadUserDataModel();


                    using (SqlCommand cmdGrp = new SqlCommand())
                    {
                        cmdGrp.Connection = lconn;

                        cmdGrp.CommandText = "sp_get_user_groups_with_select";
                        cmdGrp.CommandType = CommandType.StoredProcedure;

                        cmdGrp.Parameters.AddWithValue("@USER_ID", "*#@%&");
                        cmdGrp.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dtaGrp = new SqlDataAdapter();
                        dtaGrp.SelectCommand = cmdGrp;
                        DataSet DsGrp = new DataSet();
                        dtaGrp.Fill(DsGrp);

                        if (DsGrp != null && DsGrp.Tables.Count > 0 && DsGrp.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdrGrp in DsGrp.Tables[0].Rows)
                            {
                                ReturnUserGroupModel objGrpData = new ReturnUserGroupModel
                                {
                                    UGM_ID = rdrGrp["UGM_ID"].ToString(),
                                    IndexNo = rdrGrp["IndexNo"].ToString(),
                                    UGM_Name = rdrGrp["UGM_Name"].ToString(),
                                    UAG_Select = Convert.ToBoolean(rdrGrp["UAG_Select"])
                                };

                                objGrpSList.Add(objGrpData);

                                if (objUserData.usergroup == null)
                                {
                                    objUserData.usergroup = new List<ReturnUserGroupModel>();
                                }


                                objUserData.usergroup.Add(objGrpData);
                            }
                        }
                    }
                    using (SqlCommand cmdBu = new SqlCommand())
                    {
                        cmdBu.Connection = lconn;

                        cmdBu.CommandText = "sp_get_user_business_units_with_select";
                        cmdBu.CommandType = CommandType.StoredProcedure;

                        cmdBu.Parameters.AddWithValue("@USER_ID", "*#@%&");
                        cmdBu.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dtaBu = new SqlDataAdapter();
                        dtaBu.SelectCommand = cmdBu;
                        DataSet DsBu = new DataSet();
                        dtaBu.Fill(DsBu);

                        if (DsBu != null && DsBu.Tables.Count > 0 && DsBu.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdrBu in DsBu.Tables[0].Rows)
                            {
                                ReturnUserBuModel objBuData = new ReturnUserBuModel
                                {
                                    BU_ID = rdrBu["BU_ID"].ToString(),
                                    IndexNo = rdrBu["IndexNo"].ToString(),
                                    BU_CompanyName = rdrBu["BU_CompanyName"].ToString(),
                                    BU_CountryCode = rdrBu["BU_CountryCode"].ToString(),
                                    UAG_Select = Convert.ToBoolean(rdrBu["UAG_Select"])
                                };

                                objBUList.Add(objBuData);

                                if (objUserData.userbu == null)
                                {
                                    objUserData.userbu = new List<ReturnUserBuModel>();
                                }

                                objUserData.userbu.Add(objBuData);

                            }
                        }
                    }
                    using (SqlCommand cmdCust = new SqlCommand())
                    {
                        cmdCust.Connection = lconn;

                        cmdCust.CommandText = "sp_get_user_customers_with_select";
                        cmdCust.CommandType = CommandType.StoredProcedure;

                        cmdCust.Parameters.AddWithValue("@USER_ID", "*#@%&");
                        cmdCust.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dtaCust = new SqlDataAdapter();
                        dtaCust.SelectCommand = cmdCust;
                        DataSet DsCust = new DataSet();
                        dtaCust.Fill(DsCust);

                        if (DsCust != null && DsCust.Tables.Count > 0 && DsCust.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdrCust in DsCust.Tables[0].Rows)
                            {
                                ReturnUserCustModel objCustData = new ReturnUserCustModel
                                {
                                    CUS_ID = rdrCust["CUS_ID"].ToString(),
                                    IndexNo = rdrCust["IndexNo"].ToString(),
                                    CUS_CompanyName = rdrCust["CUS_CompanyName"].ToString(),
                                    BU_CompanyName = rdrCust["BU_CompanyName"].ToString(),
                                    UAG_Select = Convert.ToBoolean(rdrCust["UAG_Select"])
                                };

                                objCustList.Add(objCustData);

                                if (objUserData.usercust == null)
                                {
                                    objUserData.usercust = new List<ReturnUserCustModel>();
                                }

                                objUserData.usercust.Add(objCustData);


                            }

                        }
                    }
                    objUserHead.resp = true;

                    objUserHeadList.Add(objUserData);
                }
                return objUserHeadList;

            }
            catch (Exception ex)
            {
                ReturnLoadUserDataModel objUserHead = new ReturnLoadUserDataModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "User_Data", "load_user_data", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "User_Data", "load_user_data", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "User_Data", "load_user_data", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "User_Data", "load_user_data", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objUserHeadList;

        }

        public class UserGroupAddModel
        {
            public string UAG_UserID { get; set; }
            public string UAG_GroupID { get; set; }
            public string UAG_BusinessUnit { get; set; }
            public string UAG_CustomerID { get; set; }
            public string UAG_VendorID { get; set; }
            public bool UAG_Status { get; set; }
            public string UAG_CreatedBy { get; set; }
            public string UAG_CreatedDateTime { get; set; }
            public string UAG_Type { get; set; }
        }

        public static List<ReturnResponse> add_new_c_user(CUserModel item)//ok
        {
            List<ReturnResponse> objCUserHeadList = new List<ReturnResponse>();

            if (!string.IsNullOrEmpty(item.USR_EmailAddress) && !utility_handler.Utility.Misc.EmailValidator(item.USR_EmailAddress))
            {
                objCUserHeadList.Add(new ReturnResponse
                {
                    resp = false,
                    msg = "Invalid Email Address"
                });

                string logobject = JsonConvert.SerializeObject(objCUserHeadList);

                objError.WriteLog(0, "User_Data", "add_new_c_user", "Stack Track: " + logobject + item);

                return objCUserHeadList;
            }

            try
            {
                string encryptedPW = "";
                string encryptedpin = "";
                decimal Salt = 0;
                string NotEncryptedPassword = "";
                string cus_BU = "";

                string CUS_PinOrPwd = "";
                //string BU_ID = "";
                bool SMSOk = true;
                bool EmailOk = true;

                List<ReturnCustomerModelHead> cust = Customer_Data.get_customers_single(new Customer() { CUS_ID = item.USR_CustomerID });

                if (cust != null && cust.Count > 0 && cust[0].Customer != null && cust[0].Customer.Count > 0)
                {
                    CUS_PinOrPwd = cust[0].Customer[0].CUS_PinOrPwd;
                    //BU_ID = cust[0].Customer[0].CUS_BusinessUnit;
                    SMSOk = cust[0].Customer[0].CUS_OTP_By_SMS;
                    EmailOk = cust[0].Customer[0].CUS_OTP_By_Email;
                    cus_BU = cust[0].Customer[0].CUS_BusinessUnit;
                }

                if (CUS_PinOrPwd.ToUpper() == "PWD")
                {
                    NotEncryptedPassword = PasswordRelated.CreateRandomPassword();
                    PasswordRelated.CreateEncryptedPassword(NotEncryptedPassword, ref encryptedPW, ref Salt);
                }
                else
                {
                    NotEncryptedPassword = PasswordRelated.CreateRandomPIN();
                    PasswordRelated.CreateEncryptedPassword(NotEncryptedPassword, ref encryptedpin, ref Salt);
                }

                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_insert_customer_user";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@USER_ID", item.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_CustomerID", item.USR_CustomerID);
                        cmd.Parameters["@USR_CustomerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_DepartmentID", item.USR_DepartmentID);
                        cmd.Parameters["@USR_DepartmentID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_StaffID", item.USR_StaffID);
                        cmd.Parameters["@USR_StaffID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_FirstName", item.USR_FirstName);
                        cmd.Parameters["@USR_FirstName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_LastName", item.USR_LastName);
                        cmd.Parameters["@USR_LastName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_PrefferedName", item.USR_PrefferedName);
                        cmd.Parameters["@USR_PrefferedName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_OrgStructuralLevel1", item.USR_OrgStructuralLevel1);
                        cmd.Parameters["@USR_OrgStructuralLevel1"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_OrgStructuralLevel2", item.USR_OrgStructuralLevel2);
                        cmd.Parameters["@USR_OrgStructuralLevel2"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_DepartmentDetail1", item.USR_DepartmentDetail1);
                        cmd.Parameters["@USR_DepartmentDetail1"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_DepartmentDetail2", item.USR_DepartmentDetail2);
                        cmd.Parameters["@USR_DepartmentDetail2"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_DepartmentDetail3", item.USR_DepartmentDetail3);
                        cmd.Parameters["@USR_DepartmentDetail3"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_JobCodeDescription", item.USR_JobCodeDescription);
                        cmd.Parameters["@USR_JobCodeDescription"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_Address", item.USR_Address);
                        cmd.Parameters["@USR_Address"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_EmailAddress", item.USR_EmailAddress);
                        cmd.Parameters["@USR_EmailAddress"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_MobileNumber", item.USR_MobileNumber);
                        cmd.Parameters["@USR_MobileNumber"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_PhoneNumber1", item.USR_PhoneNumber1);
                        cmd.Parameters["@USR_PhoneNumber1"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_PhoneNumber2", item.USR_PhoneNumber2);
                        cmd.Parameters["@USR_PhoneNumber2"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_RankDescription", item.USR_RankDescription);
                        cmd.Parameters["@USR_RankDescription"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_StaffLocation", item.USR_StaffLocation);
                        cmd.Parameters["@USR_StaffLocation"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_PCCode", item.USR_PCCode);
                        cmd.Parameters["@USR_PCCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_PCDescription", item.USR_PCDescription);
                        cmd.Parameters["@USR_PCDescription"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_Remarks", item.USR_Remarks);
                        cmd.Parameters["@USR_Remarks"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_Pin", encryptedpin);
                        cmd.Parameters["@USR_Pin"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_Pwd", encryptedPW);
                        cmd.Parameters["@USR_Pwd"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_PwdSalt", Salt);
                        cmd.Parameters["@USR_PwdSalt"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_ActiveFrom", item.USR_ActiveFrom);
                        cmd.Parameters["@USR_ActiveFrom"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_ActiveTo", item.USR_ActiveTo);
                        cmd.Parameters["@USR_ActiveTo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_Status", item.USR_Status);
                        cmd.Parameters["@USR_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TABLE", item.TABLE);
                        cmd.Parameters["@TABLE"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_EmployeeID", item.USR_EmployeeID);
                        cmd.Parameters["@USR_EmployeeID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        int exp_date = 0;
                        String expired_date = "";

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                if (!String.IsNullOrEmpty(rdr["RTN_DATE"].ToString()))
                                {
                                    exp_date = int.Parse(rdr["RTN_DATE"].ToString());
                                    expired_date = DateTime.Now.AddDays(exp_date).ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
                                }

                                ReturnResponse objCusUserHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objCUserHeadList.Add(objCusUserHead);

                                if (objCusUserHead.resp == true)
                                {

                                    using (SqlCommand cmdud = new SqlCommand())
                                    {
                                        cmdud.Connection = lconn;
                                        {
                                            cmdud.CommandText = "sp_sav_customer_user_access_group";
                                            cmdud.CommandType = CommandType.StoredProcedure;

                                            cmdud.Parameters.AddWithValue("@USER_ID", item.USER_ID);
                                            cmdud.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                                            cmdud.Parameters.AddWithValue("@UAG_UserID", item.USR_StaffID);
                                            cmdud.Parameters["@UAG_UserID"].Direction = ParameterDirection.Input;

                                            cmdud.Parameters.AddWithValue("@UAG_GroupID", ConfigCaller.CustomerUserGroupID);
                                            cmdud.Parameters["@UAG_GroupID"].Direction = ParameterDirection.Input;

                                            cmdud.Parameters.AddWithValue("@UAG_CustomerID", item.USR_CustomerID);
                                            cmdud.Parameters["@UAG_CustomerID"].Direction = ParameterDirection.Input;

                                            cmdud.Parameters.AddWithValue("@UAG_Status", item.USR_Status);
                                            cmdud.Parameters["@UAG_Status"].Direction = ParameterDirection.Input;

                                            //cmdud.Parameters.AddWithValue("@UAG_VendorID", "0000000000");
                                            //cmdud.Parameters["@UAG_VendorID"].Direction = ParameterDirection.Input;

                                            //cmdud.Parameters.AddWithValue("@UAG_Type", "MC");
                                            //cmdud.Parameters["@UAG_Type"].Direction = ParameterDirection.Input;

                                            //cmdud.Parameters.AddWithValue("@TABLE", item.TABLE);
                                            //cmdud.Parameters["@TABLE"].Direction = ParameterDirection.Input;

                                            SqlDataReader rdrud = cmdud.ExecuteReader();

                                            cmdud.Parameters.Clear();
                                            rdrud.Close();
                                        }

                                    }

                                    //objUserSList.Add(objUserHead.objReturnUserModelList);

                                }
                            }

                        }

                        string logobject = JsonConvert.SerializeObject(objCUserHeadList);
                        string logitem = JsonConvert.SerializeObject(item);
                        objError.WriteLog(0, "User_Data", "add_new_c_user", "Stack Track: " + logobject + "   " + logitem);

                    }
                }
            }
            catch (Exception ex)
            {
                ReturnResponse objCusUserHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCUserHeadList.Add(objCusUserHead);

                objError.WriteLog(0, "User_Data", "add_new_c_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "User_Data", "add_new_c_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "User_Data", "add_new_c_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "User_Data", "add_new_c_user", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCUserHeadList;
        }

        public static (bool IsSMSFailed, bool IsEmailFailed) SendEmailSMS_CustomerUser(CUserModel item,
            List<ReturnResponse> objCUserHeadList, string NotEncryptedPassword,
            string CUS_PinOrPwd, List<ReturnCustomerModelHead> cust,
            string expired_date, string BU_ID, bool SMSOk, bool EmailOk)
        {
            bool IsSMSFailed = true;
            bool IsEmailFailed = true;
            string CentralMailroomNumber = SystemParameter_Data.PredefinedProperties.CentralMailRoomNumber();

            try
            {
                if (cust != null)
                {
                    string body = "";

                    if (string.IsNullOrEmpty(item.USR_EmailAddress))
                    {
                        body = @"Your Mailtrak PIN\Password." + " " + NotEncryptedPassword;
                    }
                    else
                    {
                        body = @"<html>
	                                        <body>
		                                        <P>Dear Valued Customer,</P>		
		                                        <P>Below are your login details.</P>	
		                                    <table>
			                                    <tr>
				                                    <td>Login ID</td>
				                                    <td>:</td>
				                                    <td><b>" + item.USR_StaffID + @"</b></td>
			                                    </tr>
			                                    <tr>
				                                    <td>Password</td>
				                                    <td>:</td>
				                                    <td><b>" + NotEncryptedPassword + @"</b></td>
			                                    </tr>						
		                                    </table>
		                                    </br>
		                                    <table>
			                                    <tr>
				                                    <td>Password Effective Date</td>
				                                    <td>:</td>
				                                    <td><b>" + DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture) + @"</b></td>
			                                    </tr>
			                                    <tr>
				                                    <td>Password Expiry Date</td>
				                                    <td>:</td>
				                                    <td><b>" + expired_date + @"</b></td>
			                                        </tr>
		                                            </table>
		                                            </br>		
		                                    <P style=""color: red; "">Note the following security tips:</P>
                                               <ul>
                                                    <li> Ignore emails requesting for User, Password or other personal information </li>    
                                                    <li> Do not write down your User, Password or reveal it to anyone </li>     
                                                    <li> Install a firewall and virus protection software, update them regularly </li>   
                                                    <li> By policy, system will issue a new password every 90 days </li>     
                                             </ul>    
                                             </br>     
                                            <P> Should you need further clarification and assistance, please call the following hotline:</P>     
                                            <P> " + CentralMailroomNumber + @" </P>    
                                            <P> This is a computer - generated email.Please Do Not Reply.</P>
     
                                            </body>
                                            </html> ";
                    }


                    if (!string.IsNullOrEmpty(item.USR_EmailAddress))
                    {
                        EmailAttachedFileDetails objFilesAttachment = new EmailAttachedFileDetails();
                        ReturnResponse rtn = Email_Sender_Preperation.Send(item.USR_EmailAddress, body, BU_ID, EmailOk, BaseClassDBCallerData.UserPwSubject, objFilesAttachment);
                        if (rtn.resp == false)
                        {
                            ReturnResponse objCusUserHead2 = new ReturnResponse
                            {
                                resp = false,
                                msg = "Email Sending Failed"
                            };
                            objCUserHeadList.Add(objCusUserHead2);
                        }
                        else
                        {
                            IsEmailFailed = false;
                            objCUserHeadList.Add(rtn);
                        }
                    }

                    if (!string.IsNullOrEmpty(item.USR_MobileNumber))
                    {
                        body = @"Your Mailtrak PIN\Password." + " " + NotEncryptedPassword;

                        ReturnResponse rtn = SMS_Sender_Preperation.SMSgateway(item.USR_MobileNumber, body, BU_ID, SMSOk);
                        if (rtn.resp == false)
                        {
                            ReturnResponse objCusUserHead2 = new ReturnResponse
                            {
                                resp = false,
                                msg = "SMS Sending Failed"
                            };
                            objCUserHeadList.Add(objCusUserHead2);
                        }
                        else
                        {
                            IsSMSFailed = false;
                            objCUserHeadList.Add(rtn);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                ReturnResponse objCusUserHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCUserHeadList.Add(objCusUserHead);

                objError.WriteLog(0, "User_Data", "SendEmailSMS_CustomerUser", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "User_Data", "SendEmailSMS_CustomerUser", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "User_Data", "SendEmailSMS_CustomerUser", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "User_Data", "SendEmailSMS_CustomerUser", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return (IsSMSFailed, IsEmailFailed);
        }

        public static List<ReturnResponse> modify_c_user(CUserModel item)//ok
        {
            List<ReturnResponse> objCUserHeadList = new List<ReturnResponse>();

            if (!string.IsNullOrEmpty(item.USR_EmailAddress) && !utility_handler.Utility.Misc.EmailValidator(item.USR_EmailAddress))
            {
                objCUserHeadList.Add(new ReturnResponse
                {
                    resp = false,
                    msg = "Invalid Email Address"
                });

                string logobject = JsonConvert.SerializeObject(objCUserHeadList);

                objError.WriteLog(0, "User_Data", "modify_c_user", "Stack Track: " + logobject + item);

                return objCUserHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_modify_customer_user";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@USER_ID", item.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_CustomerID", item.USR_CustomerID);
                        cmd.Parameters["@USR_CustomerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_DepartmentID", item.USR_DepartmentID);
                        cmd.Parameters["@USR_DepartmentID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_StaffID", item.USR_StaffID);
                        cmd.Parameters["@USR_StaffID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_FirstName", item.USR_FirstName);
                        cmd.Parameters["@USR_FirstName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_LastName", item.USR_LastName);
                        cmd.Parameters["@USR_LastName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_PrefferedName", item.USR_PrefferedName);
                        cmd.Parameters["@USR_PrefferedName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_OrgStructuralLevel1", item.USR_OrgStructuralLevel1);
                        cmd.Parameters["@USR_OrgStructuralLevel1"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_OrgStructuralLevel2", item.USR_OrgStructuralLevel2);
                        cmd.Parameters["@USR_OrgStructuralLevel2"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_DepartmentDetail1", item.USR_DepartmentDetail1);
                        cmd.Parameters["@USR_DepartmentDetail1"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_DepartmentDetail2", item.USR_DepartmentDetail2);
                        cmd.Parameters["@USR_DepartmentDetail2"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_DepartmentDetail3", item.USR_DepartmentDetail3);
                        cmd.Parameters["@USR_DepartmentDetail3"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_JobCodeDescription", item.USR_JobCodeDescription);
                        cmd.Parameters["@USR_JobCodeDescription"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_Address", item.USR_Address);
                        cmd.Parameters["@USR_Address"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_EmailAddress", item.USR_EmailAddress);
                        cmd.Parameters["@USR_EmailAddress"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_MobileNumber", item.USR_MobileNumber);
                        cmd.Parameters["@USR_MobileNumber"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_PhoneNumber1", item.USR_PhoneNumber1);
                        cmd.Parameters["@USR_PhoneNumber1"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_PhoneNumber2", item.USR_PhoneNumber2);
                        cmd.Parameters["@USR_PhoneNumber2"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_RankDescription", item.USR_RankDescription);
                        cmd.Parameters["@USR_RankDescription"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_StaffLocation", item.USR_StaffLocation);
                        cmd.Parameters["@USR_StaffLocation"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_PCCode", item.USR_PCCode);
                        cmd.Parameters["@USR_PCCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_PCDescription", item.USR_PCDescription);
                        cmd.Parameters["@USR_PCDescription"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_Remarks", item.USR_Remarks);
                        cmd.Parameters["@USR_Remarks"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_ActiveFrom", item.USR_ActiveFrom);
                        cmd.Parameters["@USR_ActiveFrom"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_ActiveTo", item.USR_ActiveTo);
                        cmd.Parameters["@USR_ActiveTo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_Status", item.USR_Status);
                        cmd.Parameters["@USR_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TABLE", item.TABLE);
                        cmd.Parameters["@TABLE"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_EmployeeID", item.USR_EmployeeID);
                        cmd.Parameters["@USR_EmployeeID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnResponse objCusUserHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objCUserHeadList.Add(objCusUserHead);

                                if (objCusUserHead.resp == true)
                                {

                                    using (SqlCommand cmdud = new SqlCommand())
                                    {
                                        cmdud.Connection = lconn;

                                        cmdud.CommandText = "sp_del_user_access_group_by_customer_staff_id";
                                        cmdud.CommandType = CommandType.StoredProcedure;

                                        cmdud.Parameters.AddWithValue("@UAG_UserID", item.USR_StaffID);
                                        cmdud.Parameters["@UAG_UserID"].Direction = ParameterDirection.Input;

                                        cmdud.Parameters.AddWithValue("@USER_ID", item.USER_ID);
                                        cmdud.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                                        cmdud.Parameters.AddWithValue("@TABLE", item.TABLE);
                                        cmdud.Parameters["@TABLE"].Direction = ParameterDirection.Input;

                                        SqlDataReader rdrud = cmdud.ExecuteReader();

                                        cmdud.Parameters.Clear();
                                        rdrud.Close();
                                    }

                                    using (SqlCommand cmdud = new SqlCommand())
                                    {
                                        cmdud.Connection = lconn;


                                        foreach (var itemcus in item.cususergroup)
                                        {
                                            cmdud.CommandText = "sp_sav_customer_user_access_group";
                                            cmdud.CommandType = CommandType.StoredProcedure;

                                            cmdud.Parameters.AddWithValue("@USER_ID", item.USER_ID);
                                            cmdud.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                                            cmdud.Parameters.AddWithValue("@UAG_UserID", item.USR_StaffID);
                                            cmdud.Parameters["@UAG_UserID"].Direction = ParameterDirection.Input;

                                            cmdud.Parameters.AddWithValue("@UAG_GroupID", itemcus.UGM_ID);
                                            cmdud.Parameters["@UAG_GroupID"].Direction = ParameterDirection.Input;

                                            cmdud.Parameters.AddWithValue("@UAG_CustomerID", item.USR_CustomerID);
                                            cmdud.Parameters["@UAG_CustomerID"].Direction = ParameterDirection.Input;

                                            cmdud.Parameters.AddWithValue("@UAG_Status", item.USR_Status);
                                            cmdud.Parameters["@UAG_Status"].Direction = ParameterDirection.Input;

                                            //cmdud.Parameters.AddWithValue("@UAG_VendorID", "0000000000");
                                            //cmdud.Parameters["@UAG_VendorID"].Direction = ParameterDirection.Input;

                                            //cmdud.Parameters.AddWithValue("@UAG_Type", "MC");
                                            //cmdud.Parameters["@UAG_Type"].Direction = ParameterDirection.Input;

                                            //cmdud.Parameters.AddWithValue("@TABLE", item.TABLE);
                                            //cmdud.Parameters["@TABLE"].Direction = ParameterDirection.Input;

                                            SqlDataReader rdrud = cmdud.ExecuteReader();

                                            cmdud.Parameters.Clear();
                                            rdrud.Close();
                                        }
                                    }
                                }

                                //objUserSList.Add(objUserHead.objReturnUserModelList);

                            }
                        }
                    }

                    string logobject = JsonConvert.SerializeObject(objCUserHeadList);
                    string logitem = JsonConvert.SerializeObject(item);
                    objError.WriteLog(0, "User_Data", "modify_c_user", "Stack Track: " + logobject + "   " + logitem);

                    //objError.WriteLog(0, "User_Data", "modify_c_user", "Stack Track: " + objCUserHeadList + item);
                }
            }
            catch (Exception ex)
            {
                ReturnResponse objCusUserHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCUserHeadList.Add(objCusUserHead);

                objError.WriteLog(0, "User_Data", "modify_c_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "User_Data", "modify_c_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "User_Data", "modify_c_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "User_Data", "modify_c_user", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCUserHeadList;
        }

        public static List<ReturnUserDropModelHead> get_transuser_dropdown(User getuserdrop)//ok
        {
            List<ReturnUserDropModelHead> objUserHeadList = new List<ReturnUserDropModelHead>();
            List<GetTuserdropdownModel> objUserSList = new List<GetTuserdropdownModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();
            SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString);
            try
            {


                if (lconn.State == ConnectionState.Closed)
                {
                    lconn.Open();
                }
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = lconn;

                    cmd.CommandText = "sp_get_transnational_user_dropdown";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@USER_ID", getuserdrop.USER_ID);
                    cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                    ReturnUserDropModelHead objUserHead = new ReturnUserDropModelHead
                    {
                        resp = true,
                        msg = "Get Dropdown"
                    };

                    SqlDataAdapter dta = new SqlDataAdapter();
                    dta.SelectCommand = cmd;
                    DataSet Ds = new DataSet();
                    dta.Fill(Ds);

                    if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow rdr in Ds.Tables[0].Rows)
                        {
                            GetTuserdropdownModel objUserdrop = new GetTuserdropdownModel
                            {
                                UT_StaffID = rdr["UT_StaffID"].ToString(),
                                UT_Name = rdr["UT_Name"].ToString()
                            };

                            objUserSList.Add(objUserdrop);

                            if (objUserHead.userdrop == null)
                            {
                                objUserHead.userdrop = new List<GetTuserdropdownModel>();
                            }
                            objUserHead.userdrop.Add(objUserdrop);
                            //objUserHead.userdrop.Add(objUserdrop);
                            //objUserHead.Tocken = objUser.notificationToken = token;


                        }
                        objUserHeadList.Add(objUserHead);

                    }
                }
            }
            catch (Exception ex)
            {

                ReturnUserDropModelHead objUserHead = new ReturnUserDropModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "User_Data", "get_transuser_dropdown", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "User_Data", "get_transuser_dropdown", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "User_Data", "get_transuser_dropdown", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "User_Data", "get_transuser_dropdown", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }

        public static List<ReturnResponse> change_password(NewpwModel item)//set use need to apply - all person
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            List<SPResponse> objResponseList = new List<SPResponse>();
            try
            {
                string encryptedPW = "";
                decimal Salt = 0;
                string emailBody = "";
                string smsBody = "";

                string PwType = GetUserPasswordType(item.USER_ID, item.USER_ID, item.USER_TABLE);

                string tmpPassword = "";

                //if (item.USER_TABLE.ToUpper() == "TBL_USER_TRANSNATIONAL")
                //{ PwType = "PWD"; }

                if (PwType.ToUpper() == "PWD")
                {
                    tmpPassword = PasswordRelated.CreateRandomPassword();
                }
                else
                {
                    tmpPassword = PasswordRelated.CreateRandomPIN();
                }

                PasswordRelated.CreateEncryptedPassword(tmpPassword, ref encryptedPW, ref Salt);

                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmdpw = new SqlCommand())
                    {
                        cmdpw.Connection = lconn;

                        cmdpw.CommandText = "sp_sav_user_pw";
                        cmdpw.CommandType = CommandType.StoredProcedure;

                        cmdpw.Parameters.AddWithValue("@USER_ID", item.USER_ID);
                        cmdpw.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        cmdpw.Parameters.AddWithValue("@USER_TABLE", item.USER_TABLE);
                        cmdpw.Parameters["@USER_TABLE"].Direction = ParameterDirection.Input;

                        cmdpw.Parameters.AddWithValue("@USER_PW", encryptedPW);
                        cmdpw.Parameters["@USER_PW"].Direction = ParameterDirection.Input;

                        cmdpw.Parameters.AddWithValue("@USER_PwdSalt", Salt);
                        cmdpw.Parameters["@USER_PwdSalt"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmdpw;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        int exp_date = 0;
                        String expired_date = "";
                        String mailroom = "";

                        var CentralMailroom = SystemParameter_Data.get_system_parameter_single(new GetSystemPMSingleModel { SP_ID = "CentralMailRoomNumber" });

                        if (CentralMailroom != null)
                        {
                            foreach (var para in CentralMailroom)
                            {
                                foreach (var para2 in para.SystemPM)
                                {
                                    mailroom = para2.SP_Value;
                                }
                            }
                        }

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            SPResponse objResponse = new SPResponse();
                            foreach (DataRow rdrpw in Ds.Tables[0].Rows)
                            {
                                if (!String.IsNullOrEmpty(rdrpw["RTN_DATE"].ToString()))
                                {
                                    exp_date = int.Parse(rdrpw["RTN_DATE"].ToString());
                                    expired_date = DateTime.Now.AddDays(exp_date).ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
                                }

                                ReturnResponse objUserHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdrpw["RTN_RESP"].ToString()),
                                    msg = rdrpw["RTN_MSG"].ToString()
                                };
                                objUserHeadList.Add(objUserHead);

                                //string body = "";
                                //if (PwType.ToUpper() == "PWD")
                                //{
                                emailBody = @"<html>
	                                        <body>
		                                        <P>Dear Valued Customer,</P>		
		                                        <P>Below are your login details.</P>	
		                                    <table>
			                                    <tr>
				                                    <td>Login ID</td>
				                                    <td>:</td>
				                                    <td><b>" + item.USER_ID + @"</b></td>
			                                    </tr>
			                                    <tr>
				                                    <td>Password</td>
				                                    <td>:</td>
				                                    <td><b>" + tmpPassword + @"</b></td>
			                                    </tr>						
		                                    </table>
		                                    </br>
		                                    <table>
			                                    <tr>
				                                    <td>Password Effective Date</td>
				                                    <td>:</td>
				                                    <td><b>" + DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture) + @"</b></td>
			                                    </tr>
			                                    <tr>
				                                    <td>Password Expiry Date</td>
				                                    <td>:</td>
				                                    <td><b>" + expired_date + @"</b></td>
			                                        </tr>
		                                            </table>
		                                            </br>		
		                                    <P style=""color: red; "">Note the following security tips:</P>
                                               <ul>
                                                    <li> Ignore emails requesting for User, Password or other personal information </li>    
                                                    <li> Do not write down your User, Password or reveal it to anyone </li>     
                                                    <li> Install a firewall and virus protection software, update them regularly </li>   
                                                    <li> By policy, system will issue a new password every 90 days </li>     
                                             </ul>    
                                             </br>     
                                            <P> Should you need further clarification and assistance, please call the following hotline:</P>     
                                            <P> " + mailroom + @" </P>    
                                            <P> This is a computer - generated email.Please Do Not Reply.</P>
     
                                            </body>
                                            </html> ";
                                //}
                                //else
                                //{
                                smsBody = "Your pin\\password has been changed." +
                                "" +
                                " Pin\\Password: " + tmpPassword;
                                //}

                                string BU_ID = "";
                                string EmailAddress = "";
                                bool IsSMSOk = false;
                                bool IsEmailOk = false;

                                //bool rtn = false;

                                List<ReturnCustomerModelHead> mod = Customer_Data.get_customers_single(new Customer() { CUS_ID = item.USER_TABLE.ToUpper().Replace("TBL_USER_CUSTOMER_", "") });

                                if (mod.FirstOrDefault().Customer != null)
                                {
                                    BU_ID = mod.FirstOrDefault().Customer.FirstOrDefault().CUS_BusinessUnit;
                                    IsSMSOk = mod.FirstOrDefault().Customer.FirstOrDefault().CUS_OTP_By_SMS;
                                    IsEmailOk = mod.FirstOrDefault().Customer.FirstOrDefault().CUS_OTP_By_Email;
                                }

                                List<ReturnCustomerUserModelHead> mod1 = User_Data.get_c_user_single(new CUser() { USER_ID = item.USER_ID, TABLE = item.USER_TABLE });

                                if (mod1.FirstOrDefault().User != null)
                                {
                                    EmailAddress = mod1.FirstOrDefault().User.FirstOrDefault().USR_EmailAddress;
                                }

                                //if (!string.IsNullOrEmpty(ObjUMP.UPM_UserEmail))
                                //{
                                //    EmailAttachedFileDetails objFilesAttachment = new EmailAttachedFileDetails();
                                //    ReturnResponse rtn = Email_Sender_Preperation.Send(/*ObjUMP.UPM_UserEmail*/EmailAddress, emailBody, BU_ID, IsEmailOk, BaseClassDBCallerData.ResetPwSubject, objFilesAttachment);

                                //    if (rtn.resp == false)
                                //    {
                                //        ReturnResponse objUserHeads = new ReturnResponse
                                //        {
                                //            resp = false,
                                //            msg = "Email Sending Failed"
                                //        };
                                //        objUserHeadList.Add(objUserHeads);
                                //    }
                                //}
                                //if (!string.IsNullOrEmpty(ObjUMP.UPM_MobileNumber))
                                //{
                                //    SMS_Sender_Preperation.SMSgateway(ObjUMP.UPM_MobileNumber, smsBody, BU_ID, IsSMSOk);
                                //}
                            }
                        }

                    }


                    return objUserHeadList;
                }
            }
            catch (Exception ex)
            {
                ReturnResponse objUserHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "User_Data", "change_password", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "User_Data", "change_password", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "User_Data", "change_password", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "User_Data", "change_password", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }
        }

        public static List<ReturnResponse> update_notification_token(NotTokModel UpNotTokModel, string userId)
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "SP_UPDATE_NOTIFICATION_TOKEN";
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@ID", userId);
                        cmd.Parameters["@ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@NOTIFICATION_TOKEN", UpNotTokModel.notification_token);
                        cmd.Parameters["@NOTIFICATION_TOKEN"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            SPResponse objResponse = new SPResponse();

                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnResponse objUserHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objUserHeadList.Add(objUserHead);
                            }
                        }
                    }

                }
                return objUserHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objUserHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "User_Data", "update_notification_token", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "User_Data", "update_notification_token", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "User_Data", "update_notification_token", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "User_Data", "update_notification_token", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }
        }

        public static List<ReturnResponse> reset_password(ResetPasswordModel resetPassword, string baseUrl)//set use need to apply - customer only
        {

            List<ReturnResponse> objOtpHeadList = new List<ReturnResponse>();
            List<ResetPasswordModel> objList = new List<ResetPasswordModel>();
            ReturnResponse objOtpHead = new ReturnResponse();

            string BU_ID = "";

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmdsmtp = new SqlCommand())
                    {
                        cmdsmtp.Connection = lconn;

                        cmdsmtp.CommandText = "SP_GET_USER_EMAIL_VERIFY_CODE";
                        cmdsmtp.CommandType = CommandType.StoredProcedure;

                        cmdsmtp.Parameters.AddWithValue("@EMAIL", resetPassword.email);
                        cmdsmtp.Parameters["@EMAIL"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmdsmtp;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdrsmtp in Ds.Tables[0].Rows)
                            {
                                string code = rdrsmtp["CODE"].ToString();
                                int id = Convert.ToInt32(rdrsmtp["ID"]);
                                string cc = "";

                                string body = "<b>Dear User,\n\r" +
                                    "Please ckick on the following link to verify your email address." +
                                    "\n\r\n\r" +
                                    "<a href=\"" + baseUrl + "/User/change_password_by_email?userId=" + id + "&email=" + resetPassword.email + "&verificationCode=" + code + "\" > Verify Email </ a > </b>";
                                //<a href=\"http://localhost:49496/Activated.aspx">login</a>

                                EmailAttachedFileDetails objFilesAttachment = new EmailAttachedFileDetails();
                                ReturnResponse rtn = Email_Sender_Preperation.Send(resetPassword.email, body, BU_ID, true, "Email Verification", objFilesAttachment);


                                if (rtn.resp == false)
                                {
                                    objOtpHead.resp = false;
                                    objOtpHead.msg = "There was an error in sending email";
                                }
                                else
                                {
                                    objOtpHead.resp = true;
                                    objOtpHead.msg = "Email sent";
                                }
                            }
                        }
                    }

                }

                objOtpHeadList.Add(objOtpHead);
            }
            catch (Exception ex)
            {

                objOtpHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objOtpHeadList.Add(objOtpHead);

                objError.WriteLog(0, "User_Data", "reset_password", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "User_Data", "reset_password", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "User_Data", "reset_password", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "User_Data", "reset_password", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objOtpHeadList;
        }

        public static string GetUserPasswordType(string userId, string email, string usertable)
        {
            string PwdType = "";
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    SqlCommand cmdpw = new SqlCommand
                    {
                        Connection = lconn,
                        CommandText = "SP_GET_USER_PASSWORDTYPE",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmdpw.Parameters.AddWithValue("@USER_ID", userId);
                    cmdpw.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                    cmdpw.Parameters.AddWithValue("@EMAIL", email);
                    cmdpw.Parameters["@EMAIL"].Direction = ParameterDirection.Input;

                    cmdpw.Parameters.AddWithValue("@USER_TABLE", usertable);
                    cmdpw.Parameters["@USER_TABLE"].Direction = ParameterDirection.Input;


                    SqlDataAdapter dta = new SqlDataAdapter();
                    dta.SelectCommand = cmdpw;
                    DataSet Ds = new DataSet();
                    dta.Fill(Ds);

                    if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow rdr in Ds.Tables[0].Rows)
                        {
                            PwdType = rdr["CUS_PinOrPwd"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objError.WriteLog(0, "User_Data", "GetUserPasswordType", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "User_Data", "GetUserPasswordType", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "User_Data", "GetUserPasswordType", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "User_Data", "GetUserPasswordType", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return PwdType;
        }

        public static string change_password_by_email(int userId, string email, string verificationCode)//set use need to apply
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            List<SPResponse> objResponseList = new List<SPResponse>();
            SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString);
            ReturnResponse objUserHead = new ReturnResponse();

            string rtnMsg = "";
            string BU_ID = "";
            try
            {
                string PwType = GetUserPasswordType(userId.ToString(), email, "");

                string tmpPassword = "";

                if (PwType.ToUpper() == "PWD")
                {
                    tmpPassword = PasswordRelated.CreateRandomPassword();
                }
                else
                {
                    tmpPassword = PasswordRelated.CreateRandomPIN();
                }

                string body = "";
                body = "Your password has been changed." +
                    "" +
                    "Password: " + tmpPassword;

                EmailAttachedFileDetails objFilesAttachment = new EmailAttachedFileDetails();
                ReturnResponse rtn = Email_Sender_Preperation.Send(email, body, BU_ID, true, BaseClassDBCallerData.ResetPwSubject, objFilesAttachment);

                if (rtn.resp == false)
                {
                    objUserHead.resp = false;
                    objUserHead.msg = "There was an error in sending the OTP";
                }
                else
                {
                    objUserHead.resp = true;
                    objUserHead.msg = "Verify OTP";

                    if (lconn.State == ConnectionState.Closed)
                    {
                        lconn.Open();
                    }

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        SqlCommand cmdpw = new SqlCommand
                        {
                            Connection = lconn,
                            CommandText = "SP_GET_USER_EMAIL_VERIFICATION",
                            CommandType = CommandType.StoredProcedure
                        };

                        cmdpw.Parameters.AddWithValue("@USER_ID", userId);
                        cmdpw.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        cmdpw.Parameters.AddWithValue("@VERIFICATION_CODE", verificationCode);
                        cmdpw.Parameters["@VERIFICATION_CODE"].Direction = ParameterDirection.Input;

                        cmdpw.Parameters.AddWithValue("@Email", email);
                        cmdpw.Parameters["@Email"].Direction = ParameterDirection.Input;


                        string enPW = "";
                        decimal PasswordSault = 0;
                        PasswordRelated.CreateEncryptedPassword(tmpPassword, ref enPW, ref PasswordSault);// BCrypt.Net.BCrypt.HashPassword(tmpPassword);

                        cmdpw.Parameters.AddWithValue("@TMP_PASSWORD", enPW);
                        cmdpw.Parameters["@TMP_PASSWORD"].Direction = ParameterDirection.Input;

                        cmdpw.Parameters.AddWithValue("@TMP_SALT", PasswordSault);
                        cmdpw.Parameters["@TMP_SALT"].Direction = ParameterDirection.Input;

                        SqlDataReader rdr = cmdpw.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {

                                try
                                {



                                    rtnMsg = rdr["RTN_MSG"].ToString();

                                }
                                catch (Exception ex)
                                {


                                    rtnMsg = ex.Message.ToString();

                                    objError.WriteLog(0, "User_Data", "PostNwpw", "Stack Track: " + ex.StackTrace);
                                    objError.WriteLog(0, "User_Data", "PostNwpw", "Error Message: " + ex.Message);
                                    if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                                    {
                                        objError.WriteLog(0, "User_Data", "PostNwpw", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                                        objError.WriteLog(0, "User_Data", "PostNwpw", "Inner Exception Message: " + ex.InnerException.Message);
                                    }

                                }

                            }
                        }

                    }
                }



                if (lconn.State == ConnectionState.Open)
                {
                    lconn.Close();
                }
                //ActivityLog.ActivityLogRequest("Password have changed by user", item.ID);
                return rtnMsg;
            }
            catch (Exception ex)
            {
                //ReturnResponse objUserHead = new ReturnResponse();
                //objUserHead.resp = false;
                //objUserHead.msg = ex.Message.ToString();
                //objUserHeadList.Add(objUserHead);
                rtnMsg = ex.Message.ToString();

                objError.WriteLog(0, "User_Data", "PostNwpw", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "User_Data", "PostNwpw", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "User_Data", "PostNwpw", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "User_Data", "PostNwpw", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return rtnMsg;
            }
        }

    }

}

