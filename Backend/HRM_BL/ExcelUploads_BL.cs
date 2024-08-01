using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using HRM_DAL.Data;
using System;
using System.Linq;


namespace HRM_BL
{
    public class ExcelUploads_BL
    {
        private static LogError objError = new LogError();

        public class User_Related
        {
            public static ReturUserExcelUploadHead user_excelupload(UserExcelUploadModel model)
            {
                return HRM_DAL.Data.ExcelUploads_Data.User_Related.user_excelupload(model);
            }

            public static List<ReturUserExcelUploadHead> add_update_user_excel(UserModel model)
            {
                return HRM_DAL.Data.ExcelUploads_Data.User_Related.add_update_user_excel(model);
            }

            public static void markall_users_excel_inactive(UserExcelUploadModel model)
            {
                HRM_DAL.Data.ExcelUploads_Data.User_Related.markall_users_excel_inactive(model);
            }
        }
    
    }
}