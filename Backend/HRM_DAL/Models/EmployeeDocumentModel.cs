using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{
    public class EmployeeDocumentModel : RequestBaseModel
    {
        public string EED_EmployeeID { get; set; }
        public string EED_EmployeeDocumentID { get; set; }
        public string EED_DocumentType { get; set; }
        public string EED_DocumentName { get; set; }
        public bool EED_Status { get; set; }
        public string EED_CreatedBy { get; set; }
        public DateTime EED_CreatedDateTime { get; set; }
        public string EED_ModifiedBy { get; set; }
        public DateTime EED_ModifiedDateTime { get; set; }
        public string EED_DocumentData { get; set; }

    }

    public class ReturnEmployeeDocumentModel
    {
        public string EED_EmployeeID { get; set; }
        public string EED_EmployeeDocumentID { get; set; }
        public string EED_DocumentType { get; set; }
        public string EED_DocumentName { get; set; }
        public bool EED_Status { get; set; }
        public string EED_CreatedBy { get; set; }
        public DateTime EED_CreatedDateTime { get; set; }
        public string EED_ModifiedBy { get; set; }
        public DateTime EED_ModifiedDateTime { get; set; }
        public string EED_DocumentData { get; set; }
    }

    public class ReturnEmployeeDocumentModelHead : ReturnResponse
    {
        public List<ReturnEmployeeDocumentModel> EmployeeDocument { get; set; }


    }
    public class InactiveEEDModel : RequestBaseModel
    {
        public string EED_EmployeeDocumentID { get; set; }
    }

    public class EmployeeDocument : RequestBaseModel
    {
        public string EED_EmployeeDocumentID { get; set; }
    }

    //public class EmployeeDocumentModel : RequestBaseModel
    //{
    //    public string EED_EmployeeID { get; set; }
    //    public string EED_DocumentData { get; set; }
    //    public string EED_DocumentType { get; set; }
    //    public string EED_DocumentName { get; set; }
    //    public bool EED_Status { get; set; }
    //    public byte[] EED_DocumentDataByte { get; set; }
    //    public string EED_EmployeeDocumentID { get; set; }
    //}
}
