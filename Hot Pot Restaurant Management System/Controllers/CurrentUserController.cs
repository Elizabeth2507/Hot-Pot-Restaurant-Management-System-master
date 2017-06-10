using Hot_Pot_Restaurant_Management_System.Common;
using Hot_Pot_Restaurant_Management_System.Common.Authentication;
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
    [Authorize(Roles = "1,2,3,4")]
    public class CurrentUserController : ManagementController<User, UserViewResult>
    {
        public ActionResult Index()
        {
            var userViewResult = new UserViewResult { UserName = HttpContext.User.Identity.Name };
            EntityHelper.CopyEntity((UserIdentity)HttpContext.User.Identity, userViewResult);

            ViewBag.Role = ConverterDictionary.UserRoleDictionary.FirstOrDefault(p => p.Key == userViewResult.Role).Value;

            return View("Index", userViewResult);
        }

        public ActionResult PasswordPage()
        {
            int totalCount;

            var viewResults = base.GetQueryResults<User, UserViewResult>(new UserQueryConditions { ID = ((UserIdentity)HttpContext.User.Identity).ID }, out totalCount);
            var viewResult = viewResults.FirstOrDefault();
            if (viewResult == null)
                return Index();

            return View("PasswordPage", viewResult);
        }

        [HttpPost]
        public ActionResult ChangePassword(int id, string userName, string oldPassword, string password)
        {
            if (id != ((UserIdentity)HttpContext.User.Identity).ID)
                return PasswordPage();

            if (id == 0)
            {
                ModelState.AddModelError("", "Parameter error");
                return PasswordPage();
            }
            if (string.IsNullOrEmpty(oldPassword))
            {
                ModelState.AddModelError("OldPassword", "Missing original password");
                return PasswordPage();
            }
            if (string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("Password", "Missing new password");
                return PasswordPage();
            }

            var service = new UserService();
            var user = new User();

            var check = service.Check(userName, oldPassword, out user);
            if (check != DBResult.Succeed)
            {
                var error = DBDictionary.DBResultDictionary.FirstOrDefault(e => e.Key == check).Value;
                ModelState.AddModelError(error[0], error[1]);
                return PasswordPage();
            }

            var result = service.ChangePassword(new User { ID = id, Password = password });
            if (result == DBResult.Succeed)
                return Index();
            else
            {
                var error = DBDictionary.DBResultDictionary.FirstOrDefault(e => e.Key == result).Value;
                ModelState.AddModelError(error[0], error[1]);
            }

            return PasswordPage();
        }
    }
}
