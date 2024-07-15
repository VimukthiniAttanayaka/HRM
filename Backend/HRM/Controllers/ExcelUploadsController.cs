using HRM_DAL.Models;
using error_handler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using utility_handler.Data;
using static error_handler.ErrorLog;
using System.Reflection;
using static error_handler.InformationLog;
using System.Linq;
using System.Data.OleDb;
using System.IO;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using HRM_DAL.Data;
using Newtonsoft.Json;

namespace HRM.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    //[BasicAuthorization]
    //[Authorize]

    public class ExcelUploadsController : ControllerBase
    {
        private LogError objError = new LogError();

        //POST api/<ExcelUploadsController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        //[Obsolete]
        public ReturUserExcelUploadHead user_excelupload(UserExcelUploadModel model)
        {
            ReturUserExcelUploadHead objHeadList = new ReturUserExcelUploadHead();
            //List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                if (model == null)
                {
                    objHeadList = new ReturUserExcelUploadHead
                    {
                        resp = false,
                        msg = "value cannot be null"
                    };
                    return objHeadList;
                }

                ReturUserExcelUploadHead tempObj = HRM_BL.ExcelUploads_BL.User_Related.user_excelupload(model);

                if (tempObj.resp == false)
                {
                    objHeadList = new ReturUserExcelUploadHead
                    {
                        resp = false,
                        msg = tempObj.msg
                    };
                    return objHeadList;
                }

                List<ReturUserExcelUploadHead> retList = new List<ReturUserExcelUploadHead>();

                if (tempObj.users != null)
                {
                    //if (model.IsCompleteList == true)
                    //{
                    //    HRM_BL.ExcelUploads_BL.User_Related.markall_users_excel_inactive(model);
                    //}

                    foreach (var item in tempObj.users)
                    {
                        item.USER_ID = model.USER_ID;
                        item.UD_CustomerID = model.DPT_CustomerID;
                        item.UD_Status = true;
                        //item.UAG_BusinessUnit = model.UAG_BusinessUnit;

                        retList.Add(HRM_BL.ExcelUploads_BL.User_Related.add_update_user_excel(item).FirstOrDefault());
                    }

                    LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, retList);

                    var temp = retList.Where(a => !a.msg.Contains("kiosk")).Count(a => a.resp == true);

                    if (temp > 0)
                    {
                        objHeadList = new ReturUserExcelUploadHead
                        {
                            resp = true,
                            msg = "Success"
                        };
                    }
                    else
                    {
                        objHeadList = new ReturUserExcelUploadHead
                        {
                            resp = false,
                            msg = "Failed"
                        };

                    }

                    objHeadList.FileNameWithPath = tempObj.FileNameWithPath;
                    objHeadList.FileName = tempObj.FileName;

                    var tmeps = retList.Where(b => !b.msg.Contains("kiosk") && b.resp == true).Select(a => new userresponcemodel_return() { StaffID = a.users.FirstOrDefault().UD_StaffID, Message = a.msg }).ToList();
                    objHeadList.success_users = tmeps;

                    var tmepsC = retList.Where(b => !b.msg.Contains("kiosk") && b.resp == false).Select(a => new userresponcemodel_return() { StaffID = a.users.FirstOrDefault().UD_StaffID, Message = a.msg }).ToList();
                    objHeadList.failed_users = tmepsC;
                }

                LogExcelUploadTracer_Data.User(objHeadList, model);

                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, objHeadList);

                return objHeadList;
            }
            catch (Exception ex)
            {
                objHeadList = new ReturUserExcelUploadHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };

                objError.WriteLog(0, "ExcelUploadsController", "user_excelupload", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ExcelUploadsController", "user_excelupload", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ExcelUploadsController", "user_excelupload", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ExcelUploadsController", "user_excelupload", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        //[Obsolete]
        public List<ExcelUploadResponceModel> loadexcelsample(ExcelUploadSampleRequestModel item)
        {
            List<ExcelUploadResponceModel> objHeadList = new List<ExcelUploadResponceModel>();
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "");

                string fileNamewithPath = "";
                fileNamewithPath = item.FileFullPath;// @"C:\Users\Neelaka.tts\Downloads\RE_HRM-UAT\report user.xlsx";

                if (string.IsNullOrEmpty(fileNamewithPath)) { objHeadList.Add(new ExcelUploadResponceModel() { }); return objHeadList; }

                byte[] fileContent = null;
                System.IO.FileStream fs = new System.IO.FileStream(fileNamewithPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fs);
                long byteLength = new System.IO.FileInfo(fileNamewithPath).Length;
                fileContent = binaryReader.ReadBytes((Int32)byteLength);
                fs.Close();
                fs.Dispose();
                binaryReader.Close();
                string base64String = Convert.ToBase64String(fileContent);

                objHeadList.Add(new ExcelUploadResponceModel() { ExcelFileUploaded = fileContent, base64String = base64String });
                return objHeadList;
            }
            catch (Exception ex)
            {
                //ReturuserModelHead objHead = new ReturuserModelHead
                //{
                //    resp = false,
                //    msg = ex.Message.ToString()
                //};
                //objHeadList.Add(objHead);

                objError.WriteLog(0, "ExcelUploadsController", "loadexcelsample", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ExcelUploadsController", "loadexcelsample", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ExcelUploadsController", "loadexcelsample", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ExcelUploadsController", "loadexcelsample", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }
    }

    public class ExcelUploadSampleRequestModel
    {
        public string FileFullPath { get; set; }
    }
    public class ExcelUploadResponceModel : RequestBaseModel
    {
        public string USER_ID { get; set; }
        public byte[] ExcelFileUploaded { get; set; }
        public string base64String { get; set; }
        public string DPT_CustomerID { get; set; }
        public bool IsCompleteList { get; set; } = false;
    }
}








