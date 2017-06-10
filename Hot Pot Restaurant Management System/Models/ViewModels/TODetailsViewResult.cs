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
    public class TODetailsViewResult
    {              
        [DisplayName("Number")]
        public string ID { get; set; }

        [DisplayName("Product name")]
        public string ProductName { get; set; }

        [DisplayName("Sales unit")]
        public string Unit { get; set; }

        [DisplayName("Quantity")]
        [NotZero]
        [MaxValueLength(9)]
        public double Amount { get; set; }

        public string OrderID { get; set; }

        [DisplayName("Batch of goods")]
        public string POID { get; set; }
    }
}