using HRM_DAL.Models;
using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_DAL.Data
{
    public class container_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnResponse> add_new_container(ContainerModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();
            ReturnResponse objHead = new ReturnResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objHead.resp = false;
                objHead.IsAuthenticated = false;
                objHeadList.Add(objHead);
                return objHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_insert_container";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CN_ID", item.CN_ID);
                        cmd.Parameters["@CN_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CN_CountryCode", item.CN_CountryCode);
                        cmd.Parameters["@CN_CountryCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CN_CustomerID", item.CN_CustomerID);
                        cmd.Parameters["@CN_CustomerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CN_DepartmentID", item.CN_DepartmentID);
                        cmd.Parameters["@CN_DepartmentID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CN_CostCentreNo", item.CN_CostCentreNo);
                        cmd.Parameters["@CN_CostCentreNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CN_DispatchTypeCode", item.CN_DispatchTypeCode);
                        cmd.Parameters["@CN_DispatchTypeCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CN_LabelFooterLine1", item.CN_LabelFooterLine1);
                        cmd.Parameters["@CN_LabelFooterLine1"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CN_LabelFooterLine2", item.CN_LabelFooterLine2);
                        cmd.Parameters["@CN_LabelFooterLine2"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USER_ID", item.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CN_LastPrintedLabelTypeID", item.CN_LastPrintedLabelTypeID);
                        cmd.Parameters["@CN_LastPrintedLabelTypeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CN_CostCentreName", item.CN_CostCentreName);
                        cmd.Parameters["@CN_CostCentreName"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                objHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objHeadList.Add(objHead);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "Container_Data", "add_new_container", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Container_Data", "add_new_container", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Container_Data", "add_new_container", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Container_Data", "add_new_container", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        public static List<ReturnResponse> modify_container(ContainerModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();
            ReturnResponse objHead = new ReturnResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objHead.resp = false;
                objHead.IsAuthenticated = false;
                objHeadList.Add(objHead);
                return objHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_modify_container";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CN_ID", item.CN_ID);
                        cmd.Parameters["@CN_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CN_CountryCode", item.CN_CountryCode);
                        cmd.Parameters["@CN_CountryCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CN_CustomerID", item.CN_CustomerID);
                        cmd.Parameters["@CN_CustomerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CN_DepartmentID", item.CN_DepartmentID);
                        cmd.Parameters["@CN_DepartmentID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CN_CostCentreNo", item.CN_CostCentreNo);
                        cmd.Parameters["@CN_CostCentreNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CN_DispatchTypeCode", item.CN_DispatchTypeCode);
                        cmd.Parameters["@CN_DispatchTypeCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CN_LabelFooterLine1", item.CN_LabelFooterLine1);
                        cmd.Parameters["@CN_LabelFooterLine1"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CN_LabelFooterLine2", item.CN_LabelFooterLine2);
                        cmd.Parameters["@CN_LabelFooterLine2"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USER_ID", item.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CN_LastPrintedLabelTypeID", item.CN_LastPrintedLabelTypeID);
                        cmd.Parameters["@CN_LastPrintedLabelTypeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CN_CostCentreName", item.CN_CostCentreName);
                        cmd.Parameters["@CN_CostCentreName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CN_Status", item.CN_Status);
                        cmd.Parameters["@CN_Status"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                objHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objHeadList.Add(objHead);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "Container_Data", "add_new_container", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Container_Data", "add_new_container", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Container_Data", "add_new_container", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Container_Data", "add_new_container", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        public static List<ReturnResponse> inactivate_container(InactiveContainerModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();
            ReturnResponse objHead = new ReturnResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objHead.resp = false;
                objHead.IsAuthenticated = false;
                objHeadList.Add(objHead);
                return objHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_del_container";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CN_ID", item.CN_ID);
                        cmd.Parameters["@CN_ID"].Direction = ParameterDirection.Input;

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

                                objHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objHeadList.Add(objHead);

                            }
                        }

                        //ActivityLog.ActivityLogRequest("Saved user details", item.ID);
                        return objHeadList;


                        //}

                    }

                    return objHeadList;
                }
            }
            catch (Exception ex)
            {
                objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "Container_Data", "inactivate_container", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Container_Data", "inactivate_container", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Container_Data", "inactivate_container", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Container_Data", "inactivate_container", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objHeadList;
            }
        }

        public static List<ReturnContainerModelHead> get_container_all(GetContainerAllModel item)//ok
        {
            List<ReturnContainerModelHead> objHeadList = new List<ReturnContainerModelHead>();
            ReturnContainerModelHead objHead = new ReturnContainerModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objHead.resp = false;
                objHead.IsAuthenticated = false;
                objHeadList.Add(objHead);
                return objHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_container_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAGE_NO", item.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", item.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CN_ID", item.CN_ID);
                        cmd.Parameters["@CN_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CN_CostCentreNo", item.CN_CostCentreNo);
                        cmd.Parameters["@CN_CostCentreNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_CompanyName", item.CUS_CompanyName);
                        cmd.Parameters["@CUS_CompanyName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CN_CountryCode", item.CN_CountryCode);
                        cmd.Parameters["@CN_CountryCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CN_CustomerID", item.CN_CustomerID);
                        cmd.Parameters["@CN_CustomerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPT_ID", item.DPT_ID);
                        cmd.Parameters["@DPT_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CN_Status", item.CN_Status);
                        cmd.Parameters["@CN_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CT_Name", item.CT_Name);
                        cmd.Parameters["@CT_Name"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CN_DispatchTypeCode", item.CN_DispatchTypeCode);
                        cmd.Parameters["@CN_DispatchTypeCode"].Direction = ParameterDirection.Input;

                        //SqlDataReader rdr = cmd.ExecuteReader();

                        string RC;
                        using (SqlCommand cmdrc = new SqlCommand())
                        {
                            cmdrc.Connection = lconn;

                            cmdrc.CommandText = "sp_get_container_count";
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
                                ReturnContainerModel objData = new ReturnContainerModel();

                                objHead.resp = true;
                                objHead.msg = "Container";

                                objData.CN_ID = rdr["CN_ID"].ToString();
                                objData.CN_CostCentreNo = rdr["CN_CostCentreNo"].ToString();
                                objData.CN_CountryCode = rdr["CN_CountryCode"].ToString();
                                objData.COU_Name = rdr["COU_Name"].ToString();
                                objData.CN_CustomerID = rdr["CN_CustomerID"].ToString();
                                objData.CUS_CompanyName = rdr["CUS_CompanyName"].ToString();
                                objData.CN_DepartmentID = rdr["CN_DepartmentID"].ToString();
                                objData.DPT_Name = rdr["DPT_Name"].ToString();
                                objData.CN_Status = rdr["CN_Status"].ToString();
                                objData.CN_DispatchTypeCode = rdr["CN_DispatchTypeCode"].ToString();
                                objData.CT_Name = rdr["CT_Name"].ToString();
                                objData.CN_LabelFooterLine1 = rdr["CN_LabelFooterLine1"].ToString();
                                objData.CN_LabelFooterLine2 = rdr["CN_LabelFooterLine2"].ToString();
                                objData.CN_LastPrintedBy = rdr["CN_LastPrintedBy"].ToString();
                                objData.CN_LastPrintedDateTime = rdr["CN_LastPrintedDateTime"].ToString();
                                objData.CN_CostCentreName = rdr["CN_CostCentreName"].ToString();
                                objData.CN_LastPrintedLabelTypeID = rdr["CN_LastPrintedLabelTypeID"].ToString();

                                objData.CN_CostCentreNo = rdr["CN_CostCentreNo"].ToString();
                                objData.CN_CreatedBy = rdr["CN_CreatedBy"].ToString();
                                objData.CN_CreatedDateTime = rdr["CN_CreatedDateTime"].ToString();
                                objData.CN_ModifiedBy = rdr["CN_ModifiedBy"].ToString();
                                objData.CN_ModifiedDateTime = rdr["CN_ModifiedDateTime"].ToString();
                                objData.CN_CostCentreName = rdr["CN_CostCentreName"].ToString();

                                objData.RC = RC;

                                if (objHead.Container == null)
                                {
                                    objHead.Container = new List<ReturnContainerModel>();
                                }

                                objHead.Container.Add(objData);
                            }
                            objHeadList.Add(objHead);
                        }
                        else
                        {
                            objHead.resp = true;
                            objHead.msg = "";
                            objHeadList.Add(objHead);


                        }

                    }


                    return objHeadList;

                }
            }
            catch (Exception ex)
            {
                objHead = new ReturnContainerModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "Container_Data", "get_container_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Container_Data", "get_container_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Container_Data", "get_container_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Container_Data", "get_container_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        public static List<ReturnContainerModelHead> get_container_single(GetContainerSingleModel item)
        {
            List<ReturnContainerModelHead> objHeadList = new List<ReturnContainerModelHead>();
            ReturnContainerModelHead objHead = new ReturnContainerModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objHead.resp = false;
                objHead.IsAuthenticated = false;
                objHeadList.Add(objHead);
                return objHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_container_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CN_ID", item.CN_ID);
                        cmd.Parameters["@CN_ID"].Direction = ParameterDirection.Input;



                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnContainerModel objData = new ReturnContainerModel();

                                objHead.resp = true;
                                objHead.msg = "Container";

                                objData.CN_ID = rdr["CN_ID"].ToString();
                                objData.CN_CostCentreNo = rdr["CN_CostCentreNo"].ToString();
                                objData.CN_CountryCode = rdr["CN_CountryCode"].ToString();
                                objData.COU_Name = rdr["COU_Name"].ToString();
                                objData.CN_CustomerID = rdr["CN_CustomerID"].ToString();
                                objData.CUS_CompanyName = rdr["CUS_CompanyName"].ToString();
                                objData.CN_DepartmentID = rdr["CN_DepartmentID"].ToString();
                                objData.DPT_Name = rdr["DPT_Name"].ToString();
                                objData.CN_Status = rdr["CN_Status"].ToString();
                                objData.CN_DispatchTypeCode = rdr["CN_DispatchTypeCode"].ToString();
                                objData.CT_Name = rdr["CT_Name"].ToString();
                                objData.CN_LabelFooterLine1 = rdr["CN_LabelFooterLine1"].ToString();
                                objData.CN_LabelFooterLine2 = rdr["CN_LabelFooterLine2"].ToString();
                                objData.CN_LastPrintedBy = rdr["CN_LastPrintedBy"].ToString();
                                objData.CN_LastPrintedDateTime = rdr["CN_LastPrintedDateTime"].ToString();
                                objData.CN_CostCentreName = rdr["CN_CostCentreName"].ToString();
                                objData.CN_LastPrintedLabelTypeID = rdr["CN_LastPrintedLabelTypeID"].ToString();
                                objData.RC = "1";

                                if (objHead.Container == null)
                                {
                                    objHead.Container = new List<ReturnContainerModel>();
                                }

                                objHead.Container.Add(objData);

                                objHeadList.Add(objHead);

                            }
                        }
                        else
                        {
                            objHead.resp = true;
                            objHead.msg = "";
                            objHeadList.Add(objHead);


                        }


                    }


                    return objHeadList;

                }
            }
            catch (Exception ex)
            {

                objHead = new ReturnContainerModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "Container_Data", "get_container_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Container_Data", "get_container_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Container_Data", "get_container_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Container_Data", "get_container_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }
    }
}








