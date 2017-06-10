using Hot_Pot_Restaurant_Management_System.Common;
using Hot_Pot_Restaurant_Management_System.Controllers.BaseControllers;
using Hot_Pot_Restaurant_Management_System.Models.DataServices;
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
    [Authorize(Roles = "1,2")]
    public class VInventoryListController : Controller
    {
        public ActionResult Index()
        {
            int totalCount = 0;
            var queryConditions = new VInventoryListQueryConditions { OrderBy = "WarehouseID", PageSize = 15, PageIndex = 1 };

            if (Request.QueryString.HasKeys())
                queryConditions.GetValues(Request.QueryString);

            if (queryConditions.PageIndex < 1)
                queryConditions.PageIndex = 1;

            var service = new VInventoryListService();
            var results = service.Query(queryConditions, out totalCount);

            ViewBag.ViewResults = EntityHelper.CopyEntities(results, new List<VInventoryListViewResult>());
            ViewBag.TotalPage = (totalCount + 14) / 15;
            ViewBag.PageIndex = queryConditions.PageIndex;
            ViewBag.QueryConditions = queryConditions;

            return View("Index");
        }
    }
}
