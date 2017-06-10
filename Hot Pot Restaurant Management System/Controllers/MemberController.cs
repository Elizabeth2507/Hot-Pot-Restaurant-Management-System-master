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
    [Authorize(Roles = "1,3")]
    public class MemberController : ManagementController<Member, MemberViewResult>
    {
        public ActionResult Index()
        {
            var queryConditions = new MemberQueryConditions { OrderBy = "ID", PageSize = 15, PageIndex = 1 };
            base.GetQueryResults(queryConditions);

            return View("Index");
        }

        public ActionResult AddPage()
        {
            return base.GetAddPage();
        }

        [HttpPost]
        public ActionResult Add(MemberViewResult viewResult)
        {
            return base.Add(viewResult, new string[] { "Index", "Member" }, AddPage);
        }

        public ActionResult EditPage(string id)
        {
            int totalCount;

            var viewResult = base.GetQueryResults<Member, MemberViewResult>(new MemberQueryConditions { ID = id }, out totalCount).FirstOrDefault();
            if (viewResult == null)
                return RedirectToAction("Error", "Home");

            return View("EditPage", viewResult);
        }

        [HttpPost]
        public ActionResult Edit(MemberViewResult viewResult, string id)
        {
            if (!ModelState.IsValid)
                return EditPage(id);

            var service = new MemberService();
            var result = service.Edit(EntityHelper.CopyEntity(viewResult, new Member()));

            if (result == DBResult.Succeed)
                return RedirectToAction("Index", "Member");
            else
            {
                var error = DBDictionary.DBResultDictionary.FirstOrDefault(e => e.Key == result).Value;
                ModelState.AddModelError(error[0], error[1]);
            }

            return EditPage(id);
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            var service = new MemberService();
            var result = service.Delete(new Member { ID = id });

            if (result == DBResult.Succeed)
                return RedirectToAction("Index", "Member");
            else
            {
                var error = DBDictionary.DBResultDictionary.FirstOrDefault(e => e.Key == result).Value;
                ModelState.AddModelError(error[0], error[1]);
            }

            return EditPage(id);
        }
    }
}
