using Hot_Pot_Restaurant_Management_System.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.QueryModels
{
    public class BillDetailsQueryConditions : QueryConditions
    {
        public string ID { get; set; }
        public string DishName { get; set; }
        public int Amount { get; set; }
        public int AmountMin { get; set; }
        public int AmountMax { get; set; }
        public string OrderID { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public string POID { get; set; }
    }
}