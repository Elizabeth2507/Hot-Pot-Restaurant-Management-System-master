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
    [Authorize(Roles = "1")]
    public class UserController : ManagementController<User, UserViewResult>
    {
        public ActionResult Index()
        {
            var queryConditions = new UserQueryConditions { OrderBy = "ShortID", PageSize = 15, PageIndex = 1 };
            base.GetQueryResults(queryConditions);

            var roleList = ConverterDictionary.UserRoleDictionary.ToList();
            roleList.Add(new KeyValuePair<int, string>(0, "Any role"));
            ViewBag.UserRoles = new SelectList(roleList, "Key", "Value", queryConditions.Role);

            return View("Index");
        }

        public ActionResult AddPage()
        {
            ViewBag.UserRoles = new SelectList(ConverterDictionary.UserRoleDictionary, "Key", "Value");
            return base.GetAddPage();
        }

        [HttpPost]
        public ActionResult Add(UserViewResult viewResult)
        {
            return base.Add(viewResult, new string[] { "Index", "User" }, AddPage);
        }

        public ActionResult EditPage(int id)
        {
            int totalCount;

            var viewResult = base.GetQueryResults<User, UserViewResult>(new UserQueryConditions { ID = id }, out totalCount).FirstOrDefault();
            if (viewResult == null)
                return RedirectToAction("Error", "Home");

            viewResult.Password = null;
            ViewBag.UserRoles = new SelectList(ConverterDictionary.UserRoleDictionary, "Key", "Value");

            return View("EditPage", viewResult);
        }

        [HttpPost]
        public ActionResult Edit(UserViewResult viewResult, int id)
        {
            return base.Edit(viewResult, id, new string[] { "Index", "User" }, EditPage);
        }

        public ActionResult PasswordPage(int id)
        {
            int totalCount;

            var viewResult = base.GetQueryResults<User, UserViewResult>(new UserQueryConditions { ID = id }, out totalCount).FirstOrDefault();
            if (viewResult == null)
                return RedirectToAction("Error", "Home");

            viewResult.Password = null;

            return View("PasswordPage", viewResult);
        }

        [HttpPost]
        public ActionResult ChangePassword(int id, string userName, string password)
        {
            if (id == 0)
            {
                ModelState.AddModelError("", "Parameter error");
                return PasswordPage(id);
            }
            if (string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("Password", "Missing new password");
                return PasswordPage(id);
            }

            var service = new UserService();
            var result = service.ChangePassword(new User { ID = id, Password = password });

            if (result == DBResult.Succeed)
                return Index();
            else
            {
                var error = DBDictionary.DBResultDictionary.FirstOrDefault(e => e.Key == result).Value;
                ModelState.AddModelError(error[0], error[1]);
            }

            return PasswordPage(id);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            return base.Delete(id, Index, EditPage);
        }
    }
}
