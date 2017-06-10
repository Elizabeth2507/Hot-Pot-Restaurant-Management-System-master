using Hot_Pot_Restaurant_Management_System.Common;
using Hot_Pot_Restaurant_Management_System.Common.Dictionaries;
using Hot_Pot_Restaurant_Management_System.Common.Enums;
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
    public class ProductController : ManagementController<Product, ProductViewResult>
    {
        public ActionResult Index()
        {
            var queryConditions = new ProductQueryConditions { OrderBy = "ShortID", PageSize = 15, PageIndex = 1 };
            base.GetQueryResults(queryConditions);

            var EmptyItem = new List<Category> { new Category { ID = 0, ShortID = 0, Name = "No" } };
            ViewBag.Categories = GetSelectList<Category>(new CategoryQueryConditions { OrderBy = "ShortID" }, 
                selectedValue: queryConditions.CategoryID, customItems: EmptyItem);

            return View("Index");
        }

        public ActionResult AddPage()
        {
            ViewBag.Categories = GetSelectList<Category>(new CategoryQueryConditions { OrderBy = "ShortID" });
            return base.GetAddPage();
        }

        [HttpPost]
        public ActionResult Add(ProductViewResult viewResult)
        {
            return base.Add(viewResult, new string[] { "Index", "Product" }, AddPage);
        }

        public ActionResult EditPage(int id)
        {
            int totalCount;

            var viewResult = base.GetQueryResults<Product, ProductViewResult>(new ProductQueryConditions { ID = id }, out totalCount).FirstOrDefault();
            if (viewResult == null)
                return RedirectToAction("Error", "Home");

            ViewBag.Categories = GetSelectList<Category>(new CategoryQueryConditions { OrderBy = "ShortID" });

            return View("EditPage", viewResult);
        }

        [HttpPost]
        public ActionResult Edit(ProductViewResult viewResult, int id)
        {
            return base.Edit(viewResult, id, new string[] { "Index", "Product" }, EditPage);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            return base.Delete(id, Index, EditPage);
        }
    }
}
