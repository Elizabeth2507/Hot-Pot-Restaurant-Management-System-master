using Hot_Pot_Restaurant_Management_System.Common.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.ViewModels
{
    public class DishViewResult
    {
        public int ID { get; set; }

        [DisplayName("Short number")]
        [Required(ErrorMessage = "Missing short number")]
        [NotZero]
        [MaxValueLength(6)]
        public int ShortID { get; set; }

        [DisplayName("Dish name")]
        [Required(ErrorMessage = "Missing dish name")]
        [MaxLength(50, ErrorMessage = "The dish name can not be greater than 50 characters")]
        public string Name { get; set; }

        [DisplayName("Short name")]
        [Required(ErrorMessage = "缺少简称")]
        [MaxLength(50, ErrorMessage = "简称不能大于50个字符")]
        public string ShortName { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage = "Missing category")]
        [NotZero]
        public int CategoryID { get; set; }

        [DisplayName("Price")]
        [Required(ErrorMessage = "Lack of price")]
        public decimal Price { get; set; }

        [DisplayName("Sales unit")]
        [Required(ErrorMessage = "Lack of pricing unit")]
        public string Unit { get; set; }

        [DisplayName("Image")]
        public string Image { get; set; }

        [DisplayName("Description")]
        
        public string Description { get; set; }

        [DisplayName("Price editable")]
        [Required(ErrorMessage = "Lack of price setting")]
        public bool PriceEditable { get; set; }

        [DisplayName("Inventory control")]
        [Required(ErrorMessage = "Missing inventory control settings")]
        public bool InventoryControl { get; set; }

        [DisplayName("Unit conversation")]
        public Nullable<double> UnitConversion { get; set; }
    }
}