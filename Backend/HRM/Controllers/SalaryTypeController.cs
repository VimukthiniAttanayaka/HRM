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

namespace HRM.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    //[BasicAuthorization]
    //[Authorize]

    public class SalaryTypeController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnSalaryTypeModelHead> get_SalaryType_single(SalaryType model)//ok
        {
            List<ReturnSalaryTypeModelHead> objSalaryTypeHeadList = new List<ReturnSalaryTypeModelHead>();
            //ReturnSalaryTypeModelHead obj = new ReturnSalaryTypeModelHead() { resp = false, msg = "sfsf" };
            //obj.SalaryType = new List<ReturnSalaryTypeModel>();
            //if (model.MDST_SalaryTypeID == "CAS")
            //    obj.SalaryType.Add(new ReturnSalaryTypeModel() { MDST_SalaryTypeID = "CAS", MDST_SalaryType = "Casual", MDST_Status = true });
            //if (model.MDST_SalaryTypeID == "ANU") obj.SalaryType.Add(new ReturnSalaryTypeModel() { MDST_SalaryTypeID = "ANU", MDST_SalaryType = "Annual", MDST_Status = true });
            //if (model.MDST_SalaryTypeID == "MED") obj.SalaryType.Add(new ReturnSalaryTypeModel() { MDST_SalaryTypeID = "MED", MDST_SalaryType = "Medical", MDST_Status = true });
            //if (model.MDST_SalaryTypeID == "MAT") obj.SalaryType.Add(new ReturnSalaryTypeModel() { MDST_SalaryTypeID = "MAT", MDST_SalaryType = "Matrinaty", MDST_Status = true });
            //objSalaryTypeHeadList.Add(obj);
            //return objSalaryTypeHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.SalaryType_BL.get_SalaryTypes_single(model);

            }
            catch (Exception ex)
            {

                ReturnSalaryTypeModelHead objSalaryTypeHead = new ReturnSalaryTypeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objSalaryTypeHeadList.Add(objSalaryTypeHead);

                objError.WriteLog(0, "SalaryTypeController", "get_SalaryType_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "SalaryTypeController", "get_SalaryType_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "SalaryTypeController", "get_SalaryType_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "SalaryTypeController", "get_SalaryType_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objSalaryTypeHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnSalaryTypeModelHead> get_SalaryType_all(SalaryTypeSearchModel model)//ok
        {
            List<ReturnSalaryTypeModelHead> objSalaryTypeHeadList = new List<ReturnSalaryTypeModelHead>();
            //ReturnSalaryTypeModelHead obj = new ReturnSalaryTypeModelHead() { resp = false, msg = "sfsf", RC = 100 };
            //obj.SalaryType = new List<ReturnSalaryTypeModel>();
            //obj.SalaryType.Add(new ReturnSalaryTypeModel() { MDST_SalaryTypeID = "CAS", MDST_SalaryType = "Casual", MDST_Status = true });
            //obj.SalaryType.Add(new ReturnSalaryTypeModel() { MDST_SalaryTypeID = "ANU", MDST_SalaryType = "Annual", MDST_Status = false });
            //obj.SalaryType.Add(new ReturnSalaryTypeModel() { MDST_SalaryTypeID = "MED", MDST_SalaryType = "Medical", MDST_Status = true });
            //obj.SalaryType.Add(new ReturnSalaryTypeModel() { MDST_SalaryTypeID = "MAT", MDST_SalaryType = "Matrinaty", MDST_Status = true });
            //obj.SalaryType.Add(new ReturnSalaryTypeModel() { MDST_SalaryTypeID = "CAS", MDST_SalaryType = "Casual", MDST_Status = true });
            //for (int i = 0; i < 100; i++)
            //{
            //    obj.SalaryType.Add(new ReturnSalaryTypeModel() { MDST_SalaryTypeID = "CAS", MDST_SalaryType = "Casual", MDST_Status = true });

            //}
            //objSalaryTypeHeadList.Add(obj);
            //return objSalaryTypeHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.SalaryType_BL.get_SalaryType_all(model);

            }
            catch (Exception ex)
            {

                ReturnSalaryTypeModelHead objSalaryTypeHead = new ReturnSalaryTypeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objSalaryTypeHeadList.Add(objSalaryTypeHead);

                objError.WriteLog(0, "SalaryTypeController", "get_SalaryType_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "SalaryTypeController", "get_SalaryType_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "SalaryTypeController", "get_SalaryType_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "SalaryTypeController", "get_SalaryType_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objSalaryTypeHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_SalaryType(SalaryTypeModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.SalaryType_BL.add_new_SalaryType(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objSalaryTypeHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objSalaryTypeHead);

                objError.WriteLog(0, "SalaryTypeController", "add_new_SalaryType", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "SalaryTypeController", "add_new_SalaryType", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "SalaryTypeController", "add_new_SalaryType", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "SalaryTypeController", "add_new_SalaryType", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_SalaryType(SalaryTypeModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.SalaryType_BL.modify_SalaryType(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objSalaryTypeHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objSalaryTypeHead);

                objError.WriteLog(0, "SalaryTypeController", "modify_SalaryType", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "SalaryTypeController", "modify_SalaryType", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "SalaryTypeController", "modify_SalaryType", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "SalaryTypeController", "modify_SalaryType", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_SalaryType(InactiveMDSTModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            //objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            //return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.SalaryType_BL.inactivate_SalaryType(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objSalaryTypeHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objSalaryTypeHead);

                objError.WriteLog(0, "SalaryTypeController", "inactivate_SalaryType", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "SalaryTypeController", "inactivate_SalaryType", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "SalaryTypeController", "inactivate_SalaryType", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "SalaryTypeController", "inactivate_SalaryType", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}

