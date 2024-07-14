
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using static HRM_DAL.Data.DayEndProcess_Data;

namespace HRM_DAL.Models
{
    public class ProcessRequestBatchNoModel : RequestBaseModel
    {
        public string BatchNo { get; set; }
    }

    public class ProcessRequestQRStringModel : RequestBaseModel
    {
        public string QRString { get; set; }
    }

    public class ProcessGridRequestBatchNoModel : RequestGridBaseModel
    {
        public string BatchNo { get; set; }
        public string Staff_ID { get; set; }
        public DateTime TrDateFrom { get; set; }
        public DateTime TrDateTo { get; set; }
        public string PCCode { get; set; }
        public string MailTypeID { get; set; }
        public string ProcessedBy { get; set; }
    }

    public class ProcessSubmitBatchNoModel : RequestBaseModel
    {
        public string BatchNo { get; set; }
        public string StaffID { get; set; }
        public string StaffName { get; set; }
        public string DepartmentID { get; set; }
        public bool IsOffLine { get; set; }
        public string PCCode { get; set; }
        public string MailType { get; set; }
        public decimal DeclaredQty { get; set; }
        public decimal RecievedQty { get; set; }
        public string CustomerID { get; set; }
        public string CreatedBy { get; set; }
        public string DeviceNo { get; set; }

        public string DeviceTypeID { get; set; }
        public string VendorID { get; set; }
        public string LocationID { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public DateTime ProcessingDateTime { get; set; }
        public DateTime ServerSyncDatetime { get; set; }

        public byte[] UploadedFile_Processing_ItemLevel_Local { get; set; }
        public byte[] UploadedFile_Processing_ItemLevel_Oversea { get; set; }
        public List<ProcessSubmitBatchNoModel_ItemLevel> ProcessSubmitBatchNoModel_ItemLevel_Local { get; set; } = new List<ProcessSubmitBatchNoModel_ItemLevel>();
        public List<ProcessSubmitBatchNoModel_ItemLevel> ProcessSubmitBatchNoModel_ItemLevel_Oversea { get; set; } = new List<ProcessSubmitBatchNoModel_ItemLevel>();
        public decimal Processing_ItemLevel_Oversea_Total { get; set; }
        public decimal Processing_ItemLevel_Local_Total { get; set; }
        public string UploadedFileFormat_Local { get; set; }
        public string UploadedFileFormat_Oversea { get; set; }


        public bool AttachDocsToEmail { get; set; }
    }

    public class ProcessSubmitBatchNoModel_ItemLevel
    {
        public string BatchNo { get; set; }
        public int SN { get; set; }
        public decimal PostageAmount { get; set; }
        public string TrackingNumber { get; set; }
        public string RecipentName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string MailItemType { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalCost { get; set; }
        public string Deliver_Courier_Company { get; set; }
        public bool TrackedMail { get; set; }
        public bool TrackedPackage { get; set; }
        public bool BatchedRecord { get; set; }
    }

    public class ProcessCreateNewBatchModel
    {
        //public string BatchNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public string StaffID { get; set; }
        public string StaffName { get; set; }
        public string DepartmentID { get; set; }
        public bool IsOffLine { get; set; }
        public string PCCode { get; set; }
        public string MailType { get; set; }
        public decimal DeclaredQty { get; set; }
        public decimal RecievedQty { get; set; }
        public string CustomerID { get; set; }
        public string CreatedBy { get; set; }
        public string DeviceNo { get; set; }

        public string DeviceTypeID { get; set; }
        public string VendorID { get; set; }
        public string LocationID { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public DateTime ServerSyncDatetime { get; set; }
        public byte[] UploadedFile { get; set; }
    }

    public class ProcessSummeryHeaderModel : ReturnResponse
    {
        public List<ProcessSummeryModel> ProcessSummeryModelList { get; set; } = new List<ProcessSummeryModel>();
    }

    public class ProcessSummeryModel
    {
        public string BatchNo { get; set; }
        public string DeviceNo { get; set; }
        public string StaffID { get; set; }
        public string MailType { get; set; }
        public string Quantity { get; set; }
        public string PCCode { get; set; }
        public bool IsOffLine { get; set; }
        public string Received_Qty { get; set; }
        public string StaffName { get; set; }
        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        //public List<DayEndProcessDetail> DayEndProcessDetails { get; set; }
    }

    public class FullProcessSummeryHeaderModel : ReturnResponse
    {
        public List<ProcessSummeryModel> ProcessSummeryModelList { get; set; } = new List<ProcessSummeryModel>();
    }

    public class ProcessGridViewHeaderModel : ReturnResponse
    {
        public List<ProcessGridViewModel> ProcessGridViewModelList { get; set; } = new List<ProcessGridViewModel>();
    }
    public class ProcessCreateNewBatchHeaderModel : ReturnResponse
    {
        public List<ProcessGridViewModel> ProcessGridViewModelList { get; set; } = new List<ProcessGridViewModel>();
    }

    public class ProcessGridViewModel : ReturnResponseGridViewBaseModel
    {
        public string BatchNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public string StaffName { get; set; }
        public string PCCode { get; set; }
        public string MailType { get; set; }
        public decimal RecievedQty { get; set; }
        public decimal DeclaredQty { get; set; }
        public string Staff_ID { get; set; }
        public string MailTypeID { get; set; }
        public string Location { get; set; }
        public decimal LocalCost { get; set; }
        public decimal OverseaCost { get; set; }
        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }

    public class ProcessSubmitBatchModel : ReturnResponse
    {
    }

}

