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
    public class MaterialsRequisitionBusinessService : InventoryBusinessService, IOrderService<MaterialsRequisitionViewResult>
    {
        
        public DBResult Add(MaterialsRequisitionViewResult orderViewResult)
        {
            return base.Add<MaterialsRequisitionViewResult, MRDetailsViewResult, MaterialsRequisition, MRDetails>(
                orderViewResult, new string[] { "Remark" }, new string[] { "ID" }, null, new string[] { "ID" });
        }
    }
}