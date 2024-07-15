﻿using HRM_DAL.Models;
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
     
    }

}








