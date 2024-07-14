using AspNetCore.Reporting;
using System.Collections.Generic;

namespace HRM.Controllers
{
    public interface IReportService
    {
        //byte[] GenerateReportAsync(string reportName);
        LocalReport SetupReport(string reportName);
        byte[] PrintReport(LocalReport report, Dictionary<string, string> parameters, string ExportMode);
    }
}