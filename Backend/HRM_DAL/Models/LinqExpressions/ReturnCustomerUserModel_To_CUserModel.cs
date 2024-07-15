using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HRM_DAL.Models.LinqExpressions
{
    public class ReturnCustomerUserModel_To_CUserModel
    {
        public static IEnumerable<CUserModel> LinqExpressions(List<ReturnCustomerUserModel> lst)
        {
            return lst.Select(a =>
            {
                return new CUserModel()
                {
                    USR_CustomerID = a.USR_CustomerID,
                    USR_DepartmentID = a.USR_DepartmentID,
                    USR_StaffID = a.USR_StaffID,
                    USR_FirstName = a.USR_FirstName,
                    USR_LastName = a.USR_LastName,
                    USR_PrefferedName = a.USR_PrefferedName,
                    USR_OrgStructuralLevel1 = a.USR_OrgStructuralLevel1,
                    USR_OrgStructuralLevel2 = a.USR_OrgStructuralLevel2,
                    USR_DepartmentDetail1 = a.USR_DepartmentDetail1,
                    USR_DepartmentDetail2 = a.USR_DepartmentDetail2,
                    USR_DepartmentDetail3 = a.USR_DepartmentDetail3,
                    USR_JobCodeDescription = a.USR_JobCodeDescription,
                    USR_Address = a.USR_Address,
                    USR_EmailAddress = a.USR_EmailAddress,
                    USR_MobileNumber = a.USR_MobileNumber,
                    USR_PhoneNumber1 = a.USR_PhoneNumber1,
                    USR_PhoneNumber2 = a.USR_PhoneNumber2,
                    USR_RankDescription = a.USR_RankDescription,
                    USR_StaffLocation = a.USR_StaffLocation,
                    USR_PCCode = a.USR_PCCode,
                    USR_PCDescription = a.USR_PCDescription,
                    USR_Remarks = a.USR_Remarks,
                    USR_MailBagCPCode = a.USR_MailBagCPCode,
                    USR_OutgoingMailCPCode = a.USR_OutgoingMailCPCode,
                    USR_OutgoingMailLocationCode = a.USR_OutgoingMailLocationCode,
                    USR_PostageUsageReportFrequency = a.USR_PostageUsageReportFrequency,
                    USR_ActiveFrom = a.USR_ActiveFrom,
                    USR_ActiveTo = a.USR_ActiveTo,
                    USR_PwdSalt = a.USR_PwdSalt,
                    USR_Pwd = a.USR_Pwd,
                    //public bool USR_Status =   ,
                    //USER_ID = a.USER_ID,
                    //TABLE = a.TABLE
                };
            });
        }
    }
}
