using Hot_Pot_Restaurant_Management_System.Common;
using Hot_Pot_Restaurant_Management_System.Common.Enums;
using Hot_Pot_Restaurant_Management_System.Common.Interfaces;
using Hot_Pot_Restaurant_Management_System.Models.Entities;
using Hot_Pot_Restaurant_Management_System.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.DataServices.BusinessServices
{
    public class StocktakingListBusinessService : InventoryBusinessService, IOrderService<StocktakingListViewResult>
    {
       
        public DBResult Add(StocktakingListViewResult orderViewResult)
        {
            return base.Add<StocktakingListViewResult, SLDetailsViewResult, StocktakingList, SLDetails>(
                orderViewResult, new string[] { "Remark" }, new string[] { "ID" }, null, new string[] { "ID" });
        }
    }
}