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
using AspNetCore.Reporting;
using System.Drawing.Printing;
using Microsoft.Reporting.WebForms;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using HRM_DAL.Models.ResponceModels;
using HRM_DAL.Models.RequestModels;
using HRM_DAL.Data;
//using static error_handler.InformationLog;

namespace HRM.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    //[BasicAuthorization]
    //[Authorize]

    public class ReportsController : ControllerBase
    {
        private LogError objError = new LogError();

        //Postal Expenses(Ordinary and Registered)
        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReportsReturnResponse> PostalExpenses(PortalExpensesRequestModel model)
        {
            List<ReportsReturnResponse> objUserHeadList = new List<ReportsReturnResponse>();

            try
            {
                if (model.DateTo < model.DateFrom)
                {
                    ReportsReturnResponse objUserHead = new ReportsReturnResponse
                    {
                        resp = false,
                        msg = "Invalid Date Range"
                    };
                    objUserHeadList.Add(objUserHead);

                    return objUserHeadList;
                }
                return HRM_BL.Reports_BL.PostalExpenses(model);
            }
            catch (Exception ex)
            {
                ReportsReturnResponse objUserHead = new ReportsReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "ReportsController", "PostalExpenses", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ReportsController", "PostalExpenses", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ReportsController", "PostalExpenses", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ReportsController", "PostalExpenses", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objUserHeadList;
        }

        //Courier Expenses
        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReportsReturnResponse> CourierExpenses(CourierExpensesRequestModel model)
        {
            List<ReportsReturnResponse> objUserHeadList = new List<ReportsReturnResponse>();

            try
            {
                if (model.DateTo < model.DateFrom)
                {
                    ReportsReturnResponse objUserHead = new ReportsReturnResponse
                    {
                        resp = false,
                        msg = "Invalid Date Range"
                    };
                    objUserHeadList.Add(objUserHead);

                    return objUserHeadList;
                }
                return HRM_BL.Reports_BL.CourierExpenses(model);
            }
            catch (Exception ex)
            {
                ReportsReturnResponse objUserHead = new ReportsReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "ReportsController", "CourierExpenses", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ReportsController", "CourierExpenses", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ReportsController", "CourierExpenses", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ReportsController", "CourierExpenses", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objUserHeadList;
        }

        //Outgoing Mail Expenses by PC Code
        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReportsReturnResponse> OutgoingMailExpensesbyPCCodes(OutgoingMailExpensesRequestModel model)
        {
            List<ReportsReturnResponse> objUserHeadList = new List<ReportsReturnResponse>();

            try
            {
                if (model.DateTo < model.DateFrom)
                {
                    ReportsReturnResponse objUserHead = new ReportsReturnResponse
                    {
                        resp = false,
                        msg = "Invalid Date Range"
                    };
                    objUserHeadList.Add(objUserHead);

                    return objUserHeadList;
                }
                return HRM_BL.Reports_BL.OutgoingMailExpensesbyPCCodes(model);
            }
            catch (Exception ex)
            {
                ReportsReturnResponse objUserHead = new ReportsReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "ReportsController", "OutgoingMailExpensesbyPCCodes", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ReportsController", "OutgoingMailExpensesbyPCCodes", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ReportsController", "OutgoingMailExpensesbyPCCodes", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ReportsController", "OutgoingMailExpensesbyPCCodes", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objUserHeadList;
        }

        //Mailbag Daily Activity Report
        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReportsReturnResponse> MailbagDailyActivityReports(MailbagDailyActivityRequestModel model)
        {
            List<ReportsReturnResponse> objUserHeadList = new List<ReportsReturnResponse>();

            try
            {
                return HRM_BL.Reports_BL.MailbagDailyActivityReports(model);
            }
            catch (Exception ex)
            {
                ReportsReturnResponse objUserHead = new ReportsReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "ReportsController", "MailbagDailyActivityReports", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ReportsController", "MailbagDailyActivityReports", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ReportsController", "MailbagDailyActivityReports", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ReportsController", "MailbagDailyActivityReports", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objUserHeadList;
        }

        //Mailbag Daily Activity Report
        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReportsReturnResponse> MailbagDailyActivityReports_V1(MailbagDailyActivityRequestModel_V1 model)
        {
            List<ReportsReturnResponse> objUserHeadList = new List<ReportsReturnResponse>();

            try
            {
                return HRM_BL.Reports_BL.MailbagDailyActivityReports_V1(model);
            }
            catch (Exception ex)
            {
                ReportsReturnResponse objUserHead = new ReportsReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "ReportsController", "MailbagDailyActivityReports_V1", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ReportsController", "MailbagDailyActivityReports_V1", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ReportsController", "MailbagDailyActivityReports_V1", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ReportsController", "MailbagDailyActivityReports_V1", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objUserHeadList;
        }



        //private void SyncWithHRMKiosk()
        //{
        //    try
        //    {
        //        int maxTransCount = ConfigCaller.SyncWithHRMKiosk_maxTransCount;
        //        string userId = ConfigCaller.SyncWithHRMKiosk_UserID;
        //        int syncStatus = 1;
        //        string reqTransType = "Get_MailBagTrans";

        //        HRMToken.Rootobject tok = HRM_APICaller_Data.GetToken();
        //        HRM_MailBag.Rootobject bag = HRM_APICaller_Data.GetMailbagTransactions(tok, maxTransCount);

        //        MailBagTransDto MailBagTransData = new MailBagTransDto()
        //        {
        //            message = bag.message,
        //            messageId = bag.messageId,
        //            result = new MailBagTransResult()
        //            {
        //                reqTransReferenceId = bag.result.reqTransReferenceId,
        //                mailBagTrans = bag.result.mailBagTrans
        //            }
        //        };

        //        List<MailBagTransDto> response = HRM_BL.HRM_BL.add_new_mailbag_trans(userId, MailBagTransData);

        //        Ack_MailBagTrans_RequestModel model_Ack = new Ack_MailBagTrans_RequestModel()
        //        {
        //            reqTransReferenceId = MailBagTransData.result.reqTransReferenceId,
        //            maxTransCount = maxTransCount,
        //            reqTransType = reqTransType,
        //            syncStatus = syncStatus
        //        };
        //        var respResult = HRM_APICaller_Data.AckMailbagTransactions(tok, model_Ack);
        //    }
        //    catch (Exception ex)
        //    {
        //        objError.WriteLog(0, "ReportsController", "SyncWithHRMKiosk", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "ReportsController", "SyncWithHRMKiosk", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "ReportsController", "SyncWithHRMKiosk", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "ReportsController", "SyncWithHRMKiosk", "Inner Exception Message: " + ex.InnerException.Message);
        //        }
        //    }
        //}

        //Mailbag Summary Report – Monthly
        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReportsReturnResponse> MailbagSummaryReportMonthly(MailbagSummaryMonthlyRequestModel model)
        {
            List<ReportsReturnResponse> objUserHeadList = new List<ReportsReturnResponse>();

            try
            {
                if (model.DateTo < model.DateFrom)
                {
                    ReportsReturnResponse objUserHead = new ReportsReturnResponse
                    {
                        resp = false,
                        msg = "Invalid Date Range"
                    };
                    objUserHeadList.Add(objUserHead);

                    return objUserHeadList;
                }
                return HRM_BL.Reports_BL.MailbagSummaryReportMonthly(model);
            }
            catch (Exception ex)
            {
                ReportsReturnResponse objUserHead = new ReportsReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "ReportsController", "MailbagSummaryReportMonthly", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ReportsController", "MailbagSummaryReportMonthly", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ReportsController", "MailbagSummaryReportMonthly", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ReportsController", "MailbagSummaryReportMonthly", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objUserHeadList;
        }


        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReportsReturnResponse> MailbagSummaryReportMonthly_V1(MailbagSummaryMonthlyRequestModel model)
        {
            List<ReportsReturnResponse> objUserHeadList = new List<ReportsReturnResponse>();

            try
            {
                if (model.DateTo < model.DateFrom)
                {
                    ReportsReturnResponse objUserHead = new ReportsReturnResponse
                    {
                        resp = false,
                        msg = "Invalid Date Range"
                    };
                    objUserHeadList.Add(objUserHead);
                    
                    return objUserHeadList;
                }
                return HRM_BL.Reports_BL.MailbagSummaryReportMonthly_V1(model);
            }
            catch (Exception ex)
            {
                ReportsReturnResponse objUserHead = new ReportsReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "ReportsController", "MailbagSummaryReportMonthly_V1", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ReportsController", "MailbagSummaryReportMonthly_V1", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ReportsController", "MailbagSummaryReportMonthly_V1", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ReportsController", "MailbagSummaryReportMonthly_V1", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objUserHeadList;
        }

        //Kiosk Activity Report
        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReportsReturnResponse> KioskActivityReport(KioskActivityRequestModel model)
        {
            List<ReportsReturnResponse> objUserHeadList = new List<ReportsReturnResponse>();

            try
            {
                if (model.DateTo < model.DateFrom)
                {
                    ReportsReturnResponse objUserHead = new ReportsReturnResponse
                    {
                        resp = false,
                        msg = "Invalid Date Range"
                    };
                    objUserHeadList.Add(objUserHead);

                    return objUserHeadList;
                }
                return HRM_BL.Reports_BL.KioskActivityReport(model);
            }
            catch (Exception ex)
            {
                ReportsReturnResponse objUserHead = new ReportsReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "ReportsController", "KioskActivityReport", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ReportsController", "KioskActivityReport", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ReportsController", "KioskActivityReport", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ReportsController", "KioskActivityReport", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objUserHeadList;
        }

        //Kiosk Activity Report
        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReportsReturnResponse> PrintContainerLabelWithQRSticker(PrintContainerRequestModel model)
        {
            List<ReportsReturnResponse> objUserHeadList = new List<ReportsReturnResponse>();

            try
            {
                return HRM_BL.Reports_BL.PrintContainerLabelWithQRSticker(model);
            }
            catch (Exception ex)
            {
                ReportsReturnResponse objUserHead = new ReportsReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "ReportsController", "PrintContainerLabelWithQRSticker", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ReportsController", "PrintContainerLabelWithQRSticker", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ReportsController", "PrintContainerLabelWithQRSticker", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ReportsController", "PrintContainerLabelWithQRSticker", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objUserHeadList;
        }
     
        //private void SyncWithHRMKiosk()
        //{
        //    try
        //    {
        //        int maxTransCount = ConfigCaller.SyncWithHRMKiosk_maxTransCount;
        //        string userId = ConfigCaller.SyncWithHRMKiosk_UserID;
        //        int syncStatus = 1;
        //        string reqTransType = "Get_MailBagTrans";

        //        HRMToken.Rootobject tok = HRM_APICaller_Data.GetToken();
        //        HRM_MailBag.Rootobject bag = HRM_APICaller_Data.GetMailbagTransactions(tok, maxTransCount);

        //        MailBagTransDto MailBagTransData = new MailBagTransDto()
        //        {
        //            message = bag.message,
        //            messageId = bag.messageId,
        //            result = new MailBagTransResult()
        //            {
        //                reqTransReferenceId = bag.result.reqTransReferenceId,
        //                mailBagTrans = bag.result.mailBagTrans
        //            }
        //        };

        //        List<MailBagTransDto> response = HRM_BL.HRM_BL.add_new_mailbag_trans(userId, MailBagTransData);

        //        Ack_MailBagTrans_RequestModel model_Ack = new Ack_MailBagTrans_RequestModel()
        //        {
        //            reqTransReferenceId = MailBagTransData.result.reqTransReferenceId,
        //            maxTransCount = maxTransCount,
        //            reqTransType = reqTransType,
        //            syncStatus = syncStatus
        //        };
        //        var respResult = HRM_APICaller_Data.AckMailbagTransactions(tok, model_Ack);
        //    }
        //    catch (Exception ex)
        //    {
        //        objError.WriteLog(0, "ReportsController", "SyncWithHRMKiosk", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "ReportsController", "SyncWithHRMKiosk", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "ReportsController", "SyncWithHRMKiosk", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "ReportsController", "SyncWithHRMKiosk", "Inner Exception Message: " + ex.InnerException.Message);
        //        }
        //    }
        //}

        //Mailbag Summary Report – Monthly
        //POST api/<UserController>
    }

}








