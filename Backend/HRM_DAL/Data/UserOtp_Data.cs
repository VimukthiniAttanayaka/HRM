using HRM_DAL.Models;
using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using sms_core;
using email_sender;
using utility_handler.Utility;
using email_sender.Models;

namespace HRM_DAL.Data
{
    public class UserOtp_Data
    {
        private static LogError objError = new LogError();
        private static SendMail sendMail = new SendMail();

        public static List<ReturnVerifyOTPModelHead> SaveUserOtp(SaveUserOtpModel saveotp)
        {
            List<ReturnVerifyOTPModelHead> objRtnOTPHeadList = new List<ReturnVerifyOTPModelHead>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmdudata = new SqlCommand())
                    {
                        cmdudata.Connection = lconn;

                        cmdudata.CommandText = "sp_get_user_table";
                        cmdudata.CommandType = CommandType.StoredProcedure;
                        cmdudata.Parameters.AddWithValue("@USER_ID", saveotp.USER_ID);
                        cmdudata.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        cmdudata.Parameters.AddWithValue("@USER_MOBILE", saveotp.USER_MOBILE);
                        cmdudata.Parameters["@USER_MOBILE"].Direction = ParameterDirection.Input;


                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmdudata;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        bool RTN_RESP = false;
                        string RTN_MSG = "";

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdrUdata in Ds.Tables[0].Rows)
                            {
                                if (Ds.Tables[0].Columns.Contains("RTN_MSG"))
                                {                                 
                                    RTN_RESP = Convert.ToBoolean(rdrUdata["RTN_RESP"].ToString());
                                    RTN_MSG = rdrUdata["RTN_MSG"].ToString();
                                    objRtnOTPHeadList.Add(new ReturnVerifyOTPModelHead() { msg = RTN_MSG, resp = RTN_RESP });
                                    return objRtnOTPHeadList;
                                }

                                using (SqlCommand cmdOTP = new SqlCommand())
                                {
                                    cmdOTP.Connection = lconn;

                                    cmdOTP.CommandText = "sp_sav_user_otp";
                                    cmdOTP.CommandType = CommandType.StoredProcedure;

                                    cmdOTP.Parameters.AddWithValue("@USER_ID", saveotp.USER_ID);
                                    cmdOTP.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                                    cmdOTP.Parameters.AddWithValue("@USER_TABLE", rdrUdata["UPM_UserTableID"].ToString());
                                    cmdOTP.Parameters["@USER_TABLE"].Direction = ParameterDirection.Input;

                                    SqlDataAdapter dtaOTP = new SqlDataAdapter();
                                    dtaOTP.SelectCommand = cmdOTP;
                                    DataSet DsOTP = new DataSet();
                                    dtaOTP.Fill(DsOTP);

                                    if (DsOTP != null && DsOTP.Tables.Count > 0 && DsOTP.Tables[0].Rows.Count > 0)
                                    {
                                        foreach (DataRow rdrOTP in DsOTP.Tables[0].Rows)
                                        {

                                            using (SqlCommand cmdsmtp = new SqlCommand())
                                            {
                                                cmdsmtp.Connection = lconn;

                                                cmdsmtp.CommandText = "sp_get_business_unit_single";
                                                cmdsmtp.CommandType = CommandType.StoredProcedure;

                                                cmdsmtp.Parameters.AddWithValue("@BU_ID", rdrUdata["UD_BusinessUnit"].ToString());
                                                cmdsmtp.Parameters["@BU_ID"].Direction = ParameterDirection.Input;

                                                SqlDataAdapter dtasmtp = new SqlDataAdapter();
                                                dtasmtp.SelectCommand = cmdsmtp;
                                                DataSet Dssmtp = new DataSet();
                                                dtasmtp.Fill(Dssmtp);

                                                if (Dssmtp != null && Dssmtp.Tables.Count > 0 && Dssmtp.Tables[0].Rows.Count > 0)
                                                {
                                                    foreach (DataRow rdrsmtp in Dssmtp.Tables[0].Rows)
                                                    {

                                                        string from = rdrsmtp["BU_EMAIL_SMTP_UID"].ToString();
                                                        string to = rdrUdata["UD_EmailAddress"].ToString(); ;
                                                        string smtpServer = rdrsmtp["BU_EMAIL_SMTP_HOST_IP"].ToString();
                                                        int smtpPort = Convert.ToInt32(rdrsmtp["BU_EMAIL_SMTP_HOST_PORT"]);
                                                        Boolean security = Convert.ToBoolean(rdrsmtp["BU_EMAIL_SMTP_SSL_ENABLE"]);
                                                        string userName = rdrsmtp["BU_EMAIL_SMTP_UID"].ToString();

                                                        var BU_EMAIL_SMTP_PWD = rdrsmtp["BU_EMAIL_SMTP_PWD"].ToString();
                                                        string password = Misc.deCrypt(BU_EMAIL_SMTP_PWD);
                                                        //bool rtn = sendMail.SendWithAuth(from, to, "Test Mail-Without Authenticate", "Test", smtpServer, smtpPort, security, userName, password);

                                                        string code = rdrOTP["RTN_MSG"].ToString();

                                                        string cc = "";
                                                        string body = "";

                                                        if (!string.IsNullOrEmpty(to))
                                                        {
                                                            body = "<b>Dear User,\n\r" +
                                                             "Please use this OTP to verify your HRM login." +
                                                            "\n\r\n\r" + "<h1>" + code + "</h1>" + " This OTP will be valid for the next 5 mins. </ a > </b>";
                                                        }
                                                        else
                                                        {
                                                            body = "Dear User Please use this OTP to verify your HRM login. \n"
                                                            + code + "\n This OTP will be valid for the next 5 mins.";
                                                        }

                                                        //<a href=\"http://localhost:49496/Activated.aspx">login</a>

                                                        ReturnVerifyOTPModelHead objUserVerifyOTPHead = new ReturnVerifyOTPModelHead();
                                                        ReturnUserOtpDatatModel objUserOtpData = new ReturnUserOtpDatatModel();

                                                        if (!string.IsNullOrEmpty(to))
                                                        {
                                                            EmailAttachedFileDetails objFilesAttachment = new EmailAttachedFileDetails();
                                                            (bool messageid, string message) rtn = email_sender.SendMail.Send_V1(from, to, cc, "OTP Verification", body, smtpServer, smtpPort, security, userName, password, ConfigCaller.EmailFromName, objFilesAttachment);

                                                            if (rtn.messageid == false)
                                                            {
                                                                objUserVerifyOTPHead.resp = false;
                                                                objUserVerifyOTPHead.msg = "There was an error in sending OTP";
                                                            }
                                                            else
                                                            {
                                                                objUserVerifyOTPHead.resp = true;
                                                                objUserVerifyOTPHead.msg = "OTP sent";

                                                                objUserOtpData.USER_ID = saveotp.USER_ID;
                                                                objUserOtpData.UPM_UserTableID = rdrUdata["UPM_UserTableID"].ToString();
                                                            }
                                                        }
                                                        else
                                                        {
                                                            var rtn = SMS_Sender_Preperation.SMSgateway(saveotp.USER_MOBILE, body, rdrUdata["UD_BusinessUnit"].ToString(), true);

                                                            if (rtn.resp == false)
                                                            {
                                                                objUserVerifyOTPHead.resp = false;
                                                                objUserVerifyOTPHead.msg = "There was an error in sending OTP";
                                                            }
                                                            else
                                                            {
                                                                objUserVerifyOTPHead.resp = true;
                                                                objUserVerifyOTPHead.msg = "OTP sent";

                                                                objUserOtpData.USER_ID = saveotp.USER_ID;
                                                                objUserOtpData.UPM_UserTableID = rdrUdata["UPM_UserTableID"].ToString();
                                                            }
                                                        }


                                                        //RtnOTPModel objVerifyOTP = new RtnOTPModel();

                                                        //ReturnVerifyOTPModelHead objUserVerifyOTPHead = new ReturnVerifyOTPModelHead();
                                                        //ReturnUserOtpDatatModel objUserOtpData = new ReturnUserOtpDatatModel();

                                                        //if (rtn.messageid == false)
                                                        //{
                                                        //    objUserVerifyOTPHead.resp = false;
                                                        //    objUserVerifyOTPHead.msg = "There was an error in sending OTP";
                                                        //}
                                                        //else
                                                        //{
                                                        //    objUserVerifyOTPHead.resp = true;
                                                        //    objUserVerifyOTPHead.msg = "OTP sent";

                                                        //    objUserOtpData.USER_ID = saveotp.USER_ID;
                                                        //    objUserOtpData.UPM_UserTableID = rdrUdata["UPM_UserTableID"].ToString();
                                                        //}


                                                        if (objUserVerifyOTPHead.userdata == null)
                                                        {
                                                            objUserVerifyOTPHead.userdata = new List<ReturnUserOtpDatatModel>();
                                                        }

                                                        objUserVerifyOTPHead.userdata.Add(objUserOtpData);
                                                        objRtnOTPHeadList.Add(objUserVerifyOTPHead);
                                                    }
                                                }
                                            }

                                        }

                                        return objRtnOTPHeadList;
                                    }




                                    //ActivityLog.ActivityLogRequest("Send OTP", USER_ID);
                                }
                            }


                        }
                    }

                }





            }
            catch (Exception ex)
            {
                ReturnVerifyOTPModelHead objUserVerifyOTPHead = new ReturnVerifyOTPModelHead
                {
                    resp = false,
                    msg = ex.Message
                };
                objRtnOTPHeadList.Add(objUserVerifyOTPHead);

                objError.WriteLog(0, "UserOtp_Data", "PostUserOtp", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserOtp_Data", "PostUserOtp", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserOtp_Data", "PostUserOtp", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserOtp_Data", "PostUserOtp", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objRtnOTPHeadList;
        }

        public static List<RtnOTPModel> VerifyOTP(UserOtpModel otp)
        {

            List<RtnOTPModel> objVerifyOTPList = new List<RtnOTPModel>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_vfy_user_otp";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@USER_ID", otp.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USER_TABLE", otp.USER_TABLE);
                        cmd.Parameters["@USER_TABLE"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@VFY_OTP", otp.VFY_OTP);
                        cmd.Parameters["@VFY_OTP"].Direction = ParameterDirection.Input;


                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                RtnOTPModel objVerifyOTP = new RtnOTPModel();

                                objVerifyOTP.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                objVerifyOTP.msg = rdr["RTN_MSG"].ToString();

                                objVerifyOTPList.Add(objVerifyOTP);
                            }
                        }

                    }


                }
            }
            catch (Exception ex)
            {

                RtnOTPModel objVerifyOTP = new RtnOTPModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objVerifyOTPList.Add(objVerifyOTP);

                objError.WriteLog(0, "UserOtp_Data", "VerifyOTP", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserOtp_Data", "VerifyOTP", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserOtp_Data", "VerifyOTP", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserOtp_Data", "VerifyOTP", "Inner Exception Message: " + ex.InnerException.Message);
                }

                //return objResponseList;
            }

            return objVerifyOTPList;
        }
    }
}
