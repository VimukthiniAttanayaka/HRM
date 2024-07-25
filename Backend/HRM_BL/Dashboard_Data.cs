using HRM_DAL.Models;
using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_DAL.Data
{
    public class Dashboard_Data
    {
        private static LogError objError = new LogError();

        //public static ProgressGraphReturnResponseModel ProgressGraph(DashboardRequestModel model)
        //{
        //    ProgressGraphReturnResponseModel objHead = new ProgressGraphReturnResponseModel() { msg = "ProgressGraph", resp = true };
        //    try
        //    {
        //        using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
        //        {
        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.Connection = lconn;

        //                //Business Unit
        //                cmd.CommandText = "sp_get_dashboard_ProgressGraph";
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                cmd.Parameters.AddWithValue("@User_ID", model.User_ID);
        //                cmd.Parameters["@User_ID"].Direction = ParameterDirection.Input;

        //                SqlDataAdapter dta = new SqlDataAdapter();
        //                dta.SelectCommand = cmd;
        //                DataSet Ds = new DataSet();
        //                dta.Fill(Ds);

        //                if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        //                {
        //                    foreach (DataRow rdr in Ds.Tables[0].Rows)
        //                    {
        //                        objHead.List.Add(new ProgressGraphModel()
        //                        {
        //                            Value = int.Parse(rdr["Value"].ToString()),
        //                            Month = rdr["Month"].ToString(),
        //                            MonthText = rdr["MonthText"].ToString(),
        //                            Year = rdr["Year"].ToString()
        //                        });
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objHead = new ProgressGraphReturnResponseModel
        //        {
        //            resp = false,
        //            msg = ex.Message.ToString()
        //        };

        //        objError.WriteLog(0, "Dashboard_Data", "ProgressGraph", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "Dashboard_Data", "ProgressGraph", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "Dashboard_Data", "ProgressGraph", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "Dashboard_Data", "ProgressGraph", "Inner Exception Message: " + ex.InnerException.Message);
        //        }

        //    }
        //    return objHead;
        //}

    }
}