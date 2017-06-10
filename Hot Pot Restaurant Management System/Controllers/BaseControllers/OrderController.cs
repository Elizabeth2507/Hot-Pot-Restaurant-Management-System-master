using Hot_Pot_Restaurant_Management_System.Common;
using Hot_Pot_Restaurant_Management_System.Common.Dictionaries;
using Hot_Pot_Restaurant_Management_System.Common.Enums;
using Hot_Pot_Restaurant_Management_System.Common.Interfaces;
using Hot_Pot_Restaurant_Management_System.Models.DataServices;
using Hot_Pot_Restaurant_Management_System.Models.QueryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hot_Pot_Restaurant_Management_System.Controllers.BaseControllers
{
    public class OrderController : BaseController
    {
        
        protected T SetViewResult<T,S>(T viewResult, string pOID = null)
            where T : IOrder<S>, new()
            where S : IOrderDetails, new()
        {
            if (!string.IsNullOrEmpty(pOID))
            {
                var service = new VInventoryListService();
                int totalCount = 0;

                var queryResult = service.Query(new VInventoryListQueryConditions { POID = pOID }, out totalCount);
                if (totalCount != 0)
                {
                    viewResult = EntityHelper.CopyEntity(queryResult.First(), viewResult);
                    viewResult.Details = EntityHelper.CopyEntities(queryResult, new List<S>());
                }
            }

            var orderForeID = BuilderDictionary.ForeIDDictionary.FirstOrDefault(i => i.Key == typeof(T)).Value;
            var nowDate = DateTime.Now;

            viewResult.ID = orderForeID + nowDate.ToString("yyyyMMddHHmmss");
            viewResult.Date = nowDate;
            //EntityHelper.SetEntityID(viewResult, orderForeID + nowDate.ToString("yyyyMMddHHmmss"));
            //EntityHelper.SetPropertyValue(viewResult, "Date", nowDate);

            return viewResult;
        }

        
        protected ActionResult Add<T>(T orderViewResult, Func<ActionResult> succeedPage, Func<ActionResult> errorPage)
            where T : class, new()
        {
            if (!ModelState.IsValid)
                return errorPage();

            var service = ServiceHelper.GetOrderService<T>();
            var result = service.Add(orderViewResult);
            if (GetModelError(result))
                return errorPage == null ? null : errorPage();

            return succeedPage == null ? null : succeedPage();
        }

        
        protected ActionResult Add<T>(T orderViewResult, string[] succeedPage, string[] errorPage)
            where T : class, new()
        {
            if (!ModelState.IsValid)
                return RedirectToAction(errorPage[0], errorPage[1]);

            var service = ServiceHelper.GetOrderService<T>();
            var result = service.Add(orderViewResult);
            if (GetModelError(result))
                return errorPage == null ? null : RedirectToAction(errorPage[0], errorPage[1]);

            return succeedPage == null ? null : RedirectToAction(succeedPage[0], succeedPage[1]);
        }
    }
}
