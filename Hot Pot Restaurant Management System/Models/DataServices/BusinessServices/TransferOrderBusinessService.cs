using Hot_Pot_Restaurant_Management_System.Common;
using Hot_Pot_Restaurant_Management_System.Common.Dictionaries;
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
    public class TransferOrderBusinessService : DataService, IOrderService<TransferOrderViewResult>
    {
        
        public DBResult Add(TransferOrderViewResult orderViewResult)
        {
            int detailsCount = 1;
            foreach (var detailsViewResult in orderViewResult.Details)
            {
                var detailsForeID = BuilderDictionary.ForeIDDictionary.FirstOrDefault(i => i.Key == typeof(TransferOrderViewResult)).Value;
                var nowDate = DateTime.Now;

                detailsViewResult.ID = detailsForeID + nowDate.ToString("yyyyMMddHHmmss") + detailsCount;
                detailsViewResult.OrderID = orderViewResult.ID;

                detailsCount++;
            }

            var order = EntityHelper.CopyEntity(orderViewResult, new TransferOrder());
            if (EntityHelper.HasNullProperty(order, new string[] { "Remark" }))
                return DBResult.WrongParameter;

            using (var db = new WarehouseEntities())
            {
                var orderExistResult = CheckExists(db.TransferOrder, new string[] { "ID" }, order);
                if (orderExistResult != DBResult.Succeed)
                    return orderExistResult;

                db.TransferOrder.Add(order);

                var outWarehouse = db.Warehouse.FirstOrDefault(w => w.Name == order.OutName);
                var inWarehouse = db.Warehouse.FirstOrDefault(w => w.Name == order.InName);
                if (outWarehouse == null || inWarehouse == null)
                    return DBResult.NotFound;

                foreach (var detailsViewResult in orderViewResult.Details)
                {
                    var details = EntityHelper.CopyEntity(detailsViewResult, new TODetails());
                    if (EntityHelper.HasNullProperty(details))
                        return DBResult.WrongParameter;

                    var detailsExistResult = CheckExists(db.TODetails, new string[] { "ID" }, details);
                    if (detailsExistResult != DBResult.Succeed)
                        return detailsExistResult;

                    db.TODetails.Add(details);

                    var product = db.Product.FirstOrDefault(p => p.Name == details.ProductName);
                    if (product == null)
                        return DBResult.NotFound;

                    var outInventoryList = db.InventoryList.FirstOrDefault(l => l.POID == details.POID && l.WarehouseID == outWarehouse.ID);
                    if (outInventoryList == null)
                        return DBResult.NotFound;

                    outInventoryList.Amount -= details.Amount;

                    var inInventoryList = db.InventoryList.FirstOrDefault(l => l.POID == details.POID && l.WarehouseID == inWarehouse.ID);
                    if (inInventoryList == null)                        
                        db.InventoryList.Add(new InventoryList { ProductID = product.ID, POID = details.POID, WarehouseID = inWarehouse.ID, Amount = details.Amount });
                    else
                        inInventoryList.Amount += details.Amount;                    
                }

                db.SaveChanges();
                return DBResult.Succeed;
            }
        }
    }
}