using Hot_Pot_Restaurant_Management_System.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.QueryModels
{
    public class MonthlyReportQueryConditions : QueryConditions
    {
        public string ID { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateMin { get; set; }
        public DateTime DateMax { get; set; }
        public string WarehouseName { get; set; }
    }
}