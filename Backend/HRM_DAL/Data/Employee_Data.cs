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

                        cmd.Parameters.AddWithValue("@EME_EmployeeID", model.EME_EmployeeID);
                        cmd.Parameters["@EME_EmployeeID"].Direction = ParameterDirection.Input;

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

                                objemployee.EME_CustomerID = rdr["EME_CustomerID"].ToString();
                                objemployee.EME_DepartmentID = rdr["EME_DepartmentID"].ToString();
                                objemployee.EME_EmployeeID = rdr["EME_EmployeeID"].ToString();
                                objemployee.EME_FirstName = rdr["EME_FirstName"].ToString();
                                objemployee.EME_LastName = rdr["EME_LastName"].ToString();
                                objemployee.EME_Gender = rdr["EME_Gender"].ToString();
                                objemployee.EME_MaritalStatus = rdr["EME_MaritalStatus"].ToString();
                                objemployee.EME_Nationality = rdr["EME_Nationality"].ToString();
                                objemployee.EME_BloodGroup = rdr["EME_BloodGroup"].ToString();
                                objemployee.EME_NIC = rdr["EME_NIC"].ToString();
                                objemployee.EME_Passport = rdr["EME_Passport"].ToString();
                                objemployee.EME_DrivingLicense = rdr["EME_DrivingLicense"].ToString();
                                objemployee.EME_PrefferedName = rdr["EME_PrefferedName"].ToString();
                                objemployee.EME_JobTitle_Code = rdr["EME_JobTitle_Code"].ToString();
                                objemployee.EME_ReportingManager = rdr["EME_ReportingManager"].ToString();
                                objemployee.EME_EmployeeType = rdr["EME_EmployeeType"].ToString();
                                objemployee.EME_PayeeTaxNumber = rdr["EME_PayeeTaxNumber"].ToString();
                                objemployee.EME_Salary = Convert.ToDecimal(rdr["EME_Salary"].ToString());
                                objemployee.EME_Address = rdr["EME_Address"].ToString();
                                objemployee.EME_EmailAddress = rdr["EME_EmailAddress"].ToString();
                                objemployee.EME_MobileNumber = rdr["EME_MobileNumber"].ToString();
                                objemployee.EME_PhoneNumber1 = rdr["EME_PhoneNumber1"].ToString();
                                objemployee.EME_PhoneNumber2 = rdr["EME_PhoneNumber2"].ToString();
                                objemployee.EME_Status = Convert.ToBoolean(rdr["EME_Status"].ToString());
                                //objemployee.EME_DateOfBirth = Convert.ToDateTime(rdr["EME_DateOfBirth"].ToString());
                                if (rdr["EME_DateOfBirth"] != DBNull.Value)
                                {
                                    objemployee.EME_DateOfBirth = Convert.ToDateTime(rdr["EME_DateOfBirth"]);
                                }
                                else
                                {
                                    // Handle null value, e.g.,
                                    objemployee.EME_DateOfBirth = DateTime.MinValue; // Or another default value
                                }
                                if (rdr["EME_DateOfHire"] != DBNull.Value)
                                {
                                    objemployee.EME_DateOfHire = Convert.ToDateTime(rdr["EME_DateOfHire"]);
                                }
                                else
                                {
                                    // Handle null value, e.g.,
                                    objemployee.EME_DateOfHire = DateTime.MinValue; // Or another default value
                                }

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

            if (objemployeeHead.Employee == null)
            {
                objemployeeHead.Employee = new List<ReturnEmployeeModel>();
            }

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

                        cmd.CommandText = "sp_get_employee_all";
                        cmd.CommandType = CommandType.StoredProcedure;

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

                                objemployee.EME_CustomerID = rdr["EME_CustomerID"].ToString();
                                objemployee.EME_DepartmentID = rdr["EME_DepartmentID"].ToString();
                                objemployee.EME_EmployeeID = rdr["EME_EmployeeID"].ToString();
                                objemployee.EME_FirstName = rdr["EME_FirstName"].ToString();
                                objemployee.EME_LastName = rdr["EME_LastName"].ToString();
                                objemployee.EME_Gender = rdr["EME_Gender"].ToString();
                                objemployee.EME_MaritalStatus = rdr["EME_MaritalStatus"].ToString();
                                objemployee.EME_Nationality = rdr["EME_Nationality"].ToString();
                                objemployee.EME_BloodGroup = rdr["EME_BloodGroup"].ToString();
                                objemployee.EME_NIC = rdr["EME_NIC"].ToString();
                                objemployee.EME_Passport = rdr["EME_Passport"].ToString();
                                objemployee.EME_DrivingLicense = rdr["EME_DrivingLicense"].ToString();
                                objemployee.EME_PrefferedName = rdr["EME_PrefferedName"].ToString();
                                objemployee.EME_JobTitle_Code = rdr["EME_JobTitle_Code"].ToString();
                                objemployee.EME_ReportingManager = rdr["EME_ReportingManager"].ToString();
                                objemployee.EME_EmployeeType = rdr["EME_EmployeeType"].ToString();
                                objemployee.EME_PayeeTaxNumber = rdr["EME_PayeeTaxNumber"].ToString();
                                objemployee.EME_Salary = Convert.ToDecimal(rdr["EME_Salary"].ToString());
                                objemployee.EME_Address = rdr["EME_Address"].ToString();
                                objemployee.EME_EmailAddress = rdr["EME_EmailAddress"].ToString();
                                objemployee.EME_MobileNumber = rdr["EME_MobileNumber"].ToString();
                                objemployee.EME_PhoneNumber1 = rdr["EME_PhoneNumber1"].ToString();
                                objemployee.EME_PhoneNumber2 = rdr["EME_PhoneNumber2"].ToString();
                                objemployee.EME_Status = Convert.ToBoolean(rdr["EME_Status"].ToString());
                                //objemployee.EME_DateOfHire = Convert.ToDateTime(rdr["EME_DateOfHire"]);
                                if (rdr["EME_DateOfBirth"] != DBNull.Value)
                                {
                                    objemployee.EME_DateOfBirth = Convert.ToDateTime(rdr["EME_DateOfBirth"]);
                                }
                                else
                                {
                                    // Handle null value, e.g.,
                                    objemployee.EME_DateOfBirth = DateTime.MinValue; // Or another default value
                                }
                                if (rdr["EME_DateOfHire"] != DBNull.Value)
                                {
                                    objemployee.EME_DateOfHire = Convert.ToDateTime(rdr["EME_DateOfHire"]);
                                }
                                else
                                {
                                    // Handle null value, e.g.,
                                    objemployee.EME_DateOfHire = DateTime.MinValue; // Or another default value
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

        public static List<ReturnResponse> add_new_employee(EmployeeModel item)//ok
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


                        cmd.CommandText = "sp_insert_employee";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_CustomerID", item.EME_CustomerID);
                        cmd.Parameters["@EME_CustomerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_DepartmentID", item.EME_DepartmentID);
                        cmd.Parameters["@EME_DepartmentID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_EmployeeID", item.EME_EmployeeID);
                        cmd.Parameters["@EME_EmployeeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_FirstName", item.EME_FirstName);
                        cmd.Parameters["@EME_FirstName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_LastName", item.EME_LastName);
                        cmd.Parameters["@EME_LastName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_Gender", item.EME_Gender);
                        cmd.Parameters["@EME_Gender"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_MaritalStatus", item.EME_MaritalStatus);
                        cmd.Parameters["@EME_MaritalStatus"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_Nationality", item.EME_Nationality);
                        cmd.Parameters["@EME_Nationality"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_BloodGroup", item.EME_BloodGroup);
                        cmd.Parameters["@EME_BloodGroup"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_NIC", item.EME_NIC);
                        cmd.Parameters["@EME_NIC"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_Passport", item.EME_Passport);
                        cmd.Parameters["@EME_Passport"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_DrivingLicense", item.EME_DrivingLicense);
                        cmd.Parameters["@EME_DrivingLicense"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_PrefferedName", item.EME_PrefferedName);
                        cmd.Parameters["@EME_PrefferedName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_JobTitle_Code", item.EME_JobTitle_Code);
                        cmd.Parameters["@EME_JobTitle_Code"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_ReportingManager", item.EME_ReportingManager);
                        cmd.Parameters["@EME_ReportingManager"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_EmployeeType", item.EME_EmployeeType);
                        cmd.Parameters["@EME_EmployeeType"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_PayeeTaxNumber", item.EME_PayeeTaxNumber);
                        cmd.Parameters["@EME_PayeeTaxNumber"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_Salary", item.EME_Salary);
                        cmd.Parameters["@EME_Salary"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_Address", item.EME_Address);
                        cmd.Parameters["@EME_Address"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_EmailAddress", item.EME_EmailAddress);
                        cmd.Parameters["@EME_EmailAddress"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_MobileNumber", item.EME_MobileNumber);
                        cmd.Parameters["@EME_MobileNumber"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_PhoneNumber1", item.EME_PhoneNumber1);
                        cmd.Parameters["@EME_PhoneNumber1"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_PhoneNumber2", item.EME_PhoneNumber2);
                        cmd.Parameters["@EME_PhoneNumber2"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_DateOfHire", item.EME_DateOfHire);
                        cmd.Parameters["@EME_DateOfHire"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_Status", item.EME_Status);
                        cmd.Parameters["@EME_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_DateOfBirth", item.EME_DateOfBirth);
                        cmd.Parameters["@EME_DateOfBirth"].Direction = ParameterDirection.Input;

                        string mailtypes = "";

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
        public static List<ReturnResponse> upload_employee_documents(List<EmployeeAttachmentModel> item)//ok
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

                        foreach (EmployeeAttachmentModel p in item)
                        {

                            cmd.Parameters.AddWithValue("@USRED_EmployeeID", p.USRED_EmployeeID);
                            cmd.Parameters["@USRED_EmployeeID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USRED_DocumentData", p.USRED_DocumentData);
                            cmd.Parameters["@USRED_DocumentData"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USRED_DocumentType", p.USRED_DocumentType);
                            cmd.Parameters["@USRED_DocumentType"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USRED_DocumentName", p.USRED_DocumentName);
                            cmd.Parameters["@USRED_DocumentName"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USRED_Status", p.USRED_Status);
                            cmd.Parameters["@USRED_Status"].Direction = ParameterDirection.Input;


                            string mailtypes = "";

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

        public static List<EmployeeAttachmentModel> get_employeeDocument_all(EmployeeSearchModel model)//ok
        {
            List<EmployeeAttachmentModel> objEmployeeHeadList = new List<EmployeeAttachmentModel>();
            EmployeeAttachmentModel objemployeeHead = new EmployeeAttachmentModel();

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
                        cmd.Parameters.AddWithValue("@USRED_EmployeeID", model.EME_EmployeeID);
                        cmd.Parameters["@USRED_EmployeeID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                EmployeeAttachmentModel objemployee = new EmployeeAttachmentModel();

                                //objemployeeHead.resp = true;
                                //objemployeeHead.msg = "Get Employee";
                                objemployee.USRED_DocumentName = rdr["USRED_DocumentName"].ToString();
                                objemployee.USRED_EmployeeID = rdr["USRED_EmployeeID"].ToString();
                                objemployee.USRED_DocumentType = rdr["USRED_DocumentType"].ToString();
                                objemployee.USRED_Status = Convert.ToBoolean(rdr["USRED_Status"].ToString());
                                objemployee.USRED_DocumentData = rdr["USRED_DocumentData"].ToString();
                                objemployee.USRED_DocumentDataByte = Convert.FromBase64String(rdr["USRED_DocumentData"].ToString());

                                objEmployeeHeadList.Add(objemployee);
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
                objemployeeHead = new EmployeeAttachmentModel
                {
                    //resp = false,
                    //msg = ex.Message.ToString()
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
        public static List<ReturnResponse> modify_employee(EmployeeModel item)//ok
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


                        cmd.CommandText = "sp_modify_employee";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_CustomerID", item.EME_CustomerID);
                        cmd.Parameters["@EME_CustomerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_DepartmentID", item.EME_DepartmentID);
                        cmd.Parameters["@EME_DepartmentID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_EmployeeID", item.EME_EmployeeID);
                        cmd.Parameters["@EME_EmployeeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_FirstName", item.EME_FirstName);
                        cmd.Parameters["@EME_FirstName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_LastName", item.EME_LastName);
                        cmd.Parameters["@EME_LastName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_Gender", item.EME_Gender);
                        cmd.Parameters["@EME_Gender"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_MaritalStatus", item.EME_MaritalStatus);
                        cmd.Parameters["@EME_MaritalStatus"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_Nationality", item.EME_Nationality);
                        cmd.Parameters["@EME_Nationality"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_BloodGroup", item.EME_BloodGroup);
                        cmd.Parameters["@EME_BloodGroup"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_NIC", item.EME_NIC);
                        cmd.Parameters["@EME_NIC"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_Passport", item.EME_Passport);
                        cmd.Parameters["@EME_Passport"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_DrivingLicense", item.EME_DrivingLicense);
                        cmd.Parameters["@EME_DrivingLicense"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_PrefferedName", item.EME_PrefferedName);
                        cmd.Parameters["@EME_PrefferedName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_JobTitle_Code", item.EME_JobTitle_Code);
                        cmd.Parameters["@EME_JobTitle_Code"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_ReportingManager", item.EME_ReportingManager);
                        cmd.Parameters["@EME_ReportingManager"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_EmployeeType", item.EME_EmployeeType);
                        cmd.Parameters["@EME_EmployeeType"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_PayeeTaxNumber", item.EME_PayeeTaxNumber);
                        cmd.Parameters["@EME_PayeeTaxNumber"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_Salary", item.EME_Salary);
                        cmd.Parameters["@EME_Salary"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_Address", item.EME_Address);
                        cmd.Parameters["@EME_Address"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_EmailAddress", item.EME_EmailAddress);
                        cmd.Parameters["@EME_EmailAddress"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_MobileNumber", item.EME_MobileNumber);
                        cmd.Parameters["@EME_MobileNumber"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_PhoneNumber1", item.EME_PhoneNumber1);
                        cmd.Parameters["@EME_PhoneNumber1"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_PhoneNumber2", item.EME_PhoneNumber2);
                        cmd.Parameters["@EME_PhoneNumber2"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_DateOfHire", item.EME_DateOfHire);
                        cmd.Parameters["@EME_DateOfHire"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_Status", item.EME_Status);
                        cmd.Parameters["@EME_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EME_DateOfBirth", item.EME_DateOfBirth);
                        cmd.Parameters["@EME_DateOfBirth"].Direction = ParameterDirection.Input;

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

                        cmd.Parameters.AddWithValue("@EME_EmployeeID", item.EME_EmployeeID);
                        cmd.Parameters["@EME_EmployeeID"].Direction = ParameterDirection.Input;

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

