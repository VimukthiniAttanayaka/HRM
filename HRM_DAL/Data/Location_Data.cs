using HRM_DAL.Models;
using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_DAL.Data
{
    public class Location_Data
    {
        private static LogError objError = new LogError();


        //[Authorize]
        public static List<ReturnLocationAllModelHead> get_location_all(GetLocationAllModel item)//ok
        {
            List<ReturnLocationAllModelHead> objHeadList = new List<ReturnLocationAllModelHead>();
            List<ReturnLocationAllModel> objList = new List<ReturnLocationAllModel>();
            ReturnLocationAllModelHead objHead = new ReturnLocationAllModelHead();

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

                    //ReturnLocationAllModelHead objHead = new ReturnLocationAllModelHead();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        if (lconn.State == ConnectionState.Closed)
                        {
                            lconn.Open();
                        }

                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_location_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAGE_NO", item.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", item.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@LOC_ID", item.LOC_ID);
                        cmd.Parameters["@LOC_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@LOC_Name", item.LOC_Name);
                        cmd.Parameters["@LOC_Name"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_CompanyName", item.BU_CompanyName);
                        cmd.Parameters["@BU_CompanyName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_CompanyName", item.CUS_CompanyName);
                        cmd.Parameters["@CUS_CompanyName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@LOC_Status", item.LOC_Status);
                        cmd.Parameters["@LOC_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_ID", item.CUS_ID);
                        cmd.Parameters["@CUS_ID"].Direction = ParameterDirection.Input;

                        string RC;
                        using (SqlCommand cmdrc = new SqlCommand())
                        {
                            cmdrc.Connection = lconn;

                            cmdrc.CommandText = "sp_get_location_count";
                            cmdrc.CommandType = CommandType.StoredProcedure;
                            SqlDataReader rdrrc = cmdrc.ExecuteReader();
                            rdrrc.Read();
                            RC = rdrrc["RC"].ToString();
                        }


                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnLocationAllModel objData = new ReturnLocationAllModel();

                                objHead.resp = true;
                                objHead.msg = "Location";

                                objData.LOC_ID = rdr["LOC_ID"].ToString();
                                objData.LOC_Name = rdr["LOC_Name"].ToString();
                                objData.CUS_CompanyName = rdr["CUS_CompanyName"].ToString();
                                objData.BU_CompanyName = rdr["BU_CompanyName"].ToString();
                                objData.CUS_CompanyName = rdr["CUS_CompanyName"].ToString();
                                objData.LOC_Status = rdr["LOC_Status"].ToString();
                                objData.RC = RC;

                                //objUserData.UserGroup.Add(objUserHead);

                                objList.Add(objData);

                                if (objHead.locationall == null)
                                {
                                    objHead.locationall = new List<ReturnLocationAllModel>();
                                }

                                objHead.locationall.Add(objData);

                                objList.Add(objData);

                            }
                        }
                        else
                        {
                            objHead.resp = true;
                            objHead.msg = "";
                        }
                        objHeadList.Add(objHead);
                    }

                    if (lconn.State == ConnectionState.Open)
                    {
                        lconn.Close();
                    }

                    return objHeadList;
                }
            }
            catch (Exception ex)
            {

                objHead = new ReturnLocationAllModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "Location_Data", "get_location_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Location_Data", "get_location_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Location_Data", "get_location_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Location_Data", "get_location_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }


        public static List<ReturnLocationModelHead> get_location_single(GetLocationSingleModel item)
        {
            List<ReturnLocationModelHead> objHeadList = new List<ReturnLocationModelHead>();
            List<ReturnLocationModel> objList = new List<ReturnLocationModel>();
            ReturnLocationModelHead objHead = new ReturnLocationModelHead();

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

                    objHead = new ReturnLocationModelHead();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_location_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@LOC_ID", item.LOC_ID);
                        cmd.Parameters["@LOC_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnLocationModel objData = new ReturnLocationModel();

                                objHead.resp = true;
                                objHead.msg = "Location";

                                objData.LOC_ID = rdr["LOC_ID"].ToString();
                                objData.LOC_Name = rdr["LOC_Name"].ToString();
                                objData.LOC_CUS_ID = rdr["LOC_CUS_ID"].ToString();
                                objData.CUS_CompanyName = rdr["CUS_CompanyName"].ToString();
                                objData.BU_CompanyName = rdr["BU_CompanyName"].ToString();
                                objData.LOC_Status = rdr["LOC_Status"].ToString();

                                objList.Add(objData);

                                if (objHead.location == null)
                                {
                                    objHead.location = new List<ReturnLocationModel>();
                                }

                                objHead.location.Add(objData);

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
                objHead = new ReturnLocationModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "Location_Data", "get_location_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Location_Data", "get_location_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Location_Data", "get_location_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Location_Data", "get_location_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }



    }








}








