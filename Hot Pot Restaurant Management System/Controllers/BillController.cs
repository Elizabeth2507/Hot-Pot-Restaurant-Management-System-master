using Hot_Pot_Restaurant_Management_System.Common;
using Hot_Pot_Restaurant_Management_System.Common.Dictionaries;
using Hot_Pot_Restaurant_Management_System.Common.Enums;
using Hot_Pot_Restaurant_Management_System.Controllers.BaseControllers;
using Hot_Pot_Restaurant_Management_System.Models.DataServices;
using Hot_Pot_Restaurant_Management_System.Models.DataServices.BusinessServices;
using Hot_Pot_Restaurant_Management_System.Models.Entities;
using Hot_Pot_Restaurant_Management_System.Models.QueryModels;
using Hot_Pot_Restaurant_Management_System.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hot_Pot_Restaurant_Management_System.Controllers
{
    [Authorize(Roles = "1,3")]
    public class BillController : BaseController
    {
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult AddPage()
        {
            DateTime nowDate = DateTime.Now;
            int nowHour = nowDate.Hour;

            int timePeriod = ConverterDictionary.NowTimePeriodDictionary.FirstOrDefault(p => nowHour >= p.Key[0] && nowHour < p.Key[1]).Value;            
            var orderForeID = BuilderDictionary.ForeIDDictionary.FirstOrDefault(i => i.Key == typeof(BillViewResult)).Value;

            var viewResult = new BillViewResult();            
            viewResult.ID = orderForeID + nowDate.ToString("yyyyMMddHHmmss");
            viewResult.Date = nowDate;
            viewResult.TimePeriod = timePeriod;

            ViewBag.TimePeriods = new SelectList(ConverterDictionary.TimePeriodDictionary, "Key", "Value");

            return View("AddPage", viewResult);
        }

        [HttpPost]
        public ActionResult Add(BillViewResult billViewResult)
        {
            ViewBag.TimePeriods = new SelectList(ConverterDictionary.TimePeriodDictionary, "Key", "Value");

            if (!ModelState.IsValid)
                return View("AddPage", billViewResult);

            var service = ServiceHelper.GetOrderService<BillViewResult>();
            var result = service.Add(billViewResult);
            if (GetModelError(result))
                return View("AddPage", billViewResult);

            return Index();
        }

        public ActionResult EditTablePage()
        {
            return View("EditTablePage");
        }


        public ActionResult EditPage(int tableID)
        {
            var service = new VBillService();
            var vBills = service.QueryServing(tableID);
            if (vBills == null || vBills.Count() == 0)
            {
                GetModelError(DBResult.NotFound);
                return EditTablePage();
            }

            var billViewResult = EntityHelper.CopyEntity(vBills.First(), new BillViewResult());
            billViewResult.ID = vBills.First().BillID;

            billViewResult.Details = EntityHelper.CopyEntities(vBills, new List<BillDetailsViewResult>());
            for (int i = 1; i < billViewResult.Details.Count(); i++)
            {
                billViewResult.Details[i].ID = vBills[i].DetailsID;
            }
            
            ViewBag.TimePeriod = ConverterDictionary.TimePeriodDictionary.FirstOrDefault(p => p.Key == billViewResult.TimePeriod).Value;

            return View("EditPage", billViewResult);
        }

        [HttpPost]
        public ActionResult Edit(BillViewResult billViewResult)
        {
            ViewBag.TimePeriod = ConverterDictionary.TimePeriodDictionary.FirstOrDefault(p => p.Key == billViewResult.TimePeriod).Value;

            var detailsViewResults = billViewResult.Details;
            if (detailsViewResults == null)
            {
                GetModelError(DBResult.WrongParameter);
                return View("EditPage", billViewResult);
            }

            for (int i = detailsViewResults.Count() - 1; i >= 0; i--)
            {
                if (detailsViewResults[i] == null)
                    detailsViewResults.Remove(detailsViewResults[i]);
            }

            if (!ModelState.IsValid)
                return View("EditPage", billViewResult);

            var service = new BillBusinessService();
            var result = service.Edit(billViewResult);
            if (GetModelError(result))
                return View("EditPage", billViewResult);

            return Index();
        }


        public ActionResult PayTablePage()
        {
            return View("PayTablePage");
        }


        public ActionResult DiscountPage(int tableID)
        {
            var service = new VBillService();
            var vBills = service.QueryServing(tableID);
            if (vBills == null || vBills.Count() == 0)
            {
                GetModelError(DBResult.NotFound);
                return EditTablePage();
            }

            var billViewResult = EntityHelper.CopyEntity(vBills.First(), new BillViewResult());
            billViewResult.ID = vBills.First().BillID;

            billViewResult.Details = EntityHelper.CopyEntities(vBills, new List<BillDetailsViewResult>());
            for (int i = 1; i < billViewResult.Details.Count(); i++)
            {
                billViewResult.Details[i].ID = vBills[i].DetailsID;
            }

            ViewBag.Discounts = GetSelectList<Discount>(new DiscountQueryConditions { OrderBy = "ID", IgnoredProperties = new string[] { "IsMemberOnly" } }, "Description", "Description");
            ViewBag.TimePeriod = ConverterDictionary.TimePeriodDictionary.FirstOrDefault(p => p.Key == billViewResult.TimePeriod).Value;

            return View("DiscountPage", billViewResult);
        }


        [HttpPost]
        public ActionResult Discount(BillViewResult billViewResult)
        {
            var newBillViewResult = new BillViewResult();

            ViewBag.Discounts = GetSelectList<Discount>(new DiscountQueryConditions { OrderBy = "ID", IgnoredProperties = new string[] { "IsMemberOnly" } }, "Description", "Description");
            ViewBag.TimePeriod = ConverterDictionary.TimePeriodDictionary.FirstOrDefault(p => p.Key == billViewResult.TimePeriod).Value;

            var service = new BillBusinessService();
            var result = service.Discount(billViewResult, out newBillViewResult);
            if (GetModelError(result))
                return View("DiscountPage", billViewResult);

            return PayPage(newBillViewResult);
        }


        public ActionResult PayPage(BillViewResult billViewResult)
        {            
            ViewBag.TimePeriod = ConverterDictionary.TimePeriodDictionary.FirstOrDefault(p => p.Key == billViewResult.TimePeriod).Value;
            return View("PayPage", billViewResult);
        }


        public ActionResult Pay(BillViewResult billViewResult)
        {
            ViewBag.TimePeriod = ConverterDictionary.TimePeriodDictionary.FirstOrDefault(p => p.Key == billViewResult.TimePeriod).Value;

            var service = new BillBusinessService();
            var result = service.Pay(billViewResult);
            if (GetModelError(result))
                return View("PayPage", billViewResult);

            return Index();
        }

        public ActionResult ServingTable()
        {
            int totalCount;
            ViewBag.ServingTables = GetQueryResults<ServingTable, ServingTableViewResult>(new ServingTableQueryConditions { OrderBy = "ID" }, out totalCount);
            return View("ServingTable");
        }
    }
}
