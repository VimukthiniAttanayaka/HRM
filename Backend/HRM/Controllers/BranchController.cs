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

    public class BranchController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnBranchModelHead> get_Branch_single(Branch model)//ok
        {
            List<ReturnBranchModelHead> objBranchHeadList = new List<ReturnBranchModelHead>();
            //ReturnBranchModelHead obj = new ReturnBranchModelHead() { resp = false, msg = "sfsf" };
            //obj.Branch = new List<ReturnBranchModel>();
            //if (model.MDB_BranchID == "CAS")
            //    obj.Branch.Add(new ReturnBranchModel() { MDB_BranchID = "CAS", MDB_Branch = "Casual", MDB_Status = true });
            //if (model.MDB_BranchID == "ANU") obj.Branch.Add(new ReturnBranchModel() { MDB_BranchID = "ANU", MDB_Branch = "Annual", MDB_Status = true });
            //if (model.MDB_BranchID == "MED") obj.Branch.Add(new ReturnBranchModel() { MDB_BranchID = "MED", MDB_Branch = "Medical", MDB_Status = true });
            //if (model.MDB_BranchID == "MAT") obj.Branch.Add(new ReturnBranchModel() { MDB_BranchID = "MAT", MDB_Branch = "Matrinaty", MDB_Status = true });
            //objBranchHeadList.Add(obj);
            //return objBranchHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.Branch_BL.get_Branchs_single(model);

            }
            catch (Exception ex)
            {

                ReturnBranchModelHead objBranchHead = new ReturnBranchModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objBranchHeadList.Add(objBranchHead);

                objError.WriteLog(0, "BranchController", "get_Branch_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "BranchController", "get_Branch_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "BranchController", "get_Branch_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "BranchController", "get_Branch_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objBranchHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnBranchModelHead> get_Branch_all(BranchSearchModel model)//ok
        {
            List<ReturnBranchModelHead> objBranchHeadList = new List<ReturnBranchModelHead>();
            ReturnBranchModelHead obj = new ReturnBranchModelHead() { resp = false, msg = "sfsf" };
            //obj.Branch = new List<ReturnBranchModel>();
            //obj.Branch.Add(new ReturnBranchModel() { MDB_BranchID = "CAS", MDB_Branch = "Casual", MDB_Status = true });
            //obj.Branch.Add(new ReturnBranchModel() { MDB_BranchID = "ANU", MDB_Branch = "Annual", MDB_Status = true });
            //obj.Branch.Add(new ReturnBranchModel() { MDB_BranchID = "MED", MDB_Branch = "Medical", MDB_Status = true });
            //obj.Branch.Add(new ReturnBranchModel() { MDB_BranchID = "MAT", MDB_Branch = "Matrinaty", MDB_Status = true });
            //objBranchHeadList.Add(obj);
            //return objBranchHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.Branch_BL.get_Branch_all(model);

            }
            catch (Exception ex)
            {

                ReturnBranchModelHead objBranchHead = new ReturnBranchModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objBranchHeadList.Add(objBranchHead);

                objError.WriteLog(0, "BranchController", "get_Branch_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "BranchController", "get_Branch_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "BranchController", "get_Branch_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "BranchController", "get_Branch_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objBranchHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_Branch(BranchModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.Branch_BL.add_new_Branch(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objBranchHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objBranchHead);

                objError.WriteLog(0, "BranchController", "add_new_Branch", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "BranchController", "add_new_Branch", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "BranchController", "add_new_Branch", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "BranchController", "add_new_Branch", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_Branch(BranchModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.Branch_BL.modify_Branch(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objBranchHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objBranchHead);

                objError.WriteLog(0, "BranchController", "modify_Branch", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "BranchController", "modify_Branch", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "BranchController", "modify_Branch", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "BranchController", "modify_Branch", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_Branch(InactiveMDBModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            //objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            //return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.Branch_BL.inactivate_Branch(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objBranchHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objBranchHead);

                objError.WriteLog(0, "BranchController", "inactivate_Branch", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "BranchController", "inactivate_Branch", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "BranchController", "inactivate_Branch", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "BranchController", "inactivate_Branch", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}

