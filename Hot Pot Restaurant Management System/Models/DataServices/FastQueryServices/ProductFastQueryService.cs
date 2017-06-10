using Hot_Pot_Restaurant_Management_System.Common.Interfaces;
using Hot_Pot_Restaurant_Management_System.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.DataServices.FastQueryServices
{
    public class ProductFastQueryService : FastQueryService, IFastQueryService<Product>
    {
        public List<Product> FastQuery(string queryText)
        {
            return FastQuery<Product>(queryText);
        }
    }
}