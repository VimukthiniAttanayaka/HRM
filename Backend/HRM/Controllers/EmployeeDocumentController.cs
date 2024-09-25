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

    public class EmployeeDocumentController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnEmployeeDocumentModelHead> get_employeedocument_single(EmployeeDocument model)//ok
        {
            List<ReturnEmployeeDocumentModelHead> objemployeeHeadList = new List<ReturnEmployeeDocumentModelHead>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.EmployeeDocument_BL.get_employeeDocument_single(model);
                
            }
            catch (Exception ex)
            {

                ReturnEmployeeDocumentModelHead objemployeeHead = new ReturnEmployeeDocumentModelHead
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
        public List<ReturnEmployeeDocumentModelHead> get_employeedocument_all(EmployeeDocumentSearchModel model)//ok
        {
            List<ReturnEmployeeDocumentModelHead> objemployeeHeadList = new List<ReturnEmployeeDocumentModelHead>();
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

                return HRM_BL.EmployeeDocument_BL.get_employeeDocument_all(model);

            }
            catch (Exception ex)
            {

                ReturnEmployeeDocumentModelHead objemployeeHead = new ReturnEmployeeDocumentModelHead
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
        public List<ReturnResponse> add_new_employeedocument(EmployeeDocumentModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.EmployeeDocument_BL.add_new_employeedocument(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objemployeeHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objemployeeHead);

                objError.WriteLog(0, "employeeController", "add_new_employeedocument", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "employeeController", "add_new_employeedocument", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "employeeController", "add_new_employeedocument", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "employeeController", "add_new_employeedocument", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        ////POST api/<UserController>
        //[HttpPost]
        //[Route("[action]")]
        ////[Authorize]
        //public List<ReturnResponse> modify_employeedocument(EmployeeDocumentModel item)//ok
        //{
        //    List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

        //    try
        //    {
        //        LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

        //        return HRM_BL.EmployeeDocument_BL.modify_employeedocument(item);

        //    }
        //    catch (Exception ex)
        //    {

        //        ReturnResponse objemployeeHead = new ReturnResponse
        //        {
        //            resp = false,
        //            msg = ex.Message.ToString()
        //        };
        //        objCustHeadList.Add(objemployeeHead);

        //        objError.WriteLog(0, "employeeController", "modify_employeedocument", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "employeeController", "modify_employeedocument", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "employeeController", "modify_employeedocument", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "employeeController", "modify_employeedocument", "Inner Exception Message: " + ex.InnerException.Message);
        //        }


        //    }

        //    return objCustHeadList;
        //}

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_employeedocument(InactiveEEDModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            //objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            //return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.EmployeeDocument_BL.inactivate_employeedocument(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objemployeeHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objemployeeHead);

                objError.WriteLog(0, "employeeController", "inactivate_employeedocument", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "employeeController", "inactivate_employeedocument", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "employeeController", "inactivate_employeedocument", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "employeeController", "inactivate_employeedocument", "Inner Exception Message: " + ex.InnerException.Message);
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
        public List<ReturnResponse> uploadAttachment(Employee model)
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();
            //var emp = model.EME_EmployeeID;
            //string basecv = Convert.ToBase64String(frncv.ImageData);
            List<EmployeeDocumentModel> attachmentList = new List<EmployeeDocumentModel>();
            EmployeeDocumentModel attachmentModel = null;
            if (frncv != null && frncv.ImageData != null)
            {
                attachmentModel = new EmployeeDocumentModel
                {
                    EED_EmployeeID = model.EME_EmployeeID,
                    EED_DocumentData = Convert.ToBase64String(frncv.ImageData),
                    EED_DocumentType = "pdf",
                    EED_DocumentName = "cv",
                    EED_Status = true
                };
                attachmentList.Add(attachmentModel);
            }
            if (frnnic != null && frnnic.ImageData != null)
            {
                attachmentModel = new EmployeeDocumentModel
                {
                    EED_EmployeeID = model.EME_EmployeeID,
                    EED_DocumentData = Convert.ToBase64String(frnnic.ImageData),
                    EED_DocumentType = "jpg",
                    EED_DocumentName = "nic",
                    EED_Status = true
                };
                attachmentList.Add(attachmentModel);
            }
            if (frnprofileImage != null && frnprofileImage.ImageData != null)
            {
                attachmentModel = new EmployeeDocumentModel
                {
                    EED_EmployeeID = model.EME_EmployeeID,
                    EED_DocumentData = Convert.ToBase64String(frnprofileImage.ImageData),
                    EED_DocumentType = "jpg",
                    EED_DocumentName = "profileImage",
                    EED_Status = true
                };
                attachmentList.Add(attachmentModel);
            }
            if (frnpassport != null && frnpassport.ImageData != null)
            {
                attachmentModel = new EmployeeDocumentModel
                {
                    EED_EmployeeID = model.EME_EmployeeID,
                    EED_DocumentData = Convert.ToBase64String(frnpassport.ImageData),
                    EED_DocumentType = "jpg",
                    EED_DocumentName = "passport",
                    EED_Status = true
                };
                attachmentList.Add(attachmentModel);
            }
            if (frndrivingLicense != null && frndrivingLicense.ImageData != null)
            {
                attachmentModel = new EmployeeDocumentModel
                {
                    EED_EmployeeID = model.EME_EmployeeID,
                    EED_DocumentData = Convert.ToBase64String(frndrivingLicense.ImageData),
                    EED_DocumentType = "jpg",
                    EED_DocumentName = "drivingLicense",
                    EED_Status = true
                };
                attachmentList.Add(attachmentModel);
            }
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, attachmentList);

                return HRM_BL.EmployeeDocument_BL.upload_employee_documents(attachmentList);

            }
            catch (Exception ex)
            {

                ReturnResponse objemployeeHead = new ReturnResponse
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

        //[HttpPost]
        //[Route("[action]")]
        ////[Authorize]
        //public List<EmployeeDocumentModelHead> get_employeeDocument_all(EmployeeDocumentSearchModel model)//ok
        //{
        //    List<EmployeeDocumentModelHead> objemployeeHeadList = new List<EmployeeDocumentModelHead>();

        //    try
        //    {
        //        LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

        //        objemployeeHeadList = HRM_BL.EmployeeDocument_BL.get_employeeDocument_all(model);
        //        //foreach (var item in objemployeeHeadList)
        //        //{
        //        //    if (item.EED_DocumentName == "cv")
        //        //    {
        //        //        frncv = new ImageModel()
        //        //        {
        //        //            ImageData = item.EED_DocumentDataByte
        //        //        };
        //        //    }
        //        //    if (item.EED_DocumentName == "nic")
        //        //    {
        //        //        frnnic = new ImageModel()
        //        //        {
        //        //            ImageData = item.EED_DocumentDataByte
        //        //        };
        //        //    }
        //        //    if (item.EED_DocumentName == "profileImage")
        //        //    {
        //        //        frnprofileImage = new ImageModel()
        //        //        {
        //        //            ImageData = item.EED_DocumentDataByte
        //        //        };
        //        //    }
        //        //    if (item.EED_DocumentName == "passport")
        //        //    {
        //        //        frnpassport = new ImageModel()
        //        //        {
        //        //            ImageData = item.EED_DocumentDataByte
        //        //        };
        //        //    }
        //        //    if (item.EED_DocumentName == "drivingLicense")
        //        //    {
        //        //        frndrivingLicense = new ImageModel()
        //        //        {
        //        //            ImageData = item.EED_DocumentDataByte
        //        //        };
        //        //    }
        //        //}
        //        return objemployeeHeadList;

        //    }
        //    catch (Exception ex)
        //    {

        //        EmployeeDocumentModelHead objemployeeHead = new EmployeeDocumentModelHead
        //        {
        //            //resp = false,
        //            //msg = ex.Message.ToString()
        //        };
        //        objemployeeHeadList.Add(objemployeeHead);

        //        objError.WriteLog(0, "employeeController", "get_employee_single", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "employeeController", "get_employee_single", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "employeeController", "get_employee_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "employeeController", "get_employee_single", "Inner Exception Message: " + ex.InnerException.Message);
        //        }


        //    }

        //    return objemployeeHeadList;

        //}

        //[HttpPost]
        //[Route("[action]")]
        ////[Authorize]
        //public List<EmployeeDocumentModelHead> get_employeeDocument_single(EmployeeDocumentSearchModel model)//ok
        //{
        //    List<EmployeeDocumentModelHead> objemployeeHeadList = new List<EmployeeDocumentModelHead>();

        //    try
        //    {
        //        LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

        //        objemployeeHeadList = HRM_BL.EmployeeDocument_BL.get_employeeDocument_single(model);
        //        //foreach (var item in objemployeeHeadList)
        //        //{
        //        //    if (item.EED_DocumentName == "cv")
        //        //    {
        //        //        frncv = new ImageModel()
        //        //        {
        //        //            ImageData = item.EED_DocumentDataByte
        //        //        };
        //        //    }
        //        //    if (item.EED_DocumentName == "nic")
        //        //    {
        //        //        frnnic = new ImageModel()
        //        //        {
        //        //            ImageData = item.EED_DocumentDataByte
        //        //        };
        //        //    }
        //        //    if (item.EED_DocumentName == "profileImage")
        //        //    {
        //        //        frnprofileImage = new ImageModel()
        //        //        {
        //        //            ImageData = item.EED_DocumentDataByte
        //        //        };
        //        //    }
        //        //    if (item.EED_DocumentName == "passport")
        //        //    {
        //        //        frnpassport = new ImageModel()
        //        //        {
        //        //            ImageData = item.EED_DocumentDataByte
        //        //        };
        //        //    }
        //        //    if (item.EED_DocumentName == "drivingLicense")
        //        //    {
        //        //        frndrivingLicense = new ImageModel()
        //        //        {
        //        //            ImageData = item.EED_DocumentDataByte
        //        //        };
        //        //    }
        //        //}
        //        return objemployeeHeadList;

        //    }
        //    catch (Exception ex)
        //    {

        //        EmployeeDocumentModelHead objemployeeHead = new EmployeeDocumentModelHead
        //        {
        //            //resp = false,
        //            //msg = ex.Message.ToString()
        //        };
        //        objemployeeHeadList.Add(objemployeeHead);

        //        objError.WriteLog(0, "employeeController", "get_employee_single", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "employeeController", "get_employee_single", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "employeeController", "get_employee_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "employeeController", "get_employee_single", "Inner Exception Message: " + ex.InnerException.Message);
        //        }


        //    }

        //    return objemployeeHeadList;

        //}

        public class ImageModel
        {
            public int Id { get; set; }
            public byte[] ImageData { get; set; }
            public string Type { get; set; }
        }
    }

}

