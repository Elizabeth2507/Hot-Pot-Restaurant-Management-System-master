using Hot_Pot_Restaurant_Management_System.Models.DataServices.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hot_Pot_Restaurant_Management_System.Controllers
{
    [Authorize(Roles = "1,4")]
    public class MonthlyReportController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult CurrentMonthPage()
        {
            var service = new MonthlyReportBusinessService();
            ViewBag.ViewResults = service.GetCurrentMonth();

            return View("CurrentMonthPage");
        }

        public ActionResult MonthlyReportPage(DateTime date)
        {
            var service = new MonthlyReportBusinessService();
            if (date != null)
                ViewBag.ViewResults = service.Get(date);

            ViewBag.Date = date;

            return View("MonthlyReportPage");
        }

        public ActionResult ReCalculate(DateTime date)
        {
            var service = new MonthlyReportBusinessService();
            if (date != null)
                ViewBag.ViewResults = service.ReCalculate(date);

            ViewBag.Date = date;

            return View("MonthlyReportPage");
        }
    }
}
