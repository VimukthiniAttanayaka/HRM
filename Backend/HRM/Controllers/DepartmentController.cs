using HRM_DAL.Models;
using error_handler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using utility_handler.Data;
//using static error_handler.InformationLog;
using static error_handler.ErrorLog;
using System.Reflection;
using static error_handler.InformationLog;
using System.Linq;
using System.Data.OleDb;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using HRM_DAL.Data;

namespace HRM.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    //[BasicAuthorization]
    //[Authorize]

    public class DepartmentController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnCustomerSelectModelHead> get_customer_with_select()
        {
            List<ReturnCustomerSelectModelHead> objCustomerHeadList = new List<ReturnCustomerSelectModelHead>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "");

                return HRM_BL.Department_BL.get_customer_with_select();

            }
            catch (Exception ex)
            {

                ReturnCustomerSelectModelHead objcustomerHead = new ReturnCustomerSelectModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustomerHeadList.Add(objcustomerHead);

                objError.WriteLog(0, "DepartmentController", "get_customer_with_select", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentController", "get_customer_with_select", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentController", "get_customer_with_select", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentController", "get_customer_with_select", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustomerHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturDepartmentAllModelHead> get_department_by_customer_id(GetDepartmentSingleModel item)
        {
            List<ReturDepartmentAllModelHead> objCustomerHeadList = new List<ReturDepartmentAllModelHead>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "");

                return HRM_BL.Department_BL.get_department_by_customer_id(item);

            }
            catch (Exception ex)
            {

                ReturDepartmentAllModelHead objcustomerHead = new ReturDepartmentAllModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustomerHeadList.Add(objcustomerHead);

                objError.WriteLog(0, "DepartmentController", "get_customer_with_select", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentController", "get_customer_with_select", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentController", "get_customer_with_select", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentController", "get_customer_with_select", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustomerHeadList;

        }


        //Unfinalized codes, cause of abnormal shut off of project!!!!!
        //POST api/<DepartmentController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_department(DepartmentModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();
            //List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = HRM_BL.Department_BL.add_new_department(item);
                return objHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DepartmentController", "add_new_department", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentController", "add_new_department", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentController", "add_new_department", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentController", "add_new_department", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        //Unfinalized codes, cause of abnormal shut off of project!!!!!
        //POST api/<DepartmentController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_department_Bulk(DepartmentBulkModel model)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();
            //List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                if (model == null)
                {
                    ReturnResponse objHead = new ReturnResponse
                    {
                        resp = false,
                        msg = "value cannot be null"
                    };
                    objHeadList.Add(objHead);
                    return objHeadList;
                }
                if (model.deplist == null)
                {
                    ReturnResponse objHead = new ReturnResponse
                    {
                        resp = false,
                        msg = "value list cannot be null"
                    };
                    objHeadList.Add(objHead);
                    return objHeadList;
                }

                foreach (var item in model.deplist)
                {
                    List<ReturDepartmentModelHead> temp = HRM_BL.Department_BL.get_department_single(new GetDepartmentSingleModel() { DPT_ID = item.DPT_ID, DPT_CustomerID = item.DPT_CustomerID });
                    if (temp != null && temp.Count > 0 && temp[0].Department != null && temp[0].Department.Count > 0)
                    {
                        objHeadList.Add(HRM_BL.Department_BL.modify_department(item).FirstOrDefault());
                    }
                    else
                    {
                        objHeadList.Add(HRM_BL.Department_BL.add_new_department(item).FirstOrDefault());
                    }
                }
                return objHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DepartmentController", "add_new_department_Bulk", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentController", "add_new_department_Bulk", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentController", "add_new_department_Bulk", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentController", "add_new_department_Bulk", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        #region moved to ecelupload by V2
        ////POST api/<DepartmentController>
        //[HttpPost]
        //[Route("[action]")]
        ////[Authorize]
        //[Obsolete]
        //public ReturnDepartmentExcelUploadHead department_excelupload(DepartmentExcelUploadModel model)//ok
        //{
        //    ReturnDepartmentExcelUploadHead objHeadList = new ReturnDepartmentExcelUploadHead();
        //    //List<SPResponse> objResponseList = new List<SPResponse>();

        //    try
        //    {
        //        LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

        //        if (model == null)
        //        {
        //            ReturnDepartmentExcelUploadHead objHead = new ReturnDepartmentExcelUploadHead
        //            {
        //                resp = false,
        //                msg = "value cannot be null"
        //            };
        //            return objHeadList;
        //        }

        //        ReturnDepartmentExcelUploadHead tempObj = HRM_BL.Department_BL.department_excelupload(model);
        //        List<ReturnDepartmentExcelUploadHead> retList = new List<ReturnDepartmentExcelUploadHead>();

        //        if (tempObj.resp == false)
        //        {
        //            objHeadList = new ReturnDepartmentExcelUploadHead
        //            {
        //                resp = false,
        //                msg = tempObj.msg
        //            };
        //            return objHeadList;
        //        }

        //        if (tempObj.Department != null)
        //        {
        //            foreach (var item in tempObj.Department)
        //            {
        //                item.USER_ID = model.USER_ID;
        //                item.DPT_Status = true;

        //                retList.AddRange(HRM_BL.Department_BL.add_update_department_excel(item));
        //            }

        //            LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, retList);

        //            var temp = retList.Where(a => !a.msg.Contains("kiosk")).Count(a => a.resp == true);

        //            if (temp > 0)
        //            {
        //                objHeadList = new ReturnDepartmentExcelUploadHead
        //                {
        //                    resp = true,
        //                    msg = "Success"
        //                };
        //            }
        //            else
        //            {
        //                objHeadList = new ReturnDepartmentExcelUploadHead
        //                {
        //                    resp = false,
        //                    msg = "Failed"
        //                };

        //            }

        //            objHeadList.FileNameWithPath = tempObj.FileNameWithPath;
        //            objHeadList.FileName = tempObj.FileName;

        //            var tmeps = retList.Where(b => !b.msg.Contains("kiosk") && b.resp == true).Select(a => new departmentresponcemodel_return() { DPT_ID = a.DPT_ID, Message = a.msg }).ToList();
        //            //var tmeps = retList.Where(b => !b.msg.Contains("kiosk") && b.resp == true);
        //            objHeadList.success_departments = tmeps;

        //            var tmepsC = retList.Where(b => !b.msg.Contains("kiosk") && b.resp == false).Select(a => new departmentresponcemodel_return() { DPT_ID = a.DPT_ID, Message = a.msg }).ToList();
        //            objHeadList.failed_departments = tmepsC;
        //        }

        //        LogExcelUploadTracer_Data.Department(objHeadList, model);

        //        LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, objHeadList);

        //        return objHeadList;
        //    }
        //    catch (Exception ex)
        //    {
        //        objHeadList = new ReturnDepartmentExcelUploadHead
        //        {
        //            resp = false,
        //            msg = ex.Message.ToString()
        //        };

        //        objError.WriteLog(0, "DepartmentController", "department_excelupload", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "DepartmentController", "department_excelupload", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "DepartmentController", "department_excelupload", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "DepartmentController", "department_excelupload", "Inner Exception Message: " + ex.InnerException.Message);
        //        }

        //    }
        //    return objHeadList;
        //}
        #endregion moved to ecelupload by V2

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_department(DepartmentModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = HRM_BL.Department_BL.modify_department(item);
                return objHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DepartmentController", "modify_department", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentController", "modify_department", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentController", "modify_department", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentController", "modify_department", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_department(InactiveDepartmentModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = HRM_BL.Department_BL.inactivate_department(item);
                return objHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DepartmentController", "inactivate_department", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentController", "inactivate_department", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentController", "inactivate_department", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentController", "inactivate_department", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objHeadList;
            }




        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturDepartmentModelHead> get_department_all(GetDepartmentAllModel item)//ok
        {
            List<ReturDepartmentModelHead> objHeadList = new List<ReturDepartmentModelHead>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = HRM_BL.Department_BL.get_department_all(item);
                return objHeadList;

            }
            catch (Exception ex)
            {
                ReturDepartmentModelHead objHead = new ReturDepartmentModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DepartmentController", "get_department_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentController", "get_department_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentController", "get_department_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentController", "get_department_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturDepartmentModelHead> get_department_single(GetDepartmentSingleModel item)
        {
            List<ReturDepartmentModelHead> objHeadList = new List<ReturDepartmentModelHead>();
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = HRM_BL.Department_BL.get_department_single(item);
                return objHeadList;
            }
            catch (Exception ex)
            {
                ReturDepartmentModelHead objHead = new ReturDepartmentModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DepartmentController", "get_department_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentController", "get_department_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentController", "get_department_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentController", "get_department_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        #region moved to ecelupload by V2
        //[HttpPost]
        //[Route("[action]")]
        ////[Authorize]
        //[Obsolete]
        //public List<DepartmentExcelUploadModel> loadexcelsample(DepartmentExcelSampleModel item)
        //{
        //    List<DepartmentExcelUploadModel> objHeadList = new List<DepartmentExcelUploadModel>();
        //    try
        //    {
        //        LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "");

        //        string fileNamewithPath = "";
        //        fileNamewithPath = item.FileFullPath;// @"C:\Users\Neelaka.tts\Downloads\RE_HRM-UAT\report dep.xlsx";

        //        if (string.IsNullOrEmpty(fileNamewithPath)) { objHeadList.Add(new DepartmentExcelUploadModel() { }); return objHeadList; }

        //        byte[] fileContent = null;
        //        System.IO.FileStream fs = new System.IO.FileStream(fileNamewithPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
        //        System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fs);
        //        long byteLength = new System.IO.FileInfo(fileNamewithPath).Length;
        //        fileContent = binaryReader.ReadBytes((Int32)byteLength);
        //        fs.Close();
        //        fs.Dispose();
        //        binaryReader.Close();
        //        string base64String = Convert.ToBase64String(fileContent);

        //        objHeadList.Add(new DepartmentExcelUploadModel() { ExcelFileUploaded = fileContent, base64String = base64String });
        //        return objHeadList;
        //    }
        //    catch (Exception ex)
        //    {
        //        //ReturDepartmentModelHead objHead = new ReturDepartmentModelHead
        //        //{
        //        //    resp = false,
        //        //    msg = ex.Message.ToString()
        //        //};
        //        //objHeadList.Add(objHead);

        //        objError.WriteLog(0, "DepartmentController", "loadexcelsample", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "DepartmentController", "loadexcelsample", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "DepartmentController", "loadexcelsample", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "DepartmentController", "loadexcelsample", "Inner Exception Message: " + ex.InnerException.Message);
        //        }


        //    }

        //    return objHeadList;

        //}
        #endregion moved to ecelupload by V2
    }

    public class DepartmentExcelSampleModel
    {
        public string FileFullPath { get; set; }
    }
}








