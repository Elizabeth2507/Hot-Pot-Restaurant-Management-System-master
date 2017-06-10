using Hot_Pot_Restaurant_Management_System.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.QueryModels
{
    public class BillQueryConditions : QueryConditions
    {
        public string ID { get; set; }
        public int TableID { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateMin { get; set; }
        public DateTime DateMax { get; set; }
        public int CustomerCount { get; set; }
        public int CustomerCountMin { get; set; }
        public int CustomerCountMax { get; set; }
        public int TimePeriod { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalCostMin { get; set; }
        public decimal TotalCostMax { get; set; }
        public int Discount { get; set; }
        public int DiscountMin { get; set; }
        public int DiscountMax { get; set; }
        public string DiscountType { get; set; }
        public decimal ExactCost { get; set; }
        public decimal ExactCostMin { get; set; }
        public decimal ExactCostMax { get; set; }
        public string Remark { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string MemberID { get; set; }
        public decimal ReceivedMoney { get; set; }
        public decimal ReceivedMoneyMin { get; set; }
        public decimal ReceivedMoneyMax { get; set; }
        public decimal Change { get; set; }
        public decimal ChangeMin { get; set; }
        public decimal ChangeMax { get; set; }
    }
}