using Hot_Pot_Restaurant_Management_System.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.QueryModels
{
    public class DiscountQueryConditions : QueryConditions
    {
        public int ID { get; set; }
        public int DiscountPercent { get; set; }
        public int DiscountPercentMin { get; set; }
        public int DiscountPercentMax { get; set; }
        public string IgnoredCategories { get; set; }
        public string Description { get; set; }
        public bool IsMemberOnly { get; set; }
    }
}