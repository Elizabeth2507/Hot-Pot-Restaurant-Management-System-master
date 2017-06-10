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
    public class CreditOrderBusinessService : InventoryBusinessService, IOrderService<CreditOrderViewResult>
    {
       
        public DBResult Add(CreditOrderViewResult orderViewResult)
        {
            return base.Add<CreditOrderViewResult, CODetailsViewResult, CreditOrder, CODetails>(
                orderViewResult, new string[] { "SupplierName", "Remark" }, new string[] { "ID" }, new string[] { "Price" }, new string[] { "ID" });
        }
    }
}