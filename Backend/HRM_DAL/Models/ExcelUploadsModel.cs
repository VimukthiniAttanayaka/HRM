using System;
using System.Collections.Generic;

namespace HRM_DAL.Models
{
    public class ExcelUploadBaseModel : RequestBaseModel
    {
        public string USER_ID { get; set; }
        public byte[] ExcelFileUploaded { get; set; }
        public string base64String { get; set; }
        public string DPT_CustomerID { get; set; }
        public bool IsCompleteList { get; set; } = false;
    }

    public class UserExcelUploadModel : ExcelUploadBaseModel
    {
        public string UAG_BusinessUnit { get; set; }
    }

    public class ReturUserExcelUploadHead : ReturnResponse
    {
        public List<UserModel> users { get; set; } = new List<UserModel>();
        public List<userresponcemodel_return> success_users { get; set; } = new List<userresponcemodel_return>();
        public List<userresponcemodel_return> failed_users { get; set; } = new List<userresponcemodel_return>();
        public string FileNameWithPath { get; set; }
        public string FileName { get; set; }
    }

    public class userresponcemodel_return { public string StaffID { get; set; } public string Message { get; set; } }

}
