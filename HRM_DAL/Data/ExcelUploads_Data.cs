using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using HRM_DAL.Data;
using System;
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
//using Excel = Microsoft.Office.Interop.Excel;
using email_sender;
using error_handler;
using ExcelDataReader;
using HRM_DAL.Models;
using HRM_DAL.Models.RequestModels;
using HRM_DAL.Models.ResponceModels;
using HRM_DAL.Utility;
using Newtonsoft.Json;
using sms_core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Claims;
using utility_handler.Data;

namespace HRM_DAL.Data
{
    public class ExcelUploads_Data
    {
        private static LogError objError = new LogError();

        public class User_Related
        {
            public static ReturUserExcelUploadHead user_excelupload(UserExcelUploadModel model)
            {
                ReturUserExcelUploadHead lst = new ReturUserExcelUploadHead();
                try
                {
                    string fileNamewithPath = "";
                    fileNamewithPath = "";// @"C:\Users\Neelaka.tts\Downloads\RE_HRM-UAT\report.xlsx";
                    if (string.IsNullOrEmpty(model.base64String) == false)
                    {
                        model.ExcelFileUploaded = Convert.FromBase64String(model.base64String);
                    }

                    (string fileNamewithPath, string batchno) ret = ("", "");

                    if (model.ExcelFileUploaded != null)
                    {
                        //ret = SaveExcelToFileFolder(model.ExcelFileUploaded, "FilePathReference_User_ExcelFileUpload", "Staff");
                    }

                    if (string.IsNullOrEmpty(ret.fileNamewithPath))
                    {
                        lst = new ReturUserExcelUploadHead()
                        {
                            resp = false,
                            msg = "File Not Saved",
                            FileNameWithPath = ret.fileNamewithPath,
                            FileName = ret.batchno
                        };
                        return lst;
                    }

                    List<CUserModel> User = new List<CUserModel>();

                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    //using (var stream = System.IO.File.Open(fileNamewithPath, FileMode.Open, FileAccess.Read))
                    //{
                    Stream stream = new MemoryStream(model.ExcelFileUploaded);

                    try
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            var conf = new ExcelDataSetConfiguration
                            {
                                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                                {
                                    UseHeaderRow = false// true
                                }
                            };
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == "Neither stream 'Workbook' nor 'Book' was found in file.")
                        {
                            lst = new ReturUserExcelUploadHead()
                            {
                                resp = false,
                                msg = "File Upload Error ! Please ensure format is correct and has public access. ",
                                FileNameWithPath = ret.fileNamewithPath,
                                FileName = ret.batchno
                            };
                        }
                        else
                        {
                            lst = new ReturUserExcelUploadHead()
                            {
                                resp = false,
                                msg = "Invalid File - " + ex.Message,
                                FileNameWithPath = ret.fileNamewithPath,
                                FileName = ret.batchno
                            };
                        }
                        return lst;
                    }

                    stream = new MemoryStream(model.ExcelFileUploaded);

                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var conf = new ExcelDataSetConfiguration
                        {
                            ConfigureDataTable = _ => new ExcelDataTableConfiguration
                            {
                                UseHeaderRow = false// true
                            }
                        };

                        DataSet dataSet = reader.AsDataSet(conf);
                        int indexPrimaryFirstName = -1;
                        int indexPrimaryLastName = -1;
                        int indexEmployeeLocation = -1;
                        int indexHandPhonePager = -1;
                        int indexAlternateTelephone = -1;
                        int indexPrimaryTelephone = -1;
                        int indexRankDescription = -1;
                        int indexPreferredName = -1;
                        int indexOrgStructuralLevel1 = -1;
                        int indexOrgStructuralLevel2 = -1;
                        int indexLevel3Descr = -1;
                        int indexLevel4Descr = -1;
                        int indexLevel5Descr = -1;
                        int indexJobCodeDescr = -1;
                        int index1BankEmailAddress = -1;
                        int index1BankID = -1;
                        int indexPCCode = -1;
                        int indexPCDescription = -1;
                        int indexDepartmentID = -1;
                        int indexDepartmentAddress = -1;
                        int indexEmployeeID = -1;

                        string indexerros = "";

                        TestColumnExists(dataSet,
                            ref indexPrimaryFirstName,
                            ref indexPrimaryLastName,
                            ref indexEmployeeLocation,
                            ref indexHandPhonePager,
                            ref indexAlternateTelephone,
                            ref indexPrimaryTelephone,
                            ref indexRankDescription,
                            ref indexPreferredName,
                            ref indexOrgStructuralLevel1,
                            ref indexOrgStructuralLevel2,
                            ref indexLevel3Descr,
                            ref indexLevel4Descr,
                            ref indexLevel5Descr,
                            ref indexJobCodeDescr,
                            ref index1BankEmailAddress,
                            ref index1BankID,
                            ref indexPCCode,
                            ref indexPCDescription,
                            ref indexDepartmentID,
                            ref indexDepartmentAddress,
                            ref indexEmployeeID,
                            ref indexerros);

                        if (indexerros != "")
                        {
                            lst = new ReturUserExcelUploadHead()
                            {
                                resp = false,
                                msg = "Invalid File - " + indexerros + "  Not found - In the excel",
                                FileNameWithPath = ret.fileNamewithPath,
                                FileName = ret.batchno
                            };
                            return lst;
                        }

                        //if (dataSet.Tables[0].Columns.Contains("Primary First Name")) { int prime = dataSet.Tables[0].Columns.IndexOf("Primary First Name"); }

                        for (int i = 1; i < dataSet.Tables[0].Rows.Count; i++)
                        {
                            var obj = new CUserModel() { };

                            obj.USR_FirstName = dataSet.Tables[0].Rows[i][indexPrimaryFirstName].ToString().Trim();
                            obj.USR_LastName = dataSet.Tables[0].Rows[i][indexPrimaryLastName].ToString().Trim();
                            obj.USR_PrefferedName = dataSet.Tables[0].Rows[i][indexPreferredName].ToString().Trim();
                            obj.USR_OrgStructuralLevel1 = dataSet.Tables[0].Rows[i][indexOrgStructuralLevel1].ToString().Trim();
                            obj.USR_OrgStructuralLevel2 = dataSet.Tables[0].Rows[i][indexOrgStructuralLevel2].ToString().Trim();
                            obj.USR_DepartmentDetail1 = dataSet.Tables[0].Rows[i][indexLevel3Descr].ToString().Trim();
                            obj.USR_DepartmentDetail2 = dataSet.Tables[0].Rows[i][indexLevel4Descr].ToString().Trim();
                            obj.USR_DepartmentDetail3 = dataSet.Tables[0].Rows[i][indexLevel5Descr].ToString().Trim();
                            obj.USR_JobCodeDescription = dataSet.Tables[0].Rows[i][indexJobCodeDescr].ToString().Trim();
                            obj.USR_EmailAddress = dataSet.Tables[0].Rows[i][index1BankEmailAddress].ToString().Trim();
                            obj.USR_StaffID = dataSet.Tables[0].Rows[i][index1BankID].ToString().Trim();
                            obj.USR_PCCode = dataSet.Tables[0].Rows[i][indexPCCode].ToString().Trim();
                            obj.USR_PCDescription = dataSet.Tables[0].Rows[i][indexPCDescription].ToString().Trim();
                            obj.USR_DepartmentID = dataSet.Tables[0].Rows[i][indexDepartmentID].ToString().Trim();
                            //obj.DPT_CPCode=dataSet.Tables[0].Rows[i][indexDepartmentName].ToString();
                            obj.USR_Address = dataSet.Tables[0].Rows[i][indexDepartmentAddress].ToString().Trim();
                            obj.USR_RankDescription = dataSet.Tables[0].Rows[i][indexRankDescription].ToString().Trim();
                            obj.USR_PhoneNumber1 = dataSet.Tables[0].Rows[i][indexPrimaryTelephone].ToString().Trim();
                            obj.USR_PhoneNumber2 = dataSet.Tables[0].Rows[i][indexAlternateTelephone].ToString().Trim();
                            obj.USR_MobileNumber = dataSet.Tables[0].Rows[i][indexHandPhonePager].ToString().Trim();
                            obj.USR_StaffLocation = dataSet.Tables[0].Rows[i][indexEmployeeLocation].ToString().Trim();
                            obj.USR_EmployeeID = dataSet.Tables[0].Rows[i][indexEmployeeID].ToString().Trim();

                            User.Add(obj);
                        }

                        lst = new ReturUserExcelUploadHead() { resp = true, users = User, FileNameWithPath = ret.fileNamewithPath, FileName = ret.batchno };
                    }

                    //}
                }
                catch (Exception ex)
                {
                    lst = new ReturUserExcelUploadHead()
                    {
                        resp = false,
                        msg = ex.StackTrace
                    };

                    objError.WriteLog(0, "ExcelUploads_Data", "user_excelupload", "Stack Track: " + ex.StackTrace);
                    objError.WriteLog(0, "ExcelUploads_Data", "user_excelupload", "Error Message: " + ex.Message);
                    if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                    {
                        objError.WriteLog(0, "ExcelUploads_Data", "user_excelupload", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                        objError.WriteLog(0, "ExcelUploads_Data", "user_excelupload", "Inner Exception Message: " + ex.InnerException.Message);
                    }
                }
                return lst;
            }

            public static List<ReturUserExcelUploadHead> add_update_user_excel(CUserModel model)
            {
                List<ReturUserExcelUploadHead> objCUserHeadList = new List<ReturUserExcelUploadHead>();
                ReturUserExcelUploadHead objCusUserHead = new ReturUserExcelUploadHead();

                if (!string.IsNullOrEmpty(model.USR_EmailAddress) && !utility_handler.Utility.Misc.EmailValidator(model.USR_EmailAddress))
                {
                    objCusUserHead = new ReturUserExcelUploadHead
                    {
                        resp = false,
                        msg = "Invalid Email Address"
                    };

                    objCusUserHead.users.Add(model);

                    string logobject = JsonConvert.SerializeObject(objCusUserHead);

                    new WhiteLog("add_update_kiosk_excel - update log" + logobject, "ExcelUploads_Data", "add_update_kiosk_excel", true, true);

                    objCUserHeadList.Add(objCusUserHead);

                    return objCUserHeadList;
                }


                try
                {
                    string encryptedPW = "";
                    string encryptedpin = "";
                    decimal Salt = 0;
                    string NotEncryptedPassword = "";

                    string CUS_PinOrPwd = "";
                    string BU_ID = "";
                    bool SMSOk = true;
                    bool EmailOk = true;

                    List<ReturnCustomerModelHead> cust = Customer_Data.get_customers_single(new Customer() { CUS_ID = model.USR_CustomerID });

                    if (cust != null && cust.Count > 0 && cust[0].Customer != null && cust[0].Customer.Count > 0)
                    {
                        CUS_PinOrPwd = cust[0].Customer[0].CUS_PinOrPwd;
                        BU_ID = cust[0].Customer[0].CUS_BusinessUnit;

                        //SMSOk = cust[0].Customer[0].CUS_OTP_By_Email;
                        //EmailOk = cust[0].Customer[0].CUS_OTP_By_SMS;

                        SMSOk = cust[0].Customer[0].CUS_OTP_By_SMS;
                        EmailOk = cust[0].Customer[0].CUS_OTP_By_Email;
                    }

                    if (CUS_PinOrPwd.ToUpper() == "PWD")
                    {
                        NotEncryptedPassword = PasswordRelated.CreateRandomPassword();
                        PasswordRelated.CreateEncryptedPassword(NotEncryptedPassword, ref encryptedPW, ref Salt);
                    }
                    else
                    {
                        NotEncryptedPassword = PasswordRelated.CreateRandomPIN();
                        PasswordRelated.CreateEncryptedPassword(NotEncryptedPassword, ref encryptedpin, ref Salt);
                    }


                    using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = lconn;
                            lconn.Open();

                            cmd.CommandText = "sp_add_update_user_excel";
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@USER_ID", model.USER_ID);
                            cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USR_CustomerID", model.USR_CustomerID);
                            cmd.Parameters["@USR_CustomerID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USR_DepartmentID", model.USR_DepartmentID);
                            cmd.Parameters["@USR_DepartmentID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USR_StaffID", model.USR_StaffID);
                            cmd.Parameters["@USR_StaffID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USR_FirstName", model.USR_FirstName);
                            cmd.Parameters["@USR_FirstName"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USR_LastName", model.USR_LastName);
                            cmd.Parameters["@USR_LastName"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USR_PrefferedName", model.USR_PrefferedName);
                            cmd.Parameters["@USR_PrefferedName"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USR_OrgStructuralLevel1", model.USR_OrgStructuralLevel1);
                            cmd.Parameters["@USR_OrgStructuralLevel1"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USR_OrgStructuralLevel2", model.USR_OrgStructuralLevel2);
                            cmd.Parameters["@USR_OrgStructuralLevel2"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USR_DepartmentDetail1", model.USR_DepartmentDetail1);
                            cmd.Parameters["@USR_DepartmentDetail1"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USR_DepartmentDetail2", model.USR_DepartmentDetail2);
                            cmd.Parameters["@USR_DepartmentDetail2"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USR_DepartmentDetail3", model.USR_DepartmentDetail3);
                            cmd.Parameters["@USR_DepartmentDetail3"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USR_JobCodeDescription", model.USR_JobCodeDescription);
                            cmd.Parameters["@USR_JobCodeDescription"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USR_Address", model.USR_Address);
                            cmd.Parameters["@USR_Address"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USR_EmailAddress", model.USR_EmailAddress);
                            cmd.Parameters["@USR_EmailAddress"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USR_MobileNumber", model.USR_MobileNumber);
                            cmd.Parameters["@USR_MobileNumber"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USR_PhoneNumber1", model.USR_PhoneNumber1);
                            cmd.Parameters["@USR_PhoneNumber1"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USR_PhoneNumber2", model.USR_PhoneNumber2);
                            cmd.Parameters["@USR_PhoneNumber2"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USR_RankDescription", model.USR_RankDescription);
                            cmd.Parameters["@USR_RankDescription"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USR_StaffLocation", model.USR_StaffLocation);
                            cmd.Parameters["@USR_StaffLocation"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USR_PCCode", model.USR_PCCode);
                            cmd.Parameters["@USR_PCCode"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USR_PCDescription", model.USR_PCDescription);
                            cmd.Parameters["@USR_PCDescription"].Direction = ParameterDirection.Input;

                            if (string.IsNullOrEmpty(model.USR_Remarks)) model.USR_Remarks = "";
                            cmd.Parameters.AddWithValue("@USR_Remarks", model.USR_Remarks);
                            cmd.Parameters["@USR_Remarks"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USR_Pin", encryptedpin);
                            cmd.Parameters["@USR_Pin"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USR_Pwd", encryptedPW);
                            cmd.Parameters["@USR_Pwd"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USR_PwdSalt", Salt);
                            cmd.Parameters["@USR_PwdSalt"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USR_Status", model.USR_Status);
                            cmd.Parameters["@USR_Status"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@TABLE", model.TABLE);
                            cmd.Parameters["@TABLE"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@UAG_GroupID", ConfigCaller.CustomerUserGroupID);
                            cmd.Parameters["@UAG_GroupID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USR_EmployeeID", model.USR_EmployeeID);
                            cmd.Parameters["@USR_EmployeeID"].Direction = ParameterDirection.Input;

                            //cmd.Parameters.AddWithValue("@UAG_BusinessUnit", model.UAG_BusinessUnit);
                            //cmd.Parameters["@UAG_BusinessUnit"].Direction = ParameterDirection.Input;

                            SqlDataAdapter dta = new SqlDataAdapter();
                            dta.SelectCommand = cmd;
                            DataSet Ds = new DataSet();
                            dta.Fill(Ds);

                            int exp_date = 0;
                            String expired_date = "";

                            if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow rdr in Ds.Tables[0].Rows)
                                {
                                    if (!String.IsNullOrEmpty(rdr["RTN_DATE"].ToString()))
                                    {
                                        exp_date = int.Parse(rdr["RTN_DATE"].ToString());
                                        expired_date = DateTime.Now.AddDays(exp_date).ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
                                    }

                                    objCusUserHead = new ReturUserExcelUploadHead
                                    {
                                        resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                        msg = rdr["RTN_MSG"].ToString()
                                    };

                                    objCusUserHead.users.Add(model);

                                    objCUserHeadList.Add(objCusUserHead);

                                    //if (objCusUserHead.resp == true)
                                    //{
                                    //    List<ReturnResponse> retlist = new List<ReturnResponse>();
                                    //(bool IsSMSFailed, bool IsEmailFailed) res = User_Data.SendEmailSMS_CustomerUser(model, retlist, NotEncryptedPassword, CUS_PinOrPwd, cust, expired_date, BU_ID, SMSOk, EmailOk);

                                    //retlist.AddRange(User_Data.sync_c_user_kioski(new CUser()
                                    //{
                                    //    USER_ID = model.USR_StaffID,
                                    //    TABLE = model.TABLE
                                    //}));

                                    //retlist.ForEach((item) =>
                                    //{
                                    //    objCusUserHead = new ReturUserExcelUploadHead()
                                    //    {
                                    //        msg = item.msg,
                                    //        resp = item.resp,
                                    //    };

                                    //    objCusUserHead.users.Add(model);

                                    //    objCUserHeadList.Add(objCusUserHead);
                                    //});
                                    //}

                                    //objUserSList.Add(objUserHead.objReturnUserModelList);

                                    string logobject = JsonConvert.SerializeObject(objCUserHeadList);

                                    new WhiteLog("add_update_user_excel - update log" + logobject, "ExcelUploads_Data", "add_update_user_excel", true, true);

                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    objCusUserHead = new ReturUserExcelUploadHead
                    {
                        resp = false,
                        msg = ex.Message.ToString()
                    };
                    objCUserHeadList.Add(objCusUserHead);

                    objError.WriteLog(0, "ExcelUploads_Data", "add_update_user_excel", "Stack Track: " + ex.StackTrace);
                    objError.WriteLog(0, "ExcelUploads_Data", "add_update_user_excel", "Error Message: " + ex.Message);
                    if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                    {
                        objError.WriteLog(0, "ExcelUploads_Data", "add_update_user_excel", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                        objError.WriteLog(0, "ExcelUploads_Data", "add_update_user_excel", "Inner Exception Message: " + ex.InnerException.Message);
                    }

                }
                return objCUserHeadList;
            }

            public static void markall_users_excel_inactive(UserExcelUploadModel model)
            {
                try
                {
                    using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = lconn;
                            lconn.Open();

                            cmd.CommandText = "markall_users_excel_inactive";
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@USER_ID", model.USER_ID);
                            cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@USR_CustomerID", model.DPT_CustomerID);
                            cmd.Parameters["@USR_CustomerID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@TABLE", model.TABLE);
                            cmd.Parameters["@TABLE"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@UAG_GroupID", ConfigCaller.CustomerUserGroupID);
                            cmd.Parameters["@UAG_GroupID"].Direction = ParameterDirection.Input;

                            SqlDataAdapter dta = new SqlDataAdapter();
                            dta.SelectCommand = cmd;
                            DataSet Ds = new DataSet();
                            dta.Fill(Ds);
                        }
                    }
                }
                catch (Exception ex)
                {
                    objError.WriteLog(0, "ExcelUploads_Data", "markall_users_excel_inactive", "Stack Track: " + ex.StackTrace);
                    objError.WriteLog(0, "ExcelUploads_Data", "markall_users_excel_inactive", "Error Message: " + ex.Message);
                    if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                    {
                        objError.WriteLog(0, "ExcelUploads_Data", "markall_users_excel_inactive", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                        objError.WriteLog(0, "ExcelUploads_Data", "markall_users_excel_inactive", "Inner Exception Message: " + ex.InnerException.Message);
                    }

                }
            }

            public static void TestColumnExists(DataSet dataSet,
                                                ref int indexPrimaryFirstName,
                                                ref int indexPrimaryLastName,
                                                ref int indexEmployeeLocation,
                                                ref int indexHandPhonePager,
                                                ref int indexAlternateTelephone,
                                                ref int indexPrimaryTelephone,
                                                ref int indexRankDescription,
                                                ref int indexPreferredName,
                                                ref int indexOrgStructuralLevel1,
                                                ref int indexOrgStructuralLevel2,
                                                ref int indexLevel3Descr,
                                                ref int indexLevel4Descr,
                                                ref int indexLevel5Descr,
                                                ref int indexJobCodeDescr,
                                                ref int index1BankEmailAddress,
                                                ref int index1BankID,
                                                ref int indexPCCode,
                                                ref int indexPCDescription,
                                                ref int indexDepartmentID,
                                                ref int indexDepartmentAddress,
                                                ref int indexEmployeeID,
                                                ref string indexerros)
            {
                for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
                {
                    if (dataSet.Tables[0].Rows[0][i].ToString().ToUpper().Trim().Contains("PRIMARY FIRST NAME"))
                        indexPrimaryFirstName = i;
                    if (dataSet.Tables[0].Rows[0][i].ToString().ToUpper().Trim().Contains("PRIMARY LAST NAME"))
                        indexPrimaryLastName = i;

                    if (dataSet.Tables[0].Rows[0][i].ToString().ToUpper().Trim().Contains("PREFERRED NAME"))
                        indexPreferredName = i;
                    if (dataSet.Tables[0].Rows[0][i].ToString().ToUpper().Trim().Contains("ORG STRUCTURAL LEVEL 1"))
                        indexOrgStructuralLevel1 = i;
                    if (dataSet.Tables[0].Rows[0][i].ToString().ToUpper().Trim().Contains("ORG STRUCTURAL LEVEL 2"))
                        indexOrgStructuralLevel2 = i;
                    if (dataSet.Tables[0].Rows[0][i].ToString().ToUpper().Trim().Contains("LEVEL 3 DESCR"))
                        indexLevel3Descr = i;
                    if (dataSet.Tables[0].Rows[0][i].ToString().ToUpper().Trim().Contains("LEVEL 4 DESCR"))
                        indexLevel4Descr = i;
                    if (dataSet.Tables[0].Rows[0][i].ToString().ToUpper().Trim().Contains("LEVEL 5 DESCR"))
                        indexLevel5Descr = i;
                    if (dataSet.Tables[0].Rows[0][i].ToString().ToUpper().Trim().Contains("JOB CODE DESCR"))
                        indexJobCodeDescr = i;
                    if (dataSet.Tables[0].Rows[0][i].ToString().ToUpper().Trim().Contains("1BANK EMAIL ADDRESS"))
                        index1BankEmailAddress = i;
                    if (dataSet.Tables[0].Rows[0][i].ToString().ToUpper().Trim().Contains("1BANK ID"))
                        index1BankID = i;
                    if (dataSet.Tables[0].Rows[0][i].ToString().ToUpper().Trim().Contains("PC CODE"))
                        indexPCCode = i;
                    if (dataSet.Tables[0].Rows[0][i].ToString().ToUpper().Trim().Contains("PC DESCRIPTION"))
                        indexPCDescription = i;
                    if (dataSet.Tables[0].Rows[0][i].ToString().ToUpper().Trim().Contains("DEPARTMENT ID"))
                        indexDepartmentID = i;
                    if (dataSet.Tables[0].Rows[0][i].ToString().ToUpper().Trim().Contains("DEPARTMENT ADDRESS"))
                        indexDepartmentAddress = i;
                    if (dataSet.Tables[0].Rows[0][i].ToString().ToUpper().Trim().Contains("RANK DESCRIPTION"))
                        indexRankDescription = i;
                    if (dataSet.Tables[0].Rows[0][i].ToString().ToUpper().Trim().Contains("PRIMARY TELEPHONE"))
                        indexPrimaryTelephone = i;
                    if (dataSet.Tables[0].Rows[0][i].ToString().ToUpper().Trim().Contains("ALTERNATE TELEPHONE"))
                        indexAlternateTelephone = i;
                    if (dataSet.Tables[0].Rows[0][i].ToString().ToUpper().Trim().Contains("HANDPHONE/PAGER"))
                        indexHandPhonePager = i;
                    if (dataSet.Tables[0].Rows[0][i].ToString().ToUpper().Trim().Contains("EMPLOYEE LOCATION"))
                        indexEmployeeLocation = i;
                    if (dataSet.Tables[0].Rows[0][i].ToString().ToUpper().Trim().Contains("EMPLOYEE ID"))
                        indexEmployeeID = i;
                }

                if (indexPrimaryFirstName == -1)
                { indexerros = "Primary First Name"; }
                if (indexPrimaryLastName == -1)
                { indexerros = "Primary Last Name"; }

                if (indexPreferredName == -1)
                {
                    indexerros = "Preferred Name";
                }
                if (indexOrgStructuralLevel1 == -1)
                {
                    indexerros = "Org Structural Level 1";
                }
                if (indexOrgStructuralLevel2 == -1)
                {
                    indexerros = "Org Structural Level 2";
                }
                if (indexLevel3Descr == -1)
                {
                    indexerros = "Level 3 Descr";
                }
                if (indexLevel4Descr == -1)
                {
                    indexerros = "Level 4 Descr";
                }
                if (indexLevel5Descr == -1)
                {
                    indexerros = "Level 5 Descr";
                }
                if (indexJobCodeDescr == -1)
                {
                    indexerros = "Job Code Descr";
                }
                if (index1BankEmailAddress == -1)
                {
                    indexerros = "1Bank Email Address";
                }
                if (index1BankID == -1)
                {
                    indexerros = "1Bank ID";
                }
                if (indexPCCode == -1)
                {
                    indexerros = "PC Code";
                }
                if (indexPCDescription == -1)
                {
                    indexerros = "PC Description";
                }
                if (indexDepartmentID == -1)
                {
                    indexerros = "Department ID";
                }
                if (indexDepartmentAddress == -1)
                {
                    indexerros = "Department Address";
                }
                if (indexRankDescription == -1)
                {
                    indexerros = "Rank Description";
                }
                if (indexPrimaryTelephone == -1)
                {
                    indexerros = "Primary Telephone";
                }
                if (indexAlternateTelephone == -1)
                {
                    indexerros = "Alternate Telephone";
                }
                if (indexHandPhonePager == -1)
                {
                    indexerros = "HandPhone/Pager";
                }
                if (indexEmployeeLocation == -1)
                {
                    indexerros = "Employee Location";
                }
                if (indexEmployeeID == -1)
                {
                    indexerros = "Employee ID";
                }
            }
        }

    }
}