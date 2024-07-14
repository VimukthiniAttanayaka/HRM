using HRM_DAL.Models;
using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_DAL.Data
{
    public class MailType_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnResponse> add_new_mail_type(MailTypeModel item)//ok
        {
            List<ReturnResponse> objMTHeadList = new List<ReturnResponse>();
            ReturnResponse objMTHead = new ReturnResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objMTHead.resp = false;
                objMTHead.IsAuthenticated = false;
                objMTHeadList.Add(objMTHead);
                return objMTHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_insert_mail_type";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MT_ID", item.MT_ID);
                        cmd.Parameters["@MT_ID"].Direction = ParameterDirection.Input;


                        cmd.Parameters.AddWithValue("@MT_Name", item.MT_Name);
                        cmd.Parameters["@MT_Name"].Direction = ParameterDirection.Input;

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
                                objMTHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objMTHeadList.Add(objMTHead);

                                //objUserSList.Add(objUserHead.objReturnUserModelList);


                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objMTHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objMTHeadList.Add(objMTHead);

                objError.WriteLog(0, "MailType_Data", "add_new_mail_type", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "MailType_Data", "add_new_mail_type", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "MailType_Data", "add_new_mail_type", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "MailType_Data", "add_new_mail_type", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objMTHeadList;
        }

        public static List<ReturnResponse> modify_mail_type(MailTypeModel item)//ok
        {
            List<ReturnResponse> objMTHeadList = new List<ReturnResponse>();
            ReturnResponse objMTHead = new ReturnResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objMTHead.resp = false;
                objMTHead.IsAuthenticated = false;
                objMTHeadList.Add(objMTHead);
                return objMTHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_modify_mail_type";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MT_ID", item.MT_ID);
                        cmd.Parameters["@MT_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MT_Name", item.MT_Name);
                        cmd.Parameters["@MT_Name"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USER_ID", item.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MT_Status", item.MT_Status);
                        cmd.Parameters["@MT_Status"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                objMTHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objMTHeadList.Add(objMTHead);

                                //objUserSList.Add(objUserHead.objReturnUserModelList);


                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objMTHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objMTHeadList.Add(objMTHead);

                objError.WriteLog(0, "MailType_Data", "modify_mail_type", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "MailType_Data", "modify_mail_type", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "MailType_Data", "modify_mail_type", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "MailType_Data", "modify_mail_type", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objMTHeadList;
        }

        public static List<ReturnResponse> inactivate_mail_type(InactiveMailTypeModel item)//ok
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


                        cmd.CommandText = "sp_del_mail_type";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MT_ID", item.MT_ID);
                        cmd.Parameters["@MT_ID"].Direction = ParameterDirection.Input;

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
                                objUserHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objUserHeadList.Add(objUserHead);
                            }
                        }
                    }
                    return objUserHeadList;
                }

                return objUserHeadList;
            }
            catch (Exception ex)
            {
                objUserHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "MailType_Data", "inactivate_mail_type", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "MailType_Data", "inactivate_mail_type", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "MailType_Data", "inactivate_mail_type", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "MailType_Data", "inactivate_mail_type", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }



        }

        public static List<ReturMailTypeModelHead> get_mail_type_single(GetMtsingleModel MTingle)
        {
            List<ReturMailTypeModelHead> objMTHeadList = new List<ReturMailTypeModelHead>();
            ReturnMailTypeModel objMTData = new ReturnMailTypeModel();
            ReturMailTypeModelHead objMTHead = new ReturMailTypeModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(MTingle) == false)
            {
                objMTHead.resp = false;
                objMTHead.IsAuthenticated = false;
                objMTHeadList.Add(objMTHead);
                return objMTHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_mail_type_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MT_ID", MTingle.MT_ID);
                        cmd.Parameters["@MT_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                objMTData = new ReturnMailTypeModel();

                                objMTHead.resp = true;
                                objMTHead.msg = "Mail Type";

                                objMTData.MT_ID = rdr["MT_ID"].ToString();
                                objMTData.MT_Name = rdr["MT_Name"].ToString();
                                objMTData.MT_Status = rdr["MT_Status"].ToString();
                                objMTData.RC = "1";

                                if (objMTHead.MailType == null)
                                {
                                    objMTHead.MailType = new List<ReturnMailTypeModel>();
                                }

                                objMTHead.MailType.Add(objMTData);

                                objMTHeadList.Add(objMTHead);
                            }

                        }
                        else
                        {
                            objMTHead.resp = true;
                            objMTHead.msg = "";
                            objMTHeadList.Add(objMTHead);
                        }
                    }
                    return objMTHeadList;
                }
            }
            catch (Exception ex)
            {
                objMTHead = new ReturMailTypeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objMTHeadList.Add(objMTHead);

                objError.WriteLog(0, "MailType_Data", "get_mail_type_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "MailType_Data", "get_mail_type_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "MailType_Data", "get_mail_type_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "MailType_Data", "get_mail_type_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objMTHeadList;

        }

        public static List<ReturMailTypeModelHead> get_mail_type_all(GetMtAllModel MTall)
        {
            List<ReturMailTypeModelHead> objMTHeadList = new List<ReturMailTypeModelHead>();
            ReturnMailTypeModel objMTData = new ReturnMailTypeModel();
            ReturMailTypeModelHead objMTHead = new ReturMailTypeModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(MTall) == false)
            {
                objMTHead.resp = false;
                objMTHead.IsAuthenticated = false;
                objMTHeadList.Add(objMTHead);
                return objMTHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    lconn.Open();

                    objMTHead = new ReturMailTypeModelHead();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_mail_type_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAGE_NO", MTall.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", MTall.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MT_Name", MTall.MT_Name);
                        cmd.Parameters["@MT_Name"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MT_Status", MTall.MT_Status);
                        cmd.Parameters["@MT_Status"].Direction = ParameterDirection.Input;

                        string RC;
                        using (SqlCommand cmdrc = new SqlCommand())
                        {
                            cmdrc.Connection = lconn;

                            cmdrc.CommandText = "sp_get_mail_type_count";
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
                                objMTData = new ReturnMailTypeModel();


                                objMTHead.resp = true;
                                objMTHead.msg = "Mail Type";

                                objMTData.MT_ID = rdr["MT_ID"].ToString();
                                objMTData.MT_Name = rdr["MT_Name"].ToString();
                                objMTData.MT_Status = rdr["MT_Status"].ToString();
                                objMTData.MT_CreatedBy = rdr["MT_CreatedBy"].ToString();
                                objMTData.MT_CreatedDateTime = rdr["MT_CreatedDateTime"].ToString();
                                objMTData.MT_ModifiedBy = rdr["MT_ModifiedBy"].ToString();
                                objMTData.MT_ModifiedDateTime = rdr["MT_ModifiedDateTime"].ToString();
                                objMTData.RC = RC;

                                if (objMTHead.MailType == null)
                                {
                                    objMTHead.MailType = new List<ReturnMailTypeModel>();
                                }

                                objMTHead.MailType.Add(objMTData);

                                //objMTHeadList.Add(objMTHead);

                            }
                            objMTHeadList.Add(objMTHead);

                        }
                        else
                        {
                            objMTHead.resp = true;
                            objMTHead.msg = "";
                            objMTHeadList.Add(objMTHead);
                        }
                    }
                    return objMTHeadList;
                }
            }
            catch (Exception ex)
            {
                objMTHead = new ReturMailTypeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objMTHeadList.Add(objMTHead);

                objError.WriteLog(0, "MailType_Data", "get_mail_type_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "MailType_Data", "get_mail_type_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "MailType_Data", "get_mail_type_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "MailType_Data", "get_mail_type_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objMTHeadList;

        }
    }
}








