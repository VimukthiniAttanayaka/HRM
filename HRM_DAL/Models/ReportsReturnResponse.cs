
using System;

namespace HRM_DAL.Models
{
    public class ReportsReturnResponse : ReturnResponse
    {
        public string PDFFilePath { get; set; }
        public string base64String { get; set; }
    }
    public class ReportsReturnResponse_Image : ReportsReturnResponse
    {
        public string ImageFilePath { get;  set; }
        public string base64String { get; set; }
    }
}