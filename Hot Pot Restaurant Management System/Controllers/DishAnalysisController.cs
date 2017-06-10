using Hot_Pot_Restaurant_Management_System.Common;
using Hot_Pot_Restaurant_Management_System.Common.Enums;
using Hot_Pot_Restaurant_Management_System.Controllers.BaseControllers;
using Hot_Pot_Restaurant_Management_System.Models.DataServices.BusinessServices;
using Hot_Pot_Restaurant_Management_System.Models.ViewModels.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Hot_Pot_Restaurant_Management_System.Controllers
{
    [Authorize(Roles = "1,4")]
    public class DishAnalysisController : BaseController
    {
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult AmountChart()
        {
            return View("AmountChart");
        }

        public JsonResult GetAmountChart(string dishName, DateTime dateMin, DateTime dateMax)
        {
            string[] names = dishName.Split(',');

            var service = new DishChartService();
            var chartHelper = new ChartHelper<double>();

            foreach (var name in names)
            {
                if (string.IsNullOrEmpty(name))
                    continue;

                var results = service.GetSingleData(name, dateMin, dateMax);
                chartHelper.AddData(name, ChartType.spline, results[0]);
            }

            chartHelper.Chart.type = ChartType.spline.ToString();
            chartHelper.Title.text = "Sales trend";
            chartHelper.XAxis.type = AxisType.datetime.ToString();
            chartHelper.YAxis.title.text = "Sales";
            chartHelper.PlotOptions.series.pointStart = dateMin.ToString("yyyy/MM/dd");
            chartHelper.PlotOptions.series.pointInterval = 24 * 3600 * 1000;
            chartHelper.PlotOptions.series.enableMouseTracking = true;

            var viewResult = chartHelper.HighCharts();
            return Json(viewResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MoneyChart()
        {
            return View("MoneyChart");
        }

        public JsonResult GetMoneyChart(string dishName, DateTime dateMin, DateTime dateMax)
        {
            var service = new DishChartService();
            var chartHelper = new ChartHelper<double>();

            var results = service.GetSingleData(dishName, dateMin, dateMax);
            chartHelper.AddData("Sales", ChartType.spline, results[1]);

            if (!results[2].Contains(-1))
                chartHelper.AddData("Cost", ChartType.spline, results[2]);

            chartHelper.Chart.type = ChartType.spline.ToString();
            chartHelper.Title.text = "Food sales trends";
            chartHelper.XAxis.type = AxisType.datetime.ToString();
            chartHelper.YAxis.title.text = "Amount of money";
            chartHelper.PlotOptions.series.pointStart = dateMin.ToString("yyyy/MM/dd");
            chartHelper.PlotOptions.series.pointInterval = 24 * 3600 * 1000;
            chartHelper.PlotOptions.series.enableMouseTracking = true;

            var viewResult = chartHelper.HighCharts();
            return Json(viewResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TotalDailyChart()
        {
            return View("TotalDailyChart");
        }

        public JsonResult GetTotalDailyChart(DateTime dateMin, DateTime dateMax)
        {
            var service = new DishChartService();
            var chartHelper = new ChartHelper<double>();

            var results = service.GetMoneyData(dateMin, dateMax);
            chartHelper.AddData("Sales", ChartType.spline, results[0]);
            chartHelper.AddData("Discount amount", ChartType.spline, results[1]);
            chartHelper.AddData("Cost", ChartType.spline, results[2]);

            chartHelper.Chart.type = ChartType.spline.ToString();
            chartHelper.Title.text = "Inventory control of food sales trends";
            chartHelper.XAxis.type = AxisType.datetime.ToString();
            chartHelper.YAxis.title.text = "Amount of money";
            chartHelper.PlotOptions.series.pointStart = dateMin.ToString("yyyy/MM/dd");
            chartHelper.PlotOptions.series.pointInterval = 24 * 3600 * 1000;
            chartHelper.PlotOptions.series.enableMouseTracking = true;

            var viewResult = chartHelper.HighCharts();
            return Json(viewResult, JsonRequestBehavior.AllowGet);
        }
    }
}