using System;
using System.Collections.Generic;
using System.Text;

namespace HRM_DAL.ReportModels
{
    public class PortalExpensesModel
    {
        public string CustomerName { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string PCCode { get; set; }
        public string DepartmentName { get; set; }
        public decimal GrandTotal_Cover { get; set; }
        public decimal GrandTotal_Postage { get; set; }
        public decimal TotalOfLocalPostage { get; set; }
        public decimal TotalOfOverseaPostage { get; set; }
        public decimal Registered_Oversea_Cover { get; set; }
        public decimal Registered_Oversea_Postage { get; set; }
        public decimal Registered_Total_Cover { get; set; }
        public decimal Registered_Total_Postage { get; set; }
        public decimal OrdinaryMail_Local_Cover { get; set; }
        public decimal OrdinaryMail_Local_Postage { get; set; }
        public decimal OrdinaryMail_Oversea_Cover { get; set; }
        public decimal OrdinaryMail_Oversea_Postage { get; set; }
        public decimal OrdinaryMail_Total_Cover { get; set; }
        public decimal OrdinaryMail_Total_Postage { get; set; }
        public decimal Registered_Local_Cover { get; set; }
        public decimal Registered_Local_Postage { get; set; }
    }
}
