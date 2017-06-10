using Hot_Pot_Restaurant_Management_System.Common;
using Hot_Pot_Restaurant_Management_System.Common.Dictionaries;
using Hot_Pot_Restaurant_Management_System.Common.Enums;
using Hot_Pot_Restaurant_Management_System.Models.Entities;
using Hot_Pot_Restaurant_Management_System.Models.QueryModels;
using Hot_Pot_Restaurant_Management_System.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.DataServices.BusinessServices
{
    public class MonthlyReportBusinessService : DataService
    {
        public List<MonthlyReportViewResult> GetCurrentMonth()
        {
            var timeNow = DateTime.Now;
            DateTime monthStart = new DateTime(timeNow.Year, timeNow.Month, 1);

            return CalculateMonthlyReport(monthStart, timeNow);
        }

        
        public List<MonthlyReportViewResult> Get(DateTime date)
        {
            int totalCount = 0;
            int startOfTermsCount;
            DateTime monthStart = new DateTime(date.Year, date.Month, 1);

            var startOfTerms = Query<StartOfTerm>(new StartOfTermQueryConditions { Date = monthStart }, out startOfTermsCount);
            var results = Query<MonthlyReport>(new MonthlyReportQueryConditions { Date = monthStart }, out totalCount);

            if (results != null && totalCount != 0)
            {
                var viewResults = EntityHelper.CopyEntities(results, new List<MonthlyReportViewResult>());
                foreach (var viewResult in viewResults)
                {
                    int detailsCount = 0;
                    viewResult.Details = new List<MReportDetailsViewResult>();

                    var details = Query<MReportDetails>(new MReportDetailsQueryConditions { OrderID = viewResult.ID }, out detailsCount);
                    if (details != null && detailsCount != 0)
                    {
                        viewResult.Details.AddRange(EntityHelper.CopyEntities(details, new List<MReportDetailsViewResult>()));
                        foreach (var detailsViewResult in viewResult.Details)
                        {
                            detailsViewResult.StartOfTerm = new StartOfTermViewResult();

                            var startOfTerm = startOfTerms
                                .FirstOrDefault(s => s.ProductName == detailsViewResult.ProductName && s.WarehouseName == viewResult.WarehouseName);
                            if (startOfTerms != null)
                                detailsViewResult.StartOfTerm = EntityHelper.CopyEntity(startOfTerm, new StartOfTermViewResult());
                        }
                    }
                }

                return viewResults;
            }

            if (startOfTermsCount == 0)
            {
                int lastReportsCount = 0;
                DateTime lastMonthStart = date.Month == 1 ? new DateTime(date.Year - 1, 12, 1) : new DateTime(date.Year, date.Month - 1, 1);

                var lastReports = Query<MonthlyReport>(new MonthlyReportQueryConditions { Date = lastMonthStart }, out lastReportsCount);
                if (lastReportsCount != 0)
                {
                    foreach (var lastReport in lastReports)
                    {
                        int detailsCount = 0;

                        var details = Query<MReportDetails>(new MReportDetailsQueryConditions { OrderID = lastReport.ID }, out detailsCount);
                        if (detailsCount != 0)
                        {
                            foreach (var detail in details)
                            {
                                var newStartOfTerm = new StartOfTerm
                                {
                                    Date = lastReport.Date,
                                    WarehouseName = lastReport.WarehouseName,
                                    ProductName = detail.ProductName,
                                    Price = detail.SListPrice,
                                    Amount = detail.SListAmount,
                                    TotalPrice = detail.SListTotalPrice
                                };

                                var termDBResult = AddStartOfTerm(newStartOfTerm);
                                if (termDBResult != DBResult.Succeed)
                                    return new List<MonthlyReportViewResult>();
                            }
                        }
                    }
                }
            }

            var calViewResults = CalculateMonthlyReport(monthStart);

            var dBResult = Add(calViewResults);
            if (dBResult != DBResult.Succeed)
                return new List<MonthlyReportViewResult>();

            return calViewResults;
        }

        public List<MonthlyReportViewResult> ReCalculate(DateTime date)
        {
            int lastReportsCount = 0;
            DateTime monthStart = new DateTime(date.Year, date.Month, 1);
            DateTime lastMonthStart = date.Month == 1 ? new DateTime(date.Year - 1, 12, 1) : new DateTime(date.Year, date.Month - 1, 1);

            var lastReports = Query<MonthlyReport>(new MonthlyReportQueryConditions { Date = lastMonthStart }, out lastReportsCount);
            if (lastReportsCount != 0)
            {
                foreach (var lastReport in lastReports)
                {
                    int detailsCount = 0;

                    var details = Query<MReportDetails>(new MReportDetailsQueryConditions { OrderID = lastReport.ID }, out detailsCount);
                    if (detailsCount != 0)
                    {
                        foreach (var detail in details)
                        {
                            var newStartOfTerm = new StartOfTerm
                            {
                                Date = lastReport.Date,
                                WarehouseName = lastReport.WarehouseName,
                                ProductName = detail.ProductName,
                                Price = detail.SListPrice,
                                Amount = detail.SListAmount,
                                TotalPrice = detail.SListTotalPrice
                            };

                            var termDBResult = EditStartOfTerm(newStartOfTerm);
                            if (termDBResult != DBResult.Succeed)
                                return new List<MonthlyReportViewResult>();
                        }
                    }
                }
            }

            var viewResults = CalculateMonthlyReport(monthStart);

            var dBResult = Edit(viewResults);
            if (dBResult != DBResult.Succeed)
                return new List<MonthlyReportViewResult>();

            return viewResults;
        }

        private DBResult Add(List<MonthlyReportViewResult> viewResults)
        {
            if (viewResults == null)
                return DBResult.WrongParameter;

            using (var db = new ReportEntities())
            {
                foreach (var viewResult in viewResults)
                {
                    var monthlyReport = EntityHelper.CopyEntity(viewResult, new MonthlyReport());
                    db.MonthlyReport.Add(monthlyReport);

                    if (viewResult.Details.Count == 0)
                        continue;

                    foreach (var detailsViewResult in viewResult.Details)
                    {
                        var mReportDetails = EntityHelper.CopyEntity(detailsViewResult, new MReportDetails());
                        db.MReportDetails.Add(mReportDetails);
                    }
                }

                db.SaveChanges();
                return DBResult.Succeed;
            }
        }

        private DBResult Edit(List<MonthlyReportViewResult> viewResults)
        {
            if (viewResults == null)
                return DBResult.WrongParameter;

            using (var db = new ReportEntities())
            {
                foreach (var viewResult in viewResults)
                {
                    var monthlyReport = db.MonthlyReport.FirstOrDefault(r => r.ID == viewResult.ID);
                    if (monthlyReport == null)
                        db.MonthlyReport.Add(EntityHelper.CopyEntity(viewResult, new MonthlyReport()));

                    EntityHelper.CopyEntity(viewResult, monthlyReport);

                    if (viewResult.Details.Count == 0)
                        continue;

                    foreach (var detailsViewResult in viewResult.Details)
                    {
                        var mReportDetails = db.MReportDetails.FirstOrDefault(d => d.ID == detailsViewResult.ID);
                        if (mReportDetails == null)
                            db.MReportDetails.Add(mReportDetails);

                        EntityHelper.CopyEntity(detailsViewResult, mReportDetails);
                    }
                }

                db.SaveChanges();
                return DBResult.Succeed;
            }
        }


        private DBResult AddStartOfTerm(StartOfTerm entity)
        {
            if (entity == null)
                return DBResult.WrongParameter;

            string foreID = BuilderDictionary.ForeIDDictionary.FirstOrDefault(p => p.Key == typeof(StartOfTermViewResult)).Value;
            entity.ID = foreID + entity.Date.ToString("yyyyMMddHHmmss");

            return Add<StartOfTerm>(entity, null, new string[] { "ID", "Date" });
        }


        private DBResult EditStartOfTerm(StartOfTerm entity)
        {
            if (entity == null)
                return DBResult.WrongParameter;

            string foreID = BuilderDictionary.ForeIDDictionary.FirstOrDefault(p => p.Key == typeof(StartOfTermViewResult)).Value;
            entity.ID = foreID + entity.Date.ToString("yyyyMMddHHmmss");

            using (var db = new ReportEntities())
            {
                var startOfTerm = db.StartOfTerm.FirstOrDefault(t => t.ID == entity.ID);
                if (startOfTerm == null)
                    db.StartOfTerm.Add(entity);

                EntityHelper.CopyEntity(entity, startOfTerm);

                db.SaveChanges();
                return DBResult.Succeed;
            }
        }
        
        private List<MonthlyReportViewResult> CalculateMonthlyReport(DateTime dateStart, DateTime? dateEnd = null)
        {
            int reportCount = 1;
            int productCount = 1;

            if (dateEnd == null)
                dateEnd = dateStart.Month == 12 ? new DateTime(dateStart.Year + 1, 1, 1) : new DateTime(dateStart.Year, dateStart.Month + 1, 1);

            string reportForeID = BuilderDictionary.ForeIDDictionary.FirstOrDefault(p => p.Key == typeof(MonthlyReportViewResult)).Value;
            string detailsForeID = BuilderDictionary.ForeIDDictionary.FirstOrDefault(p => p.Key == typeof(MReportDetailsViewResult)).Value;

            var reports = new List<MonthlyReportViewResult>();

            using (var reportEntities = new ReportEntities())
            {
                using (var warehouseEntities = new WarehouseEntities())
                {
                    using (var frontDeskEntities = new FrontDeskEntities())
                    {
                        var startOfTerms = reportEntities.StartOfTerm.Where(s => s.Date == dateStart);
                        var vPurchaseOrders = reportEntities.VPurchaseOrder.Where(o => o.Date >= dateStart && o.Date < dateEnd);
                        var vCreditOrders = reportEntities.VCreditOrder.Where(o => o.Date >= dateStart && o.Date < dateEnd);
                        var vMaterialsRequisitions = reportEntities.VMaterialsRequisition.Where(o => o.Date >= dateStart && o.Date < dateEnd);
                        var vMaterialsReturnOrders = reportEntities.VMaterialsReturnOrder.Where(o => o.Date >= dateStart && o.Date < dateEnd);
                        var vStockingLists = reportEntities.VStockingList.Where(o => o.Date >= dateStart && o.Date < dateEnd);
                        var vBills = frontDeskEntities.VBill.Where(o => o.Date >= dateStart && o.Date < dateEnd);

                        var warehouses = warehouseEntities.Warehouse.ToList();
                        var products = warehouseEntities.Product.ToList();

                        foreach (var warehouse in warehouses)
                        {
                            var viewResult = new MonthlyReportViewResult
                            {
                                ID = reportForeID + dateStart.ToString("yyyyMMddHHmmss") + reportCount,
                                WarehouseName = warehouse.Name,
                                Date = dateStart,
                                Details = new List<MReportDetailsViewResult>()
                            };

                            reportCount++;

                            foreach (var product in products)
                            {
                                var productStart = startOfTerms.FirstOrDefault(s => s.ProductName == product.Name && s.WarehouseName == warehouse.Name);
                                var productPurchaseOrders = vPurchaseOrders.Where(o => o.ProductName == product.Name && o.WarehouseName == warehouse.Name);

                                if (productStart == null && productPurchaseOrders.Count() == 0)
                                    continue;

                                var productEnd = warehouseEntities.VInventoryList.Where(l => l.ProductName == product.Name && l.WarehouseName == warehouse.Name);
                                double productEndAmount = productEnd.Count() == 0 ? 0 : productEnd.Sum(l => l.Amount);

                                var detailsViewResult = new MReportDetailsViewResult
                                {
                                    ID = detailsForeID + dateStart.ToString("yyyyMMddHHmmss") + productCount,
                                    OrderID = viewResult.ID,
                                    ProductName = product.Name,
                                    PurchasePrice = 0,
                                    PurchaseAmount = 0,
                                    PurchaseTotalPrice = 0,
                                    CreditPrice = 0,
                                    CreditAmount = 0,
                                    CreditTotalPrice = 0,
                                    MRequisitionPrice = 0,
                                    MRequisitionAmount = 0,
                                    MRequisitionTotalPrice = 0,
                                    MReturnPrice = 0,
                                    MReturnAmount = 0,
                                    MReturnTotalPrice = 0,
                                    SListPrice = 0,
                                    SListAmount = 0,
                                    SListTotalPrice = 0,
                                    StartOfTerm = EntityHelper.CopyEntity(productStart, new StartOfTermViewResult())
                                };

                                productCount++;

                                var productCreditOrders = vCreditOrders
                                    .Where(o => o.ProductName == product.Name && o.WarehouseName == warehouse.Name).ToList();

                                var productMaterialsRequisitions = vMaterialsRequisitions
                                    .Where(o => o.ProductName == product.Name && o.WarehouseName == warehouse.Name).ToList();

                                var productMaterialsReturnOrders = vMaterialsReturnOrders
                                    .Where(o => o.ProductName == product.Name && o.WarehouseName == warehouse.Name).ToList();

                                var productStockingLists = vStockingLists
                                    .Where(o => o.ProductName == product.Name && o.WarehouseName == warehouse.Name).ToList();

                                if (productPurchaseOrders != null)
                                {
                                    double? totalPrice = productPurchaseOrders.Sum(o => o.TotalPrice);
                                    double amount = productPurchaseOrders.Sum(o => o.Amount);

                                    if (totalPrice != null && amount != 0)
                                    {
                                        detailsViewResult.PurchaseTotalPrice = (decimal)totalPrice.Value;
                                        detailsViewResult.PurchaseAmount = amount;
                                        detailsViewResult.PurchasePrice = (decimal)(totalPrice.Value / amount);
                                    }
                                }

                                if (productMaterialsRequisitions != null)
                                {
                                    double? totalPrice = productMaterialsRequisitions.Sum(o => o.TotalPrice);
                                    double amount = productMaterialsRequisitions.Sum(o => o.Amount);

                                    if (totalPrice != null && amount != 0)
                                    {
                                        detailsViewResult.MRequisitionTotalPrice = (decimal)totalPrice.Value;
                                        detailsViewResult.MRequisitionAmount = amount;
                                        detailsViewResult.MRequisitionPrice = (decimal)(totalPrice.Value / amount);
                                    }
                                }

                                if (productMaterialsReturnOrders != null)
                                {
                                    double? totalPrice = productMaterialsReturnOrders.Sum(o => o.TotalPrice);
                                    double amount = productMaterialsReturnOrders.Sum(o => o.Amount);

                                    if (totalPrice != null && amount != 0)
                                    {
                                        detailsViewResult.MReturnTotalPrice = (decimal)totalPrice.Value;
                                        detailsViewResult.MReturnAmount = amount;
                                        detailsViewResult.MReturnPrice = (decimal)(totalPrice.Value / amount);
                                    }
                                }


                                if (productCreditOrders != null)
                                {
                                    double? totalPrice = productCreditOrders.Sum(o => o.TotalPrice);
                                    double amount = productCreditOrders.Sum(o => o.Amount);

                                    if (totalPrice != null && amount != 0)
                                    {
                                        detailsViewResult.CreditTotalPrice = (decimal)totalPrice.Value;
                                        detailsViewResult.CreditAmount = amount;
                                        detailsViewResult.CreditPrice = (decimal)(totalPrice.Value / amount);
                                    }
                                }

                                if (productCreditOrders != null)
                                {
                                    double? totalPrice = productCreditOrders.Sum(o => o.TotalPrice);
                                    double amount = productCreditOrders.Sum(o => o.Amount);

                                    if (totalPrice != null && amount != 0)
                                    {
                                        detailsViewResult.CreditTotalPrice = (decimal)totalPrice.Value;
                                        detailsViewResult.CreditAmount = amount;
                                        detailsViewResult.CreditPrice = (decimal)(totalPrice.Value / amount);
                                    }
                                }

                                if (productStockingLists != null)
                                {
                                    double? totalPrice = productStockingLists.Sum(o => o.TotalPrice);
                                    double amount = productStockingLists.Sum(o => o.Amount);

                                    if (totalPrice != null && amount != 0)
                                    {
                                        detailsViewResult.SListTotalPrice = (decimal)totalPrice.Value;
                                        detailsViewResult.SListAmount = amount;
                                        detailsViewResult.SListPrice = (decimal)(totalPrice.Value / amount);
                                    }
                                }

                                var dish = frontDeskEntities.Dish.FirstOrDefault(d => d.Name == product.Name && d.InventoryControl == true);
                                if (dish != null && dish.UnitConversion != null)
                                {
                                    double unitConversion = dish.UnitConversion.Value;

                                    var dishBills = vBills.Where(b => b.DishName == dish.Name);
                                    foreach (var dishBill in dishBills)
                                    {
                                        var dishDetails = frontDeskEntities.BillDetails.FirstOrDefault(d => d.ID == dishBill.DetailsID);
                                        if (dishDetails == null)
                                            continue;

                                        decimal productPrice = warehouseEntities.PODetails.FirstOrDefault(d => d.ID == dishDetails.POID).Price;
                                        double productAmount = dishBill.Amount * unitConversion;

                                        detailsViewResult.BillTotalPrice += productPrice * (decimal)productAmount;
                                        detailsViewResult.BillAmount += productAmount;
                                    }

                                    if (detailsViewResult.BillAmount != 0)
                                        detailsViewResult.BillPrice = detailsViewResult.BillTotalPrice / (decimal)detailsViewResult.BillAmount;
                                }

                                viewResult.Details.Add(detailsViewResult);
                            }

                            reports.Add(viewResult);
                        }
                    }
                }
            }

            return reports;
        }
    }
}