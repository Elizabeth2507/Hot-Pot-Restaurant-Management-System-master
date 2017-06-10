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
    public class CODetailsViewResult : IOrderDetails
    {
        [DisplayName("Number")]
        public string ID { get; set; }

        [DisplayName("Product name")]
        [Required(ErrorMessage = "Missing product name")]
        [MaxLength(50, ErrorMessage = "The product name can not be greater than 50 characters")]
        public string ProductName { get; set; }

        [DisplayName("Sales unit")]
        [Required(ErrorMessage = "Lack of pricing unit")]
        public string Unit { get; set; }

        [DisplayName("Quantity")]
        [Required(ErrorMessage = "Missing quantity")]
        [NotZero]
        [MaxValueLength(9)]
        public double Amount { get; set; }

        [DisplayName("Price")]
        [Required(ErrorMessage = "Lack of price")]
        public decimal Price { get; set; }

        public string OrderID { get; set; }

        [DisplayName("Batch of goods")]
        [Required(ErrorMessage= "Missing product batches")]
        [MaxLength(50, ErrorMessage = "The batch can not be more than 50 characters")]
        public string POID { get; set; }
    }
}