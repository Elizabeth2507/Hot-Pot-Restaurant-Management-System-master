using Hot_Pot_Restaurant_Management_System.Common.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.ViewModels
{
    public class ProductViewResult
    {
        public int ID { get; set; }

        [DisplayName("Shoer number")]
        [Required(ErrorMessage = "Missing short number")]
        [NotZero]
        [MaxValueLength(6)]
        public int ShortID { get; set; }

        [DisplayName("Product name")]
        public string Name { get; set; }

        [DisplayName("Short name")]
        public string ShortName { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage = "Missing category")]
        [NotZero]
        public int CategoryID { get; set; }

        [DisplayName("Sales unit")]
        [Required(ErrorMessage = "Lack of sales unit")]
        public string Unit { get; set; }
    }
}