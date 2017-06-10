using Hot_Pot_Restaurant_Management_System.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.QueryModels
{
    public class DishQueryConditions : QueryConditions
    {
        public int ID { get; set; }
        public int ShortID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int CategoryID { get; set; }
        public decimal Price { get; set; }
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }
        public bool PriceEditable { get; set; }
        public bool InventoryControl { get; set; }
        public Nullable<double> UnitConversion { get; set; }
    }
}