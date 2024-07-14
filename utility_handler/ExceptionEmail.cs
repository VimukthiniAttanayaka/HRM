using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Web.Script.Serialization;
using Kioski_APIChecker_DL;
using static Kioski_APIChecker_DL.CallAPI_OutlookEmail;

namespace ExceptionEmailHandler_DL
{
    public class ExceptionEmail
    {
        public List<ReturnResponse> RunProcess()
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();

            try
            {
                //LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, new ReturnResponse() { });

                objHeadList = HRM_BL.OutgoingMailExceptionHandling_BL.RunProcess();

                return objHeadList;

            }
            catch (Exception ex)
            {
                ExceptionEmailHandler_Data.WriteLog("RunProcess", "Fail " + ex.Message + " - " + ex.StackTrace);
            }

            return objHeadList;

        }

        public List<ReturnResponse> MainFlow1(List<ExceptionMailReaderTable> mailList)//triggering from emailread winsvc
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();

            try
            {
                //LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, new ReturnResponse() { });

                objHeadList = HRM_BL.OutgoingMailExceptionHandling_BL.MainFlow1(mailList);

                return objHeadList;

            }
            catch (System.Exception ex)
            {

                ExceptionEmailHandler_Data.WriteLog("MainFlow1", "Fail " + ex.Message + " - " + ex.StackTrace);
            }

            return objHeadList;
        }
    }
}