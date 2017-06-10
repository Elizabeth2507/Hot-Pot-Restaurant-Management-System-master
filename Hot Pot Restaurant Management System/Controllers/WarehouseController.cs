using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hot_Pot_Restaurant_Management_System.Models.DataServices;
using Hot_Pot_Restaurant_Management_System.Models.QueryModels;
using Hot_Pot_Restaurant_Management_System.Common;
using Hot_Pot_Restaurant_Management_System.Models.ViewModels;
using Hot_Pot_Restaurant_Management_System.Models.Entities;
using Hot_Pot_Restaurant_Management_System.Common.Enums;
using Hot_Pot_Restaurant_Management_System.Common.Dictionaries;
using Hot_Pot_Restaurant_Management_System.Controllers.BaseControllers;

namespace Hot_Pot_Restaurant_Management_System.Controllers
{
    [Authorize(Roles = "1,2")]
    public class WarehouseController : ManagementController<Warehouse, WarehouseViewResult>
    {
        public ActionResult Index()
        {
            var queryConditions = new WarehouseQueryConditions { OrderBy = "ShortID", PageSize = 15, PageIndex = 1 };
            base.GetQueryResults(queryConditions);

            return View("Index");
        }

        public ActionResult AddPage()
        {
            return base.GetAddPage();
        }

        [HttpPost]
        public ActionResult Add(WarehouseViewResult viewResult)
        {
            return base.Add(viewResult, new string[] { "Index", "Warehouse" }, AddPage);
        }

        public ActionResult EditPage(int id)
        {
            int totalCount;

            var viewResult = base.GetQueryResults<Warehouse, WarehouseViewResult>(new WarehouseQueryConditions { ID = id }, out totalCount).FirstOrDefault();
            if (viewResult == null)
                return RedirectToAction("Error", "Home");

            return View("EditPage", viewResult);
        }

        [HttpPost]
        public ActionResult Edit(WarehouseViewResult viewResult, int id)
        {
            return base.Edit(viewResult, id, new string[] { "Index", "Warehouse" }, EditPage);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            return base.Delete(id, Index, EditPage);
        }
    }
}
