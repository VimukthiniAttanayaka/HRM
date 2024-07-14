using HRM_DAL.Models;
using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_DAL.Data
{
    public class DeliveryCourierCompany_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnResponse> add_new_delivery_courier_company(DeliveryCourierCompanyModel item)//ok
        {
            List<ReturnResponse> objDCCHeadList = new List<ReturnResponse>();
            ReturnResponse objDCCHead = new ReturnResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objDCCHead.resp = false;
                objDCCHead.IsAuthenticated = false;
                objDCCHeadList.Add(objDCCHead);
                return objDCCHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_insert_delivery_courier_company";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DCC_ID", item.DCC_ID);
                        cmd.Parameters["@DCC_ID"].Direction = ParameterDirection.Input;


                        cmd.Parameters.AddWithValue("@DCC_Name", item.DCC_Name);
                        cmd.Parameters["@DCC_Name"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DCC_Is_Local", item.DCC_Is_Local);
                        cmd.Parameters["@DCC_Is_Local"].Direction = ParameterDirection.Input;


                        cmd.Parameters.AddWithValue("@DCC_Is_Overseas", item.DCC_Is_Overseas);
                        cmd.Parameters["@DCC_Is_Overseas"].Direction = ParameterDirection.Input;

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
                                objDCCHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objDCCHeadList.Add(objDCCHead);

                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                objDCCHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objDCCHeadList.Add(objDCCHead);

                objError.WriteLog(0, "DeliveryCourierCompany_Data", "add_new_delivery_courier_company", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DeliveryCourierCompany_Data", "add_new_delivery_courier_company", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DeliveryCourierCompany_Data", "add_new_delivery_courier_company", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DeliveryCourierCompany_Data", "add_new_delivery_courier_company", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objDCCHeadList;
        }

        public static List<ReturnResponse> modify_delivery_courier_company(DeliveryCourierCompanyModel item)//ok
        {
            List<ReturnResponse> objDCCHeadList = new List<ReturnResponse>();
            ReturnResponse objDCCHead = new ReturnResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objDCCHead.resp = false;
                objDCCHead.IsAuthenticated = false;
                objDCCHeadList.Add(objDCCHead);
                return objDCCHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_modify_delivery_courier_company";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DCC_ID", item.DCC_ID);
                        cmd.Parameters["@DCC_ID"].Direction = ParameterDirection.Input;


                        cmd.Parameters.AddWithValue("@DCC_Name", item.DCC_Name);
                        cmd.Parameters["@DCC_Name"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DCC_Is_Local", item.DCC_Is_Local);
                        cmd.Parameters["@DCC_Is_Local"].Direction = ParameterDirection.Input;


                        cmd.Parameters.AddWithValue("@DCC_Is_Overseas", item.DCC_Is_Overseas);
                        cmd.Parameters["@DCC_Is_Overseas"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USER_ID", item.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DCC_Status", item.DCC_Status);
                        cmd.Parameters["@DCC_Status"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                objDCCHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objDCCHeadList.Add(objDCCHead);

                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                objDCCHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objDCCHeadList.Add(objDCCHead);

                objError.WriteLog(0, "DeliveryCourierCompany_Data", "modify_delivery_courier_company", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DeliveryCourierCompany_Data", "modify_delivery_courier_company", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DeliveryCourierCompany_Data", "modify_delivery_courier_company", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DeliveryCourierCompany_Data", "modify_delivery_courier_company", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objDCCHeadList;
        }

        public static List<ReturnResponse> inactivate_delivery_courier_company(InactiveDCCompanyModel item)//ok
        {
            List<ReturnResponse> objDCCHeadList = new List<ReturnResponse>();
            ReturnResponse objDCCHead = new ReturnResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objDCCHead.resp = false;
                objDCCHead.IsAuthenticated = false;
                objDCCHeadList.Add(objDCCHead);
                return objDCCHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_del_delivery_courier_company";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DCC_ID", item.DCC_ID);
                        cmd.Parameters["@DCC_ID"].Direction = ParameterDirection.Input;

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
                                objDCCHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objDCCHeadList.Add(objDCCHead);

                            }
                        }

                        //ActivityLog.ActivityLogRequest("Saved user details", item.ID);
                        return objDCCHeadList;


                        //}

                    }
                }

                return objDCCHeadList;
            }
            catch (Exception ex)
            {
                objDCCHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objDCCHeadList.Add(objDCCHead);

                objError.WriteLog(0, "DeliveryCourierCompany_Data", "inactivate_delivery_courier_company", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DeliveryCourierCompany_Data", "inactivate_delivery_courier_company", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DeliveryCourierCompany_Data", "inactivate_delivery_courier_company", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DeliveryCourierCompany_Data", "inactivate_delivery_courier_company", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objDCCHeadList;
            }




        }

        public static List<ReturDCCompanyModelHead> get_delivery_courier_company_all(GetDCCompanyAllModel Dccall)//ok
        {
            List<ReturDCCompanyModelHead> objDCCHeadList = new List<ReturDCCompanyModelHead>();
            ReturDCCompanyModelHead objDCCHead = new ReturDCCompanyModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(Dccall) == false)
            {
                objDCCHead.resp = false;
                objDCCHead.IsAuthenticated = false;
                objDCCHeadList.Add(objDCCHead);
                return objDCCHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        if (lconn == null || lconn.State == ConnectionState.Closed)
                        {
                            lconn.Open();
                        }

                        cmd.CommandText = "sp_get_delivery_courier_company_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAGE_NO", Dccall.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", Dccall.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DCC_ID", Dccall.DCC_ID);
                        cmd.Parameters["@DCC_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DCC_Name", Dccall.DCC_Name);
                        cmd.Parameters["@DCC_Name"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DCC_Is_Local", Dccall.DCC_Is_Local);
                        cmd.Parameters["@DCC_Is_Local"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DCC_Is_Overseas", Dccall.DCC_Is_Overseas);
                        cmd.Parameters["@DCC_Is_Overseas"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DCC_Status", Dccall.DCC_Status);
                        cmd.Parameters["@DCC_Status"].Direction = ParameterDirection.Input;

                        string RC;
                        using (SqlCommand cmdrc = new SqlCommand())
                        {
                            cmdrc.Connection = lconn;

                            cmdrc.CommandText = "sp_get_delivery_courier_company_count";
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
                                ReturnDCCompanyModel objDCCData = new ReturnDCCompanyModel();

                                objDCCHead.resp = true;
                                objDCCHead.msg = "Delivery Courier Company";

                                objDCCData.DCC_ID = rdr["DCC_ID"].ToString();
                                objDCCData.DCC_Name = rdr["DCC_Name"].ToString();
                                objDCCData.DCC_Is_Local = rdr["DCC_Is_Local"].ToString();
                                objDCCData.DCC_Is_Overseas = rdr["DCC_Is_Overseas"].ToString();
                                objDCCData.DCC_Status = rdr["DCC_Status"].ToString();

                                objDCCData.DCC_CreatedBy = rdr["DCC_CreatedBy"].ToString();
                                objDCCData.DCC_CreatedDateTime = rdr["DCC_CreatedDateTime"].ToString();
                                objDCCData.DCC_ModifiedBy = rdr["DCC_ModifiedBy"].ToString();
                                objDCCData.DCC_ModifiedDateTime = rdr["DCC_ModifiedDateTime"].ToString();
                                objDCCData.RC = RC;

                                if (objDCCHead.DCCompany == null)
                                {
                                    objDCCHead.DCCompany = new List<ReturnDCCompanyModel>();
                                }

                                objDCCHead.DCCompany.Add(objDCCData);

                            }
                            objDCCHeadList.Add(objDCCHead);
                        }
                        else
                        {
                            objDCCHead.resp = true;
                            objDCCHead.msg = "";
                            objDCCHeadList.Add(objDCCHead);


                        }


                    }
                    if (lconn.State == ConnectionState.Open)
                    {
                        lconn.Close();
                    }
                }
                return objDCCHeadList;

            }
            catch (Exception ex)
            {
                objDCCHead = new ReturDCCompanyModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objDCCHeadList.Add(objDCCHead);

                objError.WriteLog(0, "DeliveryCourierCompany_Data", "get_delivery_courier_company_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DeliveryCourierCompany_Data", "get_delivery_courier_company_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DeliveryCourierCompany_Data", "get_delivery_courier_company_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DeliveryCourierCompany_Data", "get_delivery_courier_company_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objDCCHeadList;

        }

        public static List<ReturDCCompanyModelHead> get_delivery_courier_company_single(GetDCCompanyModel DCCsingle)
        {
            List<ReturDCCompanyModelHead> objDCCHeadList = new List<ReturDCCompanyModelHead>();
            ReturDCCompanyModelHead objDCCHead = new ReturDCCompanyModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(DCCsingle) == false)
            {
                objDCCHead.resp = false;
                objDCCHead.IsAuthenticated = false;
                objDCCHeadList.Add(objDCCHead);
                return objDCCHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_delivery_courier_company_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DCC_ID", DCCsingle.DCC_ID);
                        cmd.Parameters["@DCC_ID"].Direction = ParameterDirection.Input;



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
                                ReturnDCCompanyModel objDCCData = new ReturnDCCompanyModel();

                                objDCCHead.resp = true;
                                objDCCHead.msg = "Delivery Courier Company";

                                objDCCData.DCC_ID = rdr["DCC_ID"].ToString();
                                objDCCData.DCC_Name = rdr["DCC_Name"].ToString();
                                objDCCData.DCC_Is_Local = rdr["DCC_Is_Local"].ToString();
                                objDCCData.DCC_Is_Overseas = rdr["DCC_Is_Overseas"].ToString();
                                objDCCData.DCC_Status = rdr["DCC_Status"].ToString();
                                objDCCData.RC = "1";

                                if (objDCCHead.DCCompany == null)
                                {
                                    objDCCHead.DCCompany = new List<ReturnDCCompanyModel>();
                                }

                                objDCCHead.DCCompany.Add(objDCCData);
                                objDCCHeadList.Add(objDCCHead);
                            }

                        }
                        else
                        {
                            objDCCHead.resp = true;
                            objDCCHead.msg = "";
                            objDCCHeadList.Add(objDCCHead);


                        }


                    }
                    return objDCCHeadList;
                }
            }
            catch (Exception ex)
            {

                objDCCHead = new ReturDCCompanyModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objDCCHeadList.Add(objDCCHead);

                objError.WriteLog(0, "DeliveryCourierCompany_Data", "get_delivery_courier_company_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DeliveryCourierCompany_Data", "get_delivery_courier_company_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DeliveryCourierCompany_Data", "get_delivery_courier_company_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DeliveryCourierCompany_Data", "get_delivery_courier_company_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objDCCHeadList;

        }



    }








}








