using System;
using System.Collections.Generic;
using System.Text;

namespace HRM_DAL.ReportModels
{
    public class CourierExpensesModel
    {
        public string CustomerName { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string PCCode { get; set; }
        public string DepartmentName { get; set; }
        public decimal Courier_Local_Cover { get; set; }
        public decimal Courier_Local_Postage { get; set; }
        public decimal Courier_Oversea_Cover { get; set; }
        public decimal Courier_Oversea_Postage { get; set; }
        public decimal Courier_Total_Cover { get; set; }
        public decimal Courier_Total_Postage { get; set; }
    }
}