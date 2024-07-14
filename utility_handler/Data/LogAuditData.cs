using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace utility_handler.Data
{
    public class LogAuditData
    {
        public class ModuleNames
        {
            public static string HRM_API = "HRM API";
        }

        public static void AuditLogRequest(string module, string controler, string action,/* int identity, */string request)
        {
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

                using (SqlConnection connection = new SqlConnection(ConfigCaller.ConnectionString))
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

                DayEndProcess_Data.WriteLog("AuditLogRequest", "Fail " + ex.Message + " - " + ex.StackTrace);
                throw ex;
            }
        }

        public static void AuditLogResponce<T>(string module, string controler, string action,/* int identity,*/ T obj) where T : class
        {
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

                using (SqlConnection connection = new SqlConnection(ConfigCaller.ConnectionString))
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

                DayEndProcess_Data.WriteLog("AuditLogResponce", "Fail " + ex.Message + " - " + ex.StackTrace);
                throw ex;
            }
        }

        public static void AuditLogRequest<T>(string module, string controler, string action,/* int identity,*/ T obj) where T : class
        {
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

                using (SqlConnection connection = new SqlConnection(ConfigCaller.ConnectionString))
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

                DayEndProcess_Data.WriteLog("AuditLogRequest", "Fail " + ex.Message + " - " + ex.StackTrace);
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

                DayEndProcess_Data.WriteLog("SetupParameters", "Fail " + ex.Message + " - " + ex.StackTrace);
                throw ex;
            }
        }

    }
    internal class AuditLog
    {
        public AuditLog()
        {
        }

        public string Module { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public int Identity { get; set; }
        public string ClientIP { get; set; }
        public string Controler { get; internal set; }
        public string ActionType { get; internal set; }
    }
}
