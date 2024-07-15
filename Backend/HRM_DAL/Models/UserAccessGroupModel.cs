
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{
    public class UAGModel : RequestBaseModel
    {
        public string USER_ID { get; set; }
        public List<ExistingUAGModel> ExistingUAG { get; set; }
        public List<KioskAGModel> KioskAG { get; set; }
    }

    public class UAGUsrModel : RequestBaseModel
    {
        public string USER_ID { get; set; }

        public string TABLE { get; set; }

        public List<ExistingUAGModel> ExistingUAG { get; set; }
        public List<KioskAGModel> KioskAG { get; set; }
        public string UAG_Type { get; set; }
    }

    public class ExistingUAGModel //: RequestBaseModel
    {
        public string UAG_UserID { get; set; }
        public string UAG_GroupID { get; set; }
        public string UAG_BusinessUnit { get; set; }
        public string UAG_CustomerID { get; set; }
        public string UAG_VendorID { get; set; }
        public bool UAG_Status { get; set; }
        public string UAG_Type { get; set; }
        public string TABLE { get; set; }
        public string USER_ID { get; set; }
    }

    public class KioskAGModel
    {
        public string UAG_GroupID { get; set; }
        public string UAG_VendorID { get; set; }
    }

    public class GetUAGAllModel : RequestBaseModel
    {

        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }
        public string UD_StaffID { get; set; }
        public string UD_FirstName { get; set; }
        public string UD_LastName { get; set; }
        public string UGM_Name { get; set; }
        public string BU_CompanyName { get; set; }
        public string CUS_CompanyName { get; set; }
        public string UAG_Status { get; set; }
    }

    public class GetUAGSingleModel : RequestBaseModel
    {
        public string UAG_UserID { get; set; }
        public string UAG_GroupID { get; set; }
        public string UAG_BusinessUnit { get; set; }
        public string UAG_CustomerID { get; set; }
        public string UAG_Type { get; set; }
        public string TABLE { get; set; }
    }

    public class GetUAGUsrAllModel : RequestBaseModel
    {

        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }
        public string UD_StaffID { get; set; }
        public string UD_FirstName { get; set; }
        public string UD_LastName { get; set; }
        public string UGM_Name { get; set; }
        public string BU_CompanyName { get; set; }
        public string UD_DepartmentID { get; set; }
        public string UAG_Status { get; set; }
        public string TABLE { get; set; }
    }

    public class ReturnUAGAllModelHead : ReturnResponse
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnUAGModel> User { get; set; }
    }

    public class ReturnUAGUsrAllModelHead : ReturnResponse
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnUAGUsrModel> User { get; set; }
    }

    public class ReturnUAGModel
    {
        [Key]
        public string UD_StaffID { get; set; }
        public string UD_FirstName { get; set; }
        public string UD_LastName { get; set; }
        public string UAG_GroupID { get; set; }
        public string UGM_Name { get; set; }
        public string UAG_BusinessUnit { get; set; }
        public string BU_CompanyName { get; set; }
        public string UAG_CustomerID { get; set; }
        public string CUS_CompanyName { get; set; }
        public string UAG_VendorID { get; set; }
        public string UAG_Status { get; set; }
        public string RC { get; set; }
    }

    public class ReturnUAGUsrModel
    {
        [Key]
        public string UD_StaffID { get; set; }
        public string UD_FirstName { get; set; }
        public string UD_LastName { get; set; }
        public string UAG_GroupID { get; set; }
        public string UGM_Name { get; set; }
        public string UAG_BusinessUnit { get; set; }
        public string BU_CompanyName { get; set; }
        public string UAG_CustomerID { get; set; }
        public string CUS_CompanyName { get; set; }
        public string UAG_VendorID { get; set; }
        public string UAG_Status { get; set; }
        public string RC { get; set; }
    }







}
