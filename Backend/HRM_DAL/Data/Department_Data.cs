using error_handler;
using ExcelDataReader;
using HRM_DAL.Models;
using HRM_DAL.Models.RequestModels;
using HRM_DAL.Models.ResponceModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using utility_handler.Data;

namespace HRM_DAL.Data
{
    public partial class Department_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnResponse> add_new_department(DepartmentModel item)//ok
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


                        cmd.CommandText = "sp_insert_department";
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@DPT_ID", item.DPT_ID);
                        //cmd.Parameters["@DPT_ID"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@DPT_Name", item.DPT_Name);
                        //cmd.Parameters["@DPT_Name"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@DPT_LocationCode", item.DPT_LocationCode);
                        //cmd.Parameters["@DPT_LocationCode"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@DPT_Adrs_BlockBuildingNo", item.DPT_Adrs_BlockBuildingNo);
                        //cmd.Parameters["@DPT_Adrs_BlockBuildingNo"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@DPT_Adrs_BuildingName", item.DPT_Adrs_BuildingName);
                        //cmd.Parameters["@DPT_Adrs_BuildingName"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@DPT_Adrs_UnitNumber", item.DPT_Adrs_UnitNumber);
                        //cmd.Parameters["@DPT_Adrs_UnitNumber"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@DPT_Adrs_StreetName", item.DPT_Adrs_StreetName);
                        //cmd.Parameters["@DPT_Adrs_StreetName"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@DPT_Adrs_City", item.DPT_Adrs_City);
                        //cmd.Parameters["@DPT_Adrs_City"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@DPT_Adrs_CountryCode", item.DPT_Adrs_CountryCode);
                        //cmd.Parameters["@DPT_Adrs_CountryCode"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@DPT_Adrs_PostalCode", item.DPT_Adrs_PostalCode);
                        //cmd.Parameters["@DPT_Adrs_PostalCode"].Direction = ParameterDirection.Input;                  

                        cmd.Parameters.AddWithValue("@USER_ID", item.UD_StaffID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "Department_Data", "add_new_department", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Department_Data", "add_new_department", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Department_Data", "add_new_department", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Department_Data", "add_new_department", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        public static List<ReturnResponse> modify_department(DepartmentModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();
            List<SPResponse> objResponseList = new List<SPResponse>();
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


                        cmd.CommandText = "sp_modify_department";
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@DPT_ID", item.DPT_ID);
                        //cmd.Parameters["@DPT_ID"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@DPT_Name", item.DPT_Name);
                        //cmd.Parameters["@DPT_Name"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@DPT_LocationCode", item.DPT_LocationCode);
                        //cmd.Parameters["@DPT_LocationCode"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@DPT_Adrs_BlockBuildingNo", item.DPT_Adrs_BlockBuildingNo);
                        //cmd.Parameters["@DPT_Adrs_BlockBuildingNo"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@DPT_Adrs_BuildingName", item.DPT_Adrs_BuildingName);
                        //cmd.Parameters["@DPT_Adrs_BuildingName"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@DPT_Adrs_UnitNumber", item.DPT_Adrs_UnitNumber);
                        //cmd.Parameters["@DPT_Adrs_UnitNumber"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@DPT_Adrs_StreetName", item.DPT_Adrs_StreetName);
                        //cmd.Parameters["@DPT_Adrs_StreetName"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@DPT_Adrs_City", item.DPT_Adrs_City);
                        //cmd.Parameters["@DPT_Adrs_City"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@DPT_Adrs_CountryCode", item.DPT_Adrs_CountryCode);
                        //cmd.Parameters["@DPT_Adrs_CountryCode"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@DPT_Adrs_PostalCode", item.DPT_Adrs_PostalCode);
                        //cmd.Parameters["@DPT_Adrs_PostalCode"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@USER_ID", item.UD_StaffID);
                        //cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@DPT_Status", item.DPT_Status);
                        //cmd.Parameters["@DPT_Status"].Direction = ParameterDirection.Input;


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

                objError.WriteLog(0, "Department_Data", "modify_department", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Department_Data", "modify_department", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Department_Data", "modify_department", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Department_Data", "modify_department", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        public static List<ReturnResponse> inactivate_department(InactiveDepartmentModel item)//ok
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


                        cmd.CommandText = "sp_del_department";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DPT_ID", item.MDD_DepartmentID);
                        cmd.Parameters["@DPT_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UD_StaffID", item.UD_StaffID);
                        cmd.Parameters["@UD_StaffID"].Direction = ParameterDirection.Input;


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

                objError.WriteLog(0, "Department_Data", "inactivate_department", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Department_Data", "inactivate_department", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Department_Data", "inactivate_department", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Department_Data", "inactivate_department", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objHeadList;
            }
        }

        public static List<ReturDepartmentModelHead> get_department_all(GetDepartmentAllModel item)//ok
        {
            List<ReturDepartmentModelHead> objHeadList = new List<ReturDepartmentModelHead>();
            ReturDepartmentModelHead objHead = new ReturDepartmentModelHead();

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

                        cmd.CommandText = "sp_get_department_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAGE_NO", item.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", item.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@DPT_ID", item.DPT_ID);
                        //cmd.Parameters["@DPT_ID"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@DPT_Name", item.DPT_Name);
                        //cmd.Parameters["@DPT_Name"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@DPT_Status", item.DPT_Status);
                        //cmd.Parameters["@DPT_Status"].Direction = ParameterDirection.Input;

                        string RC;
                        using (SqlCommand cmdrc = new SqlCommand())
                        {
                            cmdrc.Connection = lconn;

                            cmdrc.CommandText = "sp_get_department_count";
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
                                ReturnDepartmentModel objData = new ReturnDepartmentModel();

                                objHead.resp = true;
                                objHead.msg = "Department";

                                //objData.DPT_ID = rdr["DPT_ID"].ToString();
                                //objData.DPT_CustomerID = rdr["DPT_CustomerID"].ToString();
                                //objData.DPT_Name = rdr["DPT_Name"].ToString();
                                //objData.DPT_Adrs_BlockBuildingNo = rdr["DPT_Adrs_BlockBuildingNo"].ToString();
                                //objData.DPT_Adrs_BuildingName = rdr["DPT_Adrs_BuildingName"].ToString();
                                //objData.DPT_Adrs_UnitNumber = rdr["DPT_Adrs_UnitNumber"].ToString();
                                //objData.DPT_Adrs_StreetName = rdr["DPT_Adrs_StreetName"].ToString();
                                //objData.DPT_Adrs_City = rdr["DPT_Adrs_City"].ToString();
                                //objData.DPT_Adrs_CountryCode = rdr["DPT_Adrs_CountryCode"].ToString();
                                //objData.DPT_Adrs_PostalCode = rdr["DPT_Adrs_PostalCode"].ToString();
                                //objData.CUS_CompanyName = rdr["CUS_CompanyName"].ToString();
                                //objData.DPT_Status = Convert.ToBoolean(rdr["DPT_Status"].ToString());


                                //objData.DPT_CreatedBy = rdr["DPT_CreatedBy"].ToString();
                                //objData.DPT_CreatedDateTime = rdr["DPT_CreatedDateTime"].ToString();
                                //objData.DPT_ModifiedBy = rdr["DPT_ModifiedBy"].ToString();
                                //objData.DPT_ModifiedDateTime = rdr["DPT_ModifiedDateTime"].ToString();

                                objData.RC = RC;

                                if (objHead.Department == null)
                                {
                                    objHead.Department = new List<ReturnDepartmentModel>();
                                }

                                objHead.Department.Add(objData);

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

                objHead = new ReturDepartmentModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "Department_Data", "get_department_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Department_Data", "get_department_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Department_Data", "get_department_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Department_Data", "get_department_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        public static List<ReturDepartmentModelHead> get_department_single(GetDepartmentSingleModel item)
        {
            List<ReturDepartmentModelHead> objHeadList = new List<ReturDepartmentModelHead>();
            ReturDepartmentModelHead objHead = new ReturDepartmentModelHead();

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

                        cmd.CommandText = "sp_get_department_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DPT_ID", item.MDD_DepartmentID);
                        cmd.Parameters["@DPT_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnDepartmentModel objData = new ReturnDepartmentModel();


                                objHead.resp = true;
                                objHead.msg = "Department";

                                //objData.DPT_ID = rdr["DPT_ID"].ToString();
                                //objData.DPT_CustomerID = rdr["DPT_CustomerID"].ToString();
                                //objData.DPT_Name = rdr["DPT_Name"].ToString();
                                //objData.DPT_Adrs_BlockBuildingNo = rdr["DPT_Adrs_BlockBuildingNo"].ToString();
                                //objData.DPT_Adrs_BuildingName = rdr["DPT_Adrs_BuildingName"].ToString();
                                //objData.DPT_Adrs_UnitNumber = rdr["DPT_Adrs_UnitNumber"].ToString();
                                //objData.DPT_Adrs_StreetName = rdr["DPT_Adrs_StreetName"].ToString();
                                //objData.DPT_Adrs_City = rdr["DPT_Adrs_City"].ToString();
                                //objData.DPT_Adrs_CountryCode = rdr["DPT_Adrs_CountryCode"].ToString();
                                //objData.DPT_Adrs_PostalCode = rdr["DPT_Adrs_PostalCode"].ToString();
                                //objData.CUS_CompanyName = rdr["CUS_CompanyName"].ToString();
                                //objData.DPT_ModifiedDateTime = rdr["DPT_ModifiedDateTime"].ToString();
                                //objData.DPT_CreatedDateTime = rdr["DPT_CreatedDateTime"].ToString();
                                //objData.DPT_Status = Convert.ToBoolean(rdr["DPT_Status"].ToString());
                                objData.RC = "1";


                                if (objHead.Department == null)
                                {
                                    objHead.Department = new List<ReturnDepartmentModel>();
                                }

                                objHead.Department.Add(objData);
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
                objHead = new ReturDepartmentModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "Department_Data", "get_department_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Department_Data", "get_department_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Department_Data", "get_department_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Department_Data", "get_department_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

    }
}








