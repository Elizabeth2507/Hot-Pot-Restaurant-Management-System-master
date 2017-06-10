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
    public class InventoryBusinessService : DataService
    {
        
        public DBResult Add<T, S, R, U>(T orderViewResult, string[] orderIgnoreNullCheck, string[] orderCheckExists, 
            string[] detailsIgnoreNullCheck, string[] detailsCheckExists)
            where T : IOrder<S>
            where S : IOrderDetails
            where R : class, new()
            where U : class, new()
        {
            int detailsCount = 1;
            var detailsForeID = BuilderDictionary.ForeIDDictionary.FirstOrDefault(i => i.Key == typeof(S)).Value;
            var nowDate = DateTime.Now;

            string warehouseName = orderViewResult.WarehouseName;

            foreach (var detailsViewResult in orderViewResult.Details)
            {
                detailsViewResult.ID = detailsForeID + nowDate.ToString("yyyyMMddHHmmss") + detailsCount;
                detailsViewResult.OrderID = orderViewResult.ID;

                detailsCount++;
            }

            var order = EntityHelper.CopyEntity(orderViewResult, new R());
            if (EntityHelper.HasNullProperty(order, orderIgnoreNullCheck))
                return DBResult.WrongParameter;

            using (var db = new WarehouseEntities())
            {
                var orderSet = db.Set<R>();
                var detailsSet = db.Set<U>();

                var orderExistResult = CheckExists(orderSet, orderCheckExists, order);
                if (orderExistResult != DBResult.Succeed)
                    return orderExistResult;

                orderSet.Add(order);

                var warehouse = db.Warehouse.FirstOrDefault(w => w.Name == warehouseName);
                if (warehouse == null)
                    return DBResult.NotFound;

                foreach (var detailsViewResult in orderViewResult.Details)
                {
                    string productName = detailsViewResult.ProductName;
                    double amount = detailsViewResult.Amount;

                    var details = EntityHelper.CopyEntity(detailsViewResult, new U());

                    if (EntityHelper.HasNullProperty(details, detailsIgnoreNullCheck))
                        return DBResult.WrongParameter;

                    var detailsExistResult = CheckExists(detailsSet, detailsCheckExists, details);
                    if (detailsExistResult != DBResult.Succeed)
                        return detailsExistResult;

                    detailsSet.Add(details);

                    var product = db.Product.FirstOrDefault(p => p.Name == productName);                    
                    if (product == null)
                        return DBResult.NotFound;

                    if (order.GetType() == typeof(PurchaseOrder))
                    {
                        var newlist = new InventoryList { ProductID = product.ID, WarehouseID = warehouse.ID, Amount = amount, POID = detailsViewResult.ID };
                        db.InventoryList.Add(newlist);
                    }
                    else
                    {
                        var pOID = EntityHelper.GetPropertyValue(details, "POID").ToString();

                        var inventoryList = db.InventoryList.FirstOrDefault(l => l.POID == pOID && l.WarehouseID == warehouse.ID);
                        if (inventoryList == null)
                            return DBResult.NotFound;

                        var type = order.GetType();

                        if (type == typeof(MaterialsReturnOrder))
                            inventoryList.Amount += amount;
                        if (type == typeof(CreditOrder) || type == typeof(MaterialsRequisition))
                            inventoryList.Amount -= amount;
                        if (type == typeof(StocktakingList))
                            inventoryList.Amount = amount;
                    }
                }

                db.SaveChanges();
                return DBResult.Succeed;
            }
        }
    }
}