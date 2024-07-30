using email_sender;
using error_handler;
using HRM_DAL.Models;
using HRM_DAL.Utility;
using Microsoft.AspNetCore.Mvc;
using sms_core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using utility_handler.Data;
using utility_handler.Utility;
using email_sender.Models;

namespace HRM_DAL.Data
{
    public class login_Data
    {
        private static LogError objError = new LogError();

        public static ReturnUserModelHead login(LogdataModel logdata)
        {

            ReturnUserModelHead objUserHeadList = new ReturnUserModelHead();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_user_login";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@USER_ID", logdata.username);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USER_PASSWORD", logdata.password);
                        cmd.Parameters["@USER_PASSWORD"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        ReturnUserModelHead objUserHead = new ReturnUserModelHead();
                        objUserHead.resp = true;
                        objUserHead.msg = "Login";

                        //if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        //{
                        //    foreach (DataRow rdr in Ds.Tables[0].Rows)
                        //    {
                        //        if (Ds.Tables[0].Columns.Contains("RTN_RESP"))//echeck for error path
                        //        {
                        //            objUserHead = new ReturnUserModelHead
                        //            {
                        //                resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                        //                msg = rdr["RTN_MSG"].ToString()
                        //            };
                        //            if (objUserHead.user == null)
                        //            {
                        //                objUserHead.user = new List<ReturnUserModel>();
                        //            }
                        //            objUserHeadList.Add(objUserHead);
                        //            //return objUserHeadList;
                        //        }
                        //    }
                        //}
                        //if (Ds != null && Ds.Tables.Count > 1 && Ds.Tables[1].Rows.Count > 0)
                        //{
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                //if (!(Misc.deCrypt(rdr["UD_Pwd"].ToString()) == logdata.password))
                                ////if (!PasswordRelated.ValidatePassword(logdata.password, rdr["UD_Pwd"].ToString(), rdr["UD_PwdSalt"].ToString()))
                                //{
                                //    objUserHead = new ReturnUserModelHead
                                //    {
                                //        resp = false,
                                //        msg = "Invalid Password"
                                //    };
                                //    if (objUserHead.user == null)
                                //    {
                                //        objUserHead.user = new List<ReturnUserModel>();
                                //    }
                                //    objUserHeadList.Add(objUserHead);
                                //    //return objUserHeadList;
                                //}
                                //else
                                //{
                                    objUserHead = new ReturnUserModelHead
                                    {
                                        resp = true,
                                        msg = "Welcome to HRM"
                                    };

                                    ReturnUserModel objUser = new ReturnUserModel();
                                    var tok = rdr["UD_UserID"].ToString();
                                    string token = JwToken.Authenticate(tok);
                                    //string token = JwToken.Authenticate(Convert.ToInt32(rdr["UD_StaffID"]));
                                    objUser.UD_StaffID = rdr["UD_UserID"].ToString();
                                    objUser.UD_FirstName = rdr["UD_FirstName"].ToString();
                                    objUser.UD_LastName = rdr["UD_LastName"].ToString();
                                    objUser.UD_EmailAddress = rdr["UD_EmailAddress"].ToString();
                                    objUser.UD_MobileNumber = rdr["UD_MobileNumber"].ToString();
                                    objUser.UD_PhoneNumber = rdr["UD_PhoneNumber"].ToString();
                                    objUser.UD_Remarks = rdr["UD_Remarks"].ToString();

                                    objUser.UD_AuthorizationToken = token;

                                    AuthenticationKeySetupWithDB(objUser);

                                    if (objUserHead.user == null)
                                    {
                                        objUserHead.user = new List<ReturnUserModel>();
                                    }

                                    objUserHead.user.Add(objUser);
                                    ////objUserHeadList.Add(objUserHead);

                                    return objUserHeadList;
                                }

                        ////    }
                        ////}
                        //if (objUserHeadList.Count == 0)
                        //{
                        //    objUserHead.resp = false;
                        //    objUserHead.msg = "Invalid User";
                        //    objUserHeadList.Add(objUserHead);
                        //}
                    }
                    return objUserHeadList;
                }
            }
            catch (Exception ex)
            {

                ReturnUserModelHead objUserHead = new ReturnUserModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                //objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "login_Data", "login", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "login_Data", "login", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "login_Data", "login", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "login_Data", "login", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }

        private static void AuthenticationKeySetupWithDB(ReturnUserModel objUser)
        {
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_set_AuthenticationKeySetupWithDB";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_USERID", objUser.UD_StaffID);
                        cmd.Parameters["@UD_USERID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@NOTIFICATIONTOKEN", objUser.UD_AuthorizationToken);
                        cmd.Parameters["@NOTIFICATIONTOKEN"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);
                    }
                }
            }
            catch (Exception ex)
            {
                objError.WriteLog(0, "login_Data", "AuthenticationKeySetupWithDB", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "login_Data", "AuthenticationKeySetupWithDB", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "login_Data", "AuthenticationKeySetupWithDB", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "login_Data", "AuthenticationKeySetupWithDB", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
        }

        public static bool AuthenticationKeyValidateWithDB(AuthenticationRequestBaseModel objUser)
        {
            try
            {
                return true;

                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_set_AuthenticationKeyValidateWithDB";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_USERID", objUser.UD_StaffID);
                        cmd.Parameters["@UD_USERID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@NOTIFICATIONTOKEN", objUser.AUD_notificationToken);
                        cmd.Parameters["@NOTIFICATIONTOKEN"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);
                    }
                }
            }
            catch (Exception ex)
            {
                objError.WriteLog(0, "login_Data", "AuthenticationKeySetupWithDB", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "login_Data", "AuthenticationKeySetupWithDB", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "login_Data", "AuthenticationKeySetupWithDB", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "login_Data", "AuthenticationKeySetupWithDB", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return true;//until proper michanism
        }

        private static bool SendOTP(string From, string to, string cc, int OTP, string smtpServer, int smtpPort, Boolean security, string userName, string password)
        {
            try
            {
                string subject = "HRM OTP";
                string body = "Use " + OTP.ToString() + " as the HRM OTP for current login. Valid for five minutes.";
                EmailAttachedFileDetails objFilesAttachment = new EmailAttachedFileDetails();
                (bool messageid, string message) result = SendMail.Send_V1(From, to, cc, subject, body, smtpServer, smtpPort, security, userName, password, ConfigCaller.EmailFromName, objFilesAttachment);
                return result.messageid;
            }
            catch (Exception)
            {
                return false;
            }


        }

    }

}

