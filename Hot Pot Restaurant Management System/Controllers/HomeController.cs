using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Hot_Pot_Restaurant_Management_System.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "1,2,3,4")]
        public ActionResult Index()
        {
            return View("Index");
        }

        [Authorize(Roles = "1,2")]
        public ActionResult WarehouseIndex()
        {
            return View("WarehouseIndex");
        }

        [Authorize(Roles = "1,3")]
        public ActionResult FrontDeskIndex()
        {
            return View("FrontDeskIndex");
        }

        [Authorize(Roles = "1,4")]
        public ActionResult ReportIndex()
        {
            return View("ReportIndex");
        }

        [Authorize(Roles = "1")]
        public ActionResult SystemIndex()
        {
            return View("SystemIndex");
        }

        [HttpPost]
        [Authorize(Roles = "1,2,3,4")]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("Index", "Login");
        }

        [Authorize(Roles = "1,2,3,4")]
        public ActionResult Error()
        {
            return View("Error");
        }
    }
}
