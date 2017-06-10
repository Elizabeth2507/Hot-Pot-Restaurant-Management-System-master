using Hot_Pot_Restaurant_Management_System.Common.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.ViewModels
{
    public class BillViewResult
    {
        [DisplayName("Number")]
        [Required(ErrorMessage = "Missing number")]
        [MaxLength(50, ErrorMessage = "The number can not be greater than 50 characters")]
        public string ID { get; set; }

        [DisplayName("Table number")]
        [Required(ErrorMessage = "Missing table number")]
        [NotZero]
        [MaxValueLength(6)]
        public int TableID { get; set; }

        [DisplayName("Date")]
        [Required(ErrorMessage = "Missing date")]
        [NotZero]
        public DateTime Date { get; set; }

        [DisplayName("Number of customers")]
        [Required(ErrorMessage = "Lack of customer number")]
        [NotZero]
        [MaxValueLength(6)]
        public int CustomerCount { get; set; }

        [DisplayName("Time period")]
        [Required(ErrorMessage = "Lack of time")]
        [NotZero]
        [MaxValueLength(6)]
        public int TimePeriod { get; set; }

        [DisplayName("Total price")]
        [Required(ErrorMessage = "Lack of total price")]
        public decimal TotalCost { get; set; }

        [DisplayName("Discount (percentage)")]
        public Nullable<int> Discount { get; set; }

        [DisplayName("Discount")]
        public string DiscountType { get; set; }

        [DisplayName("Actual price")]
        [Required(ErrorMessage = "Lack of actual price")]
        public decimal ExactCost { get; set; }

        [DisplayName("Remarks")]
        [MaxLength(50, ErrorMessage = "Remarks can not be greater than 50 characters")]
        public string Remark { get; set; }

        [DisplayName("User number")]
        [Required(ErrorMessage = "Missing user number")]
        [NotZero]
        [MaxValueLength(6)]
        public int UserID { get; set; }

        [DisplayName("User name")]
        [Required(ErrorMessage = "Lack of user name")]
        [MaxLength(50, ErrorMessage = "The user name can not be greater than 50 characters")]
        public string UserName { get; set; }

        [DisplayName("Member number")]
        [MaxLength(50, ErrorMessage = "The number can not be greater than 50 characters")]
        public string MemberID { get; set; }

        [DisplayName("Payment amount")]
        [Required(ErrorMessage = "Lack of payment amount")]
        public decimal ReceivedMoney { get; set; }

        [DisplayName("Change")]
        [Required(ErrorMessage = "Lack of change")]
        public decimal Change { get; set; }

        public List<BillDetailsViewResult> Details { get; set; }
    }
}