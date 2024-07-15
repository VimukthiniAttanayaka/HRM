
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{
    public class ExceptionsSubmitModel : RequestBaseModel
    {
        public string BatchNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Location { get; set; }
        public string KioskID { get; set; }
        public string StaffName { get; set; }
        public string PCCode { get; set; }
        public string MailType { get; set; }
        public string ProcessStage { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionStatus { get; set; }
        public decimal DeclaredQty { get; set; }
        public decimal ReceivedQty { get; set; }
        public string CreatedBy { get; set; }
    }

    public class ExceptionsStatusSubmitModel : RequestBaseModel
    {
        public string BatchNo { get; set; }
        public string ExceptionStatus { get; set; }
        public string CreatedBy { get; set; }
    }

    public class ExceptionsSubmitResponceModel : ReturnResponse
    {
    }
    public class ExceptionsRequestModel : RequestBaseModel
    {
        public string BatchNo { get; set; }
    }

    public class ExceptionsResponceModel
    {
        public string BatchNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Location { get; set; }
        public string KioskID { get; set; }
        public string StaffName { get; set; }
        public string PCCode { get; set; }
        public string MailType { get; set; }
        public string ProcessStage { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionStatus { get; set; }
        public decimal DeclaredQty { get; set; }
        public decimal ReceivedQty { get; set; }
        public string Staff_ID { get;  set; }
        public string LocationID { get;  set; }
        public string MailTypeID { get;  set; }
    }

    public class ExceptionsHeaderResponceModel : ReturnResponse
    {
        public List<ExceptionsResponceModel> ExceptionsResponceModelList { get; set; } = new List<ExceptionsResponceModel>();

    }
    public class ExceptionsStatusHeaderResponceModel : ReturnResponse
    {

    }

    #region Grid Sction

    public class ExceptionsGridRequestModel : RequestGridBaseModel
    {
        public string BatchNo { get; set; }
        public string TransactionDate { get; set; }
        public string Staff_ID { get; set; }
        public string PCCode { get; set; }
        public string MailTypeID { get; set; }
        public string ProcessStage { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionStatus { get; set; }
    }

    public class ExceptionsGridViewHeaderModel : ReturnResponse
    {
        public List<ExceptionsGridViewModel> ExceptionsGridViewModelList { get; set; } = new List<ExceptionsGridViewModel>();
    }

    public class ExceptionsGridViewModel : ReturnResponseGridViewBaseModel
    {
        public string BatchNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public string StaffName { get; set; }
        public string PCCode { get; set; }
        public string MailType { get; set; }
        public string ProcessStage { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionStatus { get; set; }
        public string MailTypeID { get;  set; }
        public string Staff_ID { get;  set; }
        public string DepartmentID { get;  set; }
        public string FilePathReference_Processing_ItemLevel_Oversea { get;  set; }
        public string Processing_ItemLevel_Local_Total { get;  set; }
        public string Processing_ItemLevel_Oversea_Total { get;  set; }
        public string FilePathReference_Processing_ItemLevel_Local { get;  set; }
        public string KioskID { get;  set; }
        public string DeviceTypeID { get;  set; }
        public string VendorID { get;  set; }
        public string Declared_Qty { get;  set; }
        public string Received_Qty { get;  set; }
        public string LocationID { get;  set; }
        public string Location { get;  set; }
        public string Status { get;  set; }
        public string ServerSyncDatetime { get;  set; }
        public string Processing_Date { get;  set; }
        public string IsOffline { get;  set; }
        public string IsManualBatch { get;  set; }
        public string IsManualBatchDataSync { get;  set; }
        public string TransactionSyncDateTime { get;  set; }
        public string RefBatchNo { get;  set; }
        public string StatusChangedBy { get;  set; }
        public string StatusChangedDatetime { get;  set; }
        public string CreatedDatetime { get;  set; }
        public string CreatedBy { get;  set; }
        public string ReceivedDatetime { get;  set; }
        public string ReceivedBy { get;  set; }
        public string ProcessedDatetime { get;  set; }
        public string ProcessedBy { get;  set; }
        public string FilePathReference_Receiving { get;  set; }
    }

    #endregion Grid Sction
}
