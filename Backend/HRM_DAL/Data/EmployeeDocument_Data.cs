using HRM_DAL.Models;
using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using Newtonsoft.Json;

namespace HRM_DAL.Data
{
    public class EmployeeDocument_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnResponse> inactivate_employeedocument(InactiveEEDModel item)
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            ReturnResponse objUserHead = new ReturnResponse();
            List<SPResponse> objResponseList = new List<SPResponse>();

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



                        cmd.CommandText = "sp_del_employee";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EED_EmployeeDocumentID", item.EED_EmployeeDocumentID);
                        cmd.Parameters["@EED_EmployeeDocumentID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;



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
                        return objUserHeadList;
                    }
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

                objError.WriteLog(0, "Employee_Data", "inactivate_employee", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Employee_Data", "inactivate_employee", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Employee_Data", "inactivate_employee", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Employee_Data", "inactivate_employee", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }
        }

        //public static List<ReturnResponse> modify_employeedocument(EmployeeDocumentModel item)
        //{
        //    List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();
        //    ReturnResponse objCustHead = new ReturnResponse();

        //    if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
        //    {
        //        objCustHead.resp = false;
        //        objCustHead.IsAuthenticated = false;
        //        objCustHeadList.Add(objCustHead);
        //        return objCustHeadList;
        //    }

        //    try
        //    {
        //        using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
        //        {

        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.Connection = lconn;


        //                cmd.CommandText = "sp_modify_employee";
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
        //                cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

        //                cmd.Parameters.AddWithValue("@EED_EmployeeID", item.EED_EmployeeID);
        //                cmd.Parameters["@EED_EmployeeID"].Direction = ParameterDirection.Input;

        //                cmd.Parameters.AddWithValue("@EED_DocumentType", item.EED_DocumentType);
        //                cmd.Parameters["@EED_DocumentType"].Direction = ParameterDirection.Input;

        //                cmd.Parameters.AddWithValue("@EED_DocumentName", item.EED_DocumentName);
        //                cmd.Parameters["@EED_DocumentName"].Direction = ParameterDirection.Input;

        //                cmd.Parameters.AddWithValue("@EED_DocumentData", item.EED_DocumentData);
        //                cmd.Parameters["@EED_DocumentData"].Direction = ParameterDirection.Input;

        //                cmd.Parameters.AddWithValue("@EED_EmployeeDocumentID", item.EED_EmployeeDocumentID);
        //                cmd.Parameters["@EED_EmployeeDocumentID"].Direction = ParameterDirection.Input;

        //                cmd.Parameters.AddWithValue("@EED_Status", item.EED_Status);
        //                cmd.Parameters["@EED_Status"].Direction = ParameterDirection.Input;

        //                SqlDataAdapter dta = new SqlDataAdapter();
        //                dta.SelectCommand = cmd;
        //                DataSet Ds = new DataSet();
        //                dta.Fill(Ds);

        //                if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        //                {
        //                    foreach (DataRow rdr in Ds.Tables[0].Rows)
        //                    {
        //                        objCustHead = new ReturnResponse
        //                        {
        //                            resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
        //                            msg = rdr["RTN_MSG"].ToString()
        //                        };
        //                        objCustHeadList.Add(objCustHead);

        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objCustHead = new ReturnResponse
        //        {
        //            resp = false,
        //            msg = ex.Message.ToString()
        //        };
        //        objCustHeadList.Add(objCustHead);

        //        objError.WriteLog(0, "Employee_Data", "add_new_employee", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "Employee_Data", "add_new_employee", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "Employee_Data", "add_new_employee", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "Employee_Data", "add_new_employee", "Inner Exception Message: " + ex.InnerException.Message);
        //        }

        //    }
        //    return objCustHeadList;
        //}

        public static List<ReturnResponse> add_new_employeedocument(EmployeeDocumentModel item)
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();
            ReturnResponse objCustHead = new ReturnResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objCustHead.resp = false;
                objCustHead.IsAuthenticated = false;
                objCustHeadList.Add(objCustHead);
                return objCustHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_insert_employeedocument";
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        //cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EED_EmployeeID", item.EED_EmployeeID);
                        cmd.Parameters["@EED_EmployeeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EED_DocumentType", item.EED_DocumentType);
                        cmd.Parameters["@EED_DocumentType"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EED_DocumentName", item.EED_DocumentName);
                        cmd.Parameters["@EED_DocumentName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EED_DocumentData", item.EED_DocumentData);
                        cmd.Parameters["@EED_DocumentData"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@EED_EmployeeDocumentID", item.EED_EmployeeDocumentID);
                        //cmd.Parameters["@EED_EmployeeDocumentID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EED_Status", item.EED_Status);
                        cmd.Parameters["@EED_Status"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                objCustHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objCustHeadList.Add(objCustHead);

                            }
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                objCustHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objCustHead);

                objError.WriteLog(0, "Employee_Data", "add_new_employee", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Employee_Data", "add_new_employee", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Employee_Data", "add_new_employee", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Employee_Data", "add_new_employee", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> upload_employee_documents(List<EmployeeDocumentModel> item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();
            ReturnResponse objCustHead = new ReturnResponse();

            //if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            //{
            //    objCustHead.resp = false;
            //    objCustHead.IsAuthenticated = false;
            //    objCustHeadList.Add(objCustHead);
            //    return objCustHeadList;
            //}

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_upload_employee_documents";
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (EmployeeDocumentModel p in item)
                        {

                            cmd.Parameters.AddWithValue("@EED_EmployeeID", p.EED_EmployeeID);
                            cmd.Parameters["@EED_EmployeeID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@EED_DocumentData", p.EED_DocumentData);
                            cmd.Parameters["@EED_DocumentData"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@EED_DocumentType", p.EED_DocumentType);
                            cmd.Parameters["@EED_DocumentType"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@EED_DocumentName", p.EED_DocumentName);
                            cmd.Parameters["@EED_DocumentName"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@EED_Status", p.EED_Status);
                            cmd.Parameters["@EED_Status"].Direction = ParameterDirection.Input;

                            SqlDataAdapter dta = new SqlDataAdapter();
                            dta.SelectCommand = cmd;
                            DataSet Ds = new DataSet();
                            dta.Fill(Ds);

                            if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow rdr in Ds.Tables[0].Rows)
                                {
                                    objCustHead = new ReturnResponse
                                    {
                                        resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                        msg = rdr["RTN_MSG"].ToString()
                                    };
                                    objCustHeadList.Add(objCustHead);

                                }
                            }

                            cmd.Parameters.Clear();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                objCustHead.resp = false;
                objCustHead.msg = ex.Message.ToString();

                objCustHeadList.Add(objCustHead);

                objError.WriteLog(0, "Employee_Data", "add_new_employee", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Employee_Data", "add_new_employee", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Employee_Data", "add_new_employee", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Employee_Data", "add_new_employee", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnEmployeeDocumentModelHead> get_employeeDocument_all(EmployeeDocumentSearchModel model)//ok
        {
            List<ReturnEmployeeDocumentModelHead> objEmployeeHeadList = new List<ReturnEmployeeDocumentModelHead>();
            ReturnEmployeeDocumentModelHead objemployeeHead = new ReturnEmployeeDocumentModelHead();

            if (objemployeeHead.EmployeeDocument == null)
            {
                objemployeeHead.EmployeeDocument = new List<ReturnEmployeeDocumentModel>();
            }

            //if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            //{
            //    objemployeeHead.resp = false;
            //    objemployeeHead.IsAuthenticated = false;
            //    objEmployeeHeadList.Add(objemployeeHead);
            //    return objEmployeeHeadList;
            //}

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_employeeDocument_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EED_EmployeeID", model.EME_EmployeeID);
                        cmd.Parameters["@EED_EmployeeID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnEmployeeDocumentModel objemployee = new ReturnEmployeeDocumentModel();

                                //objemployeeHead.resp = true;
                                //objemployeeHead.msg = "Get Employee";
                                objemployee.EED_DocumentName = rdr["EED_DocumentName"].ToString();
                                objemployee.EED_EmployeeDocumentID = rdr["EED_EmployeeDocumentID"].ToString();
                                objemployee.EED_EmployeeID = rdr["EED_EmployeeID"].ToString();
                                objemployee.EED_DocumentType = rdr["EED_DocumentType"].ToString();
                                objemployee.EED_Status = Convert.ToBoolean(rdr["EED_Status"].ToString());
                                objemployee.EED_DocumentData = rdr["EED_DocumentData"].ToString();
                                //objemployee.EED_DocumentDataByte = Convert.FromBase64String(rdr["EED_DocumentData"].ToString());

                                objemployeeHead.EmployeeDocument.Add(objemployee);

                                objEmployeeHeadList.Add(objemployeeHead);
                            }

                        }
                        else
                        {
                            ReturnEmployeeModel objemployee = new ReturnEmployeeModel();
                            //objemployeeHead.resp = true;
                            //objemployeeHead.msg = "";
                            objEmployeeHeadList.Add(objemployeeHead);


                        }


                    }
                    return objEmployeeHeadList;

                }
            }
            catch (Exception ex)
            {
                objemployeeHead.resp = false;
                objemployeeHead.msg = ex.Message.ToString();

                objEmployeeHeadList.Add(objemployeeHead);

                objError.WriteLog(0, "Employee_Data", "get_employee_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Employee_Data", "get_employee_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Employee_Data", "get_employee_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Employee_Data", "get_employee_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objEmployeeHeadList;

        }

        public static List<ReturnEmployeeDocumentModelHead> get_employeeDocument_single(EmployeeDocument model)//ok
        {
            List<ReturnEmployeeDocumentModelHead> objEmployeeHeadList = new List<ReturnEmployeeDocumentModelHead>();
            ReturnEmployeeDocumentModelHead objemployeeHead = new ReturnEmployeeDocumentModelHead();

            if (objemployeeHead.EmployeeDocument == null)
            {
                objemployeeHead.EmployeeDocument = new List<ReturnEmployeeDocumentModel>();
            }

            //if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            //{
            //    objemployeeHead.resp = false;
            //    objemployeeHead.IsAuthenticated = false;
            //    objEmployeeHeadList.Add(objemployeeHead);
            //    return objEmployeeHeadList;
            //}

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_employeeDocument_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EED_EmployeeDocumentID", model.EED_EmployeeDocumentID);
                        cmd.Parameters["@EED_EmployeeDocumentID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnEmployeeDocumentModel objemployee = new ReturnEmployeeDocumentModel();

                                //objemployeeHead.resp = true;
                                //objemployeeHead.msg = "Get Employee";
                                objemployee.EED_DocumentName = rdr["EED_DocumentName"].ToString();
                                objemployee.EED_EmployeeDocumentID = rdr["EED_EmployeeDocumentID"].ToString();
                                objemployee.EED_EmployeeID = rdr["EED_EmployeeID"].ToString();
                                objemployee.EED_DocumentType = rdr["EED_DocumentType"].ToString();
                                objemployee.EED_Status = Convert.ToBoolean(rdr["EED_Status"].ToString());
                                objemployee.EED_DocumentData = rdr["EED_DocumentData"].ToString();
                                //objemployee.EED_DocumentDataByte = Convert.FromBase64String(rdr["EED_DocumentData"].ToString());

                                objemployeeHead.EmployeeDocument.Add(objemployee);

                                objEmployeeHeadList.Add(objemployeeHead);
                            }

                        }
                        else
                        {
                            ReturnEmployeeModel objemployee = new ReturnEmployeeModel();
                            //objemployeeHead.resp = true;
                            //objemployeeHead.msg = "";
                            objEmployeeHeadList.Add(objemployeeHead);


                        }


                    }
                    return objEmployeeHeadList;

                }
            }
            catch (Exception ex)
            {
                objemployeeHead.resp = false;
                objemployeeHead.msg = ex.Message.ToString();

                objEmployeeHeadList.Add(objemployeeHead);

                objError.WriteLog(0, "Employee_Data", "get_employeeDocument_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Employee_Data", "get_employeeDocument_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Employee_Data", "get_employeeDocument_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Employee_Data", "get_employeeDocument_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objEmployeeHeadList;

        }
    }

}

