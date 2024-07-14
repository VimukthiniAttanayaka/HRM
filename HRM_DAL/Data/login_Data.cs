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
        private static SendMail sendMail = new SendMail();
        private static SendSMS sendSMS = new SendSMS();

        public static List<ReturnUserModelHead> login(LogdataModel logdata)
        {

            List<ReturnUserModel> objUserSList = new List<ReturnUserModel>();
            List<ReturnUserModelHead> objUserHeadList = new List<ReturnUserModelHead>();
            List<ReturnResponse> objReturnResponseList = new List<ReturnResponse>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_user_login_V1";
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

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                if (Ds.Tables[0].Columns.Contains("RTN_RESP"))//echeck for error path
                                {
                                    objUserHead = new ReturnUserModelHead
                                    {
                                        resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                        msg = rdr["RTN_MSG"].ToString()
                                    };
                                    if (objUserHead.user == null)
                                    {
                                        objUserHead.user = new List<ReturnUserModel>();
                                    }
                                    objUserHeadList.Add(objUserHead);
                                    //return objUserHeadList;
                                }
                            }
                        }
                        if (Ds != null && Ds.Tables.Count > 1 && Ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[1].Rows)
                            {
                                if (!PasswordRelated.ValidatePassword(logdata.password, rdr["UT_Pwd"].ToString(), rdr["UT_PwdSalt"].ToString()))
                                {
                                    objUserHead = new ReturnUserModelHead
                                    {
                                        resp = false,
                                        msg = "Invalid Password"
                                    };
                                    if (objUserHead.user == null)
                                    {
                                        objUserHead.user = new List<ReturnUserModel>();
                                    }
                                    objUserHeadList.Add(objUserHead);
                                    //return objUserHeadList;
                                }
                                else
                                {
                                    objUserHead = new ReturnUserModelHead
                                    {
                                        resp = true,
                                        msg = "Welcome to HRM"
                                    };

                                    ReturnUserModel objUser = new ReturnUserModel();
                                    var tok = rdr["UT_StaffID"].ToString();
                                    string token = JwToken.Authenticate(tok);
                                    //string token = JwToken.Authenticate(Convert.ToInt32(rdr["UT_StaffID"]));
                                    objUser.UT_StaffID = rdr["UT_StaffID"].ToString();
                                    objUser.UT_FirstName = rdr["UT_FirstName"].ToString();
                                    objUser.UT_LastName = rdr["UT_LastName"].ToString();
                                    objUser.UT_EmailAddress = rdr["UT_EmailAddress"].ToString();
                                    objUser.UT_MobileNumber = rdr["UT_MobileNumber"].ToString();
                                    objUser.UT_PhoneNumber = rdr["UT_PhoneNumber"].ToString();
                                    objUser.UT_BusinessUnit = rdr["UT_BusinessUnit"].ToString();
                                    objUser.BU_CompanyName = rdr["BU_CompanyName"].ToString();
                                    objUser.UT_IsKioskUser = rdr["UT_IsKioskUser"].ToString() == "1" ? true : false;// Convert.ToBoolean(rdr["UT_IsKioskUser"]);
                                    objUser.UT_IsHRMUser = rdr["UT_IsHRMUser"].ToString() == "1" ? true : false;// Convert.ToBoolean(rdr["UT_IsHRMUser"]);
                                    objUser.UPM_UserTableID = rdr["UPM_UserTableID"].ToString();
                                    objUser.UT_Remarks = rdr["UT_Remarks"].ToString();
                                    objUser.BU_ChangeProcessDate = rdr["BU_ChangeProcessDate"].ToString() == "1" ? true : false;

                                    objUser.notificationToken = token;

                                    objUser.authorizationToken = token;

                                    AuthenticationKeySetupWithDB(objUser);

                                    if (objUserHead.user == null)
                                    {
                                        objUserHead.user = new List<ReturnUserModel>();
                                    }

                                    //objUser.UserAccessList = new List<ReturnUserAccessModel>();

                                    //objUser.UserAccessList = LoadUserAccessList(objUser);

                                    objUserHead.user.Add(objUser);



                                    objUserHeadList.Add(objUserHead);

                                    try
                                    {

                                        using (SqlCommand cmdOTP = new SqlCommand())
                                        {
                                            cmdOTP.Connection = lconn;

                                            var sID = rdr["UT_StaffID"].ToString();

                                            cmdOTP.CommandText = "sp_sav_user_otp";
                                            cmdOTP.CommandType = CommandType.StoredProcedure;

                                            cmdOTP.Parameters.AddWithValue("@USER_ID", sID);
                                            cmdOTP.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                                            cmdOTP.Parameters.AddWithValue("@USER_TABLE", objUser.UPM_UserTableID); //"tbl_user_transnational");
                                            cmdOTP.Parameters["@USER_TABLE"].Direction = ParameterDirection.Input;

                                            SqlDataAdapter dtaOTP = new SqlDataAdapter();
                                            dtaOTP.SelectCommand = cmdOTP;
                                            DataSet DsOTP = new DataSet();
                                            dtaOTP.Fill(DsOTP);

                                            if (DsOTP != null && DsOTP.Tables.Count > 0 && DsOTP.Tables[0].Rows.Count > 0)
                                            {
                                                string Emailbody = "";
                                                string SMSbody = "";
                                                foreach (DataRow rdrOTP in DsOTP.Tables[0].Rows)
                                                {
                                                    string code = rdrOTP["RTN_MSG"].ToString();

                                                    if (!string.IsNullOrEmpty(objUser.UT_EmailAddress))
                                                    {
                                                        Emailbody = "<b>Dear User,\n\r<br>" +
                                                                  "Please use this OTP to verify your HRM login." +
                                                                  "\n\r\n\r" + "<h1>" + code + "</h1>" + " This OTP will be valid for the next 5 mins. </ a > </b>";
                                                    }

                                                    if (!string.IsNullOrEmpty(objUser.UT_MobileNumber))
                                                    {
                                                        SMSbody = "Dear User Please use this OTP to verify your HRM login.\n" + code + "\n This OTP will be valid for the next 5 mins.";
                                                    }

                                                    if (!String.IsNullOrEmpty(Emailbody))
                                                    {
                                                        SendEmailOrSMS(new NewpwModel() { USER_ID = sID, USER_TABLE = objUser.UPM_UserTableID }, objReturnResponseList, Emailbody, SMSbody, "OTP Verification", objUser.UT_MobileNumber, objUser.UT_EmailAddress);
                                                    }
                                                    else
                                                    {
                                                        SendEmailOrSMS(new NewpwModel() { USER_ID = sID, USER_TABLE = objUser.UPM_UserTableID }, objReturnResponseList, Emailbody, SMSbody, "OTP Verification", objUser.UT_MobileNumber, objUser.UT_EmailAddress);
                                                    }


                                                    foreach (var item in objReturnResponseList)
                                                    {
                                                        objUserHead = new ReturnUserModelHead
                                                        {
                                                            resp = item.resp,
                                                            msg = item.msg,
                                                        };
                                                    }
                                                    return objUserHeadList;

                                                }
                                            }


                                        }
                                    }
                                    catch
                                    {
                                        objUserHead = new ReturnUserModelHead
                                        {
                                            resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                            msg = rdr["RTN_MSG"].ToString()
                                        };
                                        if (objUserHead.user == null)
                                        {
                                            objUserHead.user = new List<ReturnUserModel>();
                                        }
                                        objUserHeadList.Add(objUserHead);


                                    }
                                    return objUserHeadList;
                                }

                            }
                        }
                        if (objUserHeadList.Count == 0)
                        {
                            objUserHead.resp = false;
                            objUserHead.msg = "Invalid User";
                            objUserHeadList.Add(objUserHead);
                        }
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
                objUserHeadList.Add(objUserHead);

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

        public static List<ReturnUserAccessModelHead> LoadUserAccessList(RequestUserAccessModel objUser)
        {
            List<ReturnUserAccessModel> UserAccessList = new List<ReturnUserAccessModel>();
            List<ReturnUserAccessModelHead> ReturnUserAccessList = new List<ReturnUserAccessModelHead>();


            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_user_login_access";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UT_StaffID", objUser.UT_StaffID);
                        cmd.Parameters["@UT_StaffID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UT_BusinessUnit", objUser.UT_BusinessUnit);
                        cmd.Parameters["@UT_BusinessUnit"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UT_CustomerCode", objUser.UT_CustomerCode);
                        cmd.Parameters["@UT_CustomerCode"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnUserAccessModel objaccess = new ReturnUserAccessModel();

                                objaccess.Menu_Code = rdr["Menu_Code"].ToString();
                                objaccess.Menu_Description = rdr["Menu_Description"].ToString();
                                objaccess.Menu_Item_Type = rdr["Menu_Item_Type"].ToString();
                                objaccess.USER_ID = rdr["UAG_UserID"].ToString();
                                objaccess.UAG_GroupID = rdr["UAG_GroupID"].ToString();

                                UserAccessList.Add(objaccess);
                            }
                        }

                    }
                }

                ReturnUserAccessList.Add(new ReturnUserAccessModelHead() { resp = true, msg = "Load User Access List", UserAccessList = UserAccessList });
            }
            catch (Exception ex)
            {

                ReturnUserAccessList.Add(new ReturnUserAccessModelHead() { resp = false, msg = ex.Message });

                objError.WriteLog(0, "login_Data", "LoadUserAccessList", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "login_Data", "LoadUserAccessList", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "login_Data", "LoadUserAccessList", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "login_Data", "LoadUserAccessList", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return ReturnUserAccessList;
        }

        private static void SendEmailOrSMS(NewpwModel item, List<ReturnResponse> objUserHeadList, String Emailbody, String SMSbody, string subject, string usermobilenumber, string useremail)
        {
            try
            {
                string BU_ID = "";
                string EmailAddress = "";
                bool IsSMSOk = false;
                bool IsEmailOk = false;

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

                if (!string.IsNullOrEmpty(useremail))
                {
                    EmailAttachedFileDetails objFilesAttachment = new EmailAttachedFileDetails();
                    ReturnResponse rtn = Email_Sender_Preperation.Send(/*ObjUMP.UPM_UserEmail*/EmailAddress, Emailbody, BU_ID, IsEmailOk, subject, objFilesAttachment);

                    if (rtn.resp == false)
                    {
                        ReturnResponse objUserHeads = new ReturnResponse
                        {
                            resp = false,
                            msg = "Email Sending Failed"
                        };
                        objUserHeadList.Add(objUserHeads);
                    }
                }
                if (!string.IsNullOrEmpty(usermobilenumber))
                {
                    SMS_Sender_Preperation.SMSgateway(usermobilenumber, SMSbody, BU_ID, IsSMSOk);
                }

            }
            catch (Exception ex)
            {

                ReturnUserModelHead objUserHead = new ReturnUserModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "login_Data", "login", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "login_Data", "login", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "login_Data", "login", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "login_Data", "login", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
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

                        cmd.Parameters.AddWithValue("@UT_USERID", objUser.UT_StaffID);
                        cmd.Parameters["@UT_USERID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UPM_USERTABLEID", objUser.UPM_UserTableID);
                        cmd.Parameters["@UPM_USERTABLEID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@NOTIFICATIONTOKEN", objUser.notificationToken);
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

                        cmd.Parameters.AddWithValue("@UT_USERID", objUser.AUT_StaffID);
                        cmd.Parameters["@UT_USERID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UPM_USERTABLEID", objUser.AUT_UserTableID);
                        cmd.Parameters["@UPM_USERTABLEID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@NOTIFICATIONTOKEN", objUser.AUT_notificationToken);
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

        public static List<ReturnLoadCustomerModelHead> load_customer(LoadCustomerModel LoadCust)
        {

            List<ReturnLoadCustomerModel> objCustSList = new List<ReturnLoadCustomerModel>();
            List<ReturnLoadCustomerModelHead> objCustHeadList = new List<ReturnLoadCustomerModelHead>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_user_customers";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@USER_ID", LoadCust.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            ReturnLoadCustomerModelHead objCustHead = new ReturnLoadCustomerModelHead();
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                objCustHead.resp = true;
                                objCustHead.msg = "Welcome to HRM";


                                ReturnLoadCustomerModel objCust = new ReturnLoadCustomerModel
                                {
                                    UAG_CustomerID = rdr["UAG_CustomerID"].ToString(),
                                    CUS_CompanyName = rdr["CUS_CompanyName"].ToString()
                                };


                                if (objCustHead.Customer == null)
                                {
                                    objCustHead.Customer = new List<ReturnLoadCustomerModel>();
                                }

                                objCustHead.Customer.Add(objCust);


                            }
                            objCustHeadList.Add(objCustHead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                ReturnLoadCustomerModelHead objCustHead = new ReturnLoadCustomerModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objCustHead);

                objError.WriteLog(0, "login_Data", "login", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "login_Data", "login", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "login_Data", "login", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "login_Data", "login", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objCustHeadList;
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

