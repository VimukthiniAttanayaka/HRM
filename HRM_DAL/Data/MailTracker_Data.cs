using HRM_DAL.Models;
using HRM_DAL.Models.RequestModels;
using HRM_DAL.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_DAL.Data
{
    public class HRM_Data
    {
        #region save data (data fetch from kiosk)

        #region add_new_location
        public static List<ReturnResponse> add_update_location(string userId, LocationDto location)
        {
            List<ReturnResponse> respLocList = new List<ReturnResponse>();
            ReturnResponse objHead = new ReturnResponse();
            SqlTransaction trans = null;

            try
            {
                if (location == null || (location != null && location.result == null) || (location != null && location.result != null && location.result.locations == null))
                {
                    respLocList.Add(new ReturnResponse { resp = false, msg = Messages.NoLocationData });
                    return respLocList;
                }

                using (SqlConnection conn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    conn.Open();
                    trans = conn.BeginTransaction();

                    CustomerLocation cusLoc = location.result;
                    List<Location> locs = cusLoc.locations;

                    foreach (var loc in locs)
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = conn;
                            cmd.Transaction = trans;

                            cmd.CommandText = "sp_sav_location";
                            cmd.CommandType = CommandType.StoredProcedure;



                            cmd.Parameters.AddWithValue("@LOC_ID", loc.locationId);
                            cmd.Parameters.AddWithValue("@LOC_Name", loc.locationName);
                            cmd.Parameters.AddWithValue("@LOC_CUS_ID", cusLoc.customerId);
                            cmd.Parameters.AddWithValue("@LOC_Status", (loc.activeStatus.ToLower() == "active") ? 1 : 0);
                            cmd.Parameters.AddWithValue("@USER_ID", userId);
                            cmd.Parameters.AddWithValue("@LOC_CreatedDateTime", loc.createdDateTime);
                            cmd.Parameters.AddWithValue("@LOC_ModifiedDateTime", loc.lastModifiedDateTime);

                            SqlDataAdapter dta = new SqlDataAdapter(cmd);
                            DataSet Ds = new DataSet();
                            dta.Fill(Ds);

                            if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow rdr in Ds.Tables[0].Rows)
                                {
                                    objHead = new ReturnResponse
                                    {
                                        resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                        msg = rdr["RTN_MSG"].ToString(),
                                        obj = new
                                        {
                                            locationId = loc.locationId,
                                            locationName = loc.locationName,
                                            customerId = cusLoc.customerId,
                                            ActiveStatus = loc.activeStatus,
                                            USER_ID = userId
                                        }
                                    };
                                    respLocList.Add(objHead);
                                }
                            }
                            else
                            {
                                objHead = new ReturnResponse
                                {
                                    resp = true,
                                    msg = "",
                                    obj = new
                                    {
                                        locationId = loc.locationId,
                                        locationName = loc.locationName,
                                        customerId = cusLoc.customerId,
                                        ActiveStatus = loc.activeStatus,
                                        USER_ID = userId
                                    }
                                };
                                respLocList.Add(objHead);
                            }


                            string logobject = JsonConvert.SerializeObject(objHead);

                            new WhiteLog("add_update_location - update log" + logobject, "HRM_Data", "add_update_location", true, true);

                            cmd.Parameters.Clear();
                        }
                    }

                    trans.Commit();
                    trans.Dispose();
                }
            }
            catch (Exception ex)
            {
                respLocList.Add(new ReturnResponse { resp = false, msg = ex.Message.ToString() });
                new WhiteLog(ex, "HRM_Data", "add_new_location");

                if (trans != null)
                {
                    trans.Rollback();
                    trans.Dispose();
                }
            }
            return respLocList;
        }

        public static void set_acknowledged_mails(Ack_MailBagTrans_RequestModel model)
        {
            List<MailBagTransDto> maiBagList = new List<MailBagTransDto>();

            try
            {
                using (SqlConnection conn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    new WhiteLog("Step 2", "HRM_Data", "set_acknowledged_mails", true, true);
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;

                        cmd.CommandText = "set_acknowledged_mails";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserId", model.userId);

                        cmd.Parameters.AddWithValue("@RequestReferenceID", model.reqTransReferenceId);

                        SqlDataAdapter dta = new SqlDataAdapter(cmd);
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);
                    }
                }
            }
            catch (Exception ex)
            {
                maiBagList.Add(new MailBagTransDto
                {
                    messageId = 0,
                    message = ex.Message.ToString()
                });
                new WhiteLog(ex, "HRM_Data", "set_acknowledged_mails");
            }
        }
        #endregion

        public static void set_acknowledged_outgoingmails(Ack_OutGoingMailTrans_RequestModel model)
        {
            List<MailBagTransDto> maiBagList = new List<MailBagTransDto>();

            try
            {
                using (SqlConnection conn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    new WhiteLog("Step 2", "HRM_Data", "set_acknowledged_outgoingmails", true, true);
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;

                        cmd.CommandText = "set_acknowledged_outgoingmails";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserId", model.userId);

                        cmd.Parameters.AddWithValue("@RequestReferenceID", model.reqTransReferenceId);

                        SqlDataAdapter dta = new SqlDataAdapter(cmd);
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);
                    }
                }
            }
            catch (Exception ex)
            {
                maiBagList.Add(new MailBagTransDto
                {
                    messageId = 0,
                    message = ex.Message.ToString()
                });
                new WhiteLog(ex, "HRM_Data", "set_acknowledged_outgoingmails");
            }
        }
        #endregion

        public static void set_acknowledged_deviceacts(Ack_DeviceActs_RequestModel model)
        {
            List<MailBagTransDto> maiBagList = new List<MailBagTransDto>();

            try
            {
                using (SqlConnection conn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    new WhiteLog("Step 2", "HRM_Data", "set_acknowledged_deviceacts", true, true);
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;

                        cmd.CommandText = "set_acknowledged_deviceacts";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserId", model.userId);

                        cmd.Parameters.AddWithValue("@RequestReferenceID", model.reqTransReferenceId);

                        SqlDataAdapter dta = new SqlDataAdapter(cmd);
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);
                    }
                }
            }
            catch (Exception ex)
            {
                maiBagList.Add(new MailBagTransDto
                {
                    messageId = 0,
                    message = ex.Message.ToString()
                });
                new WhiteLog(ex, "HRM_Data", "set_acknowledged_deviceacts");
            }
        }

        #region add_new_department
        public static List<ReturnResponse> add_update_department(string userId, DepartmentDto department)
        {
            List<ReturnResponse> respDeptList = new List<ReturnResponse>();
            SqlTransaction trans = null;

            try
            {
                if (department == null)
                {
                    respDeptList.Add(new ReturnResponse { resp = false, msg = Messages.NoDepartmentData });
                    return respDeptList;
                }

                using (SqlConnection conn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    trans = conn.BeginTransaction();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;

                        cmd.CommandText = "sp_sav_department_kiosk";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = trans;

                        CustomerDepartment cusDept = department.result;
                        List<Department> depts = cusDept.departments;

                        foreach (var dept in depts)
                        {
                            cmd.Parameters.AddWithValue("@DPT_CustomerID", cusDept.customerId);
                            cmd.Parameters.AddWithValue("@DPT_ID", dept.deptId);
                            cmd.Parameters.AddWithValue("@DPT_Name", dept.deptName);
                            cmd.Parameters.AddWithValue("@DPT_CPCode", dept.cpCode);
                            cmd.Parameters.AddWithValue("@DPDB_DeviceNo", dept.deviceNo);
                            cmd.Parameters.AddWithValue("@DPDB_DeviceTypeNo", dept.deviceTypeId);
                            cmd.Parameters.AddWithValue("@DPDB_VendorID", dept.vendorId);
                            cmd.Parameters.AddWithValue("@DPT_Status", (dept.activeStatus.ToLower() == "active") ? 1 : 0);
                            cmd.Parameters.AddWithValue("@USER_ID", userId);
                            //cmd.Parameters.AddWithValue("@DPT_CreatedDateTime", dept.createdDateTime);
                            //cmd.Parameters.AddWithValue("@DPT_ModifiedDateTime", dept.lastModifiedDateTime);
                            if (dept.createdDateTime != null)
                            {
                                cmd.Parameters.AddWithValue("@DPT_CreatedDateTime", dept.createdDateTime);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@DPT_CreatedDateTime", null);
                            }
                            if (dept.lastModifiedDateTime != null)
                            {
                                cmd.Parameters.AddWithValue("@DPT_ModifiedDateTime", dept.lastModifiedDateTime);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@DPT_ModifiedDateTime", null);
                            }

                            List<string> boxes = dept.boxNos;
                            if (boxes == null)
                            {
                                boxes = new List<string>();
                            }
                            foreach (var box in boxes)
                            {
                                cmd.Parameters.AddWithValue("@DPDB_BoxNo", box);

                                SqlDataAdapter dta = new SqlDataAdapter(cmd);
                                DataSet Ds = new DataSet();
                                dta.Fill(Ds);

                                if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow rdr in Ds.Tables[0].Rows)
                                    {
                                        respDeptList.Add(new ReturnResponse { resp = Boolean.Parse(rdr["RTN_RESP"].ToString()), msg = rdr["RTN_MSG"].ToString(), obj = cusDept });
                                    }
                                }
                                else
                                {
                                    respDeptList.Add(new ReturnResponse { resp = true, msg = "", obj = cusDept });
                                }
                                cmd.Parameters.RemoveAt("@DPDB_BoxNo");
                            }
                            cmd.Parameters.Clear();
                        }
                    }
                }

                if (trans.Connection != null) //Detecting zombie transaction
                {
                    trans.Commit();
                }
                //trans.Commit();
                trans.Dispose();
            }
            catch (Exception ex)
            {
                if (trans != null)
                {
                    if (trans.Connection != null)
                    {
                        trans.Rollback();
                    }
                    trans.Dispose();
                }
                respDeptList.Add(new ReturnResponse { resp = false, msg = ex.Message.ToString(), obj = department });
                new WhiteLog(ex, "HRM_Data", "add_new_department");
            }
            return respDeptList;
        }

        public static List<(string DPT_ID, string DPT_CustomerID)> get_not_synced_departments()
        {
            List<(string DPT_ID, string DPT_CustomerID)> maiBagList = new List<(string DPT_ID, string DPT_CustomerID)>();

            try
            {
                using (SqlConnection conn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    new WhiteLog("Step 2", "HRM_Data", "get_not_synced_departments", true, true);
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;

                        cmd.CommandText = "get_not_synced_departments";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter dta = new SqlDataAdapter(cmd);
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                maiBagList.Add((rdr["DPT_CustomerID"].ToString(), rdr["DPT_CustomerID"].ToString()));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new WhiteLog(ex, "HRM_Data", "get_not_synced_departments");
            }
            return maiBagList;
        }

        public static List<(string USER_ID, string TABLE)> get_not_synced_users()
        {
            List<(string USER_ID, string TABLE)> maiBagList = new List<(string USER_ID, string TABLE)>();

            try
            {
                using (SqlConnection conn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    new WhiteLog("Step 2", "HRM_Data", "get_not_synced_users", true, true);
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;

                        cmd.CommandText = "get_not_synced_users";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter dta = new SqlDataAdapter(cmd);
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                maiBagList.Add((rdr["UPM_UserID"].ToString(), rdr["UPM_UserTableID"].ToString()));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new WhiteLog(ex, "HRM_Data", "get_not_synced_users");
            }
            return maiBagList;
        }
        #endregion

        #region add_new_usergroup
        public static List<ReturnResponse> add_update_usergroup(string userId, Get_UserGroups_ResponceModel userGroup)
        {
            List<ReturnResponse> respUsrGrpList = new List<ReturnResponse>();
            SqlTransaction trans = null;
            ReturnResponse res = new ReturnResponse();

            try
            {
                if (userGroup == null || (userGroup != null && userGroup.result == null))
                {
                    respUsrGrpList.Add(new ReturnResponse { resp = false, msg = Messages.NoUserGroupData });
                    return respUsrGrpList;
                }

                using (SqlConnection conn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    trans = conn.BeginTransaction();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;

                        cmd.CommandText = "sp_sav_user_access_group_kiosk";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = trans;

                        string logobject = JsonConvert.SerializeObject(userGroup.result);

                        new WhiteLog("add_update_usergroup - responce log" + logobject, "HRM_Data", "add_update_usergroup", true, true);

                        foreach (UsergroupResult group in userGroup.result)
                        {
                            List<Usergroup> groups = group.userGroups;
                            foreach (Usergroup group1 in groups)
                            {
                                cmd.Parameters.AddWithValue("@UGM_VendorID", group.VendorID);
                                cmd.Parameters.AddWithValue("@GroupId", group1.groupId);
                                cmd.Parameters.AddWithValue("@UGM_Name", group1.groupName);
                                cmd.Parameters.AddWithValue("@UGM_Status", (group1.activeStatus.ToLower() == "active") ? 1 : 0);
                                cmd.Parameters.AddWithValue("@USER_ID", userId);
                                if (group1.createDateTime != null)
                                {
                                    cmd.Parameters.AddWithValue("@UGM_CreatedDateTime", group1.createDateTime);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@UGM_CreatedDateTime", null);
                                }
                                //cmd.Parameters.AddWithValue("@UGM_CreatedDateTime", group1.createDateTime.HasValue ? group1.createDateTime : null);
                                if (group1.lastModifiedDateTime != null)
                                {
                                    cmd.Parameters.AddWithValue("@UGM_ModifiedDateTime", group1.lastModifiedDateTime);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@UGM_ModifiedDateTime", null);
                                }

                                SqlDataAdapter dta = new SqlDataAdapter(cmd);
                                DataSet Ds = new DataSet();
                                dta.Fill(Ds);

                                if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow rdr in Ds.Tables[0].Rows)
                                    {
                                        res = new ReturnResponse
                                        {
                                            resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                            msg = rdr["RTN_MSG"].ToString(),
                                            obj = new
                                            {
                                                VendorId = group.VendorID,
                                                GroupId = group1.groupId,
                                                GroupName = group1.groupName,
                                                ActiveStatus = group1.activeStatus,
                                                USER_ID = userId
                                            }
                                        };
                                        respUsrGrpList.Add(res);
                                    }
                                }
                                else
                                {
                                    res = new ReturnResponse
                                    {
                                        resp = true,
                                        msg = "",
                                        obj = new
                                        {
                                            VendorId = group.VendorID,
                                            GroupId = group1.groupId,
                                            GroupName = group1.groupName,
                                            ActiveStatus = group1.activeStatus,
                                            USER_ID = userId
                                        }
                                    };
                                    respUsrGrpList.Add(res);
                                }
                                logobject = JsonConvert.SerializeObject(res);

                                new WhiteLog("add_update_usergroup - update log" + logobject, "HRM_Data", "add_update_usergroup", true, true);

                                cmd.Parameters.Clear();
                            }
                        }
                    }

                    if (trans.Connection != null) //Detecting zombie transaction
                    {
                        trans.Commit();
                    }
                    trans.Dispose();
                }

            }
            catch (Exception ex)
            {
                if (trans != null)
                {
                    if (trans.Connection != null) //Detecting zombie transaction
                    {
                        trans.Rollback();
                    }
                    trans.Dispose();
                }
                respUsrGrpList.Add(new ReturnResponse { resp = false, msg = ex.Message.ToString() });
                new WhiteLog(ex, "HRM_Data", "add_new_usergroup");
            }
            return respUsrGrpList;
        }
        #endregion

        #region add_new_outgoing_mail
        public static List<OutGoingMailDto> add_new_outgoing_mail(OutGoingMailDto mailBag)
        {
            List<OutGoingMailDto> respUsrGrpList = new List<OutGoingMailDto>();

            try
            {
                if (mailBag == null || (mailBag != null && mailBag.result.outgoingMailTrans == null) || (mailBag != null && mailBag.result.outgoingMailTrans.Count == 0))
                {
                    respUsrGrpList.Add(new OutGoingMailDto { resp = false, msg = Messages.NoOutGoingMailData, result = null });
                    return respUsrGrpList;
                }

                using (SqlConnection conn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    new WhiteLog("Step 2", "HRM_Data", "add_new_outgoing_mail", true, true);
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;

                        cmd.CommandText = "sp_sav_outgoing_mail_trans";
                        cmd.CommandType = CommandType.StoredProcedure;

                        OutgoingMailResult mailResult = mailBag.result;
                        List<OutgoingMailTrans> mails = mailResult.outgoingMailTrans;

                        OutGoingMailDto resultObj = new OutGoingMailDto() { };


                        foreach (var mail in mails)
                        {
                            cmd.Parameters.AddWithValue("@BatchNo", mail.batchNo);
                            cmd.Parameters.AddWithValue("@TransactionDateTime", mail.transactionDateTime.HasValue ? mail.transactionDateTime : null);
                            cmd.Parameters.AddWithValue("@ServerSyncDateTime", mail.serverSyncDateTime.HasValue ? mail.serverSyncDateTime : null);
                            cmd.Parameters.AddWithValue("@DeviceNo", mail.deviceNo);
                            cmd.Parameters.AddWithValue("@DeviceTypeId", mail.deviceTypeId);
                            cmd.Parameters.AddWithValue("@VendorId", mail.vendorId);
                            cmd.Parameters.AddWithValue("@LocationId", mail.locationId);
                            cmd.Parameters.AddWithValue("@CustomerId", mail.customerId);
                            cmd.Parameters.AddWithValue("@StaffId", mail.staffId);
                            cmd.Parameters.AddWithValue("@PcCode", mail.pcCode);
                            cmd.Parameters.AddWithValue("@MailTypeId", mail.mailTypeId);
                            cmd.Parameters.AddWithValue("@Qty", mail.qty.HasValue ? mail.qty : 0);
                            cmd.Parameters.AddWithValue("@RequestReferenceID", mailResult.reqTransReferenceId);
                            cmd.Parameters.AddWithValue("@userLoginDateTime", mail.userLoginDateTime);

                            SqlDataAdapter dta = new SqlDataAdapter(cmd);
                            DataSet Ds = new DataSet();
                            dta.Fill(Ds);

                            OutgoingMailResult retObj = new OutgoingMailResult()
                            {
                                reqTransReferenceId = mailBag.result.reqTransReferenceId,
                                outgoingMailTrans = new List<OutgoingMailTrans>() { }
                            };
                            retObj.outgoingMailTrans.Add(mail);


                            if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow rdr in Ds.Tables[0].Rows)
                                {

                                    resultObj = new OutGoingMailDto
                                    {
                                        resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                        msg = rdr["RTN_MSG"].ToString(),
                                        result = retObj
                                    };
                                    respUsrGrpList.Add(resultObj);
                                }
                            }
                            else
                            {
                                resultObj = new OutGoingMailDto
                                {
                                    resp = true,
                                    msg = "",
                                    result = retObj
                                };
                                respUsrGrpList.Add(resultObj);
                            }
                            cmd.Parameters.Clear();
                        }

                        string logobject = JsonConvert.SerializeObject(resultObj);

                        new WhiteLog("add_new_outgoing_mail - update log" + logobject, "HRM_Data", "add_new_outgoing_mail", true, true);
                    }
                }
            }
            catch (Exception ex)
            {
                respUsrGrpList.Add(new OutGoingMailDto { resp = false, msg = ex.Message.ToString(), result = mailBag.result });
                new WhiteLog(ex, "HRM_Data", "add_new_outgoing_mail");
            }
            return respUsrGrpList;
        }
        #endregion

        #region get_not_acknowledged_mails
        public static List<MailBagTransDto> get_not_acknowledged_mails()
        {
            List<MailBagTransDto> maiBagList = new List<MailBagTransDto>();

            try
            {
                using (SqlConnection conn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    new WhiteLog("Step 2", "HRM_Data", "get_not_acknowledged_mails", true, true);
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;

                        cmd.CommandText = "get_not_acknowledged_mails";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter dta = new SqlDataAdapter(cmd);
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                maiBagList.Add(new MailBagTransDto
                                {
                                    messageId = 1,
                                    //message = rdr["RTN_MSG"].ToString(),
                                    result = new MailBagTransResult() { reqTransReferenceId = rdr["RequestReferenceID"].ToString() }
                                });
                            }
                        }
                        else
                        {
                            maiBagList.Add(new MailBagTransDto { messageId = 0, message = "" });
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                maiBagList.Add(new MailBagTransDto
                {
                    messageId = 0,
                    message = ex.Message.ToString()
                });
                new WhiteLog(ex, "HRM_Data", "get_not_acknowledged_mails");
            }
            return maiBagList;
        }
        #endregion

        #region add_new_mailbag_trans
        public static List<MailBagTransDto> add_new_mailbag_trans(string userId, MailBagTransDto mailBag)
        {
            List<MailBagTransDto> maiBagList = new List<MailBagTransDto>();

            try
            {
                if (mailBag == null || (mailBag != null && mailBag.result.mailBagTrans == null) || (mailBag != null && mailBag.result.mailBagTrans.Count == 0))
                {
                    maiBagList.Add(new MailBagTransDto { messageId = 0, message = Messages.NoMailBagData, result = null });
                    return maiBagList;
                }

                using (SqlConnection conn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    new WhiteLog("Step 2", "HRM_Data", "add_new_mailbag_trans", true, true);
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                        }

                        cmd.Connection = conn;

                        cmd.CommandText = "sp_sav_mail_bag_trans";
                        cmd.CommandType = CommandType.StoredProcedure;

                        MailBagTransResult mailResult = mailBag.result;
                        List<MailTransactionHeader> mails = mailResult.mailBagTrans;

                        if (mails != null)
                        {
                            foreach (var mail in mails)
                            {
                                if (string.IsNullOrEmpty(mail.tripNo) == true) { mail.tripNo = ""; }

                                cmd.Parameters.AddWithValue("@TransactionNo", mail.transactionNo);
                                cmd.Parameters.AddWithValue("@TransactionType", mail.transactionType);
                                cmd.Parameters.AddWithValue("@TripNo", mail.tripNo);
                                cmd.Parameters.AddWithValue("@TransactionDateTime", mail.transactionDateTime);
                                cmd.Parameters.AddWithValue("@ServerSyncDateTime", mail.serverSyncDateTime);
                                cmd.Parameters.AddWithValue("@DeviceNo", mail.deviceNo);
                                cmd.Parameters.AddWithValue("@DeviceTypeId", mail.deviceTypeId);
                                cmd.Parameters.AddWithValue("@VendorId", mail.vendorId);
                                cmd.Parameters.AddWithValue("@LocationId", mail.locationId);
                                cmd.Parameters.AddWithValue("@CustomerID", mail.customerID);
                                cmd.Parameters.AddWithValue("@CpCode", mail.cpCode);
                                cmd.Parameters.AddWithValue("@IsNoBag", mail.isNoBag);
                                cmd.Parameters.AddWithValue("@isLooseMail", mail.isLooseMail);
                                cmd.Parameters.AddWithValue("@UserId", mail.userId);
                                cmd.Parameters.AddWithValue("@RequestReferenceID", mailBag.result.reqTransReferenceId);
                                cmd.Parameters.AddWithValue("@userLoginDateTime", mail.userLoginDateTime);

                                MailBagTransDto resultObj = new MailBagTransDto() { };

                                List<MailBag> Bags = mail.mailBags;
                                if (Bags == null) Bags = new List<MailBag>();
                                if (Bags.Count == 0) Bags.Add(new MailBag());

                                foreach (var bag in Bags)
                                {
                                    if (string.IsNullOrEmpty(bag.boxNo) == true) { bag.boxNo = ""; }
                                    if (string.IsNullOrEmpty(bag.containerId) == true) { bag.containerId = ""; }
                                    if (string.IsNullOrEmpty(bag.sealId) == true) { bag.sealId = ""; }
                                    if (string.IsNullOrEmpty(bag.bagType) == true) { bag.bagType = ""; }
                                    if (string.IsNullOrEmpty(bag.action) == true) { bag.action = ""; }

                                    cmd.Parameters.AddWithValue("@boxNo", bag.boxNo);
                                    cmd.Parameters.AddWithValue("@ContainerId", bag.containerId);
                                    cmd.Parameters.AddWithValue("@SealId", bag.sealId);
                                    cmd.Parameters.AddWithValue("@BagType", bag.bagType);
                                    cmd.Parameters.AddWithValue("@Action", bag.action);

                                    SqlDataAdapter dta = new SqlDataAdapter(cmd);
                                    DataSet Ds = new DataSet();
                                    dta.Fill(Ds);

                                    MailBagTransResult retObj = new MailBagTransResult()
                                    {
                                        reqTransReferenceId = mailBag.result.reqTransReferenceId,
                                        mailBagTrans = new List<MailTransactionHeader>() { }
                                    };
                                    retObj.mailBagTrans.Add(mail);



                                    if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                                    {
                                        foreach (DataRow rdr in Ds.Tables[0].Rows)
                                        {
                                            resultObj = new MailBagTransDto
                                            {
                                                messageId = bool.Parse(rdr["RTN_RESP"].ToString()) == true ? 1 : 0,
                                                message = rdr["RTN_MSG"].ToString(),
                                                result = retObj
                                                //mailBag.result
                                                //new MailBagTransResult() { reqTransReferenceId = mailBag.result.reqTransReferenceId, mailBagTrans = }
                                            };
                                            maiBagList.Add(resultObj);
                                        }
                                    }
                                    else
                                    {
                                        resultObj = new MailBagTransDto { messageId = 1, message = "", result = retObj };
                                        maiBagList.Add(resultObj);
                                    }
                                    cmd.Parameters.RemoveAt("@boxNo");
                                    cmd.Parameters.RemoveAt("@ContainerId");
                                    cmd.Parameters.RemoveAt("@SealId");
                                    cmd.Parameters.RemoveAt("@BagType");
                                    cmd.Parameters.RemoveAt("@Action");
                                }


                                string logobject = JsonConvert.SerializeObject(resultObj);

                                new WhiteLog("add_new_mailbag_trans - update log" + logobject, "HRM_Data", "add_new_mailbag_trans", true, true);

                                cmd.Parameters.Clear();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                maiBagList.Add(new MailBagTransDto { messageId = 0, message = ex.Message.ToString(), result = mailBag.result });
                new WhiteLog(ex, "HRM_Data", "add_new_mailbag_trans");
            }
            return maiBagList;
        }
        #endregion

        #region add_new_device_activity
        public static List<ReturnResponse> add_new_device_activity(DeviceActivityDto device)
        {
            List<ReturnResponse> respLocList = new List<ReturnResponse>();

            try
            {
                if (device == null || (device != null && device.result.deviceActivities == null) || (device != null && device.result.deviceActivities.Count == 0))
                {
                    respLocList.Add(new ReturnResponse { resp = false, msg = Messages.NoDeviceActivityData, obj = null });
                    return respLocList;
                }

                using (SqlConnection conn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                        }

                        cmd.Connection = conn;

                        cmd.CommandText = "sp_sav_device_activity";
                        cmd.CommandType = CommandType.StoredProcedure;

                        DeviceResult deviceResult = device.result;
                        List<DeviceActivity> activities = deviceResult.deviceActivities;

                        foreach (var activity in activities)
                        {
                            cmd.Parameters.AddWithValue("@DeviceNo", activity.deviceNo);
                            cmd.Parameters.AddWithValue("@DeviceTypeId", activity.deviceTypeId);
                            cmd.Parameters.AddWithValue("@VendorId", activity.vendorId);
                            cmd.Parameters.AddWithValue("@LocationId", activity.locationId);
                            cmd.Parameters.AddWithValue("@TransactionDateTime", activity.transactionDateTime);
                            cmd.Parameters.AddWithValue("@ServerSyncDateTime", activity.serverSyncDateTime);
                            cmd.Parameters.AddWithValue("@UserId", activity.userId);
                            cmd.Parameters.AddWithValue("@ActivityType", activity.activityType);
                            cmd.Parameters.AddWithValue("@ActivityDescription", activity.activityDescription);
                            cmd.Parameters.AddWithValue("@RequestReferenceID", device.result.reqTransReferenceId);

                            SqlDataAdapter dta = new SqlDataAdapter(cmd);
                            DataSet Ds = new DataSet();
                            dta.Fill(Ds);

                            if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow rdr in Ds.Tables[0].Rows)
                                {
                                    respLocList.Add(new ReturnResponse
                                    {
                                        resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                        msg = rdr["RTN_MSG"].ToString(),
                                        obj = new
                                        {
                                            deviceNo = activity.deviceNo,
                                            deviceTypeId = activity.deviceTypeId,
                                            vendorId = activity.vendorId,
                                            locationId = activity.locationId,
                                            transactionDateTime = activity.transactionDateTime,
                                            serverSyncDateTime = activity.serverSyncDateTime,
                                            activityType = activity.activityType,
                                            activityDescription = activity.activityDescription,
                                            reqTransReferenceId = device.result.reqTransReferenceId,
                                            USER_ID = activity.userId
                                        }
                                    });
                                }
                            }
                            else
                            {
                                respLocList.Add(new ReturnResponse
                                {
                                    resp = true,
                                    msg = "",
                                    obj = new
                                    {
                                        deviceNo = activity.deviceNo,
                                        deviceTypeId = activity.deviceTypeId,
                                        vendorId = activity.vendorId,
                                        locationId = activity.locationId,
                                        transactionDateTime = activity.transactionDateTime,
                                        serverSyncDateTime = activity.serverSyncDateTime,
                                        activityType = activity.activityType,
                                        activityDescription = activity.activityDescription,
                                        reqTransReferenceId = device.result.reqTransReferenceId,
                                        USER_ID = activity.userId
                                    }
                                });
                            }

                            string logobject = JsonConvert.SerializeObject(respLocList);

                            new WhiteLog("add_new_device_activity - update log" + logobject, "HRM_Data", "add_new_device_activity", true, true);

                            cmd.Parameters.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respLocList.Add(new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                });
                new WhiteLog(ex, "HRM_Data", "add_new_device_activity");
            }
            return respLocList;
        }
        #endregion

        #region get data (from the db)

        //public static DepartmentRequestDto Set_Departments(string customerId)
        //{
        //    //_logger.LogInformation($"REPO: HRMRepository.Get_Departments | Calling Get_Departments with params - Customer Id: {customerId}");
        //    DataSet ds = CallSpGetDepartments(customerId);
        //    DepartmentRequestDto deptDto = CreateDepartmentDto(customerId, ds);
        //    return deptDto;
        //}

        //public static UserRequestDto Set_Users()
        //{
        //    DataSet ds = CallSpGetUsers();
        //    UserRequestDto userDto = CreateUserDto(ds);
        //    return userDto;
        //}

        #endregion

        #region Call DB to fetch data

        //private static DataSet CallSpGetDepartments(string customerId)
        //{
        //    //_logger.LogInformation($"REPO: Calling CallSpGetDepartments with params = Customer Id: {customerId}");

        //    DataSet ds = new DataSet();

        //    using (SqlConnection conn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
        //    using (SqlCommand cmd = conn.CreateCommand())
        //    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
        //    {
        //        cmd.Parameters.AddWithValue("@CustomerId", customerId);

        //        cmd.CommandText = "dbo.sp_get_department_kiosk";
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        try
        //        {
        //            conn.Open();
        //            adapter.Fill(ds);
        //        }
        //        catch (Exception ex)
        //        {
        //            //_logger.LogInformation(ex.StackTrace);
        //            throw;
        //        }
        //    }
        //    return ds;
        //}

        //private static DataSet CallSpGetUsers()
        //{
        //    DataSet ds = new DataSet();

        //    using (SqlConnection conn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
        //    using (SqlCommand cmd = conn.CreateCommand())
        //    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
        //    {
        //        //cmd.Parameters.AddWithValue("@CustomerId", customerId);

        //        cmd.CommandText = "dbo.sp_get_users_kiosk";
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        try
        //        {
        //            conn.Open();
        //            adapter.Fill(ds);

        //            foreach (DataRow item in ds.Tables[0].Rows)
        //            {
        //                string drs = item["JsonScript"].ToString();
        //                User_RequestModel DATA = JsonConvert.DeserializeObject<User_RequestModel>(drs);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            //_logger.LogInformation(ex.StackTrace);
        //            throw;
        //        }
        //    }
        //    return ds;
        //}

        #endregion

        #region Create Object

        //private static DepartmentRequestDto CreateDepartmentDto(string customerId, DataSet ds)
        //{
        //    DepartmentRequestDto response = new DepartmentRequestDto();
        //    response.isCompleteList = 1;
        //    response.customerId = customerId;
        //    List<DepartmentData> departments = new List<DepartmentData>();
        //    DepartmentData department = null;
        //    Address address = null;

        //    foreach (DataTable table in ds.Tables)
        //    {
        //        foreach (DataRow dr in table.Rows)
        //        {
        //            department = new DepartmentData();
        //            address = new Address();

        //            department.deptId = dr["DPT_ID"].ToString();
        //            department.deptName = dr["DPT_Name"].ToString();

        //            address.blockNo = dr["DPT_Adrs_BlockBuildingNo"].ToString();
        //            address.streetName = dr["DPT_Adrs_StreetName"].ToString();
        //            address.unitNo = dr["DPT_Adrs_UnitNumber"].ToString();
        //            address.buildingName = dr["DPT_Adrs_BuildingName"].ToString();
        //            address.City = dr["DPT_Adrs_City"].ToString();
        //            address.CountryId = dr["DPT_Adrs_CountryCode"].ToString();
        //            address.postalCode = dr["DPT_Adrs_PostalCode"].ToString();

        //            department.address = address;

        //            department.cpCode = dr["DPT_CPCode"].ToString();
        //            department.activeStatus = (bool)dr["DPT_Status"] == true ? "Active" : "Incative";
        //            department.createdDateTime = (dr["DPT_CreatedDateTime"].ToString() == "") ? null : (DateTime?)dr["DPT_CreatedDateTime"];
        //            department.lastModifiedDateTime = (dr["DPT_ModifiedDateTime"].ToString() == "") ? null : (DateTime?)dr["DPT_ModifiedDateTime"];

        //            departments.Add(department);
        //        }
        //    }

        //    response.departments = departments;
        //    return response;
        //}

        //private static UserRequestDto CreateUserDto(DataSet ds)
        //{
        //    UserRequestDto response = new UserRequestDto();
        //    //response.isCompleteList = 1;
        //    //response.customerId = customerId;
        //    //List<DepartmentData> departments = new List<DepartmentData>();
        //    //DepartmentData department = null;
        //    //Address address = null;

        //    //foreach (DataTable table in ds.Tables)
        //    //{
        //    //    foreach (DataRow dr in table.Rows)
        //    //    {
        //    //        department = new DepartmentData();
        //    //        address = new Address();

        //    //        department.deptId = dr["DPT_ID"].ToString();
        //    //        department.deptName = dr["DPT_Name"].ToString();

        //    //        address.blockNo = dr["DPT_Adrs_BlockBuildingNo"].ToString();
        //    //        address.streetName = dr["DPT_Adrs_StreetName"].ToString();
        //    //        address.unitNo = dr["DPT_Adrs_UnitNumber"].ToString();
        //    //        address.buildingName = dr["DPT_Adrs_BuildingName"].ToString();
        //    //        address.City = dr["DPT_Adrs_City"].ToString();
        //    //        address.CountryId = dr["DPT_Adrs_CountryCode"].ToString();
        //    //        address.postalCode = dr["DPT_Adrs_PostalCode"].ToString();

        //    //        department.address = address;

        //    //        department.cpCode = dr["DPT_CPCode"].ToString();
        //    //        department.activeStatus = (bool)dr["DPT_Status"] == true ? "Active" : "Incative";
        //    //        department.createdDateTime = (dr["DPT_CreatedDateTime"].ToString() == "") ? null : (DateTime?)dr["DPT_CreatedDateTime"];
        //    //        department.lastModifiedDateTime = (dr["DPT_ModifiedDateTime"].ToString() == "") ? null : (DateTime?)dr["DPT_ModifiedDateTime"];

        //    //        departments.Add(department);
        //    //    }
        //    //}

        //    //response.departments = departments;
        //    return response;
        //}

        #endregion
    }
}
