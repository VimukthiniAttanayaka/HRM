using error_handler;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using utility_handler.Data;
using static error_handler.ErrorLog;
//using static error_handler.InformationLog;
using HRM_DAL.Models;
using HRM_DAL.Data;
using HRM_BL;

namespace HRM.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]

    public class LogExcelUploadTracerController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public SearchTracerResponceModel SearchTracer(SearchTracerRequestModel item)//ok
        {
            SearchTracerResponceModel objCUserHeadList = new SearchTracerResponceModel();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objCUserHeadList = LogExcelUploadTracer_BL.SearchTracer(item);

                return objCUserHeadList;
            }
            catch (Exception ex)
            {
                objCUserHeadList = new SearchTracerResponceModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };

                objError.WriteLog(0, "LogExcelUploadTracerController", "SearchTracer", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LogExcelUploadTracerController", "SearchTracer", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LogExcelUploadTracerController", "SearchTracer", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LogExcelUploadTracerController", "SearchTracer", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCUserHeadList;
        }
    }
}
