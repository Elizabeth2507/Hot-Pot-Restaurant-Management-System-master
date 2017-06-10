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
    public class CategoryViewResult : ITreeView
    {
        public int ID { get; set; }

        [DisplayName("Number")]
        [Required(ErrorMessage = "Missing number")]
        [NotZero]
        [MaxValueLength(6)]
        public int ShortID { get; set; }

        [DisplayName("Category Name")]
        [Required(ErrorMessage = "Missing category name")]
        [MaxLength(50, ErrorMessage = "The category name can not be greater than 50 characters")]
        public string Name { get; set; }

        [DisplayName("Sub-headings")]
        public int SuperiorID { get; set; }

        public List<ITreeView> Children { get; set; }

        public CategoryViewResult()
        {
            Children = new List<ITreeView>();
        }
    }
}