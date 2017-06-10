using Hot_Pot_Restaurant_Management_System.Common;
using Hot_Pot_Restaurant_Management_System.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.DataServices
{
    public class VInventoryListService : DataService
    {
        
        public List<VInventoryList> Query(QueryConditions queryConditions, out int totalCount)
        {
            return Query<VInventoryList>(queryConditions, out totalCount);
        }
    }
}