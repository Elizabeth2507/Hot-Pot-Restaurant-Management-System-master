using Hot_Pot_Restaurant_Management_System.Common.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.ViewModels
{
    public class StartOfTermViewResult
    {
        [DisplayName("Number")]
        public string ID { get; set; }

        [DisplayName("Date")]
        [NotZero]
        public DateTime Date { get; set; }

        [DisplayName("Product name")]
        public string ProductName { get; set; }

        [DisplayName("Warehouse name")]
        public string WarehouseName { get; set; }

        [DisplayName("Price")]
        [Required(ErrorMessage = "Missing price")]
        public decimal Price { get; set; }

        [DisplayName("Quantity")]
        [NotZero]
        [MaxValueLength(9)]
        public double Amount { get; set; }

        [DisplayName("Total price")]
        public decimal TotalPrice { get; set; }
    }
}