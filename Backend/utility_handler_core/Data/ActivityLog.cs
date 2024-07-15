using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using utility_handler.Model;
using utility_handler.Utility;
using Microsoft.Extensions.Configuration;

namespace utility_handler.Data
{
    public class ActivityLog
    {
        static IConfigurationRoot config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();

        public static void ActivityLogRequest(string ACTIVITY_DESCRIPTION, string USER_ID) 
        {
            LogError objError = new LogError();
            DateTime CreatedOn = DateTime.Now;
          
            try
            {

                ActivityLogModel Log = new ActivityLogModel()
                {
                    ACTIVITY_DESCRIPTION = ACTIVITY_DESCRIPTION,
                    USER_ID = USER_ID,                   
                };

                using (SqlConnection connection = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    connection.Open();
                    // Create a SqlCommand, and identify it as a stored procedure.
                    using (SqlCommand sqlCommand = new SqlCommand("SP_SAV_ACTIVITY_LOG", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        SetupParameters(Log, sqlCommand);

                        try
                        {
                            if (connection.State != ConnectionState.Open) connection.Open();
                            // Run the stored procedure.
                            int i = sqlCommand.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                objError.WriteLog(0, "LogAuditData", "AuditLogRequest", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LogAuditData", "AuditLogRequest", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LogAuditData", "AuditLogRequest", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LogAuditData", "AuditLogRequest", "Inner Exception Message: " + ex.InnerException.Message);
                }
                throw ex;
            }
        }
                  
        private static SqlCommand SetupParameters(ActivityLogModel Log, SqlCommand sqlCommand)
        {
            LogError objError = new LogError();

            try
            {
                
                sqlCommand.Parameters.Add(new SqlParameter("@ACTIVITY_DESCRIPTION", Log.ACTIVITY_DESCRIPTION));

                sqlCommand.Parameters.Add(new SqlParameter("@USER_ID", Log.USER_ID));
              
                return sqlCommand;
            }
            catch (Exception ex)
            {
                
                objError.WriteLog(0, "ActivityLogData", "SetupParameters", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ActivityLogData", "SetupParameters", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ActivityLogData", "SetupParameters", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ActivityLogData", "SetupParameters", "Inner Exception Message: " + ex.InnerException.Message);
                }
                throw ex;
            }
        }

    }
}
