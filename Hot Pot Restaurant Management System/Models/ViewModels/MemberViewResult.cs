using Hot_Pot_Restaurant_Management_System.Common.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.ViewModels
{
    public class MemberViewResult
    {
        [DisplayName("Member number")]
        [Required(ErrorMessage = "Missing member number")]
       
        public string ID { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Missing member name")]
        
        public string Name { get; set; }

        [DisplayName("Contact number")]
        [Required(ErrorMessage = "Missing contact number")]
        [MaxLength(50, ErrorMessage = "The contact number can not be greater than 50 characters")]
        [RegularExpression(@"\d+", ErrorMessage = "Need a valid number")]
        public string Tele { get; set; }

        [DisplayName("Point")]
        [Required(ErrorMessage = "Missing point")]
        [MaxValueLength(9)]
        public int Point { get; set; }
    }
}