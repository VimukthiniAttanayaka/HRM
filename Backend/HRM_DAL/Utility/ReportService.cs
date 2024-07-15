using AspNetCore.Reporting;
using error_handler;
using HRM.Controllers;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HRM_DAL.Data
{
    public class ReportService : IReportService
    {
        private static LogError objError = new LogError();

        public ReportService()
        {
        }

        public LocalReport SetupReport(string reportName)
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                Encoding.GetEncoding("windows-1252");
                string RDLCReportPath = ConfigCaller.RDLCReportPath;
                string rdlcFilePath = RDLCReportPath + "\\" + reportName + ".RDLC";
                objError.WriteLog(0, "ReportService", "SetupReport", "Report File Path: " + rdlcFilePath);

                LocalReport report = new LocalReport(rdlcFilePath);
                return report;
            }
            catch (Exception ex)
            {
                objError.WriteLog(0, "ReportService", "SetupReport", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ReportService", "SetupReport", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ReportService", "SetupReport", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ReportService", "SetupReport", "Inner Exception Message: " + ex.InnerException.Message);
                }
                throw;
            }
        }

        /*   public byte[] GenerateReportAsync(string reportName)
           {
               Dictionary<string, string> parameters = new Dictionary<string, string>();
               Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
               Encoding.GetEncoding("windows-1252");
               string rdlcFilePath = @"D:\Foreign Projects\HRM_Backend_V1.0\HRM_DAL\LH_PDF_BPInvoice.RDLC";
               LocalReport report = new LocalReport(rdlcFilePath);

               List<UserDto> userList = new List<UserDto>();
               userList.Add(new UserDto
               {
                   FirstName = "Alex",
                   LastName = "Smith",
                   Email = "alex.smith@gmail.com",
                   Phone = "2345334432"
               });

               userList.Add(new UserDto
               {
                   FirstName = "John",
                   LastName = "Legend",
                   Email = "john.legend@gmail.com",
                   Phone = "5633435334"
               });

               userList.Add(new UserDto
               {
                   FirstName = "Stuart",
                   LastName = "Jones",
                   Email = "stuart.jones@gmail.com",
                   Phone = "3575328535"
               });

               report.AddDataSource("AcceptDataSet", userList);
               var result = report.Execute(GetRenderType("pdf"), 1, parameters);
               return result.MainStream;
           }
        */
        public byte[] PrintReport(LocalReport report, Dictionary<string, string> parameters, string reportType)
        {
            try
            {
                var result = report.Execute(GetRenderType(reportType), 1, parameters);
                return result.MainStream;
            }
            catch (Exception ex)
            {
                objError.WriteLog(0, "ReportService", "PrintReport", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ReportService", "PrintReport", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ReportService", "PrintReport", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ReportService", "PrintReport", "Inner Exception Message: " + ex.InnerException.Message);
                }
                throw;
            }
        }

        private static RenderType GetRenderType(string reportType)
        {
            if (string.IsNullOrEmpty(reportType)) reportType = "pdf";

            var renderType = RenderType.Pdf;
            switch (reportType.ToLower())
            {
                default:
                case "pdf":
                    renderType = RenderType.Pdf;
                    break;
                case "word":
                    renderType = RenderType.Word;
                    break;
                case "excel":
                    renderType = RenderType.Excel;
                    break;
            }

            return renderType;
        }
        public static string GetFileFormat(string reportType)
        {
            if (string.IsNullOrEmpty(reportType)) reportType = "pdf";

            var renderType = "Pdf";
            switch (reportType.ToLower())
            {
                default:
                case "pdf":
                    renderType = "Pdf";
                    break;
                case "word":
                    renderType = "doc";
                    break;
                case "excel":
                    renderType = "xls";
                    break;
            }

            return renderType;
        }
    }
}
