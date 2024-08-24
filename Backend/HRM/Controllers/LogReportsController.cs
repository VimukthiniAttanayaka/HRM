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

    public class LogReportsController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnAccessGroupModelHead> get_UerLogReport(AccessGroup model)//ok
        {
            List<ReturnAccessGroupModelHead> objAccessGroupHeadList = new List<ReturnAccessGroupModelHead>();
            ReturnAccessGroupModelHead obj = new ReturnAccessGroupModelHead() { resp = false, msg = "sfsf" };
            obj.AccessGroup = new List<ReturnAccessGroupModel>();
            List<AccessGroupSelect> AccessGroups = new List<AccessGroupSelect>();
            AccessGroups.Add(new AccessGroupSelect() { value = "CAS", label = "CAS", Ischecked = true });
            AccessGroups.Add(new AccessGroupSelect() { value = "ANU", label = "ANU", Ischecked = true });
            AccessGroups.Add(new AccessGroupSelect() { value = "MED", label = "MED", Ischecked = true });


            obj.AccessGroup.Add(new ReturnAccessGroupModel() { UAG_AccessGroupID = "CAS", UAG_AccessGroup = "Casual", UAG_Status = true, AccessGroups = AccessGroups });
            obj.AccessGroup.Add(new ReturnAccessGroupModel() { UAG_AccessGroupID = "ANU", UAG_AccessGroup = "Annual", UAG_Status = true, AccessGroups = AccessGroups });
            obj.AccessGroup.Add(new ReturnAccessGroupModel() { UAG_AccessGroupID = "MED", UAG_AccessGroup = "Medical", UAG_Status = true, AccessGroups = AccessGroups });
            obj.AccessGroup.Add(new ReturnAccessGroupModel() { UAG_AccessGroupID = "MAT", UAG_AccessGroup = "Matrinaty", UAG_Status = true, AccessGroups = AccessGroups });

            obj.AccessGroup.Add(new ReturnAccessGroupModel() { UAG_AccessGroupID = "MAT", UAG_AccessGroup = "Matrinaty", UAG_Status = true, AccessGroups = AccessGroups });

            objAccessGroupHeadList.Add(obj);
            return objAccessGroupHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.AccessGroup_BL.get_AccessGroups_single(model);

            }
            catch (Exception ex)
            {

                ReturnAccessGroupModelHead objAccessGroupHead = new ReturnAccessGroupModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objAccessGroupHeadList.Add(objAccessGroupHead);

                objError.WriteLog(0, "LogReportsController", "get_AccessGroup_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LogReportsController", "get_AccessGroup_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LogReportsController", "get_AccessGroup_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LogReportsController", "get_AccessGroup_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objAccessGroupHeadList;

        }
    }
}
