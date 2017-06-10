using Hot_Pot_Restaurant_Management_System.Common;
using Hot_Pot_Restaurant_Management_System.Common.Dictionaries;
using Hot_Pot_Restaurant_Management_System.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hot_Pot_Restaurant_Management_System.Controllers.BaseControllers
{
    public class BaseController : Controller
    {
        
        protected List<S> GetQueryResults<T, S>(QueryConditions queryConditions, out int totalCount)
            where T : class, new()
            where S : class, new()
        {
            var service = ServiceHelper.GetDataService<T>();
            var results = service.Query(queryConditions, out totalCount);
            var viewResults = EntityHelper.CopyEntities(results, new List<S>());

            return viewResults;
        }

        
        public bool GetModelError(DBResult dBResult)
        {
            if (dBResult == DBResult.Succeed)
                return false;

            var error = DBDictionary.DBResultDictionary.FirstOrDefault(e => e.Key == dBResult).Value;
            ModelState.AddModelError(error[0], error[1]);
            return true;
        }

        protected SelectList GetSelectList<T>(QueryConditions queryConditions, string dataValueField = "ID", string dataTextField = "Name",
            object selectedValue = null, IEnumerable<T> customItems = null)
            where T : class
        {
            int totalCount = 0;

            var service = ServiceHelper.GetDataService<T>();
            var items = service.Query(queryConditions, out totalCount);

            if (customItems != null)
                items.AddRange(customItems);

            return new SelectList(items, dataValueField, dataTextField, selectedValue);
        }
    }
}