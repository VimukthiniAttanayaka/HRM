using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace HRM_DAL.ReportModels
{
    public class PrintQRStickerModel
    {
        public string CNID { get; set; }
        public string BatchNo { get; set; }
        public string CountryCode { get; set; }
        public string StaffID { get; set; }
        public string MailType { get; set; }
        public string Quantity { get; set; }
        public string PCCode { get; set; }
        public string CompanyName { get; set; }
        public string ContainerNumber { get; set; }
        public string ContainerType { get; set; }
        public string CostCenterNumber { get; set; }
        public string CostCenterName { get; set; }
        public string CN_LabelFooterLine1 { get; set; }
        public string CN_LabelFooterLine2 { get; set; }
        public System.Byte[] BarCode { get; set; }
    }

    public class QRPrintingModel
    {
        internal string DeviceNo;

        public string DatePrinted { get; set; }
        public string BatchNo { get; set; }
        public string StaffID { get; set; }
        public string StaffName { get; set; }
        public string PCCode { get; set; }
        public string DepartmentName { get; set; }
        public string MailType { get; set; }
        public string ReceivedAtMailRoomOn { get; set; }
        public string DeclaredMailQuantity { get; set; }
        public string ActualMailQuantity { get; set; }
        public string TransactionNumber { get; set; }
        public System.Byte[] BarCode { get; set; }
        public string DepartmentID { get; set; }
        public string MailTypeID { get; set; }
        public string DeclaredQuantity { get; internal set; }
        public string TransactionDate { get; internal set; }
    }
}
