using Hot_Pot_Restaurant_Management_System.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.QueryModels
{
    public class ProductQueryConditions : QueryConditions
    {
        public int ID { get; set; }
        public int ShortID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int CategoryID { get; set; }
        public string Unit { get; set; }
    }
}