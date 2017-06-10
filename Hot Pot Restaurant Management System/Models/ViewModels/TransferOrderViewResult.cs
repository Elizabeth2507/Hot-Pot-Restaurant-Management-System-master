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
    public class TransferOrderViewResult
    {
        [DisplayName("Number")]
        public string ID { get; set; }

        [DisplayName("Outname warehouse")]
        public string OutName { get; set; }

        [DisplayName("Gotoname warehouse")]
        public string InName { get; set; }

        [DisplayName("Operator number")]
        [NotZero]
        [MaxValueLength(6)]
        public int OperatorID { get; set; }

        [DisplayName("Operator name")]
        public string OperatorName { get; set; }

        [DisplayName("User number")]
        [Required(ErrorMessage = "Missing user number")]
        [NotZero]
        [MaxValueLength(6)]
        public int UserID { get; set; }

        [DisplayName("User name")]
        public string UserName { get; set; }

        [DisplayName("Date")]
        [Required(ErrorMessage = "Missing date")]
        [NotZero]
        public DateTime Date { get; set; }

        [DisplayName("Remarks")]
        public string Remark { get; set; }

        public List<TODetailsViewResult> Details { get; set; }
    }
}