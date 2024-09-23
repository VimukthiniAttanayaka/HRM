using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{
    public class EmployeeDocumentModel : RequestBaseModel
    {
        public string USRED_EmployeeID { get; set; }
        public string USRED_EmployeeDocumentID { get; set; }
        public string USRED_DocumentType { get; set; }
        public string USRED_DocumentName { get; set; }
        public bool USRED_Status { get; set; }
        public string USRED_CreatedBy { get; set; }
        public DateTime USRED_CreatedDateTime { get; set; }
        public string USRED_ModifiedBy { get; set; }
        public DateTime USRED_ModifiedDateTime { get; set; }
        public string USRED_DocumentData { get; set; }

    }

    public class ReturnEmployeeDocumentModel
    {
        public string USRED_EmployeeID { get; set; }
        public string USRED_EmployeeDocumentID { get; set; }
        public string USRED_DocumentType { get; set; }
        public string USRED_DocumentName { get; set; }
        public bool USRED_Status { get; set; }
        public string USRED_CreatedBy { get; set; }
        public DateTime USRED_CreatedDateTime { get; set; }
        public string USRED_ModifiedBy { get; set; }
        public DateTime USRED_ModifiedDateTime { get; set; }
        public string USRED_DocumentData { get; set; }
    }

    public class ReturnEmployeeDocumentModelHead : ReturnResponse
    {
        public List<ReturnEmployeeDocumentModel> EmployeeDocument { get; set; }


    }
    public class InactiveUSREDModel : RequestBaseModel
    {
        public string USRED_EmployeeDocumentID { get; set; }
    }

    public class EmployeeDocument : RequestBaseModel
    {
        public string USRED_EmployeeDocumentID { get; set; }
    }

    //public class EmployeeDocumentModel : RequestBaseModel
    //{
    //    public string USRED_EmployeeID { get; set; }
    //    public string USRED_DocumentData { get; set; }
    //    public string USRED_DocumentType { get; set; }
    //    public string USRED_DocumentName { get; set; }
    //    public bool USRED_Status { get; set; }
    //    public byte[] USRED_DocumentDataByte { get; set; }
    //    public string USRED_EmployeeDocumentID { get; set; }
    //}
}
