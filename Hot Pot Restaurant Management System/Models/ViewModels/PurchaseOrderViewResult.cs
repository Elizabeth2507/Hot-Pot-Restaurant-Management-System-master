using Hot_Pot_Restaurant_Management_System.Common.CustomValidations;
using Hot_Pot_Restaurant_Management_System.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.ViewModels
{
    public class PurchaseOrderViewResult : IOrder<PODetailsViewResult>
    {
        [DisplayName("Number")]
        public string ID { get; set; }

        [DisplayName("Supplier name")]
        public string SupplierName { get; set; }

        [DisplayName("Warehouse name")]
        public string WarehouseName { get; set; }

        [DisplayName("Operator number")]
        [NotZero]
        [MaxValueLength(6)]
        public int OperatorID { get; set; }

        [DisplayName("Operator name")]
        public string OperatorName { get; set; }

        [DisplayName("User numbar")]
        [NotZero]
        [MaxValueLength(6)]
        public int UserID { get; set; }

        [DisplayName("User name")]
        public string UserName { get; set; }

        [DisplayName("Date")]
        [NotZero]
        public DateTime Date { get; set; }

        [DisplayName("Remark")]
        public string Remark { get; set; }

        public List<PODetailsViewResult> Details { get; set; }
    }
}