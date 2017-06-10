using Hot_Pot_Restaurant_Management_System.Common;
using Hot_Pot_Restaurant_Management_System.Models.Entities;
using Hot_Pot_Restaurant_Management_System.Models.QueryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.DataServices
{
    public class VBillService : DataService
    {
        
        public List<VBill> Query(QueryConditions queryConditions, out int totalCount)
        {
            return Query<VBill>(queryConditions, out totalCount);
        }

        
        public List<VBill> QueryServing(int tableID)
        {
            using (var db = new FrontDeskEntities())
            {
                var servingTable = db.ServingTable.FirstOrDefault(t => t.ID == tableID);
                if (servingTable == null)
                    return null;

                return db.VBill.Where(b => b.BillID == servingTable.BillID).ToList();
            }
        }
    }
}