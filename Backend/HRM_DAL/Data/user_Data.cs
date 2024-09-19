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

                        cmd.Parameters.AddWithValue("@UD_UserID", UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

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

        public static List<ReturnInternalUserModelHead> get_user_internal_single(GetInternalUserSingleModel CUser)//ok
        {
            List<ReturnInternalUserModelHead> objCusUserHeadList = new List<ReturnInternalUserModelHead>();
            ReturnInternalUserModelHead objCusUserHead = new ReturnInternalUserModelHead();

            //List<ReturnUserGroupModel> objGrpSList = new List<ReturnUserGroupModel>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_user_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", CUser.UE_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnInternalUserModel objCusUserData = new ReturnInternalUserModel();

                                objCusUserHead.resp = true;
                                objCusUserHead.msg = "Get Customer User";

                                //objCusUserData.UD_CustomerID = rdr["UD_CustomerID"].ToString();
                                //objCusUserData.CUS_CompanyName = rdr["CUS_CompanyName"].ToString();
                                //objCusUserData.UD_DepartmentID = rdr["UD_DepartmentID"].ToString();
                                //objCusUserData.DPT_Name = rdr["DPT_Name"].ToString();
                                //objCusUserData.UD_UserID = rdr["UD_UserID"].ToString();
                                //objCusUserData.UD_FirstName = rdr["UD_FirstName"].ToString();
                                //objCusUserData.UD_LastName = rdr["UD_LastName"].ToString();
                                //objCusUserData.UD_PrefferedName = rdr["UD_PrefferedName"].ToString();
                                //objCusUserData.UD_OrgStructuralLevel1 = rdr["UD_OrgStructuralLevel1"].ToString();
                                //objCusUserData.UD_OrgStructuralLevel2 = rdr["UD_OrgStructuralLevel2"].ToString();
                                //objCusUserData.UD_DepartmentDetail1 = rdr["UD_DepartmentDetail1"].ToString();
                                //objCusUserData.UD_DepartmentDetail2 = rdr["UD_DepartmentDetail2"].ToString();
                                //objCusUserData.UD_DepartmentDetail3 = rdr["UD_DepartmentDetail3"].ToString();
                                //objCusUserData.UD_JobCodeDescription = rdr["UD_JobCodeDescription"].ToString();
                                //objCusUserData.UD_Address = rdr["UD_Address"].ToString();
                                //objCusUserData.UD_EmailAddress = rdr["UD_EmailAddress"].ToString();
                                //objCusUserData.UD_MobileNumber = rdr["UD_MobileNumber"].ToString();
                                //objCusUserData.UD_PhoneNumber1 = rdr["UD_PhoneNumber1"].ToString();
                                //objCusUserData.UD_PhoneNumber2 = rdr["UD_PhoneNumber2"].ToString();
                                //objCusUserData.UD_StaffLocation = rdr["UD_StaffLocation"].ToString();
                                //objCusUserData.UD_PCCode = rdr["UD_PCCode"].ToString();
                                //objCusUserData.UD_Remarks = rdr["UD_Remarks"].ToString();
                                //objCusUserData.UD_Status = rdr["UD_Status"].ToString();
                                //objCusUserData.UD_Pwd = rdr["UD_Pwd"].ToString();
                                //objCusUserData.UD_CreatedDateTime = rdr["UD_CreatedDateTime"].ToString();
                                //objCusUserData.UD_ModifiedDateTime = rdr["UD_ModifiedDateTime"].ToString();
                                //objCusUserData.UD_ActiveFrom = rdr["UD_ActiveFrom"].ToString();
                                //objCusUserData.UD_ActiveTo = rdr["UD_ActiveTo"].ToString();

                                //objCusUserData.RC = "1";

                                //using (SqlCommand cmdGrp = new SqlCommand())
                                //{
                                //    cmdGrp.Connection = lconn;

                                //    cmdGrp.CommandText = "sp_get_user_groups_with_select";
                                //    cmdGrp.CommandType = CommandType.StoredProcedure;

                                //    cmdGrp.Parameters.AddWithValue("@UD_UserName", CUser.UD_UserName);
                                //    cmdGrp.Parameters["@UD_UserName"].Direction = ParameterDirection.Input;

                                //    SqlDataAdapter dtaGrp = new SqlDataAdapter();
                                //    dtaGrp.SelectCommand = cmdGrp;
                                //    DataSet DsGrp = new DataSet();
                                //    dtaGrp.Fill(DsGrp);

                                //    if (DsGrp != null && DsGrp.Tables.Count > 0 && DsGrp.Tables[0].Rows.Count > 0)
                                //    {
                                //        foreach (DataRow rdrGrp in DsGrp.Tables[0].Rows)
                                //        {
                                //            ReturnCusUserGroupModel objGrpData = new ReturnCusUserGroupModel
                                //            {
                                //                UGM_ID = rdrGrp["UGM_ID"].ToString(),
                                //                IndexNo = rdrGrp["IndexNo"].ToString(),
                                //                UGM_Name = rdrGrp["UGM_Name"].ToString(),
                                //                //UAG_CustomerID = rdrGrp["UGM_Name"].ToString(),
                                //                UAG_Select = Convert.ToBoolean(rdrGrp["UAG_Select"])
                                //            };



                                //            objGrpSList.Add(objGrpData);

                                //            if (objCusUserData.cususergroup == null)
                                //            {
                                //                objCusUserData.cususergroup = new List<ReturnCusUserGroupModel>();
                                //            }


                                //            objCusUserData.cususergroup.Add(objGrpData);
                                //        }

                                //    }

                                //}

                                if (objCusUserHead.user == null)
                                {
                                    objCusUserHead.user = new List<ReturnInternalUserModel>();
                                }

                                objCusUserHead.user.Add(objCusUserData);
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
                    objError.WriteLog(0, "User_Data", "get_user_single", "Log Track: " + JsonConvert.SerializeObject(objCusUserHeadList));
                    return objCusUserHeadList;

                }
            }
            catch (Exception ex)
            {

                objCusUserHead = new ReturnInternalUserModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCusUserHeadList.Add(objCusUserHead);

                objError.WriteLog(0, "User_Data", "get_user_internal_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "User_Data", "get_user_internal_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "User_Data", "get_user_internal_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "User_Data", "get_user_internal_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCusUserHeadList;

        }

        public static List<ReturnExternalUserModelHead> get_user_external_single(GetExternalUserSingleModel CUser)//ok
        {
            List<ReturnExternalUserModelHead> objCusUserHeadList = new List<ReturnExternalUserModelHead>();

            //List<ReturnUserGroupModel> objGrpSList = new List<ReturnUserGroupModel>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    ReturnExternalUserModelHead objCusUserHead = new ReturnExternalUserModelHead();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_user_external_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UE_UserID", CUser.UE_UserID);
                        cmd.Parameters["@UE_UserID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnExternalUserModel objCusUserData = new ReturnExternalUserModel();

                                objCusUserHead.resp = true;
                                objCusUserHead.msg = "Get External User";

                                objCusUserData.UE_UserID = rdr["UE_UserID"].ToString();
                                objCusUserData.UE_FirstName = rdr["UE_FirstName"].ToString();
                                objCusUserData.UE_LastName = rdr["UE_LastName"].ToString();
                                objCusUserData.UE_EmailAddress = rdr["UE_EmailAddress"].ToString();
                                objCusUserData.UE_MobileNumber = rdr["UE_MobileNumber"].ToString();
                                objCusUserData.UE_PhoneNumber = rdr["UE_PhoneNumber"].ToString();
                                objCusUserData.UE_Remarks = rdr["UE_Remarks"].ToString();
                                objCusUserData.UE_ActiveFrom = Convert.ToDateTime(rdr["UE_ActiveFrom"].ToString());
                                objCusUserData.UE_ActiveTo = Convert.ToDateTime(rdr["UE_ActiveTo"].ToString());
                                objCusUserData.UE_Status = Convert.ToBoolean(rdr["UE_Status"].ToString());
                                objCusUserData.UE_Pwd = rdr["UE_Pwd"].ToString();
                                objCusUserData.UE_PwdSalt = rdr["UE_PwdSalt"].ToString();
                                objCusUserData.UE_PwdLastResetDateTime = Convert.ToDateTime(rdr["UE_PwdLastResetDateTime"].ToString());
                                objCusUserData.UE_CreatedBy = rdr["UE_CreatedBy"].ToString();
                                objCusUserData.UE_CreatedDateTime = rdr["UE_CreatedDateTime"].ToString();
                                objCusUserData.UE_ModifiedBy = rdr["UE_ModifiedBy"].ToString();
                                objCusUserData.UE_ModifiedDateTime = rdr["UE_ModifiedDateTime"].ToString();
                                objCusUserData.UE_Otp = rdr["UE_Otp"].ToString();
                                objCusUserData.UE_Otp_Generate_On = rdr["UE_Otp_Generate_On"].ToString();

                                if (objCusUserHead.User == null)
                                {
                                    objCusUserHead.User = new List<ReturnExternalUserModel>();
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
                    objError.WriteLog(0, "User_Data", "get_user_single", "Log Track: " + JsonConvert.SerializeObject(objCusUserHeadList));
                    return objCusUserHeadList;

                }
            }
            catch (Exception ex)
            {

                ReturnExternalUserModelHead objCusUserHead = new ReturnExternalUserModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCusUserHeadList.Add(objCusUserHead);

                objError.WriteLog(0, "User_Data", "get_user_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "User_Data", "get_user_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "User_Data", "get_user_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "User_Data", "get_user_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCusUserHeadList;

        }

        public static List<ReturnExternalUserAllModelHead> get_user_external_all(GetUserAllModel CUserall)//ok
        {
            List<ReturnExternalUserAllModelHead> objCusUserHeadList = new List<ReturnExternalUserAllModelHead>();
            List<ReturnExternalUserAllModel> objCusUserSList = new List<ReturnExternalUserAllModel>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    ReturnExternalUserAllModelHead objCusUserHead = new ReturnExternalUserAllModelHead();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_user_external_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@PAGE_NO"= rdr["UD_UserID"].ToString(); CUserall.PAGE_NO);
                        //cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT"= rdr["UD_UserID"].ToString(); CUserall.PAGE_RECORDS_COUNT);
                        //cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        string RC = "";

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnExternalUserAllModel objCusUserData = new ReturnExternalUserAllModel();

                                objCusUserHead.resp = true;
                                objCusUserHead.msg = "Get External User";

                                objCusUserData.UE_UserID = rdr["UE_UserID"].ToString();
                                objCusUserData.UE_FirstName = rdr["UE_FirstName"].ToString();
                                objCusUserData.UE_LastName = rdr["UE_LastName"].ToString();
                                objCusUserData.UE_EmailAddress = rdr["UE_EmailAddress"].ToString();
                                objCusUserData.UE_MobileNumber = rdr["UE_MobileNumber"].ToString();
                                objCusUserData.UE_PhoneNumber = rdr["UE_PhoneNumber"].ToString();
                                objCusUserData.UE_Remarks = rdr["UE_Remarks"].ToString();
                                objCusUserData.UE_ActiveFrom = Convert.ToDateTime(rdr["UE_ActiveFrom"].ToString());
                                objCusUserData.UE_ActiveTo = Convert.ToDateTime(rdr["UE_ActiveTo"].ToString());
                                objCusUserData.UE_Status = Convert.ToBoolean(rdr["UE_Status"].ToString());
                                objCusUserData.UE_Pwd = rdr["UE_Pwd"].ToString();
                                objCusUserData.UE_PwdSalt = rdr["UE_PwdSalt"].ToString();
                                objCusUserData.UE_PwdLastResetDateTime = Convert.ToDateTime(rdr["UE_PwdLastResetDateTime"].ToString());
                                objCusUserData.UE_CreatedBy = rdr["UE_CreatedBy"].ToString();
                                objCusUserData.UE_CreatedDateTime = rdr["UE_CreatedDateTime"].ToString();
                                objCusUserData.UE_ModifiedBy = rdr["UE_ModifiedBy"].ToString();
                                objCusUserData.UE_ModifiedDateTime = rdr["UE_ModifiedDateTime"].ToString();
                                objCusUserData.UE_Otp = rdr["UE_Otp"].ToString();
                                objCusUserData.UE_Otp_Generate_On = rdr["UE_Otp_Generate_On"].ToString();

                                objCusUserSList.Add(objCusUserData);

                                if (objCusUserHead.User == null)
                                {
                                    objCusUserHead.User = new List<ReturnExternalUserAllModel>();
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

                ReturnExternalUserAllModelHead objCusUserHead = new ReturnExternalUserAllModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCusUserHeadList.Add(objCusUserHead);

                objError.WriteLog(0, "User_Data", "sp_get_user_external_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "User_Data", "sp_get_user_external_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "User_Data", "sp_get_user_external_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "User_Data", "sp_get_user_external_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCusUserHeadList;

        }

        public static List<ReturnInternalUserAllModelHead> get_user_internal_all(GetUserAllModel CUserall)//ok
        {
            List<ReturnInternalUserAllModelHead> objCusUserHeadList = new List<ReturnInternalUserAllModelHead>();
            List<ReturnInternalUserAllModel> objCusUserSList = new List<ReturnInternalUserAllModel>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    ReturnInternalUserAllModelHead objCusUserHead = new ReturnInternalUserAllModelHead();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_user_internal_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@PAGE_NO", CUserall.PAGE_NO);
                        //cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", CUserall.PAGE_RECORDS_COUNT);
                        //cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        string RC = "";

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnInternalUserAllModel objCusUserData = new ReturnInternalUserAllModel();

                                objCusUserHead.resp = true;
                                objCusUserHead.msg = "Get External User";

                                objCusUserData.UE_EmployeeID = rdr["UE_EmployeeID"].ToString();
                                objCusUserData.UE_UserID = rdr["UE_UserID"].ToString();
                                objCusUserData.UE_FirstName = rdr["UE_FirstName"].ToString();
                                objCusUserData.UE_LastName = rdr["UE_LastName"].ToString();
                                objCusUserData.UE_EmailAddress = rdr["UE_EmailAddress"].ToString();
                                objCusUserData.UE_MobileNumber = rdr["UE_MobileNumber"].ToString();
                                objCusUserData.UE_PhoneNumber = rdr["UE_PhoneNumber"].ToString();
                                objCusUserData.UE_Remarks = rdr["UE_Remarks"].ToString();
                                objCusUserData.UE_ActiveFrom = Convert.ToDateTime(rdr["UE_ActiveFrom"].ToString());
                                objCusUserData.UE_ActiveTo = Convert.ToDateTime(rdr["UE_ActiveTo"].ToString());
                                objCusUserData.UE_Status = Convert.ToBoolean(rdr["UE_Status"].ToString());
                                objCusUserData.UE_Pwd = rdr["UE_Pwd"].ToString();
                                objCusUserData.UE_PwdSalt = rdr["UE_PwdSalt"].ToString();
                                objCusUserData.UE_PwdLastResetDateTime = Convert.ToDateTime(rdr["UE_PwdLastResetDateTime"].ToString());
                                objCusUserData.UE_CreatedBy = rdr["UE_CreatedBy"].ToString();
                                objCusUserData.UE_CreatedDateTime = rdr["UE_CreatedDateTime"].ToString();
                                objCusUserData.UE_ModifiedBy = rdr["UE_ModifiedBy"].ToString();
                                objCusUserData.UE_ModifiedDateTime = rdr["UE_ModifiedDateTime"].ToString();
                                objCusUserData.UE_Otp = rdr["UE_Otp"].ToString();
                                objCusUserData.UE_Otp_Generate_On = rdr["UE_Otp_Generate_On"].ToString();

                                objCusUserSList.Add(objCusUserData);

                                if (objCusUserHead.User == null)
                                {
                                    objCusUserHead.User = new List<ReturnInternalUserAllModel>();
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

                ReturnInternalUserAllModelHead objCusUserHead = new ReturnInternalUserAllModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCusUserHeadList.Add(objCusUserHead);

                objError.WriteLog(0, "User_Data", "sp_get_user_internal_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "User_Data", "sp_get_user_internal_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "User_Data", "sp_get_user_internal_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "User_Data", "sp_get_user_internal_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCusUserHeadList;

        }

        public static List<ReturnResponse> add_new_user(UserModel item)//ok
        {
            List<ReturnResponse> objCUserHeadList = new List<ReturnResponse>();

            if (!string.IsNullOrEmpty(item.UD_EmailAddress) && !utility_handler.Utility.Misc.EmailValidator(item.UD_EmailAddress))
            {
                objCUserHeadList.Add(new ReturnResponse
                {
                    resp = false,
                    msg = "Invalid Email Address"
                });

                string logobject = JsonConvert.SerializeObject(objCUserHeadList);

                objError.WriteLog(0, "User_Data", "add_new_user", "Stack Track: " + logobject + item);

                return objCUserHeadList;
            }

            try
            {
                string encryptedPW = "";
                string encryptedpin = "";
                decimal Salt = 0;
                string NotEncryptedPassword = "";

                string CUS_PinOrPwd = "";
                bool SMSOk = true;
                bool EmailOk = true;

                List<ReturnCustomerModelHead> cust = Customer_Data.get_customers_single(new Customer() { CUS_ID = item.UD_CustomerID });

                if (cust != null && cust.Count > 0 && cust[0].Customer != null && cust[0].Customer.Count > 0)
                {
                    CUS_PinOrPwd = cust[0].Customer[0].CUS_PinOrPwd;
                    SMSOk = cust[0].Customer[0].CUS_OTP_By_SMS;
                    EmailOk = cust[0].Customer[0].CUS_OTP_By_Email;
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

                        cmd.Parameters.AddWithValue("@UD_CustomerID", item.UD_CustomerID);
                        cmd.Parameters["@UD_CustomerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UD_DepartmentID", item.UD_DepartmentID);
                        cmd.Parameters["@UD_DepartmentID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UD_FirstName", item.UD_FirstName);
                        cmd.Parameters["@UD_FirstName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UD_LastName", item.UD_LastName);
                        cmd.Parameters["@UD_LastName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UD_PrefferedName", item.UD_PrefferedName);
                        cmd.Parameters["@UD_PrefferedName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UD_Address", item.UD_Address);
                        cmd.Parameters["@UD_Address"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UD_EmailAddress", item.UD_EmailAddress);
                        cmd.Parameters["@UD_EmailAddress"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UD_MobileNumber", item.UD_MobileNumber);
                        cmd.Parameters["@UD_MobileNumber"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UD_PhoneNumber1", item.UD_PhoneNumber1);
                        cmd.Parameters["@UD_PhoneNumber1"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UD_PhoneNumber2", item.UD_PhoneNumber2);
                        cmd.Parameters["@UD_PhoneNumber2"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UD_RankDescription", item.UD_RankDescription);
                        cmd.Parameters["@UD_RankDescription"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UD_StaffLocation", item.UD_StaffLocation);
                        cmd.Parameters["@UD_StaffLocation"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UD_Remarks", item.UD_Remarks);
                        cmd.Parameters["@UD_Remarks"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UD_Pin", encryptedpin);
                        cmd.Parameters["@UD_Pin"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UD_Pwd", encryptedPW);
                        cmd.Parameters["@UD_Pwd"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UD_PwdSalt", Salt);
                        cmd.Parameters["@UD_PwdSalt"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@UD_ActiveFrom", item.UD_ActiveFrom);
                        //cmd.Parameters["@UD_ActiveFrom"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@UD_ActiveTo", item.UD_ActiveTo);
                        //cmd.Parameters["@UD_ActiveTo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UD_Status", item.UD_Status);
                        cmd.Parameters["@UD_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UD_EmployeeID", item.UD_EmployeeID);
                        cmd.Parameters["@UD_EmployeeID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

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

                objError.WriteLog(0, "User_Data", "add_new_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "User_Data", "add_new_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "User_Data", "add_new_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "User_Data", "add_new_user", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCUserHeadList;
        }

        public static (bool IsSMSFailed, bool IsEmailFailed) SendEmailSMS_CustomerUser(UserModel item,
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

                    if (string.IsNullOrEmpty(item.UD_EmailAddress))
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
				                                    <td><b>" + item.UD_UserID + @"</b></td>
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


                    if (!string.IsNullOrEmpty(item.UD_EmailAddress))
                    {
                        EmailAttachedFileDetails objFilesAttachment = new EmailAttachedFileDetails();
                        ReturnResponse rtn = Email_Sender_Preperation.Send(item.UD_EmailAddress, body, BU_ID, EmailOk, BaseClassDBCallerData.UserPwSubject, objFilesAttachment);
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

                    if (!string.IsNullOrEmpty(item.UD_MobileNumber))
                    {
                        body = @"Your Mailtrak PIN\Password." + " " + NotEncryptedPassword;

                        ReturnResponse rtn = SMS_Sender_Preperation.SMSgateway(item.UD_MobileNumber, body, BU_ID, SMSOk);
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

        public static List<ReturnResponse> modify_external_user(ExternalUserModel item)//ok
        {
            List<ReturnResponse> objCUserHeadList = new List<ReturnResponse>();

            if (!string.IsNullOrEmpty(item.UE_EmailAddress) && !utility_handler.Utility.Misc.EmailValidator(item.UE_EmailAddress))
            {
                objCUserHeadList.Add(new ReturnResponse
                {
                    resp = false,
                    msg = "Invalid Email Address"
                });

                string logobject = JsonConvert.SerializeObject(objCUserHeadList);

                objError.WriteLog(0, "User_Data", "modify_user", "Stack Track: " + logobject + item);

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

                        cmd.CommandText = "sp_modify_user_external";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UE_UserID", item.UE_UserID);
                        cmd.Parameters["@UE_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UE_FirstName", item.UE_FirstName);
                        cmd.Parameters["@UE_FirstName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UE_LastName", item.UE_LastName);
                        cmd.Parameters["@UE_LastName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UE_EmailAddress", item.UE_EmailAddress);
                        cmd.Parameters["@UE_EmailAddress"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UE_MobileNumber", item.UE_MobileNumber);
                        cmd.Parameters["@UE_MobileNumber"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UE_PhoneNumber", item.UE_PhoneNumber);
                        cmd.Parameters["@UE_PhoneNumber"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UE_Remarks", item.UE_Remarks);
                        cmd.Parameters["@UE_Remarks"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UE_Status", item.UE_Status);
                        cmd.Parameters["@UE_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@ModifiedUser", item.UE_Status);
                        cmd.Parameters["@ModifiedUser"].Direction = ParameterDirection.Input;

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
                            }
                        }
                    }

                    string logobject = JsonConvert.SerializeObject(objCUserHeadList);
                    string logitem = JsonConvert.SerializeObject(item);
                    objError.WriteLog(0, "User_Data", "modify_user", "Stack Track: " + logobject + "   " + logitem);

                    //objError.WriteLog(0, "User_Data", "modify_user", "Stack Track: " + objCUserHeadList + item);
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

                objError.WriteLog(0, "User_Data", "modify_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "User_Data", "modify_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "User_Data", "modify_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "User_Data", "modify_user", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCUserHeadList;
        }

        public static List<ReturnResponse> modify_internal_user(InternalUserModel item)//ok
        {
            List<ReturnResponse> objCUserHeadList = new List<ReturnResponse>();

            if (!string.IsNullOrEmpty(item.UE_EmailAddress) && !utility_handler.Utility.Misc.EmailValidator(item.UE_EmailAddress))
            {
                objCUserHeadList.Add(new ReturnResponse
                {
                    resp = false,
                    msg = "Invalid Email Address"
                });

                string logobject = JsonConvert.SerializeObject(objCUserHeadList);

                objError.WriteLog(0, "User_Data", "modify_user", "Stack Track: " + logobject + item);

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

                        cmd.Parameters.AddWithValue("@UE_UserID", item.UE_UserID);
                        cmd.Parameters["@UE_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UE_FirstName", item.UE_FirstName);
                        cmd.Parameters["@UE_FirstName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UE_LastName", item.UE_LastName);
                        cmd.Parameters["@UE_LastName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UE_EmailAddress", item.UE_EmailAddress);
                        cmd.Parameters["@UE_EmailAddress"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UE_MobileNumber", item.UE_MobileNumber);
                        cmd.Parameters["@UE_MobileNumber"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UE_PhoneNumber", item.UE_PhoneNumber);
                        cmd.Parameters["@UE_PhoneNumber"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UE_Remarks", item.UE_Remarks);
                        cmd.Parameters["@UE_Remarks"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UE_ActiveFrom", item.UE_ActiveFrom);
                        cmd.Parameters["@UE_ActiveFrom"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UE_ActiveTo", item.UE_ActiveTo);
                        cmd.Parameters["@UE_ActiveTo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UE_Status", item.UE_Status);
                        cmd.Parameters["@UE_Status"].Direction = ParameterDirection.Input;

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
                            }
                        }
                    }

                    string logobject = JsonConvert.SerializeObject(objCUserHeadList);
                    string logitem = JsonConvert.SerializeObject(item);
                    objError.WriteLog(0, "User_Data", "modify_user", "Stack Track: " + logobject + "   " + logitem);

                    //objError.WriteLog(0, "User_Data", "modify_user", "Stack Track: " + objCUserHeadList + item);
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

                objError.WriteLog(0, "User_Data", "modify_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "User_Data", "modify_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "User_Data", "modify_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "User_Data", "modify_user", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCUserHeadList;
        }

        //public static List<ReturnResponse> change_password(NewpwModel item)//set use need to apply - all person
        //{
        //    List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
        //    List<SPResponse> objResponseList = new List<SPResponse>();
        //    try
        //    {
        //        string encryptedPW = "";
        //        decimal Salt = 0;
        //        string emailBody = "";
        //        string smsBody = "";

        //        string PwType = GetUserPasswordType(item.UD_UserID, item.UD_UserID);

        //        string tmpPassword = "";

        //        if (PwType.ToUpper() == "PWD")
        //        {
        //            tmpPassword = PasswordRelated.CreateRandomPassword();
        //        }
        //        else
        //        {
        //            tmpPassword = PasswordRelated.CreateRandomPIN();
        //        }

        //        //PasswordRelated.CreateEncryptedPassword(tmpPassword, ref encryptedPW, ref Salt);
        //        encryptedPW = utility_handler.Utility.Misc.deCrypt(tmpPassword);

        //        using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
        //        {
        //            using (SqlCommand cmdpw = new SqlCommand())
        //            {
        //                cmdpw.Connection = lconn;

        //                cmdpw.CommandText = "sp_sav_user_pw";
        //                cmdpw.CommandType = CommandType.StoredProcedure;

        //                cmdpw.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
        //                cmdpw.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

        //                cmdpw.Parameters.AddWithValue("@USER_PW", encryptedPW);
        //                cmdpw.Parameters["@USER_PW"].Direction = ParameterDirection.Input;

        //                cmdpw.Parameters.AddWithValue("@USER_PwdSalt", Salt);
        //                cmdpw.Parameters["@USER_PwdSalt"].Direction = ParameterDirection.Input;

        //                SqlDataAdapter dta = new SqlDataAdapter();
        //                dta.SelectCommand = cmdpw;
        //                DataSet Ds = new DataSet();
        //                dta.Fill(Ds);

        //                int exp_date = 0;
        //                String expired_date = "";
        //                String mailroom = "";

        //                var CentralMailroom = SystemParameter_Data.get_system_parameter_single(new GetSystemPMSingleModel { SP_ID = "CentralMailRoomNumber" });

        //                if (CentralMailroom != null)
        //                {
        //                    foreach (var para in CentralMailroom)
        //                    {
        //                        foreach (var para2 in para.SystemPM)
        //                        {
        //                            mailroom = para2.SP_Value;
        //                        }
        //                    }
        //                }

        //                if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        //                {
        //                    SPResponse objResponse = new SPResponse();
        //                    foreach (DataRow rdrpw in Ds.Tables[0].Rows)
        //                    {
        //                        if (!String.IsNullOrEmpty(rdrpw["RTN_DATE"].ToString()))
        //                        {
        //                            exp_date = int.Parse(rdrpw["RTN_DATE"].ToString());
        //                            expired_date = DateTime.Now.AddDays(exp_date).ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
        //                        }

        //                        ReturnResponse objUserHead = new ReturnResponse
        //                        {
        //                            resp = Boolean.Parse(rdrpw["RTN_RESP"].ToString()),
        //                            msg = rdrpw["RTN_MSG"].ToString()
        //                        };
        //                        objUserHeadList.Add(objUserHead);

        //                        string EmailAddress = "";
        //                        bool IsSMSOk = false;
        //                        bool IsEmailOk = false;

        //                        //bool rtn = false;

        //                        List<ReturnCustomerModelHead> mod = Customer_Data.get_customers_single(new Customer() { CUS_ID = item.UD_CusID });

        //                        if (mod.FirstOrDefault().Customer != null)
        //                        {
        //                            IsSMSOk = mod.FirstOrDefault().Customer.FirstOrDefault().CUS_OTP_By_SMS;
        //                            IsEmailOk = mod.FirstOrDefault().Customer.FirstOrDefault().CUS_OTP_By_Email;
        //                        }

        //                        List<ReturnUserModelHead> mod1 = User_Data.get_user_single(new GetUserSingleModel() { UD_UserName = item.UD_UserID });

        //                        if (mod1.FirstOrDefault().User != null)
        //                        {
        //                            EmailAddress = mod1.FirstOrDefault().User.FirstOrDefault().UD_EmailAddress;
        //                        }

        //                        //if (!string.IsNullOrEmpty(ObjUMP.UPM_UserEmail))
        //                        //{
        //                        //    EmailAttachedFileDetails objFilesAttachment = new EmailAttachedFileDetails();
        //                        //    ReturnResponse rtn = Email_Sender_Preperation.Send(/*ObjUMP.UPM_UserEmail*/EmailAddress, emailBody, BU_ID, IsEmailOk, BaseClassDBCallerData.ResetPwSubject, objFilesAttachment);

        //                        //    if (rtn.resp == false)
        //                        //    {
        //                        //        ReturnResponse objUserHeads = new ReturnResponse
        //                        //        {
        //                        //            resp = false,
        //                        //            msg = "Email Sending Failed"
        //                        //        };
        //                        //        objUserHeadList.Add(objUserHeads);
        //                        //    }
        //                        //}
        //                        //if (!string.IsNullOrEmpty(ObjUMP.UPM_MobileNumber))
        //                        //{
        //                        //    SMS_Sender_Preperation.SMSgateway(ObjUMP.UPM_MobileNumber, smsBody, BU_ID, IsSMSOk);
        //                        //}
        //                    }
        //                }

        //            }


        //            return objUserHeadList;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ReturnResponse objUserHead = new ReturnResponse
        //        {
        //            resp = false,
        //            msg = ex.Message.ToString()
        //        };
        //        objUserHeadList.Add(objUserHead);

        //        objError.WriteLog(0, "User_Data", "change_password", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "User_Data", "change_password", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "User_Data", "change_password", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "User_Data", "change_password", "Inner Exception Message: " + ex.InnerException.Message);
        //        }
        //        return objUserHeadList;
        //    }
        //}

        //public static List<ReturnResponse> update_notification_token(NotificationTokenModel UpNotTokModel, string userId)
        //{
        //    List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
        //    List<SPResponse> objResponseList = new List<SPResponse>();

        //    try
        //    {
        //        using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
        //        {

        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.Connection = lconn;

        //                cmd.CommandText = "SP_UPDATE_NOTIFICATION_TOKEN";
        //                cmd.CommandType = CommandType.StoredProcedure;


        //                cmd.Parameters.AddWithValue("@ID", userId);
        //                cmd.Parameters["@ID"].Direction = ParameterDirection.Input;

        //                cmd.Parameters.AddWithValue("@NOTIFICATION_TOKEN", UpNotTokModel.notification_token);
        //                cmd.Parameters["@NOTIFICATION_TOKEN"].Direction = ParameterDirection.Input;

        //                SqlDataAdapter dta = new SqlDataAdapter();
        //                dta.SelectCommand = cmd;
        //                DataSet Ds = new DataSet();
        //                dta.Fill(Ds);

        //                if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        //                {
        //                    SPResponse objResponse = new SPResponse();

        //                    foreach (DataRow rdr in Ds.Tables[0].Rows)
        //                    {
        //                        ReturnResponse objUserHead = new ReturnResponse
        //                        {
        //                            resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
        //                            msg = rdr["RTN_MSG"].ToString()
        //                        };
        //                        objUserHeadList.Add(objUserHead);
        //                    }
        //                }
        //            }

        //        }
        //        return objUserHeadList;
        //    }
        //    catch (Exception ex)
        //    {
        //        ReturnResponse objUserHead = new ReturnResponse
        //        {
        //            resp = false,
        //            msg = ex.Message.ToString()
        //        };
        //        objUserHeadList.Add(objUserHead);

        //        objError.WriteLog(0, "User_Data", "update_notification_token", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "User_Data", "update_notification_token", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "User_Data", "update_notification_token", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "User_Data", "update_notification_token", "Inner Exception Message: " + ex.InnerException.Message);
        //        }
        //        return objUserHeadList;
        //    }
        //}

        //public static List<ReturnResponse> reset_password(ResetPasswordModel resetPassword, string baseUrl)//set use need to apply - customer only
        //{

        //    List<ReturnResponse> objOtpHeadList = new List<ReturnResponse>();
        //    List<ResetPasswordModel> objList = new List<ResetPasswordModel>();
        //    ReturnResponse objOtpHead = new ReturnResponse();

        //    string BU_ID = "";

        //    try
        //    {
        //        using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
        //        {

        //            using (SqlCommand cmdsmtp = new SqlCommand())
        //            {
        //                cmdsmtp.Connection = lconn;

        //                cmdsmtp.CommandText = "SP_GET_USER_EMAIL_VERIFY_CODE";
        //                cmdsmtp.CommandType = CommandType.StoredProcedure;

        //                cmdsmtp.Parameters.AddWithValue("@EMAIL", resetPassword.email);
        //                cmdsmtp.Parameters["@EMAIL"].Direction = ParameterDirection.Input;

        //                SqlDataAdapter dta = new SqlDataAdapter();
        //                dta.SelectCommand = cmdsmtp;
        //                DataSet Ds = new DataSet();
        //                dta.Fill(Ds);

        //                if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        //                {
        //                    foreach (DataRow rdrsmtp in Ds.Tables[0].Rows)
        //                    {
        //                        string code = rdrsmtp["CODE"].ToString();
        //                        int id = Convert.ToInt32(rdrsmtp["ID"]);
        //                        string cc = "";

        //                        string body = "<b>Dear User,\n\r" +
        //                            "Please ckick on the following link to verify your email address." +
        //                            "\n\r\n\r" +
        //                            "<a href=\"" + baseUrl + "/User/change_password_by_email?userId=" + id + "&email=" + resetPassword.email + "&verificationCode=" + code + "\" > Verify Email </ a > </b>";
        //                        //<a href=\"http://localhost:49496/Activated.aspx">login</a>

        //                        EmailAttachedFileDetails objFilesAttachment = new EmailAttachedFileDetails();
        //                        ReturnResponse rtn = Email_Sender_Preperation.Send(resetPassword.email, body, BU_ID, true, "Email Verification", objFilesAttachment);


        //                        if (rtn.resp == false)
        //                        {
        //                            objOtpHead.resp = false;
        //                            objOtpHead.msg = "There was an error in sending email";
        //                        }
        //                        else
        //                        {
        //                            objOtpHead.resp = true;
        //                            objOtpHead.msg = "Email sent";
        //                        }
        //                    }
        //                }
        //            }

        //        }

        //        objOtpHeadList.Add(objOtpHead);
        //    }
        //    catch (Exception ex)
        //    {

        //        objOtpHead = new ReturnResponse
        //        {
        //            resp = false,
        //            msg = ex.Message.ToString()
        //        };
        //        objOtpHeadList.Add(objOtpHead);

        //        objError.WriteLog(0, "User_Data", "reset_password", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "User_Data", "reset_password", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "User_Data", "reset_password", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "User_Data", "reset_password", "Inner Exception Message: " + ex.InnerException.Message);
        //        }


        //    }
        //    return objOtpHeadList;
        //}

        //public static string GetUserPasswordType(string userId, string email)
        //{
        //    string PwdType = "";
        //    try
        //    {
        //        using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
        //        {
        //            SqlCommand cmdpw = new SqlCommand
        //            {
        //                Connection = lconn,
        //                CommandText = "SP_GET_USER_PASSWORDTYPE",
        //                CommandType = CommandType.StoredProcedure
        //            };

        //            cmdpw.Parameters.AddWithValue("@USER_ID", userId);
        //            cmdpw.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

        //            cmdpw.Parameters.AddWithValue("@EMAIL", email);
        //            cmdpw.Parameters["@EMAIL"].Direction = ParameterDirection.Input;


        //            SqlDataAdapter dta = new SqlDataAdapter();
        //            dta.SelectCommand = cmdpw;
        //            DataSet Ds = new DataSet();
        //            dta.Fill(Ds);

        //            if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        //            {
        //                foreach (DataRow rdr in Ds.Tables[0].Rows)
        //                {
        //                    PwdType = rdr["CUS_PinOrPwd"].ToString();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objError.WriteLog(0, "User_Data", "GetUserPasswordType", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "User_Data", "GetUserPasswordType", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "User_Data", "GetUserPasswordType", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "User_Data", "GetUserPasswordType", "Inner Exception Message: " + ex.InnerException.Message);
        //        }
        //    }
        //    return PwdType;
        //}

        //public static string change_password_by_email(int userId, string email, string verificationCode)//set use need to apply
        //{
        //    List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
        //    List<SPResponse> objResponseList = new List<SPResponse>();
        //    SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString);
        //    ReturnResponse objUserHead = new ReturnResponse();

        //    string rtnMsg = "";
        //    string BU_ID = "";
        //    try
        //    {
        //        string PwType = GetUserPasswordType(userId.ToString(), email);

        //        string tmpPassword = "";

        //        if (PwType.ToUpper() == "PWD")
        //        {
        //            tmpPassword = PasswordRelated.CreateRandomPassword();
        //        }
        //        else
        //        {
        //            tmpPassword = PasswordRelated.CreateRandomPIN();
        //        }

        //        string body = "";
        //        body = "Your password has been changed." +
        //            "" +
        //            "Password: " + tmpPassword;

        //        EmailAttachedFileDetails objFilesAttachment = new EmailAttachedFileDetails();
        //        ReturnResponse rtn = Email_Sender_Preperation.Send(email, body, BU_ID, true, BaseClassDBCallerData.ResetPwSubject, objFilesAttachment);

        //        if (rtn.resp == false)
        //        {
        //            objUserHead.resp = false;
        //            objUserHead.msg = "There was an error in sending the OTP";
        //        }
        //        else
        //        {
        //            objUserHead.resp = true;
        //            objUserHead.msg = "Verify OTP";

        //            if (lconn.State == ConnectionState.Closed)
        //            {
        //                lconn.Open();
        //            }

        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.Connection = lconn;

        //                SqlCommand cmdpw = new SqlCommand
        //                {
        //                    Connection = lconn,
        //                    CommandText = "SP_GET_USER_EMAIL_VERIFICATION",
        //                    CommandType = CommandType.StoredProcedure
        //                };

        //                cmdpw.Parameters.AddWithValue("@USER_ID", userId);
        //                cmdpw.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

        //                cmdpw.Parameters.AddWithValue("@VERIFICATION_CODE", verificationCode);
        //                cmdpw.Parameters["@VERIFICATION_CODE"].Direction = ParameterDirection.Input;

        //                cmdpw.Parameters.AddWithValue("@Email", email);
        //                cmdpw.Parameters["@Email"].Direction = ParameterDirection.Input;


        //                string enPW = "";
        //                decimal PasswordSault = 0;
        //                PasswordRelated.CreateEncryptedPassword(tmpPassword, ref enPW, ref PasswordSault);// BCrypt.Net.BCrypt.HashPassword(tmpPassword);

        //                cmdpw.Parameters.AddWithValue("@TMP_PASSWORD", enPW);
        //                cmdpw.Parameters["@TMP_PASSWORD"].Direction = ParameterDirection.Input;

        //                cmdpw.Parameters.AddWithValue("@TMP_SALT", PasswordSault);
        //                cmdpw.Parameters["@TMP_SALT"].Direction = ParameterDirection.Input;

        //                SqlDataReader rdr = cmdpw.ExecuteReader();
        //                if (rdr.HasRows)
        //                {
        //                    while (rdr.Read())
        //                    {

        //                        try
        //                        {



        //                            rtnMsg = rdr["RTN_MSG"].ToString();

        //                        }
        //                        catch (Exception ex)
        //                        {


        //                            rtnMsg = ex.Message.ToString();

        //                            objError.WriteLog(0, "User_Data", "PostNwpw", "Stack Track: " + ex.StackTrace);
        //                            objError.WriteLog(0, "User_Data", "PostNwpw", "Error Message: " + ex.Message);
        //                            if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //                            {
        //                                objError.WriteLog(0, "User_Data", "PostNwpw", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //                                objError.WriteLog(0, "User_Data", "PostNwpw", "Inner Exception Message: " + ex.InnerException.Message);
        //                            }

        //                        }

        //                    }
        //                }

        //            }
        //        }



        //        if (lconn.State == ConnectionState.Open)
        //        {
        //            lconn.Close();
        //        }
        //        //ActivityLog.ActivityLogRequest("Password have changed by user", item.ID);
        //        return rtnMsg;
        //    }
        //    catch (Exception ex)
        //    {
        //        //ReturnResponse objUserHead = new ReturnResponse();
        //        //objUserHead.resp = false;
        //        //objUserHead.msg = ex.Message.ToString();
        //        //objUserHeadList.Add(objUserHead);
        //        rtnMsg = ex.Message.ToString();

        //        objError.WriteLog(0, "User_Data", "PostNwpw", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "User_Data", "PostNwpw", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "User_Data", "PostNwpw", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "User_Data", "PostNwpw", "Inner Exception Message: " + ex.InnerException.Message);
        //        }
        //        return rtnMsg;
        //    }
        //}

    }

}

