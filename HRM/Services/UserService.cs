using error_handler;
using HRM_DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using utility_handler.Data;

namespace HRM.Controllers.Services
{
    public interface IUserService
    {
        Task<AuthenticatedUserModel> Authenticate(/*string username, string password, */string AuthenticationKey);
    }

    public class UserService //: IUserService
    {

        //public async Task<AuthenticatedUserModel> Authenticate(/*string username, string password, */string AuthenticationKey)
        //{
        //    List<User_Profile_MapModel> temp = ValidateKeyFromDB(AuthenticationKey);
        //    AuthenticatedUserModel user = null;

        //    if (temp != null && temp.Count > 0)
        //    {
        //        user = new AuthenticatedUserModel()
        //        {
        //            UserTableID = temp[0].UPM_UserTableID,
        //            Username = temp[0].UPM_UserID,
        //            UserEmail= temp[0].UPM_UserEmail,
        //            AuthenticationKey= temp[0].UPM_AuthenticationKey,
        //        };
        //    }

        //    return user;
        //}
        private static LogError objError = new LogError();

        //private List<User_Profile_MapModel> ValidateKeyFromDB(string authenticationKey)
        //{
        //    List<User_Profile_MapModel> objUserHeadList = new List<User_Profile_MapModel>();

        //    SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString);
        //    try
        //    {


        //        if (lconn.State == ConnectionState.Closed)
        //        {
        //            lconn.Open();
        //        }
        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            cmd.Connection = lconn;

        //            cmd.CommandText = "sp_ValidateKeyFromDB";
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@AuthenticationKey", authenticationKey);
        //            cmd.Parameters["@AuthenticationKey"].Direction = ParameterDirection.Input;

        //            SqlDataAdapter dta = new SqlDataAdapter();
        //            dta.SelectCommand = cmd;
        //            DataSet Ds = new DataSet();
        //            dta.Fill(Ds);

        //            if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        //            {
        //                foreach (DataRow rdr in Ds.Tables[0].Rows)
        //                {
        //                    User_Profile_MapModel objUserdrop = new User_Profile_MapModel
        //                    {
        //                        UPM_UserID = rdr["UPM_UserID"].ToString(),
        //                        UPM_UserEmail = rdr["UPM_UserEmail"].ToString(),
        //                        UPM_UserTableID = rdr["UPM_UserTableID"].ToString(),
        //                        UPM_MobileNumber = rdr["UPM_MobileNumber"].ToString(),
        //                        UPM_Type = rdr["UPM_Type"].ToString(),
        //                        UPM_Description = rdr["UPM_Description"].ToString(),
        //                        UPM_AuthenticationKey = rdr["UPM_AuthenticationKey"].ToString()
        //                    };

        //                    objUserHeadList.Add(objUserdrop);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objError.WriteLog(0, "UserController", "ValidateKeyFromDB", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "UserController", "ValidateKeyFromDB", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "UserController", "ValidateKeyFromDB", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "UserController", "ValidateKeyFromDB", "Inner Exception Message: " + ex.InnerException.Message);
        //        }


        //    }
        //    return objUserHeadList;
        //}
    }
}