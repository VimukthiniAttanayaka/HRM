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
using HRM_BL;

namespace HRM.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    //[BasicAuthorization]
    //[Authorize]

    public class DashboardController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public ProgressGraphReturnResponseModel ProgressGraph(DashboardRequestModel model)//ok
        {
            ProgressGraphReturnResponseModel objHead = new ProgressGraphReturnResponseModel();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                if (model == null)
                {
                    objHead = new ProgressGraphReturnResponseModel
                    {
                        resp = false,
                        msg = "value cannot be null"
                    };
                    return objHead;
                }

                objHead = DashboardBL.ProgressGraph(model);

                return objHead;
            }
            catch (Exception ex)
            {
                objHead = new ProgressGraphReturnResponseModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };

                objError.WriteLog(0, "DashboardController", "ProgressGraph", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DashboardController", "ProgressGraph", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DashboardController", "ProgressGraph", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DashboardController", "ProgressGraph", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHead;
        }

    }
}








