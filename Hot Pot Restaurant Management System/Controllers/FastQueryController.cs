using Hot_Pot_Restaurant_Management_System.Common;
using Hot_Pot_Restaurant_Management_System.Controllers.BaseControllers;
using Hot_Pot_Restaurant_Management_System.Models.Entities;
using Hot_Pot_Restaurant_Management_System.Models.ViewModels.AutoComplete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hot_Pot_Restaurant_Management_System.Controllers
{
    [Authorize(Roles = "1,2,3,4")]
    public class AutoCompleteController : BaseController
    {
        public JsonResult Warehouses(string query)
        {
            var jsonResult = GetJsonResult<Warehouse>(query, "Name");
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Products(string query)
        {
            var jsonResult = GetJsonResult<Product>(query, "Name");
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Categories(string query)
        {
            var jsonResult = GetJsonResult<Category>(query, "Name");
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Dishes(string query)
        {
            var jsonResult = GetJsonResult<Dish>(query, "Name");
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Discounts(string query)
        {
            var jsonResult = GetJsonResult<Discount>(query, "Description");
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult MembersName(string query)
        {
            var jsonResult = GetJsonResult<Member>(query, "Name");
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult MembersID(string query)
        {
            var jsonResult = GetJsonResult<Member>(query, "ID");
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        } 

        public JsonResult UsersUserName(string query)
        {
            var jsonResult = GetJsonResult<User>(query, "UserName");
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UsersRealName(string query)
        {
            var jsonResult = GetJsonResult<User>(query, "RealName");
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        
        private AutoCompleteViewResult GetJsonResult<T>(string queryText, string valueField)
            where T : class
        {
            var jsonResult = new AutoCompleteViewResult
            {
                query = string.Empty,
                suggestions = new string[] { }
            };

            var queryResults = GetFastQueryResults<T>(queryText);
            if (queryResults == null || queryResults.Count() == 0)
                return jsonResult;

            var suggestions = new List<string>();
            foreach (var result in queryResults)
            {
                string value = EntityHelper.GetPropertyValue(result, valueField).ToString();
                suggestions.Add(value);
            }

            jsonResult.query = queryText;
            jsonResult.suggestions = suggestions.ToArray();

            return jsonResult;
        }
        
        private List<T> GetFastQueryResults<T>(string queryText)
            where T : class
        {
            var service = ServiceHelper.GetFastQueryService<T>();
            return service.FastQuery(queryText);
        }
    }
}
