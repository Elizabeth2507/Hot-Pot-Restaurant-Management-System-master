using Hot_Pot_Restaurant_Management_System.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.QueryModels
{
    public class VInventoryListQueryConditions : QueryConditions
    {
        public string POID { get; set; }
        public int ProductID { get; set; }
        public int ProductShortID { get; set; }
        public string ProductName { get; set; }
        public string ProductShortName { get; set; }
        public int WarehouseID { get; set; }
        public int WarehouseShortID { get; set; }
        public string WarehouseName { get; set; }
        public double Amount { get; set; }
        public double AmountMin { get; set; }
        public double AmountMax { get; set; }
        public string Unit { get; set; }
    }
}