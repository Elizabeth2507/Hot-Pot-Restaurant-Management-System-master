using Hot_Pot_Restaurant_Management_System.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.QueryModels
{
    public class MReportDetailsQueryConditions : QueryConditions
    {
        public string ID { get; set; }
        public string ProductName { get; set; }
        public string OrderID { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal PurchasePriceMin { get; set; }
        public decimal PurchasePriceMax { get; set; }
        public double PurchaseAmount { get; set; }
        public double PurchaseAmountMin { get; set; }
        public double PurchaseAmountMax { get; set; }
        public decimal PurchaseTotalPrice { get; set; }
        public decimal PurchaseTotalPriceMin { get; set; }
        public decimal PurchaseTotalPriceMax { get; set; }
        public double MRequisitionAmount { get; set; }
        public double MRequisitionAmountMin { get; set; }
        public double MRequisitionAmountMax { get; set; }
        public double MReturnAmount { get; set; }
        public double MReturnAmountMin { get; set; }
        public double MReturnAmountMax { get; set; }
        public decimal CreditPrice { get; set; }
        public decimal CreditPriceMin { get; set; }
        public decimal CreditPriceMax { get; set; }
        public double CreditAmount { get; set; }
        public double CreditAmountMin { get; set; }
        public double CreditAmountMax { get; set; }
        public decimal CreditTotalPrice { get; set; }
        public decimal CreditTotalPriceMin { get; set; }
        public decimal CreditTotalPriceMax { get; set; }
        public decimal SListPrice { get; set; }
        public decimal SListPriceMin { get; set; }
        public decimal SListPriceMax { get; set; }
        public double SListAmount { get; set; }
        public double SListAmountMin { get; set; }
        public double SListAmountMax { get; set; }
        public decimal SListTotalPrice { get; set; }
        public decimal SListTotalPriceMin { get; set; }
        public decimal SListTotalPriceMax { get; set; }
        public decimal MRequisitionPrice { get; set; }
        public decimal MRequisitionPriceMin { get; set; }
        public decimal MRequisitionPriceMax { get; set; }
        public decimal MRequisitionTotalPrice { get; set; }
        public decimal MRequisitionTotalPriceMin { get; set; }
        public decimal MRequisitionTotalPriceMax { get; set; }
        public decimal MReturnPrice { get; set; }
        public decimal MReturnPriceMin { get; set; }
        public decimal MReturnPriceMax { get; set; }
        public decimal MReturnTotalPrice { get; set; }
        public decimal MReturnTotalPriceMin { get; set; }
        public decimal MReturnTotalPriceMax { get; set; }
        public decimal BillPrice { get; set; }
        public decimal BillPriceMin { get; set; }
        public decimal BillPriceMax { get; set; }
        public double BillAmount { get; set; }
        public double BillAmountMin { get; set; }
        public double BillAmountMax { get; set; }
        public decimal BillTotalPrice { get; set; }
        public decimal BillTotalPriceMin { get; set; }
        public decimal BillTotalPriceMax { get; set; }
    }
}