﻿using Hot_Pot_Restaurant_Management_System.Common.CustomValidations;
using Hot_Pot_Restaurant_Management_System.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.ViewModels
{
    public class MaterialsReturnOrderViewResult : IOrder<MRODetailsViewResult>
    {
        [DisplayName("Number")]
        [Required(ErrorMessage = "Missing number")]
        
        public string ID { get; set; }

        [DisplayName("Warehouse name")]
        [Required(ErrorMessage = "Missing warehouse name")]
        
        public string WarehouseName { get; set; }

        [DisplayName("Operator number")]
        [Required(ErrorMessage = "Missing operator number")]
        [NotZero]
        [MaxValueLength(6)]
        public int OperatorID { get; set; }

        [DisplayName("Operator name")]
        [Required(ErrorMessage = "Missing operator name")]
        
        public string OperatorName { get; set; }

        [DisplayName("User number")]
        [Required(ErrorMessage = "Missing user number")]
        [NotZero]
        [MaxValueLength(6)]
        public int UserID { get; set; }

        [DisplayName("User name")]
        [Required(ErrorMessage = "Missing user name")]
        [MaxLength(50, ErrorMessage = "The user name can not be greater than 50 characters")]
        public string UserName { get; set; }

        [DisplayName("Date")]
        [Required(ErrorMessage = "Missing date")]
        [NotZero]
        public DateTime Date { get; set; }

        [DisplayName("Remark")]
        [MaxLength(50, ErrorMessage = "Remarks can not be greater than 50 characters")]
        public string Remark { get; set; }

        public List<MRODetailsViewResult> Details { get; set; }
    }
}