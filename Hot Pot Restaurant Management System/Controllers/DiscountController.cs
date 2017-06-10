using Hot_Pot_Restaurant_Management_System.Controllers.BaseControllers;
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
    public class DiscountController : ManagementController<Discount, DiscountViewResult>
    {
        public ActionResult Index()
        {
            var queryConditions = new DiscountQueryConditions { OrderBy = "ID", PageSize = 15, PageIndex = 1 };
            base.GetQueryResults(queryConditions);

            ViewBag.SelectBool = new SelectList(new Dictionary<string, string> { { "true", "Yes" }, { "false", "No" }, { "all", "All" } }, "key", "value");

            return View("Index", queryConditions);
        }

        public ActionResult AddPage()
        {
            return base.GetAddPage();
        }

        [HttpPost]
        public ActionResult Add(DiscountViewResult viewResult)
        {
            return base.Add(viewResult, new string[] { "Index", "Discount" }, AddPage);
        }

        public ActionResult EditPage(int id)
        {
            int totalCount;

            var viewResult = base.GetQueryResults<Discount, DiscountViewResult>
                (new DiscountQueryConditions { ID = id, IgnoredProperties = new string[] { "IsMemberOnly" } }, out totalCount).FirstOrDefault();
            if (viewResult == null)
                return RedirectToAction("Error", "Home");

            return View("EditPage", viewResult);
        }

        [HttpPost]
        public ActionResult Edit(DiscountViewResult viewResult, int id)
        {
            return base.Edit(viewResult, id, new string[] { "Index", "Discount" }, EditPage);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            return base.Delete(id, Index, EditPage);
        }
    }
}
