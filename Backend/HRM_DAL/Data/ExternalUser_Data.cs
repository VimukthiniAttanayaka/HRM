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
    public class ExternalUser_Data
    {
        private static LogError objError = new LogError();
        private static SendMail sendMail = new SendMail();
        //private static SendSMS sendSMS = new SendSMS();
        public static List<ReturnResponse> inactivate_user_external(InactiveUserModel item)
        {
            throw new NotImplementedException();
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
                                objCusUserData.UE_UserRoleID = rdr["UE_UserRoleId"].ToString();

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
            ReturnExternalUserAllModelHead objCusUserHead = new ReturnExternalUserAllModelHead();
            List<ReturnExternalUserAllModel> objCusUserSList = new List<ReturnExternalUserAllModel>();

            if (objCusUserHead.User == null)
            {
                objCusUserHead.User = new List<ReturnExternalUserAllModel>();
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_user_external_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@PAGE_NO"= rdr["UE_UserID"].ToString(); CUserall.PAGE_NO);
                        //cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT"= rdr["UE_UserID"].ToString(); CUserall.PAGE_RECORDS_COUNT);
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
                                objCusUserData.UE_UserRoleID = rdr["UE_UserRoleId"].ToString();

                                objCusUserSList.Add(objCusUserData);


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

                objCusUserHead.resp = false;
                objCusUserHead.msg = ex.Message.ToString();

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

        public static List<ReturnResponse> add_new_user_external(ExternalUserModel item)//ok
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

                objError.WriteLog(0, "User_Data", "add_new_user", "Stack Track: " + logobject + item);

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

                        cmd.CommandText = "sp_insert_user_external";
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

                        cmd.Parameters.AddWithValue("@ModifiedUser", item.UD_UserID);
                        cmd.Parameters["@ModifiedUser"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UE_UserRoleID", item.UE_UserRoleID);
                        cmd.Parameters["@UE_UserRoleID"].Direction = ParameterDirection.Input;

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

        public static List<ReturnResponse> modify_user_external(ExternalUserModel item)//ok
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

                        cmd.Parameters.AddWithValue("@ModifiedUser", item.UE_UserID);
                        cmd.Parameters["@ModifiedUser"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UE_ActiveFrom", item.UE_ActiveFrom);
                        cmd.Parameters["@UE_ActiveFrom"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UE_ActiveTo", item.UE_ActiveTo);
                        cmd.Parameters["@UE_ActiveTo"].Direction = ParameterDirection.Input;


                        cmd.Parameters.AddWithValue("@UE_UserRoleID", item.UE_UserRoleID);
                        cmd.Parameters["@UE_UserRoleID"].Direction = ParameterDirection.Input;

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
    }

}

