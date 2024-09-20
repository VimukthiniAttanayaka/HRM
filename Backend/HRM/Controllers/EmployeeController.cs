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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Threading.Tasks;
using Org.BouncyCastle.Utilities;
using static iTextSharp.text.pdf.AcroFields;

namespace HRM.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    //[BasicAuthorization]
    //[Authorize]

    public class EmployeeController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnEmployeeModelHead> get_employee_single(Employee model)//ok
        {
            List<ReturnEmployeeModelHead> objemployeeHeadList = new List<ReturnEmployeeModelHead>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.Employee_BL.get_employees_single(model);

            }
            catch (Exception ex)
            {

                ReturnEmployeeModelHead objemployeeHead = new ReturnEmployeeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objemployeeHeadList.Add(objemployeeHead);

                objError.WriteLog(0, "employeeController", "get_employee_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "employeeController", "get_employee_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "employeeController", "get_employee_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "employeeController", "get_employee_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objemployeeHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnEmployeeModelHead> get_employee_all(EmployeeSearchModel model)//ok
        {
            List<ReturnEmployeeModelHead> objemployeeHeadList = new List<ReturnEmployeeModelHead>();
            //ReturnEmployeeModelHead obj = new ReturnEmployeeModelHead() { resp = false, msg = "sfsf" };
            //obj.Employee = new List<ReturnEmployeeModel>();
            //obj.Employee.Add(new ReturnEmployeeModel() { EME_PrefferedName = "test", EME_EmployeeID = "test" });
            //obj.Employee.Add(new ReturnEmployeeModel() { EME_PrefferedName = "test1", EME_EmployeeID = "test1" });
            //obj.Employee.Add(new ReturnEmployeeModel() { EME_PrefferedName = "test2", EME_EmployeeID = "test2" });
            //objemployeeHeadList.Add(obj);
            //return objemployeeHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.Employee_BL.get_employee_all(model);

            }
            catch (Exception ex)
            {

                ReturnEmployeeModelHead objemployeeHead = new ReturnEmployeeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objemployeeHeadList.Add(objemployeeHead);

                objError.WriteLog(0, "employeeController", "get_employee_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "employeeController", "get_employee_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "employeeController", "get_employee_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "employeeController", "get_employee_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objemployeeHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> add_new_employee(EmployeeModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.Employee_BL.add_new_employee(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objemployeeHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objemployeeHead);

                objError.WriteLog(0, "employeeController", "add_new_employee", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "employeeController", "add_new_employee", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "employeeController", "add_new_employee", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "employeeController", "add_new_employee", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> modify_employee(EmployeeModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.Employee_BL.modify_employee(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objemployeeHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objemployeeHead);

                objError.WriteLog(0, "employeeController", "modify_employee", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "employeeController", "modify_employee", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "employeeController", "modify_employee", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "employeeController", "modify_employee", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_employee(InactiveEmpModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            //objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            //return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.Employee_BL.inactivate_employee(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objemployeeHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objemployeeHead);

                objError.WriteLog(0, "employeeController", "inactivate_employee", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "employeeController", "inactivate_employee", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "employeeController", "inactivate_employee", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "employeeController", "inactivate_employee", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }


        public static ImageModel frncv { get; set; }
        public static ImageModel frnnic { get; set; }
        public static ImageModel frnprofileImage { get; set; }
        public static ImageModel frnpassport { get; set; }
        public static ImageModel frndrivingLicense { get; set; }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> PostImage(IFormFile cv, IFormFile nic, IFormFile profileImage, IFormFile passport, IFormFile drivingLicense)
        {
            if (cv != null && cv.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await cv.CopyToAsync(memoryStream);
                    var imageBytes = memoryStream.ToArray();

                    // Save image bytes to database
                    var imageModel = new ImageModel { ImageData = imageBytes };
                    frncv = imageModel;
                }
            }
            if (nic != null && nic.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await nic.CopyToAsync(memoryStream);
                    var imageBytes = memoryStream.ToArray();

                    // Save image bytes to database
                    var imageModel = new ImageModel { ImageData = imageBytes };
                    frnnic = imageModel;
                }
            }
            if (profileImage != null && profileImage.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await profileImage.CopyToAsync(memoryStream);
                    var imageBytes = memoryStream.ToArray();

                    // Save image bytes to database
                    var imageModel = new ImageModel { ImageData = imageBytes };
                    frnprofileImage = imageModel;
                }
            }
            if (passport != null && passport.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await passport.CopyToAsync(memoryStream);
                    var imageBytes = memoryStream.ToArray();

                    // Save image bytes to database
                    var imageModel = new ImageModel { ImageData = imageBytes };
                    frnpassport = imageModel;
                }
            }
            if (drivingLicense != null && drivingLicense.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await drivingLicense.CopyToAsync(memoryStream);
                    var imageBytes = memoryStream.ToArray();

                    // Save image bytes to database
                    var imageModel = new ImageModel { ImageData = imageBytes };
                    frndrivingLicense = imageModel;
                }
            }
            //{
            //    return BadRequest("cv is required");
            //} 

            // Convert image to byte array
            //using (var memoryStream = new MemoryStream()) { 


            //    await image.CopyToAsync(memoryStream);
            //    var imageBytes = memoryStream.ToArray();


            //    // Save image bytes to database
            //    var imageModel = new ImageModel { ImageData = imageBytes };
            //    //var s = image.Name;
            //    //var s1 = image.FileName;
            //    //if(image.type)
            //    //_context.Images.Add(imageModel);
            //    //await _context.SaveChangesAsync();
            //}

            return Ok("Image uploaded successfully");
        }
        [HttpPost]
        [Route("[action]")]
        public List<ReturncustResponse> uploadAttachment(Employee model)
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();
            //var emp = model.EME_EmployeeID;
            //string basecv = Convert.ToBase64String(frncv.ImageData);
            List<EmployeeAttachmentModel> attachmentList = new List<EmployeeAttachmentModel>();
            EmployeeAttachmentModel attachmentModel = null;
            if (frncv != null || frncv.ImageData != null)
            {
                attachmentModel = new EmployeeAttachmentModel
                {
                    USRED_EmployeeID = model.EME_EmployeeID,
                    USRED_DocumentData = Convert.ToBase64String(frncv.ImageData),
                    USRED_DocumentType = "pdf",
                    USRED_DocumentName = "cv",
                    USRED_Status = true
                };
                attachmentList.Add(attachmentModel);
            }
            if (frnnic != null || frnnic.ImageData != null)
            {
                attachmentModel = new EmployeeAttachmentModel
                {
                    USRED_EmployeeID = model.EME_EmployeeID,
                    USRED_DocumentData = Convert.ToBase64String(frnnic.ImageData),
                    USRED_DocumentType = "jpg",
                    USRED_DocumentName = "nic",
                    USRED_Status = true
                };
                attachmentList.Add(attachmentModel);
            }
            if (frnprofileImage != null || frnprofileImage.ImageData != null)
            {
                attachmentModel = new EmployeeAttachmentModel
                {
                    USRED_EmployeeID = model.EME_EmployeeID,
                    USRED_DocumentData = Convert.ToBase64String(frnprofileImage.ImageData),
                    USRED_DocumentType = "jpg",
                    USRED_DocumentName = "profileImage",
                    USRED_Status = true
                };
                attachmentList.Add(attachmentModel);
            }
            if (frnpassport != null || frnpassport.ImageData != null)
            {
                attachmentModel = new EmployeeAttachmentModel
                {
                    USRED_EmployeeID = model.EME_EmployeeID,
                    USRED_DocumentData = Convert.ToBase64String(frnpassport.ImageData),
                    USRED_DocumentType = "jpg",
                    USRED_DocumentName = "passport",
                    USRED_Status = true
                };
                attachmentList.Add(attachmentModel);
            }
            if (frndrivingLicense != null || frndrivingLicense.ImageData != null)
            {
                attachmentModel = new EmployeeAttachmentModel
                {
                    USRED_EmployeeID = model.EME_EmployeeID,
                    USRED_DocumentData = Convert.ToBase64String(frndrivingLicense.ImageData),
                    USRED_DocumentType = "jpg",
                    USRED_DocumentName = "drivingLicense",
                    USRED_Status = true
                };
                attachmentList.Add(attachmentModel);
            }
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, attachmentList);

                return HRM_BL.Employee_BL.upload_employee_documents(attachmentList);

            }
            catch (Exception ex)
            {

                ReturncustResponse objemployeeHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objemployeeHead);

                objError.WriteLog(0, "employeeController", "add_new_employee", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "employeeController", "add_new_employee", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "employeeController", "add_new_employee", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "employeeController", "add_new_employee", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<EmployeeAttachmentModel> get_employeeDocument_all(EmployeeSearchModel model)//ok
        {
            List<EmployeeAttachmentModel> objemployeeHeadList = new List<EmployeeAttachmentModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                objemployeeHeadList = HRM_BL.Employee_BL.get_employeeDocument_all(model);
                foreach (var item in objemployeeHeadList)
                {
                    if (item.USRED_DocumentName == "cv")
                    {
                        frncv = new ImageModel()
                        {
                            ImageData = item.USRED_DocumentDataByte
                        };
                    }
                    if (item.USRED_DocumentName == "nic")
                    {
                        frnnic = new ImageModel()
                        {
                            ImageData = item.USRED_DocumentDataByte
                        };
                    }
                    if (item.USRED_DocumentName == "profileImage")
                    {
                        frnprofileImage = new ImageModel()
                        {
                            ImageData = item.USRED_DocumentDataByte
                        };
                    }
                    if (item.USRED_DocumentName == "passport")
                    {
                        frnpassport = new ImageModel()
                        {
                            ImageData = item.USRED_DocumentDataByte
                        };
                    }
                    if (item.USRED_DocumentName == "drivingLicense")
                    {
                        frndrivingLicense = new ImageModel()
                        {
                            ImageData = item.USRED_DocumentDataByte
                        };
                    }
                }
                return objemployeeHeadList;

            }
            catch (Exception ex)
            {

                EmployeeAttachmentModel objemployeeHead = new EmployeeAttachmentModel
                {
                    //resp = false,
                    //msg = ex.Message.ToString()
                };
                objemployeeHeadList.Add(objemployeeHead);

                objError.WriteLog(0, "employeeController", "get_employee_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "employeeController", "get_employee_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "employeeController", "get_employee_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "employeeController", "get_employee_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objemployeeHeadList;

        }

        public class ImageModel
        {
            public int Id { get; set; }
            public byte[] ImageData { get; set; }
            public string Type { get; set; }
        }
    }

}

