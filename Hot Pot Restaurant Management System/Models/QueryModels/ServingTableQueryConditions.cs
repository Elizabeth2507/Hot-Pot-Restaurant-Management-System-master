using Hot_Pot_Restaurant_Management_System.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.QueryModels
{
    public class ServingTableQueryConditions : QueryConditions
    {
        public int ID { get; set; }
        public string BillID { get; set; }
    }
}