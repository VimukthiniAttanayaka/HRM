using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using utility_handler.Utility;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace utility_handler.Data
{
    public class LogAuditData
    {
        static IConfigurationRoot config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();

        public class ModuleNames
        {
            public static string HRM_API = "HRM API";
        }

        public static void AuditLogRequest(string module, string controler, string action,/* int identity, */string request)
        {
            LogError objError = new LogError();
            DateTime CreatedOn = DateTime.Now;

            try
            {
                string description = "";
                string actionType = "";

                description = request;
                actionType = "Request Body";


                AuditLog auditLog = new AuditLog()
                {
                    Controler = controler,
                    ActionType = actionType,
                    Module = module,
                    Action = action,
                    Description = description,
                    //Identity = identity,
                };

                using (SqlConnection connection = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    connection.Open();
                    // Create a SqlCommand, and identify it as a stored procedure.
                    using (SqlCommand sqlCommand = new SqlCommand("sp_IntApi_InsertAuditLog", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        SetupParameters(auditLog, sqlCommand);

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

        public static void AuditLogResponce<T>(string module, string controler, string action,/* int identity,*/ T obj) where T : class
        {
            LogError objError = new LogError();
            DateTime CreatedOn = DateTime.Now;

            List<T> t = new List<T>();
            t.Add(obj);

            try
            {
                string description = "";
                string actionType = "";

                description = Misc.SerializeJason<T>(t);
                actionType = "Responce Body";


                AuditLog auditLog = new AuditLog()
                {
                    Controler = controler,
                    ActionType = actionType,
                    Module = module,
                    Action = action,
                    Description = description,
                    //Identity = identity,
                };

                using (SqlConnection connection = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    connection.Open();
                    // Create a SqlCommand, and identify it as a stored procedure.
                    using (SqlCommand sqlCommand = new SqlCommand("sp_IntApi_InsertAuditLog", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        SetupParameters(auditLog, sqlCommand);

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

                objError.WriteLog(0, "LogAuditData", "AuditLogResponce", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LogAuditData", "AuditLogResponce", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LogAuditData", "AuditLogResponce", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LogAuditData", "AuditLogResponce", "Inner Exception Message: " + ex.InnerException.Message);
                }
                throw ex;
            }
        }

        public static void AuditLogRequest<T>(string module, string controler, string action,/* int identity,*/ T obj) where T : class
        {
            return;
            LogError objError = new LogError();
            DateTime CreatedOn = DateTime.Now;

            List<T> t = new List<T>();
            t.Add(obj);

            try
            {
                string description = "";
                string actionType = "";

                description = Misc.SerializeJason<T>(t);
                actionType = "Request Body";


                AuditLog auditLog = new AuditLog()
                {
                    Controler = controler,
                    ActionType = actionType,
                    Module = module,
                    Action = action,
                    Description = description,
                    //Identity = identity,
                };

                using (SqlConnection connection = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    connection.Open();
                    // Create a SqlCommand, and identify it as a stored procedure.
                    using (SqlCommand cmd = new SqlCommand("sp_IntApi_InsertAuditLog", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SetupParameters(auditLog, cmd);

                        try
                        {
                            if (connection.State != ConnectionState.Open) connection.Open();

                            SqlDataAdapter dta = new SqlDataAdapter();
                            dta.SelectCommand = cmd;
                            DataSet Ds = new DataSet();
                            dta.Fill(Ds);
                            // Run the stored procedure.
                            //int i = cmd.ExecuteNonQuery();
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

                objError.WriteLog(0, "LogAuditData", "AuditLogResponce", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LogAuditData", "AuditLogResponce", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LogAuditData", "AuditLogResponce", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LogAuditData", "AuditLogResponce", "Inner Exception Message: " + ex.InnerException.Message);
                }
                throw ex;
            }
        }
        public static IPAddress GetUserIP()
        {
            try
            {
                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
                foreach (IPAddress address in localIPs)
                {
                    return address;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return null;
        }

        private static SqlCommand SetupParameters(AuditLog auditLog, SqlCommand sqlCommand)
        {
            LogError objError = new LogError();

            try
            {
                StaticClasses.RemoteIPAddress = GetUserIP();
                if (StaticClasses.RemoteIPAddress != null)
                {
                    auditLog.ClientIP = StaticClasses.RemoteIPAddress.ToString();
                }
                // "TEST";//client Ip part needs here
                //if (string.IsNullOrEmpty(auditLog.CreatedBy)) auditLog.CreatedBy = ConfigCaller.ServiceName;

                sqlCommand.Parameters.Add(new SqlParameter("@Module", auditLog.Module));

                sqlCommand.Parameters.Add(new SqlParameter("@Action", auditLog.Action));

                sqlCommand.Parameters.Add(new SqlParameter("@Description", auditLog.Description));

                sqlCommand.Parameters.Add(new SqlParameter("@CreatedBy", ConfigCaller.ServiceName));

                sqlCommand.Parameters.Add(new SqlParameter("@ClientIP", auditLog.ClientIP));

                sqlCommand.Parameters.Add(new SqlParameter("@Controler", auditLog.Controler));

                sqlCommand.Parameters.Add(new SqlParameter("@ActionType", auditLog.ActionType));

                //sqlCommand.Parameters.Add(new SqlParameter("@SequenceNo", auditLog.Identity));


                return sqlCommand;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                objError.WriteLog(0, "LogAuditData", "SetupParameters", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LogAuditData", "SetupParameters", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LogAuditData", "SetupParameters", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LogAuditData", "SetupParameters", "Inner Exception Message: " + ex.InnerException.Message);
                }
                throw ex;
            }
        }

    }
}
