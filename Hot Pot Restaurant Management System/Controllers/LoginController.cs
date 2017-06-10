using Hot_Pot_Restaurant_Management_System.Common;
using Hot_Pot_Restaurant_Management_System.Common.Authentication;
using Hot_Pot_Restaurant_Management_System.Controllers.BaseControllers;
using Hot_Pot_Restaurant_Management_System.Models.DataServices;
using Hot_Pot_Restaurant_Management_System.Models.Entities;
using Hot_Pot_Restaurant_Management_System.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hot_Pot_Restaurant_Management_System.Controllers
{
    public class LoginController : BaseController
    {
        public ActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View("Index");
        }

        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
            {
                ModelState.AddModelError("UserName", "Missing user name");
                return Index();
            }
            if (string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("Password", "Missing password");
                return Index();
            }

            var user = new User();
            var service = new UserService();

            var result = service.Check(userName, password, out user);
            if (GetModelError(result))
                return Index();

            var userViewResult = EntityHelper.CopyEntity(user, new UserViewResult());
            userViewResult.Password = string.Empty;

            var cookie = UserAuthentication.CreateCookie(userViewResult);
            HttpContext.Response.Cookies.Remove(cookie.Name);
            HttpContext.Response.Cookies.Add(cookie);

            return RedirectToAction("Index", "Home");
        }
    }
}
