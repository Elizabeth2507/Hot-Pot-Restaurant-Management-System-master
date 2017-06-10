using Hot_Pot_Restaurant_Management_System.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Common.Dictionaries
{
    public class BuilderDictionary
    {
        //Document number head
        public static Dictionary<Type, string> ForeIDDictionary = new Dictionary<Type, string>
        {
            { typeof(PurchaseOrderViewResult), "0001" },
            { typeof(PODetailsViewResult), "1001" },
            { typeof(MaterialsRequisitionViewResult), "0003" },
            { typeof(MRDetailsViewResult), "1003" },
            { typeof(CreditOrderViewResult), "0002" },
            { typeof(CODetailsViewResult), "1002" },
            { typeof(MaterialsReturnOrderViewResult), "0004" },
            { typeof(MRODetailsViewResult), "1004" },
            { typeof(TransferOrderViewResult), "0005" },
            { typeof(TODetailsViewResult), "1005" },
            { typeof(StocktakingListViewResult), "0006" },
            { typeof(SLDetailsViewResult), "1006" },
            { typeof(BillViewResult), "0007" },
            { typeof(BillDetailsViewResult), "1007" },
            { typeof(MonthlyReportViewResult), "0008" },
            { typeof(MReportDetailsViewResult), "1008" },
            { typeof(StartOfTermViewResult), "0009" },
        };
    }
}