
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{
    public class ReceivePendingModel : RequestGridBaseModel
    {
        public string TransactionDate { get; set; }
        public string Staff_ID { get; set; }
        public string Department { get; set; }
        public string DepartmentPCCode { get; set; }
        public string MailTypeID { get; set; }
    }

    public class ReceiveRequestBatchNoModel : RequestBaseModel
    {
        public string BatchNo { get; set; }
    }

    public class ReceiveDeleteBatchNoModel : ReceiveRequestBatchNoModel
    {
        public string CreatedBy { get; set; }
    }

    public class ReceiveGridRequestBatchNoModel : RequestGridBaseModel
    {
        public string BatchNo { get; set; }
        public string Staff_ID { get; set; }
        public string TrDateFrom { get; set; }
        public string TrDateTo { get; set; }
        public string PCCode { get; set; }
        public string MailTypeID { get; set; }
        public string USER_ID { get; set; }
    }

    public class ReceiveSubmitBatchNoModel : RequestBaseModel
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
        public string TransactionDateTime { get; set; }
        public string ServerSyncDatetime { get; set; }
    }
    public class ReceiveCreateNewBatchModel : RequestBaseModel
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
        public byte[] UploadedFile { get; set; }
        public string UploadedFileFormat { get; set; }
    }

    public class ReceiveSummeryHeaderModel : ReturnResponse
    {
        public List<ReceiveSummeryModel> ReceiveSummeryModelList { get; set; } = new List<ReceiveSummeryModel>();
    }

    public class ReceiveSummeryModel
    {
        public string BatchNo { get; set; }
        public string DeviceNo { get; set; }
        public string StaffID { get; set; }
        public string MailType { get; set; }
        public string Quantity { get; set; }
        public string PCCode { get; set; }
        public bool IsOffLine { get; set; }
        public string TransactionDate { get; set; }
        public string StaffName { get; set; }
        public string DepartmentID { get; set; }
    }

    public class ReceiveGridViewHeaderModel : ReturnResponse
    {
        public List<ReceiveGridViewModel> ReceiveGridViewModelList { get; set; } = new List<ReceiveGridViewModel>();
    }
    public class ReceiveCreateNewBatchHeaderModel : ReturnResponse
    {
        public List<ReceiveGridViewModel> ReceiveGridViewModelList { get; set; } = new List<ReceiveGridViewModel>();
    }

    public class ReceiveGridViewModel : ReturnResponseGridViewBaseModel
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
    }

    public class ReceiveSubmitBatchModel : ReturnResponse
    {
    }
    public class ServerDateTimeHeaderModel : ReturnResponse
    {
        public DateTime ServerDateTime { get; set; }
    }
}

