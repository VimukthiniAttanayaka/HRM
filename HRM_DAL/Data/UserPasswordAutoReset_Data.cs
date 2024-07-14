using HRM_DAL.Models;
using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using email_sender;
using System.Linq;
using System.Web.Script.Serialization;
using System.Text.Json;
using utility_handler.Utility;
//using Newtonsoft.Json;
using HRM_DAL.Models.ResponceModels;

namespace HRM_DAL.Data
{
    public class UserPasswordAutoReset_Data
    {
        private static LogError objError = new LogError();
        //static List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();

        public class UserPasswordAutoReset
        {
            public static List<ReturnResponse> AutoReset()
            {
                List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
                
                try
                {
                    //objUserHeadList.Clear();

                    //check timer activated
                    ReturnSystemPMModel config = SystemParameter_Data.PredefinedProperties.ServiceRelated.UserPasswordAutoReset_Active();
                    if (config != null && config.SP_Value == "1")
                    {
                        ReturnSystemPMModel obj_SessionFrom = SystemParameter_Data.PredefinedProperties.ServiceRelated.UserPasswordAutoReset_Session_From();
                        ReturnSystemPMModel obj_SessionTo = SystemParameter_Data.PredefinedProperties.ServiceRelated.UserPasswordAutoReset_Session_To();

                        if (obj_SessionFrom != null)
                        {
                            int fromMinutes = 0;
                            int fromHours = 0;

                            var fromtime = obj_SessionFrom.SP_Value.Split(":");
                            int.TryParse(fromtime[1], out fromMinutes);
                            int.TryParse(fromtime[0], out fromHours);

                            DateTime fromTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, fromHours, fromMinutes, 0);

                            int toMinutes = 0;
                            int toHours = 0;

                            var totime = obj_SessionTo.SP_Value.Split(":");
                            int.TryParse(totime[1], out toMinutes);
                            int.TryParse(totime[0], out toHours);

                            DateTime toTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, toHours, toMinutes, 0);

                            OZero_ReturnResponce retObj = new OZero_ReturnResponce();

                            if (DateTime.Now >= fromTime && DateTime.Now <= toTime)
                            {
                                //read completed jobs and non emailed from DB
                                List<ResetPassword> summeryList = UserPasswordAutoReset_where_PasswordExpired();
                              
                            }

                        }
                        //SystemParameter_Data.PredefinedProperties.ServiceRelated.UpdateRelated.DayEndProcess_Batch_Summery_Email_MarkInactive();
                    }
                }
                catch (Exception ex)
                {
                    objError.WriteLog(0, "UserPasswordAutoReset_Data", "AutoReset", "Stack Track: " + ex.StackTrace);
                    objError.WriteLog(0, "UserPasswordAutoReset_Data", "AutoReset", "Error Message: " + ex.Message);
                    if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                    {
                        objError.WriteLog(0, "UserPasswordAutoReset_Data", "AutoReset", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                        objError.WriteLog(0, "UserPasswordAutoReset_Data", "AutoReset", "Inner Exception Message: " + ex.InnerException.Message);
                    }
                }
                return objUserHeadList;
            }
        }

        public static List<ResetPassword> UserPasswordAutoReset_where_PasswordExpired()
        {
            List<ResetPassword> objHeadList = new List<ResetPassword>();
            ResetPassword obj = new ResetPassword();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    if (lconn.State == ConnectionState.Closed)
                    {
                        lconn.Open();
                    }

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_UserPasswordAutoReset_where_PasswordExpired";
                        cmd.CommandType = CommandType.StoredProcedure;


                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {

                            foreach (DataRow rdr in ds.Tables[0].Rows)
                            {
                                obj = new ResetPassword();
                                objError.WriteLog(2, "UserPasswordAutoReset_Data", "UserPasswordAutoReset_where_PasswordExpired", "Stack Track: " + DataSet_Related.DataRow_To_String(rdr));

                                obj.customerId = rdr["customerId"].ToString();
                                obj.userId = rdr["userId"].ToString();
                                obj.userType = rdr["userType"].ToString();
                                obj.deviceNo = rdr["deviceNo"].ToString();
                                obj.deviceTypeId = rdr["deviceTypeId"].ToString();
                                obj.vendorId = rdr["vendorId"].ToString();
                                obj.locationId = rdr["locationId"].ToString();
                                //obj.requestedDateTime = rdr["requestedDateTime"].ToString();
                                objHeadList.Add(obj);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objError.WriteLog(0, "UserPasswordAutoReset_Data", "UserPasswordAutoReset_where_PasswordExpired", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserPasswordAutoReset_Data", "UserPasswordAutoReset_where_PasswordExpired", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserPasswordAutoReset_Data", "UserPasswordAutoReset_where_PasswordExpired", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserPasswordAutoReset_Data", "UserPasswordAutoReset_where_PasswordExpired", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return objHeadList;
        }
    }
}