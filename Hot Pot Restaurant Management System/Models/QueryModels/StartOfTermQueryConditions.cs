using Hot_Pot_Restaurant_Management_System.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.QueryModels
{
    public class StartOfTermQueryConditions : QueryConditions
    {
        public string ID { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateMin { get; set; }
        public DateTime DateMax { get; set; }
        public string ProductName { get; set; }
        public string WarehouseName { get; set; }
        public decimal Price { get; set; }
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
        public double Amount { get; set; }
        public double AmountMin { get; set; }
        public double AmountMax { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalPriceMin { get; set; }
        public decimal TotalPriceMax { get; set; }
    }
}