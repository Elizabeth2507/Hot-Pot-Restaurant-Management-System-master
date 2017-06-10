using Hot_Pot_Restaurant_Management_System.Common.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.ViewModels
{
    public class MonthlyReportViewResult
    {
        [DisplayName("Number")]
        [Required(ErrorMessage = "Missing number")]
        [MaxLength(50, ErrorMessage = "The query number can not be greater than 50 characters")]
        public string ID { get; set; }

        [DisplayName("Date")]
        [Required(ErrorMessage = "Missing date")]
        [NotZero]
        public DateTime Date { get; set; }

        [DisplayName("Warehouse name")]
        [Required(ErrorMessage = "Missing warehouse name")]
       
        public string WarehouseName { get; set; }

        public List<MReportDetailsViewResult> Details { get; set; }
    }
}