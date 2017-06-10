using Hot_Pot_Restaurant_Management_System.Common.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.ViewModels
{
    public class ServingTableViewResult
    {
        [DisplayName("Number")]
        [NotZero]
        [MaxValueLength(6)]
        public int ID { get; set; }

        [DisplayName("Bill number")]
        public string BillID { get; set; }
    }
}