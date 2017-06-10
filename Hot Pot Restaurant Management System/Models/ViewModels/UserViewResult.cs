using Hot_Pot_Restaurant_Management_System.Common.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.ViewModels
{
    public class UserViewResult
    {
        public int ID { get; set; }

        [DisplayName("Short number")]
        [Required(ErrorMessage = "Missing short number")]
        [NotZero]
        [MaxValueLength(6)]
        public int ShortID { get; set; }

        [DisplayName("User name")]
        public string UserName { get; set; }

        [DisplayName("Role")]
        [Required(ErrorMessage = "Missing role")]
        [NotZero]
        [MaxValueLength(6)]
        public int Role { get; set; }

        [DisplayName("Password")]
        public string Password { get; set; }

        [DisplayName("Real name")]
        public string RealName { get; set; }

        [DisplayName("Real post")]
        public string RealPost { get; set; }
    }
}