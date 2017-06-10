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
    public class ManagementController<T, S> : BaseController
        where T : class, new()
        where S : class, new()
    {
        
        protected List<S> GetQueryResults(QueryConditions queryConditions)
        {
            int totalCount = 0;
            queryConditions.GetValues(Request.QueryString);

            if (queryConditions.PageIndex < 1)
                queryConditions.PageIndex = 1;

            var service = ServiceHelper.GetDataService<T>();
            var results = service.Query(queryConditions, out totalCount);
            var viewResults = EntityHelper.CopyEntities(results, new List<S>());

            ViewBag.ViewResults = viewResults;
            ViewBag.TotalPage = (totalCount + 14) / 15;
            ViewBag.PageIndex = queryConditions.PageIndex;
            ViewBag.QueryConditions = queryConditions;

            return viewResults;
        }

        
        protected ActionResult GetAddPage()
        {
            var viewResult = new S();
            return View("AddPage", viewResult);
        }

        
        protected ActionResult Add(S viewResult, Func<ActionResult> succeedPage, Func<ActionResult> errorPage)
        {
            if (!ModelState.IsValid)
                return errorPage();

            var service = ServiceHelper.GetDataService<T>();
            var result = service.Add(EntityHelper.CopyEntity(viewResult, new T()));

            if (result == DBResult.Succeed)
                return succeedPage();
            else
            {
                var error = DBDictionary.DBResultDictionary.FirstOrDefault(e => e.Key == result).Value;
                ModelState.AddModelError(error[0], error[1]);
            }

            return errorPage();
        }

        
        protected ActionResult Add(S viewResult, string[] succeedPage, Func<ActionResult> errorPage)
        {
            if (!ModelState.IsValid)
                return errorPage();

            var service = ServiceHelper.GetDataService<T>();
            var result = service.Add(EntityHelper.CopyEntity(viewResult, new T()));

            if (result == DBResult.Succeed)
                return RedirectToAction(succeedPage[0], succeedPage[1]);
            else
            {
                var error = DBDictionary.DBResultDictionary.FirstOrDefault(e => e.Key == result).Value;
                ModelState.AddModelError(error[0], error[1]);
            }

            return errorPage();
        }

        
        protected ActionResult Edit(S viewResult, int id, Func<ActionResult> succeedPage, Func<int, ActionResult> errorPage)
        {
            if (!ModelState.IsValid)
                return errorPage(id);

            var service = ServiceHelper.GetDataService<T>();
            var result = service.Edit(EntityHelper.CopyEntity(viewResult, new T()));

            if (result == DBResult.Succeed)
                return succeedPage();
            else
            {
                var error = DBDictionary.DBResultDictionary.FirstOrDefault(e => e.Key == result).Value;
                ModelState.AddModelError(error[0], error[1]);
            }

            return errorPage(id);
        }

        
        protected ActionResult Edit(S viewResult, int id, string[] succeedPage, Func<int, ActionResult> errorPage)
        {
            if (!ModelState.IsValid)
                return errorPage(id);

            var viewResultID = viewResult.GetType().GetProperty("ID");
            viewResultID.SetValue(viewResult, id);

            var service = ServiceHelper.GetDataService<T>();
            var result = service.Edit(EntityHelper.CopyEntity(viewResult, new T()));

            if (result == DBResult.Succeed)
                return RedirectToAction(succeedPage[0], succeedPage[1]);
            else
            {
                var error = DBDictionary.DBResultDictionary.FirstOrDefault(e => e.Key == result).Value;
                ModelState.AddModelError(error[0], error[1]);
            }

            return errorPage(id);
        }

        
        protected ActionResult Delete(int id, Func<ActionResult> succeedPage, Func<int, ActionResult> errorPage)
        {
            var service = ServiceHelper.GetDataService<T>();
            var result = service.Delete(id);

            if (result == DBResult.Succeed)
                return succeedPage == null ? null : succeedPage();
            else
            {
                var error = DBDictionary.DBResultDictionary.FirstOrDefault(e => e.Key == result).Value;
                ModelState.AddModelError(error[0], error[1]);
            }

            return errorPage(id);
        }

        
        protected ActionResult Delete(int id, string[] succeedPage, Func<int, ActionResult> errorPage)
        {
            var service = ServiceHelper.GetDataService<T>();
            var result = service.Delete(id);

            if (result == DBResult.Succeed)
                return RedirectToAction(succeedPage[0], succeedPage[1]);
            else
            {
                var error = DBDictionary.DBResultDictionary.FirstOrDefault(e => e.Key == result).Value;
                ModelState.AddModelError(error[0], error[1]);
            }

            return errorPage(id);
        }
    }
}
