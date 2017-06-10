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
    public class PurchaseOrderBusinessService : InventoryBusinessService, IOrderService<PurchaseOrderViewResult>
    {
        
        public DBResult Add(PurchaseOrderViewResult orderViewResult)
        {
            return base.Add<PurchaseOrderViewResult, PODetailsViewResult, PurchaseOrder, PODetails>(
                orderViewResult, new string[] { "SupplierName", "Remark" }, new string[] { "ID" }, new string[] { "Price" }, new string[] { "ID" });
        }
    }
}