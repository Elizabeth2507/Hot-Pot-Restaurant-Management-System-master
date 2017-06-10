using Hot_Pot_Restaurant_Management_System.Common.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.ViewModels
{
    public class DiscountViewResult
    {
        [DisplayName("Number")]
        public int ID { get; set; }

        [DisplayName("Discount (percentage)）")]
        [Required(ErrorMessage = "Lack of discount")]
        [NotZero]
        [MaxValueLength(6)]
        public int DiscountPercent { get; set; }

        [DisplayName("Does not include dishes in the discount")]
        public string IgnoredCategories { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "Lack of description")]
        [MaxLength(50, ErrorMessage = "Description can not be greater than 50 characters")]
        public string Description { get; set; }

        [DisplayName("Membership is limited")]
        [Required(ErrorMessage = "Missing member limit setting")]
        public bool IsMemberOnly { get; set; }
    }
}