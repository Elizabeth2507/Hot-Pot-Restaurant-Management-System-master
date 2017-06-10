using Hot_Pot_Restaurant_Management_System.Common.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.ViewModels
{
    public class VInventoryListViewResult
    {
        [DisplayName("Batch of goods")]
        [MaxLength(50, ErrorMessage = "The batch can not be more than 50 characters")]
        public string POID { get; set; }

        public int ProductID { get; set; }

        [DisplayName("Product short num")]
        [NotZero]
        [MaxValueLength(6)]
        public int ProductShortID { get; set; }

        [DisplayName("Product name")]
        public string ProductName { get; set; }

        [DisplayName("Product shortname")]
        public string ProductShortName { get; set; }

        public int WarehouseID { get; set; }

        [DisplayName("Warehouse shortnum")]
        [NotZero]
        [MaxValueLength(6)]
        public int WarehouseShortID { get; set; }

        [DisplayName("Warehouse name")]
        public string WarehouseName { get; set; }

        [DisplayName("Quantity")]
        [NotZero]
        [MaxValueLength(9)]
        public double Amount { get; set; }

        [DisplayName("Sales unit")]
        [Required(ErrorMessage = "Lack of sales unit")]
        public string Unit { get; set; }
    }
}