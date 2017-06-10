using Hot_Pot_Restaurant_Management_System.Common;
using Hot_Pot_Restaurant_Management_System.Common.Enums;
using Hot_Pot_Restaurant_Management_System.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.DataServices.BusinessServices
{
    public class DishChartService : DataService
    {
        
        public List<double>[] GetSingleData(string dishName, DateTime dateMin, DateTime dateMax)
        {
            dateMax = dateMax.AddDays(1);
            var results = new List<double>[3] { new List<double>(), new List<double>(), new List<double>() };

            using (var frontDeskEntities = new FrontDeskEntities())
            {
                using (var warehouseEntities = new WarehouseEntities())
                {
                    var dish = frontDeskEntities.Dish.FirstOrDefault(d => d.Name == dishName);
                    if (dish == null)
                        return results;

                    var bills = frontDeskEntities.Bill.Where(b => b.Date >= dateMin && b.Date < dateMax).ToList();
                    for (DateTime date = dateMin; date < dateMax; )
                    {
                        double amountResult = 0;
                        double moneyResult = 0;
                        double costResult = 0;

                        DateTime dateNext = date.AddDays(1);

                        var billsByDay = bills.Where(b => b.Date >= date && b.Date < dateNext);
                        foreach (var bill in billsByDay)
                        {
                            var details = frontDeskEntities.BillDetails.Where(d => d.OrderID == bill.ID && d.DishName == dishName);
                            if (details.Count() == 0)
                                continue;

                            amountResult += details.Sum(d => d.Amount);

                            double discount = 100;
                            if (bill.Discount != null)
                                discount = bill.Discount.Value;

                            moneyResult += details.Sum(d => (double)dish.Price * d.Amount * (discount / 100));

                            if (!dish.InventoryControl || dish.UnitConversion == null)
                            {
                                costResult = -1;
                                continue;
                            }

                            foreach (var detail in details)
                            {
                                var purchaseOrder = warehouseEntities.PODetails.FirstOrDefault(d => d.ID == detail.POID);
                                if (purchaseOrder == null)
                                    continue;

                                costResult += (double)purchaseOrder.Price * detail.Amount * dish.UnitConversion.Value;
                            }
                        }

                        results[0].Add(amountResult);
                        results[1].Add(moneyResult);
                        results[2].Add(costResult);

                        date = dateNext;
                    }
                }
            }

            return results;
        }

        public List<double>[] GetMoneyData(DateTime dateMin, DateTime dateMax)
        {
            dateMax = dateMax.AddDays(1);
            var results = new List<double>[3] { new List<double>(), new List<double>(), new List<double>() };

            using (var frontDeskEntities = new FrontDeskEntities())
            {
                using (var warehouseEntities = new WarehouseEntities())
                {
                    var bills = frontDeskEntities.Bill.Where(b => b.Date >= dateMin && b.Date < dateMax).ToList();
                    for (DateTime date = dateMin; date < dateMax; )
                    {
                        double moneyResult = 0;
                        double discountResult = 0;
                        double costResult = 0;

                        DateTime dateNext = date.AddDays(1);

                        var billsByDay = bills.Where(b => b.Date >= date && b.Date < dateNext);
                        foreach (var bill in billsByDay)
                        {
                            double discount = 100;
                            if (bill.Discount != null)
                                discount = bill.Discount.Value;

                            double payPercent = discount / 100;
                            double discountPercent = (100 - discount) / 100;

                            var details = frontDeskEntities.BillDetails.Where(d => d.POID != null && d.WarehouseID != null);
                            if (details.Count() == 0)
                                continue;

                            foreach (var detail in details)
                            {
                                var dish = frontDeskEntities.Dish.FirstOrDefault(d => d.Name == detail.DishName);
                                if (dish == null)
                                    continue;

                                double totalPay = (double)dish.Price * detail.Amount;

                                moneyResult += totalPay * payPercent;
                                discountResult += totalPay * discountPercent;

                                if (!dish.InventoryControl || dish.UnitConversion == null)
                                    continue;

                                var purchaseOrder = warehouseEntities.PODetails.FirstOrDefault(d => d.ID == detail.POID);
                                if (purchaseOrder == null)
                                    continue;

                                costResult += (double)purchaseOrder.Price * detail.Amount * dish.UnitConversion.Value;
                            }
                        }

                        results[0].Add(Math.Round(moneyResult, 2));
                        results[1].Add(Math.Round(discountResult, 2));
                        results[2].Add(Math.Round(costResult, 2));

                        date = dateNext;
                    }
                }
            }

            return results;
        }
    }
}