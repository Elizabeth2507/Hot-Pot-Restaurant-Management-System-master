using Hot_Pot_Restaurant_Management_System.Common;
using Hot_Pot_Restaurant_Management_System.Common.Dictionaries;
using Hot_Pot_Restaurant_Management_System.Controllers.BaseControllers;
using Hot_Pot_Restaurant_Management_System.Models.DataServices;
using Hot_Pot_Restaurant_Management_System.Models.DataServices.BusinessServices;
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
    [Authorize(Roles = "1,2")]
    public class OrderCreaterController : OrderController
    {
        public ActionResult Index()
        {
            return View("Index");
        }

        
        public ActionResult POAddPage()
        {
            var viewResult = new PurchaseOrderViewResult();
            viewResult = SetViewResult<PurchaseOrderViewResult, PODetailsViewResult>(viewResult);

            return View("POAddPage", viewResult);
        }

        
        [HttpPost]
        public ActionResult POAdd(PurchaseOrderViewResult orderViewResult)
        {
            return base.Add<PurchaseOrderViewResult>(orderViewResult, Index, POAddPage);
        }

        
        public ActionResult MRAddPage()
        {
            var viewResult = new MaterialsRequisitionViewResult();
            string pOID = Request.QueryString["poid"];

            viewResult = SetViewResult<MaterialsRequisitionViewResult, MRDetailsViewResult>(viewResult, pOID);
            return View("MRAddPage", viewResult);
        }
        
        [HttpPost]
        public ActionResult MRAdd(MaterialsRequisitionViewResult orderViewResult)
        {
            return base.Add<MaterialsRequisitionViewResult>(orderViewResult, Index, MRAddPage);
        }

        
        public ActionResult COAddPage()
        {
            var viewResult = new CreditOrderViewResult();
            string pOID = Request.QueryString["poid"];

            viewResult = SetViewResult<CreditOrderViewResult, CODetailsViewResult>(viewResult, pOID);
            return View("COAddPage", viewResult);
        }

        
        [HttpPost]
        public ActionResult COAdd(CreditOrderViewResult orderViewResult)
        {
            return base.Add<CreditOrderViewResult>(orderViewResult, Index, COAddPage);
        }

        
        public ActionResult MROAddPage()
        {
            var viewResult = new MaterialsReturnOrderViewResult();
            string pOID = Request.QueryString["poid"];

            viewResult = SetViewResult<MaterialsReturnOrderViewResult, MRODetailsViewResult>(viewResult, pOID);
            return View("MROAddPage", viewResult);
        }

        
        [HttpPost]
        public ActionResult MROAdd(MaterialsReturnOrderViewResult orderViewResult)
        {
            return base.Add<MaterialsReturnOrderViewResult>(orderViewResult, Index, MROAddPage);
        }

        
        public ActionResult TOAddPage()
        {
            var viewResult = new TransferOrderViewResult();

            string pOID = Request.QueryString["poid"];
            if (!string.IsNullOrEmpty(pOID))
            {
                var service = new VInventoryListService();
                int totalCount = 0;

                var queryResult = service.Query(new VInventoryListQueryConditions { POID = pOID }, out totalCount);
                if (totalCount != 0)
                {
                    viewResult.OutName = queryResult.First().WarehouseName;
                    viewResult.Details = EntityHelper.CopyEntities(queryResult, new List<TODetailsViewResult>());
                }
            }

            var orderForeID = BuilderDictionary.ForeIDDictionary.FirstOrDefault(i => i.Key == typeof(TransferOrderViewResult)).Value;
            var nowDate = DateTime.Now;

            EntityHelper.SetEntityID(viewResult, orderForeID + nowDate.ToString("yyyyMMddHHmmss"));
            EntityHelper.SetPropertyValue(viewResult, "Date", nowDate);

            return View("TOAddPage", viewResult);
        }

        
        [HttpPost]
        public ActionResult TOAdd(TransferOrderViewResult orderViewResult)
        {
            return base.Add<TransferOrderViewResult>(orderViewResult, Index, TOAddPage);
        }

        
        public ActionResult SLAddPage()
        {
            var viewResult = new StocktakingListViewResult();
            string pOID = Request.QueryString["poid"];

            viewResult = SetViewResult<StocktakingListViewResult, SLDetailsViewResult>(viewResult, pOID);
            return View("SLAddPage", viewResult);
        }
        
        [HttpPost]
        public ActionResult SLAdd(StocktakingListViewResult orderViewResult)
        {
            return base.Add<StocktakingListViewResult>(orderViewResult, Index, SLAddPage);
        }
    }
}
