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
    public class BillBusinessService : DataService, IOrderService<BillViewResult>
    {
        
        public DBResult Add(BillViewResult billViewResult)
        {
            int detailsCount = 1;
            var detailsForeID = BuilderDictionary.ForeIDDictionary.FirstOrDefault(i => i.Key == typeof(BillDetailsViewResult)).Value;
            var nowDate = DateTime.Now;

            using (var frontDeskEntities = new FrontDeskEntities())
            {
                using (var warehouseEntities = new WarehouseEntities())
                {
                    foreach (var detailsViewResult in billViewResult.Details)
                    {
                        detailsViewResult.ID = detailsForeID + nowDate.ToString("yyyyMMddHHmmss") + detailsCount;
                        detailsViewResult.OrderID = billViewResult.ID;

                        detailsCount++;

                        var details = EntityHelper.CopyEntity(detailsViewResult, new BillDetails());
                        if (EntityHelper.HasNullProperty(details, new string[] { "WarehouseID", "POID" }))
                            return DBResult.WrongParameter;

                        var detailsExistResult = CheckExists(frontDeskEntities.BillDetails, new string[] { "ID" }, details);
                        if (detailsExistResult != DBResult.Succeed)
                            return detailsExistResult;

                        var dish = frontDeskEntities.Dish.FirstOrDefault(d => d.Name == details.DishName);
                        if (dish == null)
                            return DBResult.NotFound;

                        var amount = decimal.Parse(detailsViewResult.Amount.ToString());
                        billViewResult.TotalCost += dish.Price * amount;

                        if (dish.InventoryControl)
                        {
                            var product = warehouseEntities.Product.FirstOrDefault(p => p.Name == dish.Name);
                            if (product == null)
                                return DBResult.NotFound;

                            var inventoryList = warehouseEntities.InventoryList
                                .Where(l => l.ProductID == product.ID).OrderBy(l => l.POID).OrderBy(l => l.WarehouseID).FirstOrDefault(l => l.Amount >= 0);
                            if (inventoryList == null)
                                return DBResult.InventoryEmpty;

                            var unitConversion = dish.UnitConversion;
                            if (unitConversion == null)
                                return DBResult.NotFound;

                            var consumedAmount = details.Amount * unitConversion.Value;
                            if (inventoryList.Amount - consumedAmount < 0)
                                return DBResult.InventoryEmpty;

                            inventoryList.Amount -= consumedAmount;

                            details.WarehouseID = inventoryList.WarehouseID;
                            details.POID = inventoryList.POID;
                        }

                        frontDeskEntities.BillDetails.Add(details);
                    }

                    billViewResult.ExactCost = billViewResult.TotalCost;

                    var bill = EntityHelper.CopyEntity(billViewResult, new Bill());
                    if (EntityHelper.HasNullProperty(bill, new string[] { "TotalCost", "Discount", "DiscountType", "ExactCost", "Remark", "MemberID", "ReceivedMoney", "Change" }))
                        return DBResult.WrongParameter;

                    var billExistResult = CheckExists(frontDeskEntities.Bill, new string[] { "ID" }, bill);
                    if (billExistResult != DBResult.Succeed)
                        return billExistResult;

                    frontDeskEntities.Bill.Add(bill);

                    if (frontDeskEntities.ServingTable.Any(t => t.ID == bill.TableID))
                        return DBResult.TableExisted;

                    frontDeskEntities.ServingTable.Add(new ServingTable { ID = bill.TableID, BillID = bill.ID });

                    frontDeskEntities.SaveChanges();
                    warehouseEntities.SaveChanges();

                    return DBResult.Succeed;
                }
            }
        }

        
        public DBResult Edit(BillViewResult billViewResult)
        {
            int detailsCount = 1;
            var detailsForeID = BuilderDictionary.ForeIDDictionary.FirstOrDefault(i => i.Key == typeof(BillDetailsViewResult)).Value;
            var nowDate = DateTime.Now;

            using (var frontDeskEntities = new FrontDeskEntities())
            {
                using (var warehouseEntities = new WarehouseEntities())
                {
                    var oldDetails = frontDeskEntities.BillDetails.Where(d => d.OrderID == billViewResult.ID);
                    foreach (var details in oldDetails)
                    {
                        frontDeskEntities.BillDetails.Remove(details);

                        var dish = frontDeskEntities.Dish.FirstOrDefault(d => d.Name == details.DishName);
                        if (dish == null)
                            return DBResult.NotFound;

                        if (dish.InventoryControl)
                        {
                            var product = warehouseEntities.Product.FirstOrDefault(p => p.Name == dish.Name);
                            if (product == null)
                                return DBResult.NotFound;

                            var unitConversion = dish.UnitConversion;
                            if (unitConversion == null)
                                return DBResult.NotFound;

                            var inventoryList = warehouseEntities.InventoryList.FirstOrDefault(l => l.WarehouseID == details.WarehouseID && l.POID == details.POID);
                            if (inventoryList == null)
                            {
                                var newInventoryList = new InventoryList
                                {
                                    ProductID = product.ID,
                                    Amount = details.Amount * unitConversion.Value,
                                    POID = details.POID,
                                    WarehouseID = details.WarehouseID.Value
                                };

                                warehouseEntities.InventoryList.Add(newInventoryList);
                            }

                            var consumedAmount = details.Amount * unitConversion.Value;
                            if (inventoryList.Amount + consumedAmount < 0)
                                return DBResult.InventoryEmpty;

                            inventoryList.Amount += consumedAmount;
                        }
                    }

                    foreach (var detailsViewResult in billViewResult.Details)
                    {
                        detailsViewResult.ID = detailsForeID + nowDate.ToString("yyyyMMddHHmmss") + detailsCount;
                        detailsViewResult.OrderID = billViewResult.ID;

                        detailsCount++;

                        var details = EntityHelper.CopyEntity(detailsViewResult, new BillDetails());
                        if (EntityHelper.HasNullProperty(details, new string[] { "WarehouseID", "POID" }))
                            return DBResult.WrongParameter;

                        var detailsExistResult = CheckExists(frontDeskEntities.BillDetails, new string[] { "ID" }, details);
                        if (detailsExistResult != DBResult.Succeed)
                            return detailsExistResult;

                        var dish = frontDeskEntities.Dish.FirstOrDefault(d => d.Name == details.DishName);
                        if (dish == null)
                            return DBResult.NotFound;

                        var amount = decimal.Parse(detailsViewResult.Amount.ToString());
                        billViewResult.TotalCost += dish.Price * amount;

                        if (dish.InventoryControl)
                        {
                            var product = warehouseEntities.Product.FirstOrDefault(p => p.Name == dish.Name);
                            if (product == null)
                                return DBResult.NotFound;

                            var inventoryList = warehouseEntities.InventoryList
                                .Where(l => l.ProductID == product.ID).OrderBy(l => l.POID).OrderBy(l => l.WarehouseID).FirstOrDefault(l => l.Amount >= 0);
                            if (inventoryList == null)
                                return DBResult.InventoryEmpty;

                            var unitConversion = dish.UnitConversion;
                            if (unitConversion == null)
                                return DBResult.NotFound;

                            var consumedAmount = details.Amount * unitConversion.Value;
                            if (inventoryList.Amount - consumedAmount < 0)
                                return DBResult.InventoryEmpty;

                            inventoryList.Amount -= consumedAmount;

                            details.WarehouseID = inventoryList.WarehouseID;
                            details.POID = inventoryList.POID;
                        }

                        frontDeskEntities.BillDetails.Add(details);
                    }

                    billViewResult.ExactCost = billViewResult.TotalCost;

                    var bill = frontDeskEntities.Bill.FirstOrDefault(d => d.ID == billViewResult.ID);
                    if (bill == null)
                        return DBResult.NotFound;

                    EntityHelper.CopyEntity(billViewResult, bill);
                    if (EntityHelper.HasNullProperty(bill, new string[] { "TotalCost", "Discount", "DiscountType", "ExactCost", "Remark", "MemberID", "ReceivedMoney", "Change" }))
                        return DBResult.WrongParameter;

                    var servingTable = frontDeskEntities.ServingTable.FirstOrDefault(t => t.BillID == bill.ID);
                    if (servingTable.ID != bill.TableID)
                    {
                        if (frontDeskEntities.ServingTable.Any(t => t.ID == bill.TableID))
                            return DBResult.TableExisted;

                        frontDeskEntities.ServingTable.Remove(servingTable);

                        var newTable = new ServingTable { ID = bill.TableID, BillID = bill.ID };
                        frontDeskEntities.ServingTable.Add(newTable);
                    }

                    frontDeskEntities.SaveChanges();
                    warehouseEntities.SaveChanges();

                    return DBResult.Succeed;
                }
            }
        }

        public DBResult Discount(BillViewResult billViewResult, out BillViewResult newBillViewResult)
        {
            newBillViewResult = new BillViewResult();
            using (var frontDeskEntities = new FrontDeskEntities())
            {
                using (var warehouseEntities = new WarehouseEntities())
                {
                    if (string.IsNullOrEmpty(billViewResult.DiscountType))
                    {
                        billViewResult.ExactCost = billViewResult.TotalCost;
                    }
                    else
                    {
                        var discount = frontDeskEntities.Discount.FirstOrDefault(d => d.Description == billViewResult.DiscountType);
                        if (discount == null)
                            return DBResult.WrongParameter;

                        billViewResult.Discount = discount.DiscountPercent;

                        if (!string.IsNullOrEmpty(discount.IgnoredCategories))
                        {
                            billViewResult.ExactCost = 0;

                            var ignoredCategories = discount.IgnoredCategories.Split('，');
                            var detailsViewResults = frontDeskEntities.BillDetails.Where(d => d.OrderID == billViewResult.ID);

                            foreach (var detailsViewResult in detailsViewResults)
                            {
                                var dish = frontDeskEntities.Dish.FirstOrDefault(d => d.Name == detailsViewResult.DishName);
                                if (dish == null)
                                    return DBResult.NotFound;

                                var category = warehouseEntities.Category.FirstOrDefault(c => c.ID == dish.CategoryID);
                                if (category == null)
                                    return DBResult.WrongParameter;

                                var amount = decimal.Parse(detailsViewResult.Amount.ToString());

                                if (ignoredCategories.Contains(category.Name))
                                    billViewResult.ExactCost += dish.Price * amount;
                                else
                                    billViewResult.ExactCost += (dish.Price * amount) * discount.DiscountPercent / 100;
                            }
                        }
                        else
                            billViewResult.ExactCost = billViewResult.TotalCost * discount.DiscountPercent / 100;
                    }

                    var bill = frontDeskEntities.Bill.FirstOrDefault(b => b.ID == billViewResult.ID);
                    if (bill == null)
                        return DBResult.NotFound;

                    EntityHelper.CopyEntity(billViewResult, bill);
                    frontDeskEntities.SaveChanges();
                }
            }

            newBillViewResult = billViewResult;
            return DBResult.Succeed;
        }

        
        public DBResult Pay(BillViewResult billViewResult)
        {
            using (var db = new FrontDeskEntities())
            {
                var bill = db.Bill.FirstOrDefault(b => b.ID == billViewResult.ID);
                if (bill == null)
                    return DBResult.NotFound;

                EntityHelper.CopyEntity(billViewResult, bill);

                var servingTable = db.ServingTable.FirstOrDefault(t => t.ID == billViewResult.TableID);
                if (servingTable == null)
                    return DBResult.NotFound;

                db.ServingTable.Remove(servingTable);

                db.SaveChanges();
                return DBResult.Succeed;
            }
        }
    }
}