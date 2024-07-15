using HRM_DAL.Models;
using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using sms_core;
using email_sender;
using HRM_DAL.Models.RequestModels;
using HRM_DAL.Models.ResponceModels;

namespace HRM_DAL.Data
{
    public class OZero_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnResponse> Get_OAuthToken(Get_OAuthToken_RequestModel model, string requestReferenceID, string RequestType, string SmartKioskvendorID, string accessToken, int expiresIn)
        {
            List<ReturnResponse> retres = new List<ReturnResponse>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmdudata = new SqlCommand())
                    {
                        cmdudata.Connection = lconn;

                        cmdudata.CommandText = "sp_Get_OAuthToken_Kioski";
                        cmdudata.CommandType = CommandType.StoredProcedure;

                        cmdudata.Parameters.AddWithValue("@requestReferenceID", requestReferenceID);
                        cmdudata.Parameters["@requestReferenceID"].Direction = ParameterDirection.Input;

                        cmdudata.Parameters.AddWithValue("@RequestType", RequestType);
                        cmdudata.Parameters["@RequestType"].Direction = ParameterDirection.Input;

                        cmdudata.Parameters.AddWithValue("@SmartKioskvendorID", SmartKioskvendorID);
                        cmdudata.Parameters["@SmartKioskvendorID"].Direction = ParameterDirection.Input;

                        cmdudata.Parameters.AddWithValue("@accessToken", accessToken);
                        cmdudata.Parameters["@accessToken"].Direction = ParameterDirection.Input;

                        cmdudata.Parameters.AddWithValue("@expiresIn", expiresIn);
                        cmdudata.Parameters["@expiresIn"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmdudata;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnResponse objretres = new ReturnResponse();

                                objretres.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                objretres.msg = rdr["RTN_MSG"].ToString();

                                retres.Add(objretres);
                            }


                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ReturnResponse objretres = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message
                };
                retres.Add(objretres);

                objError.WriteLog(0, "OZero_Data", "Get_OAuthToken", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "OZero_Data", "Get_OAuthToken", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "OZero_Data", "Get_OAuthToken", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "OZero_Data", "Get_OAuthToken", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return retres;
        }

        public static OZero_ReturnResponce Validate_OAuthToken(string AccessToken, string RequestReferenceID, string RequestType, string SmartKioskvendorID)
        {

            OZero_ReturnResponce retres = new OZero_ReturnResponce();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_Validate_OAuthToken";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@AccessToken", AccessToken);
                        cmd.Parameters["@AccessToken"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@RequestReferenceID", RequestReferenceID);
                        cmd.Parameters["@RequestReferenceID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@RequestType", RequestType);
                        cmd.Parameters["@RequestType"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@SmartKioskvendorID", SmartKioskvendorID);
                        cmd.Parameters["@SmartKioskvendorID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                retres = new OZero_ReturnResponce();

                                retres.messageId = Boolean.Parse(rdr["RTN_RESP"].ToString()) == true ? 1 : 0;
                                retres.message = rdr["RTN_MSG"].ToString();
                            }
                        }

                    }


                }
            }
            catch (Exception ex)
            {

                OZero_ReturnResponce objretres = new OZero_ReturnResponce
                {
                    messageId = 0,
                    message = ex.Message
                };

                objError.WriteLog(0, "OZero_Data", "Validate_OAuthToken", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "OZero_Data", "Validate_OAuthToken", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "OZero_Data", "Validate_OAuthToken", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "OZero_Data", "Validate_OAuthToken", "Inner Exception Message: " + ex.InnerException.Message);
                }

                //return objResponseList;
            }

            return retres;
        }
    }
}
