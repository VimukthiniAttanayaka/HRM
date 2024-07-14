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
//using static error_handler.InformationLog;

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

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public DeviceAnalysisReturnResponseModel DeviceAnalysis(DashboardRequestModel model)//ok
        {
            DeviceAnalysisReturnResponseModel objHead = new DeviceAnalysisReturnResponseModel();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                if (model == null)
                {
                    objHead = new DeviceAnalysisReturnResponseModel
                    {
                        resp = false,
                        msg = "value cannot be null"
                    };
                    return objHead;
                }

                objHead = DashboardBL.DeviceAnalysis(model);

                return objHead;
            }
            catch (Exception ex)
            {
                objHead = new DeviceAnalysisReturnResponseModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };

                objError.WriteLog(0, "DashboardController", "DeviceAnalysis", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DashboardController", "DeviceAnalysis", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DashboardController", "DeviceAnalysis", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DashboardController", "DeviceAnalysis", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHead;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public OutgoingMailYettoReceiveReturnResponseModel OutgoingMailYettoReceive(DashboardRequestModel model)//ok
        {
            OutgoingMailYettoReceiveReturnResponseModel objHead = new OutgoingMailYettoReceiveReturnResponseModel();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                if (model == null)
                {
                    objHead = new OutgoingMailYettoReceiveReturnResponseModel
                    {
                        resp = false,
                        msg = "value cannot be null"
                    };
                    return objHead;
                }

                objHead = DashboardBL.OutgoingMailYettoReceive(model);

                return objHead;
            }
            catch (Exception ex)
            {
                objHead = new OutgoingMailYettoReceiveReturnResponseModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };

                objError.WriteLog(0, "DashboardController", "OutgoingMailYettoReceive", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DashboardController", "OutgoingMailYettoReceive", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DashboardController", "OutgoingMailYettoReceive", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DashboardController", "OutgoingMailYettoReceive", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHead;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public OutgoingMailYetToProcessReturnResponseModel OutgoingMailYettoProcess(DashboardRequestModel model)//ok
        {
            OutgoingMailYetToProcessReturnResponseModel objHead = new OutgoingMailYetToProcessReturnResponseModel();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                if (model == null)
                {
                    objHead = new OutgoingMailYetToProcessReturnResponseModel
                    {
                        resp = false,
                        msg = "value cannot be null"
                    };
                    return objHead;
                }

                objHead = DashboardBL.OutgoingMailYettoProcess(model);

                return objHead;
            }
            catch (Exception ex)
            {
                objHead = new OutgoingMailYetToProcessReturnResponseModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };

                objError.WriteLog(0, "DashboardController", "OutgoingMailYettoProcess", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DashboardController", "OutgoingMailYettoProcess", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DashboardController", "OutgoingMailYettoProcess", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DashboardController", "OutgoingMailYettoProcess", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHead;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public ReturnMailPendingCustomerConfirmationReturnResponseModel ReturnMailPendingCustomerConfirmation(DashboardRequestModel model)//ok
        {
            ReturnMailPendingCustomerConfirmationReturnResponseModel objHead = new ReturnMailPendingCustomerConfirmationReturnResponseModel();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                if (model == null)
                {
                    objHead = new ReturnMailPendingCustomerConfirmationReturnResponseModel
                    {
                        resp = false,
                        msg = "value cannot be null"
                    };
                    return objHead;
                }

                objHead = DashboardBL.ReturnMailPendingCustomerConfirmation(model);

                return objHead;
            }
            catch (Exception ex)
            {
                objHead = new ReturnMailPendingCustomerConfirmationReturnResponseModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };

                objError.WriteLog(0, "DashboardController", "ReturnMailPendingCustomerConfirmation", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DashboardController", "ReturnMailPendingCustomerConfirmation", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DashboardController", "ReturnMailPendingCustomerConfirmation", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DashboardController", "ReturnMailPendingCustomerConfirmation", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHead;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public MailDiscrepancyPendingCustomerResponseReturnResponseModel MailDiscrepancyPendingCustomerResponse(DashboardRequestModel model)//ok
        {
            MailDiscrepancyPendingCustomerResponseReturnResponseModel objHead = new MailDiscrepancyPendingCustomerResponseReturnResponseModel();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                if (model == null)
                {
                    objHead = new MailDiscrepancyPendingCustomerResponseReturnResponseModel
                    {
                        resp = false,
                        msg = "value cannot be null"
                    };
                    return objHead;
                }

                objHead = DashboardBL.MailDiscrepancyPendingCustomerResponse(model);

                return objHead;
            }
            catch (Exception ex)
            {
                objHead = new MailDiscrepancyPendingCustomerResponseReturnResponseModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };

                objError.WriteLog(0, "DashboardController", "MailDiscrepancyPendingCustomerResponse", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DashboardController", "MailDiscrepancyPendingCustomerResponse", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DashboardController", "MailDiscrepancyPendingCustomerResponse", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DashboardController", "MailDiscrepancyPendingCustomerResponse", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHead;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public DashboardAlertResponseModel Alerts(DashboardRequestModel model)//ok
        {
            DashboardAlertResponseModel objHead = new DashboardAlertResponseModel();
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                if (model == null)
                {
                    objHead = new DashboardAlertResponseModel
                    {
                        resp = false,
                        msg = "value cannot be null"
                    };
                    return objHead;
                }

                objHead = DashboardBL.Alerts(model);


                //- Receive exception emails from customer staff -We will attend to this as soon as possible
                //- Not done Mailbag trips(if contract time exceeds the current time and not data sync to the MT yet) -We will attend to this as soon as possible.
                //- Kiosk door not close >> from Get Device Activities API - Currently, the Get Device Activities API is not returning a result.We will attend to that part when the API is working.
                //- Unopen bags >> from Get Device Activities API - Currently, the Get Device Activities API is not returning a result.We will attend to that part when the API is working.

                return objHead;
            }
            catch (Exception ex)
            {
                objHead = new DashboardAlertResponseModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };

                objError.WriteLog(0, "DashboardController", "Alerts", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DashboardController", "Alerts", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DashboardController", "Alerts", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DashboardController", "Alerts", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHead;
        }
    }
}








