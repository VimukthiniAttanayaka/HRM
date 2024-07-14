using HRM_DAL.Models;
using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_DAL.Data
{
    public class BusinessUnit_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnResponse> add_new_business_unit(BusinessUnitModel item)
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            ReturnResponse objUserHead = new ReturnResponse();

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

                        string temp = item.BU_ID.Trim() + item.BU_CompanyName + item.BU_Abbre + item.BU_Adrs_BlockBuildingNo + item.BU_Adrs_BuildingName + item.BU_Adrs_UnitNumber +
                            item.BU_Adrs_StreetName + item.BU_Adrs_City + item.BU_Adrs_CountryCode + item.BU_Adrs_PostalCode + item.BU_CurrencyCode + item.BU_CountryCode +
                            item.BU_ChangeProcessDate + item.BU_SMS_Enabled + item.BU_SMS_GW_HOST_IP + item.BU_SMS_GW_HOST_PORT + item.BU_SMS_GW_JID + item.BU_SMS_GW_PWD +
                            item.BU_SMS_GW_IIM_SVR + item.BU_SMS_GW_SMS_LIMIT + item.BU_SMS_GW_QUE_CAP + item.BU_SMS_GW_MAX_CHAR + item.BU_SMS_GW_SENDER_ID + item.BU_EMAIL_Enabled +
                            item.BU_EMAIL_SMTP_HOST_IP + item.BU_EMAIL_SMTP_HOST_PORT + item.BU_EMAIL_SMTP_UID + item.BU_EMAIL_SMTP_PWD + item.BU_EMAIL_SMTP_AUTH +
                            item.BU_EMAIL_SMTP_TLS_ENABLE + item.BU_EMAIL_SMTP_SSL_ENABLE + item.BU_EMAIL_SMTP_SSL_PROTOCOLS + item.BU_EMAIL_SMTP_SSL_SOCKET_FACTORY +
                            item.BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_CLASS + item.BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_PORT + item.USER_ID;

                        objError.WriteLog(0, "BusinessUnit_Data", "add_new_business_unit", "Stack Track: " + temp);

                        //Business Unit
                        //cmd.CommandText = "sp_sav_business_unit";
                        cmd.CommandText = "sp_insert_business_unit";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BU_ID", item.BU_ID.Trim());
                        cmd.Parameters["@BU_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_CompanyName", item.BU_CompanyName);
                        cmd.Parameters["@BU_CompanyName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_Abbre", item.BU_Abbre);
                        cmd.Parameters["@BU_Abbre"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_Adrs_BlockBuildingNo", item.BU_Adrs_BlockBuildingNo);
                        cmd.Parameters["@BU_Adrs_BlockBuildingNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_Adrs_BuildingName", item.BU_Adrs_BuildingName);
                        cmd.Parameters["@BU_Adrs_BuildingName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_Adrs_UnitNumber", item.BU_Adrs_UnitNumber);
                        cmd.Parameters["@BU_Adrs_UnitNumber"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_Adrs_StreetName", item.BU_Adrs_StreetName);
                        cmd.Parameters["@BU_Adrs_StreetName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_Adrs_City", item.BU_Adrs_City);
                        cmd.Parameters["@BU_Adrs_City"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_Adrs_CountryCode", item.BU_Adrs_CountryCode);
                        cmd.Parameters["@BU_Adrs_CountryCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_Adrs_PostalCode", item.BU_Adrs_PostalCode);
                        cmd.Parameters["@BU_Adrs_PostalCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_CurrencyCode", item.BU_CurrencyCode);
                        cmd.Parameters["@BU_CurrencyCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_CountryCode", item.BU_CountryCode);
                        cmd.Parameters["@BU_CountryCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_ChangeProcessDate", item.BU_ChangeProcessDate);
                        cmd.Parameters["@BU_ChangeProcessDate"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@BU_Status", item.BU_Status);
                        //cmd.Parameters["@BU_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_SMS_Enabled", item.BU_SMS_Enabled);
                        cmd.Parameters["@BU_SMS_Enabled"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_SMS_GW_HOST_IP", item.BU_SMS_GW_HOST_IP);
                        cmd.Parameters["@BU_SMS_GW_HOST_IP"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_SMS_GW_HOST_PORT", item.BU_SMS_GW_HOST_PORT);
                        cmd.Parameters["@BU_SMS_GW_HOST_PORT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_SMS_GW_JID", item.BU_SMS_GW_JID);
                        cmd.Parameters["@BU_SMS_GW_JID"].Direction = ParameterDirection.Input;

                        string BU_SMS_GW_PWD = utility_handler.Utility.Misc.enCrypt(item.BU_SMS_GW_PWD);
                        cmd.Parameters.AddWithValue("@BU_SMS_GW_PWD", BU_SMS_GW_PWD);
                        cmd.Parameters["@BU_SMS_GW_PWD"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_SMS_GW_IIM_SVR", item.BU_SMS_GW_IIM_SVR);
                        cmd.Parameters["@BU_SMS_GW_IIM_SVR"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_SMS_GW_SMS_LIMIT", item.BU_SMS_GW_SMS_LIMIT);
                        cmd.Parameters["@BU_SMS_GW_SMS_LIMIT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_SMS_GW_QUE_CAP", item.BU_SMS_GW_QUE_CAP);
                        cmd.Parameters["@BU_SMS_GW_QUE_CAP"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_SMS_GW_MAX_CHAR", item.BU_SMS_GW_MAX_CHAR);
                        cmd.Parameters["@BU_SMS_GW_MAX_CHAR"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_SMS_GW_SENDER_ID", item.BU_SMS_GW_SENDER_ID);
                        cmd.Parameters["@BU_SMS_GW_SENDER_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_EMAIL_Enabled", item.BU_EMAIL_Enabled);
                        cmd.Parameters["@BU_EMAIL_Enabled"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_EMAIL_SMTP_HOST_IP", item.BU_EMAIL_SMTP_HOST_IP);
                        cmd.Parameters["@BU_EMAIL_SMTP_HOST_IP"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_EMAIL_SMTP_HOST_PORT", item.BU_EMAIL_SMTP_HOST_PORT);
                        cmd.Parameters["@BU_EMAIL_SMTP_HOST_PORT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_EMAIL_SMTP_UID", item.BU_EMAIL_SMTP_UID);
                        cmd.Parameters["@BU_EMAIL_SMTP_UID"].Direction = ParameterDirection.Input;

                        string BU_EMAIL_SMTP_PWD = utility_handler.Utility.Misc.enCrypt(item.BU_EMAIL_SMTP_PWD);
                        cmd.Parameters.AddWithValue("@BU_EMAIL_SMTP_PWD", BU_EMAIL_SMTP_PWD);
                        cmd.Parameters["@BU_EMAIL_SMTP_PWD"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_EMAIL_SMTP_AUTH", item.BU_EMAIL_SMTP_AUTH);
                        cmd.Parameters["@BU_EMAIL_SMTP_AUTH"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_EMAIL_SMTP_TLS_ENABLE", item.BU_EMAIL_SMTP_TLS_ENABLE);
                        cmd.Parameters["@BU_EMAIL_SMTP_TLS_ENABLE"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_EMAIL_SMTP_SSL_ENABLE", item.BU_EMAIL_SMTP_SSL_ENABLE);
                        cmd.Parameters["@BU_EMAIL_SMTP_SSL_ENABLE"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_EMAIL_SMTP_SSL_PROTOCOLS", item.BU_EMAIL_SMTP_SSL_PROTOCOLS);
                        cmd.Parameters["@BU_EMAIL_SMTP_SSL_PROTOCOLS"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_EMAIL_SMTP_SSL_SOCKET_FACTORY", item.BU_EMAIL_SMTP_SSL_SOCKET_FACTORY);
                        cmd.Parameters["@BU_EMAIL_SMTP_SSL_SOCKET_FACTORY"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_CLASS", item.BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_CLASS);
                        cmd.Parameters["@BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_CLASS"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_PORT", item.BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_PORT);
                        cmd.Parameters["@BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_PORT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_SMS_BY_LINKURL", item.BU_SMS_BY_LINKURL);
                        cmd.Parameters["@BU_SMS_BY_LINKURL"].Direction = ParameterDirection.Input;

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

                                //SqlDataReader rdr = cmd.ExecuteReader();

                                //if (rdr.HasRows)
                                //{
                                //    while (rdr.Read())
                                //    {

                                objUserHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objUserHeadList.Add(objUserHead);

                                //objUserSList.Add(objUserHead.objReturnUserModelList);

                            }
                        }
                        else
                        {
                            objUserHead = new ReturnResponse();
                            objUserHead.resp = true;
                            objUserHead.msg = "";
                            objUserHeadList.Add(objUserHead);
                        }
                    }

                    //ActivityLog.ActivityLogRequest("Saved user details", item.ID);

                    //}

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

                objError.WriteLog(0, "BusinessUnit_Data", "add_new_business_unit", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "BusinessUnit_Data", "add_new_business_unit", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "BusinessUnit_Data", "add_new_business_unit", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "BusinessUnit_Data", "add_new_business_unit", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objUserHeadList;
        }

        public static List<ReturnResponse> modify_business_unit(BusinessUnitModel item)
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            ReturnResponse objUserHead = new ReturnResponse();

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

                        //Business Unit
                        cmd.CommandText = "sp_modify_business_unit";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BU_ID", item.BU_ID.Trim());
                        cmd.Parameters["@BU_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_CompanyName", item.BU_CompanyName);
                        cmd.Parameters["@BU_CompanyName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_Abbre", item.BU_Abbre);
                        cmd.Parameters["@BU_Abbre"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_Adrs_BlockBuildingNo", item.BU_Adrs_BlockBuildingNo);
                        cmd.Parameters["@BU_Adrs_BlockBuildingNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_Adrs_BuildingName", item.BU_Adrs_BuildingName);
                        cmd.Parameters["@BU_Adrs_BuildingName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_Adrs_UnitNumber", item.BU_Adrs_UnitNumber);
                        cmd.Parameters["@BU_Adrs_UnitNumber"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_Adrs_StreetName", item.BU_Adrs_StreetName);
                        cmd.Parameters["@BU_Adrs_StreetName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_Adrs_City", item.BU_Adrs_City);
                        cmd.Parameters["@BU_Adrs_City"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_Adrs_CountryCode", item.BU_Adrs_CountryCode);
                        cmd.Parameters["@BU_Adrs_CountryCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_Adrs_PostalCode", item.BU_Adrs_PostalCode);
                        cmd.Parameters["@BU_Adrs_PostalCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_CurrencyCode", item.BU_CurrencyCode);
                        cmd.Parameters["@BU_CurrencyCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_CountryCode", item.BU_CountryCode);
                        cmd.Parameters["@BU_CountryCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_ChangeProcessDate", item.BU_ChangeProcessDate);
                        cmd.Parameters["@BU_ChangeProcessDate"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_Status", item.BU_Status);
                        cmd.Parameters["@BU_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_SMS_Enabled", item.BU_SMS_Enabled);
                        cmd.Parameters["@BU_SMS_Enabled"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_SMS_GW_HOST_IP", item.BU_SMS_GW_HOST_IP);
                        cmd.Parameters["@BU_SMS_GW_HOST_IP"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_SMS_GW_HOST_PORT", item.BU_SMS_GW_HOST_PORT);
                        cmd.Parameters["@BU_SMS_GW_HOST_PORT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_SMS_GW_JID", item.BU_SMS_GW_JID);
                        cmd.Parameters["@BU_SMS_GW_JID"].Direction = ParameterDirection.Input;

                        string BU_SMS_GW_PWD = utility_handler.Utility.Misc.enCrypt(item.BU_SMS_GW_PWD);
                        cmd.Parameters.AddWithValue("@BU_SMS_GW_PWD", BU_SMS_GW_PWD);
                        cmd.Parameters["@BU_SMS_GW_PWD"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_SMS_GW_IIM_SVR", item.BU_SMS_GW_IIM_SVR);
                        cmd.Parameters["@BU_SMS_GW_IIM_SVR"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_SMS_GW_SMS_LIMIT", item.BU_SMS_GW_SMS_LIMIT);
                        cmd.Parameters["@BU_SMS_GW_SMS_LIMIT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_SMS_GW_QUE_CAP", item.BU_SMS_GW_QUE_CAP);
                        cmd.Parameters["@BU_SMS_GW_QUE_CAP"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_SMS_GW_MAX_CHAR", item.BU_SMS_GW_MAX_CHAR);
                        cmd.Parameters["@BU_SMS_GW_MAX_CHAR"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_SMS_GW_SENDER_ID", item.BU_SMS_GW_SENDER_ID);
                        cmd.Parameters["@BU_SMS_GW_SENDER_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_EMAIL_Enabled", item.BU_EMAIL_Enabled);
                        cmd.Parameters["@BU_EMAIL_Enabled"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_EMAIL_SMTP_HOST_IP", item.BU_EMAIL_SMTP_HOST_IP);
                        cmd.Parameters["@BU_EMAIL_SMTP_HOST_IP"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_EMAIL_SMTP_HOST_PORT", item.BU_EMAIL_SMTP_HOST_PORT);
                        cmd.Parameters["@BU_EMAIL_SMTP_HOST_PORT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_EMAIL_SMTP_UID", item.BU_EMAIL_SMTP_UID);
                        cmd.Parameters["@BU_EMAIL_SMTP_UID"].Direction = ParameterDirection.Input;

                        string BU_EMAIL_SMTP_PWD = utility_handler.Utility.Misc.enCrypt(item.BU_EMAIL_SMTP_PWD);
                        cmd.Parameters.AddWithValue("@BU_EMAIL_SMTP_PWD", BU_EMAIL_SMTP_PWD);
                        cmd.Parameters["@BU_EMAIL_SMTP_PWD"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_EMAIL_SMTP_AUTH", item.BU_EMAIL_SMTP_AUTH);
                        cmd.Parameters["@BU_EMAIL_SMTP_AUTH"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_EMAIL_SMTP_TLS_ENABLE", item.BU_EMAIL_SMTP_TLS_ENABLE);
                        cmd.Parameters["@BU_EMAIL_SMTP_TLS_ENABLE"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_EMAIL_SMTP_SSL_ENABLE", item.BU_EMAIL_SMTP_SSL_ENABLE);
                        cmd.Parameters["@BU_EMAIL_SMTP_SSL_ENABLE"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_EMAIL_SMTP_SSL_PROTOCOLS", item.BU_EMAIL_SMTP_SSL_PROTOCOLS);
                        cmd.Parameters["@BU_EMAIL_SMTP_SSL_PROTOCOLS"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_EMAIL_SMTP_SSL_SOCKET_FACTORY", item.BU_EMAIL_SMTP_SSL_SOCKET_FACTORY);
                        cmd.Parameters["@BU_EMAIL_SMTP_SSL_SOCKET_FACTORY"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_CLASS", item.BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_CLASS);
                        cmd.Parameters["@BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_CLASS"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_PORT", item.BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_PORT);
                        cmd.Parameters["@BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_PORT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_SMS_BY_LINKURL", item.BU_SMS_BY_LINKURL);
                        cmd.Parameters["@BU_SMS_BY_LINKURL"].Direction = ParameterDirection.Input;

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

                                //SqlDataReader rdr = cmd.ExecuteReader();

                                //if (rdr.HasRows)
                                //{
                                //    while (rdr.Read())
                                //    {

                                objUserHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objUserHeadList.Add(objUserHead);

                                //objUserSList.Add(objUserHead.objReturnUserModelList);

                            }
                        }
                        else
                        {
                            objUserHead = new ReturnResponse();
                            objUserHead.resp = false;
                            objUserHead.msg = "";
                            objUserHeadList.Add(objUserHead);
                        }
                    }

                    //ActivityLog.ActivityLogRequest("Saved user details", item.ID);

                    //}

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

                objError.WriteLog(0, "BusinessUnit_Data", "add_new_business_unit", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "BusinessUnit_Data", "add_new_business_unit", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "BusinessUnit_Data", "add_new_business_unit", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "BusinessUnit_Data", "add_new_business_unit", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objUserHeadList;
        }

        public static List<ReturnResponse> inactivate_business_unit(InactiveModel item)
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            ReturnResponse objUserHead = new ReturnResponse();

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


                        cmd.CommandText = "sp_del_business_unit";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BU_ID", item.BU_ID);
                        cmd.Parameters["@BU_ID"].Direction = ParameterDirection.Input;

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

                                //SqlDataReader rdr = cmd.ExecuteReader();

                                //if (rdr.HasRows)
                                //{
                                //    while (rdr.Read())
                                //    {

                                objUserHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objUserHeadList.Add(objUserHead);

                                //objUserSList.Add(objUserHead.objReturnUserModelList);

                            }
                        }
                        else
                        {
                            objUserHead = new ReturnResponse();
                            objUserHead.resp = true;
                            objUserHead.msg = "";
                            objUserHeadList.Add(objUserHead);
                        }
                    }

                    //ActivityLog.ActivityLogRequest("Saved user details", item.ID);
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

                objError.WriteLog(0, "BusinessUnit_Data", "inactivate_business_unit", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "BusinessUnit_Data", "inactivate_business_unit", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "BusinessUnit_Data", "inactivate_business_unit", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "BusinessUnit_Data", "inactivate_business_unit", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }
        }

        public static List<ReturnBusinessUnitModelHead> get_business_unit_all(GetBuAllModel Buall)
        {
            List<ReturnBusinessUnitModelHead> objBUHeadList = new List<ReturnBusinessUnitModelHead>();
            ReturnBusinessUnitModelHead objBUHead = new ReturnBusinessUnitModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(Buall) == false)
            {
                objBUHead.resp = false;
                objBUHead.IsAuthenticated = false;
                objBUHeadList.Add(objBUHead);
                return objBUHeadList;
            }


            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    //ReturnBusinessUnitModelHead objBUHead = new ReturnBusinessUnitModelHead();
                    lconn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_business_unit_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAGE_NO", Buall.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", Buall.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_ID", Buall.BU_ID);
                        cmd.Parameters["@BU_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_CompanyName", Buall.BU_CompanyName);
                        cmd.Parameters["@BU_CompanyName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_Abbre", Buall.BU_Abbre);
                        cmd.Parameters["@BU_Abbre"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@COU_Name", Buall.COU_Name);
                        cmd.Parameters["@COU_Name"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_Status", Buall.BU_Status);
                        cmd.Parameters["@BU_Status"].Direction = ParameterDirection.Input;

                        //SqlDataReader rdr = cmd.ExecuteReader();


                        string RC;
                        using (SqlCommand cmdrc = new SqlCommand())
                        {
                            cmdrc.Connection = lconn;

                            cmdrc.CommandText = "sp_get_business_unit_count";
                            cmdrc.CommandType = CommandType.StoredProcedure;
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

                                //if (rdr.HasRows)
                                //{
                                //    while (rdr.Read())
                                //    {
                                ReturnBusinessUnitModel objBUData = new ReturnBusinessUnitModel();

                                objBUHead.resp = true;
                                objBUHead.msg = "Business Unit";

                                objBUData.BU_ID = rdr["BU_ID"].ToString();
                                objBUData.BU_CompanyName = rdr["BU_CompanyName"].ToString();
                                objBUData.BU_Abbre = rdr["BU_Abbre"].ToString();
                                objBUData.BU_Adrs_BlockBuildingNo = rdr["BU_Adrs_BlockBuildingNo"].ToString();
                                objBUData.BU_Adrs_BuildingName = rdr["BU_Adrs_BuildingName"].ToString();
                                objBUData.BU_Adrs_UnitNumber = rdr["BU_Adrs_UnitNumber"].ToString();
                                objBUData.BU_Adrs_StreetName = rdr["BU_Adrs_StreetName"].ToString();
                                objBUData.BU_Adrs_City = rdr["BU_Adrs_City"].ToString();
                                objBUData.BU_CurrencyCode = rdr["BU_CurrencyCode"].ToString();
                                objBUData.CUR_Name = rdr["CUR_Name"].ToString();
                                objBUData.BU_CountryCode = rdr["BU_CountryCode"].ToString();
                                objBUData.COU_Name = rdr["COU_Name"].ToString();
                                objBUData.BU_Status = Convert.ToBoolean(rdr["BU_Status"]);

                                objBUData.BU_Adrs_CountryCode = rdr["BU_Adrs_CountryCode"].ToString();
                                objBUData.BU_Adrs_PostalCode = rdr["BU_Adrs_PostalCode"].ToString();

                                bool BU_ChangeProcessDate = false;
                                Boolean.TryParse(rdr["BU_ChangeProcessDate"].ToString(), out BU_ChangeProcessDate);
                                objBUData.BU_ChangeProcessDate = BU_ChangeProcessDate;

                                bool BU_SMS_Enabled = false;
                                Boolean.TryParse(rdr["BU_SMS_Enabled"].ToString(), out BU_SMS_Enabled);
                                objBUData.BU_SMS_Enabled = BU_SMS_Enabled;

                                objBUData.BU_SMS_GW_HOST_IP = rdr["BU_SMS_GW_HOST_IP"].ToString();

                                int BU_SMS_GW_HOST_PORT = 0;
                                int.TryParse(rdr["BU_SMS_GW_HOST_PORT"].ToString(), out BU_SMS_GW_HOST_PORT);
                                objBUData.BU_SMS_GW_HOST_PORT = BU_SMS_GW_HOST_PORT;

                                objBUData.BU_SMS_GW_JID = rdr["BU_SMS_GW_JID"].ToString();
                                string BU_SMS_GW_PWD = utility_handler.Utility.Misc.deCrypt(rdr["BU_SMS_GW_PWD"].ToString());
                                objBUData.BU_SMS_GW_PWD = BU_SMS_GW_PWD;

                                objBUData.BU_SMS_GW_IIM_SVR = rdr["BU_SMS_GW_IIM_SVR"].ToString();

                                int BU_SMS_GW_SMS_LIMIT = 0;
                                int.TryParse(rdr["BU_SMS_GW_SMS_LIMIT"].ToString(), out BU_SMS_GW_SMS_LIMIT);
                                objBUData.BU_SMS_GW_SMS_LIMIT = BU_SMS_GW_SMS_LIMIT;

                                int BU_SMS_GW_QUE_CAP = 0;
                                int.TryParse(rdr["BU_SMS_GW_QUE_CAP"].ToString(), out BU_SMS_GW_QUE_CAP);
                                objBUData.BU_SMS_GW_QUE_CAP = BU_SMS_GW_QUE_CAP;

                                int BU_SMS_GW_MAX_CHAR = 0;
                                int.TryParse(rdr["BU_SMS_GW_MAX_CHAR"].ToString(), out BU_SMS_GW_MAX_CHAR);
                                objBUData.BU_SMS_GW_MAX_CHAR = BU_SMS_GW_MAX_CHAR;

                                objBUData.BU_SMS_GW_SENDER_ID = rdr["BU_SMS_GW_SENDER_ID"].ToString();

                                bool BU_EMAIL_Enabled = false;
                                bool.TryParse(rdr["BU_EMAIL_Enabled"].ToString(), out BU_EMAIL_Enabled);
                                objBUData.BU_EMAIL_Enabled = BU_EMAIL_Enabled;

                                objBUData.BU_EMAIL_SMTP_HOST_IP = rdr["BU_EMAIL_SMTP_HOST_IP"].ToString();

                                int BU_EMAIL_SMTP_HOST_PORT = 0;
                                int.TryParse(rdr["BU_EMAIL_SMTP_HOST_PORT"].ToString(), out BU_EMAIL_SMTP_HOST_PORT);
                                objBUData.BU_EMAIL_SMTP_HOST_PORT = BU_EMAIL_SMTP_HOST_PORT;

                                objBUData.BU_EMAIL_SMTP_UID = rdr["BU_EMAIL_SMTP_UID"].ToString();
                                string BU_EMAIL_SMTP_PWD = utility_handler.Utility.Misc.deCrypt(rdr["BU_EMAIL_SMTP_PWD"].ToString());
                                objBUData.BU_EMAIL_SMTP_PWD = BU_EMAIL_SMTP_PWD;

                                bool BU_EMAIL_SMTP_AUTH = false;
                                bool.TryParse(rdr["BU_EMAIL_SMTP_AUTH"].ToString(), out BU_EMAIL_SMTP_AUTH);
                                objBUData.BU_EMAIL_SMTP_AUTH = BU_EMAIL_SMTP_AUTH;

                                bool BU_EMAIL_SMTP_TLS_ENABLE = false;
                                bool.TryParse(rdr["BU_EMAIL_SMTP_TLS_ENABLE"].ToString(), out BU_EMAIL_Enabled);
                                objBUData.BU_EMAIL_SMTP_TLS_ENABLE = BU_EMAIL_SMTP_TLS_ENABLE;

                                bool BU_EMAIL_SMTP_SSL_ENABLE = false;
                                bool.TryParse(rdr["BU_EMAIL_SMTP_SSL_ENABLE"].ToString(), out BU_EMAIL_SMTP_SSL_ENABLE);
                                objBUData.BU_EMAIL_SMTP_SSL_ENABLE = BU_EMAIL_SMTP_SSL_ENABLE;

                                objBUData.BU_EMAIL_SMTP_SSL_PROTOCOLS = rdr["BU_EMAIL_SMTP_SSL_PROTOCOLS"].ToString();
                                objBUData.BU_EMAIL_SMTP_SSL_SOCKET_FACTORY = rdr["BU_EMAIL_SMTP_SSL_SOCKET_FACTORY"].ToString();
                                objBUData.BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_CLASS = rdr["BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_CLASS"].ToString();

                                int BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_PORT = 0;
                                int.TryParse(rdr["BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_PORT"].ToString(), out BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_PORT);
                                objBUData.BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_PORT = BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_PORT;

                                objBUData.BU_CreatedBy = rdr["BU_CreatedBy"].ToString();
                                objBUData.BU_CreatedDateTime = rdr["BU_CreatedDateTime"].ToString();
                                objBUData.BU_ModifiedBy = rdr["BU_ModifiedBy"].ToString();
                                objBUData.BU_ModifiedDateTime = rdr["BU_ModifiedDateTime"].ToString();

                                objBUData.RC = RC;

                                if (objBUHead.BusinessUnit == null)
                                {
                                    objBUHead.BusinessUnit = new List<ReturnBusinessUnitModel>();
                                }

                                objBUHead.BusinessUnit.Add(objBUData);

                                //objBUHeadList.Add(objBUHead);

                            }
                            objBUHeadList.Add(objBUHead);
                        }
                        else
                        {
                            objBUHead.resp = true;
                            objBUHead.msg = "";
                            objBUHeadList.Add(objBUHead);
                        }


                    }
                }
                return objBUHeadList;

            }
            catch (Exception ex)
            {
                objBUHead = new ReturnBusinessUnitModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objBUHeadList.Add(objBUHead);

                objError.WriteLog(0, "BusinessUnit_Data", "get_business_unit_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "BusinessUnit_Data", "get_business_unit_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "BusinessUnit_Data", "get_business_unit_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "BusinessUnit_Data", "get_business_unit_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objBUHeadList;

        }

        public static List<ReturnCountryModelHead> get_country_with_select()
        {
            List<ReturnCountryModelHead> objCountryHeadList = new List<ReturnCountryModelHead>();
            List<ReturnCountryModel> objCountryList = new List<ReturnCountryModel>();
            ReturnCountryModelHead objCountryHead = new ReturnCountryModelHead();

            //if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            //{
            //    objCountryHead.resp = false;
            //    objCountryHead.IsAuthenticated = false;
            //    objCountryHeadList.Add(objCountryHead);
            //    return objCountryHeadList;
            //}


            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_country_with_select";
                        cmd.CommandType = CommandType.StoredProcedure;


                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {


                                //SqlDataReader rdr = cmd.ExecuteReader();

                                //if (rdr.HasRows)
                                //{
                                //    while (rdr.Read())
                                //    {
                                ReturnCountryModel objCountryData = new ReturnCountryModel();

                                objCountryHead.resp = true;
                                objCountryHead.msg = "Country";

                                objCountryData.COU_Code = rdr["COU_Code"].ToString().Trim();
                                objCountryData.COU_Name = rdr["COU_Name"].ToString();


                                objCountryList.Add(objCountryData);

                                if (objCountryHead.Country == null)
                                {
                                    objCountryHead.Country = new List<ReturnCountryModel>();
                                }

                                objCountryHead.Country.Add(objCountryData);
                            }
                            objCountryHeadList.Add(objCountryHead);
                        }
                        else
                        {
                            objCountryHead.resp = true;
                            objCountryHead.msg = "";
                            objCountryHeadList.Add(objCountryHead);


                        }


                    }
                }
                return objCountryHeadList;

            }
            catch (Exception ex)
            {

                objCountryHead = new ReturnCountryModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCountryHeadList.Add(objCountryHead);

                objError.WriteLog(0, "BusinessUnit_Data", "GetUser", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "BusinessUnit_Data", "GetUser", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "BusinessUnit_Data", "GetUser", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "BusinessUnit_Data", "GetUser", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCountryHeadList;

        }

        public static List<ReturnCurrencyModelHead> get_currency_with_select()
        {
            List<ReturnCurrencyModelHead> objCurrencyHeadList = new List<ReturnCurrencyModelHead>();
            List<ReturnCurrencyModel> objCurrencyList = new List<ReturnCurrencyModel>();


            //if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            //{
            //    objHead.resp = false;
            //    objHead.IsAuthenticated = false;
            //    objHeadList.Add(objHead);
            //    return objHeadList;
            //}

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    ReturnCurrencyModelHead objCurrencyHead = new ReturnCurrencyModelHead();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_currency_with_select";
                        cmd.CommandType = CommandType.StoredProcedure;


                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {

                                //SqlDataReader rdr = cmd.ExecuteReader();

                                //if (rdr.HasRows)
                                //{
                                //    while (rdr.Read())
                                //    {
                                ReturnCurrencyModel objCurrencyData = new ReturnCurrencyModel();

                                objCurrencyHead.resp = true;
                                objCurrencyHead.msg = "Currency";

                                objCurrencyData.CUR_Code = rdr["CUR_Code"].ToString();
                                objCurrencyData.CUR_Name = rdr["CUR_Name"].ToString();


                                objCurrencyList.Add(objCurrencyData);

                                if (objCurrencyHead.Currency == null)
                                {
                                    objCurrencyHead.Currency = new List<ReturnCurrencyModel>();
                                }

                                objCurrencyHead.Currency.Add(objCurrencyData);

                            }

                            objCurrencyHeadList.Add(objCurrencyHead);
                        }
                        else
                        {
                            objCurrencyHead.resp = true;
                            objCurrencyHead.msg = "";
                            objCurrencyHeadList.Add(objCurrencyHead);
                        }
                    }

                    return objCurrencyHeadList;
                }
            }
            catch (Exception ex)
            {

                ReturnCurrencyModelHead objCurrencyHead = new ReturnCurrencyModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCurrencyHeadList.Add(objCurrencyHead);

                objError.WriteLog(0, "BusinessUnit_Data", "get_currency_with_select", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "BusinessUnit_Data", "get_currency_with_select", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "BusinessUnit_Data", "get_currency_with_select", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "BusinessUnit_Data", "get_currency_with_select", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCurrencyHeadList;

        }

        public static List<ReturnBusinessUnitModelHead> get_business_unit_single(GetBusingleModel Busingle)
        {
            List<ReturnBusinessUnitModelHead> objBUHeadList = new List<ReturnBusinessUnitModelHead>();
            ReturnBusinessUnitModelHead objBUHead = new ReturnBusinessUnitModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(Busingle) == false)
            {
                objBUHead.resp = false;
                objBUHead.IsAuthenticated = false;
                objBUHeadList.Add(objBUHead);
                return objBUHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_business_unit_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BU_ID", Busingle.BU_ID);
                        cmd.Parameters["@BU_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {

                                //SqlDataReader rdr = cmd.ExecuteReader();

                                //if (rdr.HasRows)
                                //{
                                //    while (rdr.Read())
                                //    {
                                ReturnBusinessUnitModel objBUData = new ReturnBusinessUnitModel();
                                //        try
                                //        {

                                objBUHead.resp = true;
                                objBUHead.msg = "Business Unit";

                                objBUData.BU_ID = rdr["BU_ID"].ToString();
                                objBUData.BU_CompanyName = rdr["BU_CompanyName"].ToString();
                                objBUData.BU_Abbre = rdr["BU_Abbre"].ToString();
                                objBUData.BU_Adrs_BlockBuildingNo = rdr["BU_Adrs_BlockBuildingNo"].ToString();
                                objBUData.BU_Adrs_BuildingName = rdr["BU_Adrs_BuildingName"].ToString();
                                objBUData.BU_Adrs_UnitNumber = rdr["BU_Adrs_UnitNumber"].ToString();
                                objBUData.BU_Adrs_StreetName = rdr["BU_Adrs_StreetName"].ToString();
                                objBUData.BU_Adrs_City = rdr["BU_Adrs_City"].ToString();
                                objBUData.COU_Name = rdr["COU_Name"].ToString();
                                objBUData.BU_Adrs_PostalCode = rdr["BU_Adrs_PostalCode"].ToString();
                                objBUData.CUR_Name = rdr["CUR_Name"].ToString();
                                objBUData.BU_ChangeProcessDate = Convert.ToBoolean(rdr["BU_ChangeProcessDate"]);
                                objBUData.BU_Status = Convert.ToBoolean(rdr["BU_Status"]);
                                objBUData.BU_SMS_Enabled = Convert.ToBoolean(rdr["BU_SMS_Enabled"]);

                                bool BU_SMS_BY_LINKURL = false;
                                bool.TryParse(rdr["BU_SMS_BY_LINKURL"].ToString(), out BU_SMS_BY_LINKURL);
                                objBUData.BU_SMS_BY_LINKURL = BU_SMS_BY_LINKURL;

                                objBUData.BU_SMS_GW_HOST_IP = rdr["BU_SMS_GW_HOST_IP"].ToString();
                                objBUData.BU_SMS_GW_HOST_PORT = Convert.ToInt32(rdr["BU_SMS_GW_HOST_PORT"]);
                                objBUData.BU_SMS_GW_JID = rdr["BU_SMS_GW_JID"].ToString();

                                string BU_SMS_GW_PWD = utility_handler.Utility.Misc.deCrypt(rdr["BU_SMS_GW_PWD"].ToString());
                                objBUData.BU_SMS_GW_PWD = BU_SMS_GW_PWD;

                                objBUData.BU_SMS_GW_IIM_SVR = rdr["BU_SMS_GW_IIM_SVR"].ToString();
                                objBUData.BU_SMS_GW_SMS_LIMIT = Convert.ToInt32(rdr["BU_SMS_GW_SMS_LIMIT"]);
                                objBUData.BU_SMS_GW_QUE_CAP = Convert.ToInt32(rdr["BU_SMS_GW_QUE_CAP"]);
                                objBUData.BU_SMS_GW_MAX_CHAR = Convert.ToInt32(rdr["BU_SMS_GW_MAX_CHAR"]);
                                objBUData.BU_SMS_GW_SENDER_ID = rdr["BU_SMS_GW_SENDER_ID"].ToString();
                                objBUData.BU_EMAIL_Enabled = Convert.ToBoolean(rdr["BU_EMAIL_Enabled"]);
                                objBUData.BU_EMAIL_SMTP_HOST_IP = rdr["BU_EMAIL_SMTP_HOST_IP"].ToString();
                                objBUData.BU_EMAIL_SMTP_HOST_PORT = Convert.ToInt32(rdr["BU_EMAIL_SMTP_HOST_PORT"]);
                                objBUData.BU_EMAIL_SMTP_UID = rdr["BU_EMAIL_SMTP_UID"].ToString();

                                string BU_EMAIL_SMTP_PWD = utility_handler.Utility.Misc.deCrypt(rdr["BU_EMAIL_SMTP_PWD"].ToString());
                                objBUData.BU_EMAIL_SMTP_PWD = BU_EMAIL_SMTP_PWD;

                                objBUData.BU_EMAIL_SMTP_AUTH = Convert.ToBoolean(rdr["BU_EMAIL_SMTP_AUTH"]);
                                objBUData.BU_EMAIL_SMTP_TLS_ENABLE = Convert.ToBoolean(rdr["BU_EMAIL_SMTP_TLS_ENABLE"]);
                                objBUData.BU_EMAIL_SMTP_SSL_ENABLE = Convert.ToBoolean(rdr["BU_EMAIL_SMTP_SSL_ENABLE"]);
                                objBUData.BU_EMAIL_SMTP_SSL_PROTOCOLS = rdr["BU_EMAIL_SMTP_SSL_PROTOCOLS"].ToString();
                                objBUData.BU_EMAIL_SMTP_SSL_SOCKET_FACTORY = rdr["BU_EMAIL_SMTP_SSL_SOCKET_FACTORY"].ToString();
                                objBUData.BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_CLASS = rdr["BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_CLASS"].ToString();
                                objBUData.BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_PORT = Convert.ToInt32(rdr["BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_PORT"]);
                                objBUData.RC = "1";

                                if (objBUHead.BusinessUnit == null)
                                {
                                    objBUHead.BusinessUnit = new List<ReturnBusinessUnitModel>();
                                }

                                objBUHead.BusinessUnit.Add(objBUData);
                            }
                            objBUHeadList.Add(objBUHead);


                        }
                        else
                        {
                            objBUHead.resp = true;
                            objBUHead.msg = "";
                            objBUHeadList.Add(objBUHead);
                        }
                        return objBUHeadList;

                    }
                }
            }
            catch (Exception ex)
            {

                objBUHead = new ReturnBusinessUnitModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objBUHeadList.Add(objBUHead);

                objError.WriteLog(0, "BusinessUnit_Data", "get_business_unit_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "BusinessUnit_Data", "get_business_unit_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "BusinessUnit_Data", "get_business_unit_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "BusinessUnit_Data", "get_business_unit_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objBUHeadList;

        }



    }
}