using Hot_Pot_Restaurant_Management_System.Common.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.ViewModels
{
    public class WarehouseViewResult
    {
        public int ID { get; set; }

        [DisplayName("Number")]
        [NotZero]
        [MaxValueLength(6)]
        public int ShortID { get; set; }

        [DisplayName("Warehouse name")]
        [Required(ErrorMessage = "Missing warehouse name")]
        [MaxLength(50, ErrorMessage = "The warehouse name can not be greater than 50 characters")]
        public string Name { get; set; }
    }
}