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
    public class Employee_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnEmployeeModelHead> get_employees_single(Employee model)//ok
        {
            List<ReturnEmployeeModelHead> objEmployeeHeadList = new List<ReturnEmployeeModelHead>();
            ReturnEmployeeModelHead objemployeeHead = new ReturnEmployeeModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objemployeeHead.resp = false;
                objemployeeHead.IsAuthenticated = false;
                objEmployeeHeadList.Add(objemployeeHead);
                return objEmployeeHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_employees_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ECE_EmployeeID" , model.ECE_EmployeeID);
                        cmd.Parameters["@ECE_EmployeeID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnEmployeeModel objemployee = new ReturnEmployeeModel();

                                objemployeeHead.resp = true;
                                objemployeeHead.msg = "Get Employee";

                                objemployee.ECE_EmployeeID = rdr["ECE_EmployeeID"].ToString();
                                objemployee.ECE_CustomerID = rdr["ECE_CustomerID"].ToString();
                                objemployee.ECE_DepartmentID = rdr["ECE_DepartmentID"].ToString();
                                objemployee.ECE_FirstName = rdr["ECE_FirstName"].ToString();
                                objemployee.ECE_LastName = rdr["ECE_LastName"].ToString();
                                //objemployee.ECE_PrefferedName = rdr["ECE_PrefferedName"].ToString();
                                //objemployee.ECE_OrgStructuralLevel1 = rdr["ECE_OrgStructuralLevel1"].ToString();
                                //objemployee.ECE_OrgStructuralLevel2 = rdr["ECE_OrgStructuralLevel2"].ToString();
                                //objemployee.ECE_DepartmentDetail1 = rdr["ECE_DepartmentDetail1"].ToString();
                                //objemployee.ECE_DepartmentDetail2 = rdr["ECE_DepartmentDetail2"].ToString();
                                //objemployee.ECE_DepartmentDetail3 = rdr["ECE_DepartmentDetail3"].ToString();
                                //objemployee.ECE_JobCodeDescription = rdr["ECE_JobCodeDescription"].ToString();
                                objemployee.ECE_Address = rdr["ECE_Address"].ToString();
                                objemployee.ECE_EmailAddress = rdr["ECE_EmailAddress"].ToString();
                                objemployee.ECE_MobileNumber = rdr["ECE_MobileNumber"].ToString();
                                objemployee.ECE_PhoneNumber1 = rdr["ECE_PhoneNumber1"].ToString();
                                objemployee.ECE_PhoneNumber2 = rdr["ECE_PhoneNumber2"].ToString();
                                objemployee.ECE_RankDescription = rdr["ECE_RankDescription"].ToString();
                                objemployee.ECE_StaffLocation = rdr["ECE_StaffLocation"].ToString();
                                objemployee.ECE_Remarks = rdr["ECE_Remarks"].ToString();
                                //objemployee.ECE_Pwd = rdr["ECE_Pwd"].ToString();
                                //objemployee.ECE_LastResetDateTime = rdr["ECE_LastResetDateTime"].ToString();
                                //objemployee.ECE_SyncedDateTime = rdr["ECE_SyncedDateTime"].ToString();
                                //objemployee.ECE_ActiveFrom = rdr["ECE_ActiveFrom"].ToString();
                                //objemployee.ECE_ActiveTo = rdr["ECE_ActiveTo"].ToString();
                                objemployee.ECE_Status = Convert.ToBoolean(rdr["ECE_Status"].ToString());

                                if (objemployeeHead.Employee == null)
                                {
                                    objemployeeHead.Employee = new List<ReturnEmployeeModel>();
                                }

                                objemployeeHead.Employee.Add(objemployee);

                                objEmployeeHeadList.Add(objemployeeHead);
                            }

                        }
                        else
                        {
                            ReturnEmployeeModel objemployee = new ReturnEmployeeModel();
                            objemployeeHead.resp = true;
                            objemployeeHead.msg = "";
                            objEmployeeHeadList.Add(objemployeeHead);


                        }


                    }
                    return objEmployeeHeadList;

                }
            }
            catch (Exception ex)
            {
                objemployeeHead = new ReturnEmployeeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objEmployeeHeadList.Add(objemployeeHead);

                objError.WriteLog(0, "Employee_Data", "get_employees_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Employee_Data", "get_employees_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Employee_Data", "get_employees_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Employee_Data", "get_employees_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
           }

            return objEmployeeHeadList;

        }

        public static List<ReturnEmployeeModelHead> get_employee_all(EmployeeSearchModel model)//ok
        {
            List<ReturnEmployeeModelHead> objEmployeeHeadList = new List<ReturnEmployeeModelHead>();
            ReturnEmployeeModelHead objemployeeHead = new ReturnEmployeeModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objemployeeHead.resp = false;
                objemployeeHead.IsAuthenticated = false;
                objEmployeeHeadList.Add(objemployeeHead);
                return objEmployeeHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "get_employee_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ECE_EmployeeID", model.ECE_EmployeeID);
                        cmd.Parameters["@ECE_EmployeeID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnEmployeeModel objemployee = new ReturnEmployeeModel();

                                objemployeeHead.resp = true;
                                objemployeeHead.msg = "Get Employee";

                                objemployee.ECE_EmployeeID = rdr["ECE_EmployeeID"].ToString();
                                objemployee.ECE_CustomerID = rdr["ECE_CustomerID"].ToString();
                                objemployee.ECE_DepartmentID = rdr["ECE_DepartmentID"].ToString();
                                objemployee.ECE_FirstName = rdr["ECE_FirstName"].ToString();
                                objemployee.ECE_LastName = rdr["ECE_LastName"].ToString();
                                //objemployee.ECE_PrefferedName = rdr["ECE_PrefferedName"].ToString();
                                //objemployee.ECE_OrgStructuralLevel1 = rdr["ECE_OrgStructuralLevel1"].ToString();
                                //objemployee.ECE_OrgStructuralLevel2 = rdr["ECE_OrgStructuralLevel2"].ToString();
                                //objemployee.ECE_DepartmentDetail1 = rdr["ECE_DepartmentDetail1"].ToString();
                                //objemployee.ECE_DepartmentDetail2 = rdr["ECE_DepartmentDetail2"].ToString();
                                //objemployee.ECE_DepartmentDetail3 = rdr["ECE_DepartmentDetail3"].ToString();
                                //objemployee.ECE_JobCodeDescription = rdr["ECE_JobCodeDescription"].ToString();
                                objemployee.ECE_Address = rdr["ECE_Address"].ToString();
                                objemployee.ECE_EmailAddress = rdr["ECE_EmailAddress"].ToString();
                                objemployee.ECE_MobileNumber = rdr["ECE_MobileNumber"].ToString();
                                objemployee.ECE_PhoneNumber1 = rdr["ECE_PhoneNumber1"].ToString();
                                objemployee.ECE_PhoneNumber2 = rdr["ECE_PhoneNumber2"].ToString();
                                objemployee.ECE_RankDescription = rdr["ECE_RankDescription"].ToString();
                                objemployee.ECE_StaffLocation = rdr["ECE_StaffLocation"].ToString();
                                objemployee.ECE_Remarks = rdr["ECE_Remarks"].ToString();
                                //objemployee.ECE_Pwd = rdr["ECE_Pwd"].ToString();
                                //objemployee.ECE_LastResetDateTime = rdr["ECE_LastResetDateTime"].ToString();
                                //objemployee.ECE_SyncedDateTime = rdr["ECE_SyncedDateTime"].ToString();
                                //objemployee.ECE_ActiveFrom = rdr["ECE_ActiveFrom"].ToString();
                                //objemployee.ECE_ActiveTo = rdr["ECE_ActiveTo"].ToString();
                                objemployee.ECE_Status = Convert.ToBoolean(rdr["ECE_Status"].ToString());

                                if (objemployeeHead.Employee == null)
                                {
                                    objemployeeHead.Employee = new List<ReturnEmployeeModel>();
                                }

                                objemployeeHead.Employee.Add(objemployee);

                                objEmployeeHeadList.Add(objemployeeHead);
                            }

                        }
                        else
                        {
                            ReturnEmployeeModel objemployee = new ReturnEmployeeModel();
                            objemployeeHead.resp = true;
                            objemployeeHead.msg = "";
                            objEmployeeHeadList.Add(objemployeeHead);


                        }


                    }
                    return objEmployeeHeadList;

                }
            }
            catch (Exception ex)
            {
                objemployeeHead = new ReturnEmployeeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
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

        public static List<ReturncustResponse> add_new_employee(EmployeeModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();
            ReturncustResponse objCustHead = new ReturncustResponse();

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


                        cmd.CommandText = "sp_insert_employee";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@ECE_EmployeeID", item.ECE_EmployeeID);
                        cmd.Parameters["@ECE_EmployeeID"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_CompanyName", item.CUS_CompanyName);
                        //cmd.Parameters["@CUS_CompanyName"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_BlockBuildingNo", item.CUS_Adrs_BlockBuildingNo);
                        //cmd.Parameters["@CUS_Adrs_BlockBuildingNo"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_BuildingName", item.CUS_Adrs_BuildingName);
                        //cmd.Parameters["@CUS_Adrs_BuildingName"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_UnitNumber", item.CUS_Adrs_UnitNumber);
                        //cmd.Parameters["@CUS_Adrs_UnitNumber"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_StreetName", item.CUS_Adrs_StreetName);
                        //cmd.Parameters["@CUS_Adrs_StreetName"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_City", item.CUS_Adrs_City);
                        //cmd.Parameters["@CUS_Adrs_City"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_CountryCode", item.CUS_Adrs_CountryCode);
                        //cmd.Parameters["@CUS_Adrs_CountryCode"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_PostalCode", item.CUS_Adrs_PostalCode);
                        //cmd.Parameters["@CUS_Adrs_PostalCode"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_ContactPerson", item.CUS_ContactPerson);
                        //cmd.Parameters["@CUS_ContactPerson"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_ContactNumber", item.CUS_ContactNumber);
                        //cmd.Parameters["@CUS_ContactNumber"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_PinOrPwd", item.CUS_PinOrPwd);
                        //cmd.Parameters["@CUS_PinOrPwd"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_OTP_By_SMS", item.CUS_OTP_By_SMS);
                        //cmd.Parameters["@CUS_OTP_By_SMS"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_OTP_By_Email", item.CUS_OTP_By_Email);
                        //cmd.Parameters["@CUS_OTP_By_Email"].Direction = ParameterDirection.Input;

                        string mailtypes = "";

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                objCustHead = new ReturncustResponse
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
                objCustHead = new ReturncustResponse
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

        public static List<ReturncustResponse> modify_employee(EmployeeModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();
            ReturncustResponse objCustHead = new ReturncustResponse();

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


                        cmd.CommandText = "sp_modify_employee";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@ECE_EmployeeID", item.ECE_EmployeeID);
                        cmd.Parameters["@ECE_EmployeeID"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_CompanyName", item.CUS_CompanyName);
                        //cmd.Parameters["@CUS_CompanyName"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_BlockBuildingNo", item.CUS_Adrs_BlockBuildingNo);
                        //cmd.Parameters["@CUS_Adrs_BlockBuildingNo"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_BuildingName", item.CUS_Adrs_BuildingName);
                        //cmd.Parameters["@CUS_Adrs_BuildingName"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_UnitNumber", item.CUS_Adrs_UnitNumber);
                        //cmd.Parameters["@CUS_Adrs_UnitNumber"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_StreetName", item.CUS_Adrs_StreetName);
                        //cmd.Parameters["@CUS_Adrs_StreetName"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_City", item.CUS_Adrs_City);
                        //cmd.Parameters["@CUS_Adrs_City"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_CountryCode", item.CUS_Adrs_CountryCode);
                        //cmd.Parameters["@CUS_Adrs_CountryCode"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_PostalCode", item.CUS_Adrs_PostalCode);
                        //cmd.Parameters["@CUS_Adrs_PostalCode"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_ContactPerson", item.CUS_ContactPerson);
                        //cmd.Parameters["@CUS_ContactPerson"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_ContactNumber", item.CUS_ContactNumber);
                        //cmd.Parameters["@CUS_ContactNumber"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_PinOrPwd", item.CUS_PinOrPwd);
                        //cmd.Parameters["@CUS_PinOrPwd"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_OTP_By_SMS", item.CUS_OTP_By_SMS);
                        //cmd.Parameters["@CUS_OTP_By_SMS"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_OTP_By_Email", item.CUS_OTP_By_Email);
                        //cmd.Parameters["@CUS_OTP_By_Email"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Status", item.CUS_Status);
                        //cmd.Parameters["@CUS_Status"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                objCustHead = new ReturncustResponse
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
                objCustHead = new ReturncustResponse
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

        public static List<ReturnResponse> inactivate_employee(InactiveEmpModel item)//ok
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

                        cmd.Parameters.AddWithValue("@ECE_EmployeeID", item.ECE_EmployeeID);
                        cmd.Parameters["@ECE_EmployeeID"].Direction = ParameterDirection.Input;

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
    }

}

