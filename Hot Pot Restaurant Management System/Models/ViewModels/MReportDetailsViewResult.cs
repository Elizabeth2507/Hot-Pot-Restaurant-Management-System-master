using Hot_Pot_Restaurant_Management_System.Common.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.ViewModels
{
    public class MReportDetailsViewResult
    {
        [DisplayName("Number")]
        public string ID { get; set; }

        [DisplayName("Product name")]
        [Required(ErrorMessage = "Missing product name")]
        
        public string ProductName { get; set; }

        [DisplayName("Purchase price")]
        [Required(ErrorMessage = "Lack of purchase price")]
        public decimal PurchasePrice { get; set; }

        [DisplayName("Purchase quantity")]
        [Required(ErrorMessage = "Missing purchase quantity")]
        [NotZero]
        [MaxValueLength(9)]
        public double PurchaseAmount { get; set; }

        [DisplayName("PurchaseTotalPrice")]
        [Required(ErrorMessage = "Lack of purchase price")]
        public decimal PurchaseTotalPrice { get; set; }

        [DisplayName("Return price")]
        [Required(ErrorMessage = "缺少退货价格")]
        public decimal CreditPrice { get; set; }

        [DisplayName("Number of returns")]
        [Required(ErrorMessage = "Lack of return quantity")]
        [NotZero]
        [MaxValueLength(9)]
        public double CreditAmount { get; set; }

        [DisplayName("Return total price")]
        [Required(ErrorMessage = "Lack of return price")]
        public decimal CreditTotalPrice { get; set; }

        [DisplayName("Picking price")]
        [Required(ErrorMessage = "Lack of picking price")]
        public decimal MRequisitionPrice { get; set; }

        [DisplayName("Requisition amount")]
        [Required(ErrorMessage = "Lack of picking price")]
        [NotZero]
        [MaxValueLength(9)]
        public double MRequisitionAmount { get; set; }

        [DisplayName("Requis totalprice ")]
        
        public decimal MRequisitionTotalPrice { get; set; }

        [DisplayName("Refund price")]
        
        public decimal MReturnPrice { get; set; }

        [DisplayName("Return amount ")]
        
        [NotZero]
        [MaxValueLength(9)]
        public double MReturnAmount { get; set; }

        [DisplayName("Return totalprice")]
        
        public decimal MReturnTotalPrice { get; set; }

        [DisplayName("List price ")]
        
        public decimal SListPrice { get; set; }

        [DisplayName("List amount")]
        
        [NotZero]
        [MaxValueLength(9)]
        public double SListAmount { get; set; }

        [DisplayName("List totalprice")]
        
        public decimal SListTotalPrice { get; set; }

        [DisplayName("Sales cost")]
        
        public decimal BillPrice { get; set; }

        [DisplayName("Sales volume")]
       
        [NotZero]
        [MaxValueLength(9)]
        public double BillAmount { get; set; }

        [DisplayName("Sales totalcost")]
        
        public decimal BillTotalPrice { get; set; }


        public string OrderID { get; set; }

        public StartOfTermViewResult StartOfTerm { get; set; }
    }
}