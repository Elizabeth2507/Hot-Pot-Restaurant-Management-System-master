using Hot_Pot_Restaurant_Management_System.Common;
using Hot_Pot_Restaurant_Management_System.Common.Dictionaries;
using Hot_Pot_Restaurant_Management_System.Common.Enums;
using Hot_Pot_Restaurant_Management_System.Common.Interfaces;
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
    public class CategoryController : ManagementController<Category, CategoryViewResult>
    {
        public ActionResult Index()
        {
            var queryConditions = new CategoryQueryConditions { OrderBy = "ShortID", PageSize = 15, PageIndex = 1 };
            base.GetQueryResults(queryConditions);

            var EmptyItem = new List<Category> { new Category { ID = 0, ShortID = 0, Name = "No" } };

            ViewBag.Categories = GetSelectList<Category>(new CategoryQueryConditions { OrderBy = "ShortID" },
                selectedValue: queryConditions.SuperiorID, customItems: EmptyItem);

            return View("Index");
        }

        public ActionResult AddPage()
        {
            var EmptyItem = new List<Category> { new Category { ID = 0, ShortID = 0, Name = "No" } };
            ViewBag.Categories = GetSelectList<Category>(new CategoryQueryConditions { OrderBy = "ShortID" }, customItems: EmptyItem);

            return base.GetAddPage();
        }

        [HttpPost]
        public ActionResult Add(CategoryViewResult viewResult)
        {
            return base.Add(viewResult, new string[] { "Index", "Category" }, AddPage);
        }

        public ActionResult EditPage(int id)
        {
            int totalCount;

            var viewResult = base.GetQueryResults<Category, CategoryViewResult>(new CategoryQueryConditions { ID = id }, out totalCount).FirstOrDefault();
            if (viewResult == null)
                return RedirectToAction("Error", "Home");

            var EmptyItem = new List<Category> { new Category { ID = 0, ShortID = 0, Name = "No" } };
            ViewBag.Categories = GetSelectList<Category>(new CategoryQueryConditions { OrderBy = "ShortID" }, customItems: EmptyItem);

            return View("EditPage", viewResult);
        }

        [HttpPost]
        public ActionResult Edit(CategoryViewResult viewResult, int id)
        {
            return base.Edit(viewResult, id, new string[] { "Index", "Category" }, EditPage);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            return base.Delete(id, Index, EditPage);
        }

        public ActionResult TreePage()
        {
            int totalCount;

            var viewResults = base.GetQueryResults<Category, CategoryViewResult>(new CategoryQueryConditions { OrderBy = "ShortID" }, out totalCount);
            ViewBag.TreeRoot = TreeHelper.BuildTree<CategoryViewResult>(viewResults);

            return View("TreePage");
        }
    }
}
