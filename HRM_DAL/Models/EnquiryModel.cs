
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{
    public class EnquirySubmitModel : RequestBaseModel
    {
        public string BatchNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TrackingNo { get; set; }
        public string Location { get; set; }
        public string KioskID { get; set; }
        public string StaffName { get; set; }
        public string PCCode { get; set; }
        public string MailType { get; set; }
        public decimal Quantity { get; set; }
        public decimal PostageTotal { get; set; }
        public string CreatedBy { get; set; }
        public string MailItemType { get; set; }
        public string SN { get; set; }
    }

    public class EnquirySubmitResponceModel : ReturnResponse
    {
    }
    public class EnquiryRequestModel : RequestBaseModel
    {
        public string BatchNo { get; set; }
        public string MailItemType { get; set; }
        public string SN { get; set; }
    }

    public class EnquiryResponceModel
    {
        public string BatchNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TrackingNumber { get; set; }
        public string Location { get; set; }
        public string KioskID { get; set; }
        public string StaffName { get; set; }
        public string PCCode { get; set; }
        public string MailType { get; set; }
        public decimal Quantity { get; set; }
        public decimal PostageTotal { get; set; }
        public string LocationID { get; set; }
        public string Staff_ID { get; set; }
        public string MailTypeID { get; set; }




        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string RecipentName { get; set; }
        public string MailItemType { get; set; }
        public string ProcessedBy { get; set; }
        public string CPCode { get; set; }
        public string CUS_CompanyName { get; set; }
        public string SN { get; set; }
    }

    public class EnquiryHeaderResponceModel : ReturnResponse
    {
        public List<EnquiryResponceModel> EnquiryResponceModelList { get; set; } = new List<EnquiryResponceModel>();

    }

    #region Grid Sction

    public class EnquiryGridRequestModel : RequestGridBaseModel
    {
        public string BatchNo { get; set; }
        public string TransactionDate { get; set; }
        public string Staff_ID { get; set; }
        public string PCCode { get; set; }
        public string MailTypeID { get; set; }
        public string TrackingNo { get; set; }
        public string Status { get; set; }

        public string MailingType { get; set; }
        public string DepartmentID { get; set; }
        public string CPCode { get; set; }
        public string ExceptionStatus { get; set; }
        public string Receipent { get; set; }
        public string StatusChangedBy { get; set; }
        public string ProcessedBy { get; set; }


        //Sender
        //Mailtrak user(Processed by)
    }

    public class MailBagEnquiryGridRequestModel : RequestGridBaseModel
    {
        public string TransactionDate { get; set; }
        public string UserID { get; set; }
        public string PCCode { get; set; }
        public string TransactionNo { get; set; }
        public string Status { get; set; }

        public string DepartmentID { get; set; }
        public string CPCode { get; set; }
        public string StatusChangedBy { get; set; }

        public string KioskNumber { get; set; }
        public string BoxNumber { get; set; }
        public string ContainerNumber { get; set; }
        public string TransactionType { get; set; }

        //Sender
        //Mailtrak user(Processed by)
    }

    public class EnquiryGridViewHeaderModel : ReturnResponse
    {
        public List<EnquiryGridViewModel> EnquiryGridViewModelList { get; set; } = new List<EnquiryGridViewModel>();
    }

    public class EnquiryGridViewModel : ReturnResponseGridViewBaseModel
    {
        public string BatchNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public string StaffName { get; set; }
        public string PCCode { get; set; }
        public string MailType { get; set; }
        public string ProcessStage { get; set; }
        public string ExceptionType { get; set; }
        public string Enquirytatus { get; set; }
        public string MailTypeID { get; set; }
        public string Staff_ID { get; set; }
        public string TrackingNumber { get; set; }
        public string KioskID { get; set; }
        public string PostageTotal { get; set; }
        public string Quantity { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }

        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string RecipentName { get; set; }
        public string MailItemType { get; set; }
        public string ProcessedBy { get; set; }
        public string CPCode { get; set; }
        public string CUS_CompanyName { get; set; }
        public string SN { get; set; }
    }

    public class EnquiryMailBagGridViewHeaderModel : ReturnResponse
    {
        public List<EnquiryMailBagGridViewModel> EnquiryGridViewModelList { get; set; } = new List<EnquiryMailBagGridViewModel>();
    }
    public class EnquiryMailBagGridViewModel : ReturnResponseGridViewBaseModel
    {
        public string AID { get; set; }
        public string TransactionNo { get; set; }
        public string BagType { get; set; }
        public string ContainerID { get; set; }
        public string SealID { get; set; }
        public string Action { get; set; }
        public string BoxNo { get; set; }
        public string TransactionType { get; set; }
        public string CutomerID { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public DateTime ServerSyncDateTime { get; set; }
        public string TripNo { get; set; }
        public string UserID { get; set; }
        public string DeviceNo { get; set; }
        public string DeviceTypeId { get; set; }
        public string VendorID { get; set; }
        public string LocationID { get; set; }
        public string CPCode { get; set; }
        public string IsNoBag { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string IsAcknowledgedWithKioski { get; set; }
        public string RequestReferenceID { get; set; }
        public string isLooseMail { get; set; }
    }

    #endregion Grid Sction
}
