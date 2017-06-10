using Hot_Pot_Restaurant_Management_System.Common.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.ViewModels
{
    public class BillDetailsViewResult
    {
        [DisplayName("Number")]
        public string ID { get; set; }

        [DisplayName("Dish name")]
        [Required(ErrorMessage = "Missing dish name")]
        [MaxLength(50, ErrorMessage = "The menu name can not be greater than 50 characters")]
        public string DishName { get; set; }

        [DisplayName("Quantity")]
        [Required(ErrorMessage = "Missing quantity")]
        [NotZero]
        [MaxValueLength(9)]
        public double Amount { get; set; }

        public string OrderID { get; set; }

        [DisplayName("Warehouse number")]
        [MaxValueLength(9)]
        public Nullable<int> WarehouseID { get; set; }

        [DisplayName("Batch of goods")]
        [MaxLength(50, ErrorMessage = "The batch can not be more than 50 characters")]
        public string POID { get; set; }
    }
}