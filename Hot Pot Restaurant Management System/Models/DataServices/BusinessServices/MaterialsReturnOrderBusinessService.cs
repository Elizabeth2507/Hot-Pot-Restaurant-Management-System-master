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
    public class MaterialsReturnOrderBusinessService : InventoryBusinessService, IOrderService<MaterialsReturnOrderViewResult>
    {
        
        public DBResult Add(MaterialsReturnOrderViewResult orderViewResult)
        {
            return base.Add<MaterialsReturnOrderViewResult, MRODetailsViewResult, MaterialsReturnOrder, MRODetails>(
                orderViewResult, new string[] { "Remark" }, new string[] { "ID" }, null, new string[] { "ID" });
        }
    }
}