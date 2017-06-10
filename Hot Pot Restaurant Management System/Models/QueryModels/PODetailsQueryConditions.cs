using Hot_Pot_Restaurant_Management_System.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.QueryModels
{
    public class PODetailsQueryConditions : QueryConditions
    {
        public string ID { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public int Amount { get; set; }
        public int AmountMin { get; set; }
        public int AmountMax { get; set; }
        public decimal Price { get; set; }
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
        public string OrderID { get; set; }
    }
}