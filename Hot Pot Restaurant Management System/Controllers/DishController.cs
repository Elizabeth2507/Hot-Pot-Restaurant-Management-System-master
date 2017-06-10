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
    public class DishController : ManagementController<Dish, DishViewResult>
    {
        public ActionResult Index()
        {
            var queryConditions = new DishQueryConditions { OrderBy = "ShortID", PageSize = 15, PageIndex = 1 };
            base.GetQueryResults(queryConditions);

            var EmptyItem = new List<Category> { new Category { ID = 0, ShortID = 0, Name = "No" } };
            ViewBag.Categories = GetSelectList<Category>(new CategoryQueryConditions { OrderBy = "ShortID" },
                selectedValue: queryConditions.CategoryID, customItems: EmptyItem);
            ViewBag.SelectBool = new SelectList(new Dictionary<string, string> { { "true", "Yes" }, { "false", "No" }, { "all", "All" } }, "key", "value");

            return View("Index", queryConditions);
        }

        public ActionResult AddPage()
        {
            ViewBag.Categories = GetSelectList<Category>(new CategoryQueryConditions { OrderBy = "ShortID" });
            return base.GetAddPage();
        }

        [HttpPost]
        public ActionResult Add(DishViewResult viewResult)
        {
            return base.Add(viewResult, new string[] { "Index", "Dish" }, AddPage);
        }

        public ActionResult EditPage(int id)
        {
            int totalCount;

            var viewResult = base.GetQueryResults<Dish, DishViewResult>
                (new DishQueryConditions { ID = id, IgnoredProperties = new string[] { "PriceEditable", "InventoryControl" } }, out totalCount).FirstOrDefault();
            if (viewResult == null)
                return RedirectToAction("Error", "Home");

            ViewBag.Categories = GetSelectList<Category>(new CategoryQueryConditions { OrderBy = "ShortID" });

            return View("EditPage", viewResult);
        }

        [HttpPost]
        public ActionResult Edit(DishViewResult viewResult, int id)
        {
            return base.Edit(viewResult, id, new string[] { "Index", "Dish" }, EditPage);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            return base.Delete(id, Index, EditPage);
        }
    }
}
