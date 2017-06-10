using Hot_Pot_Restaurant_Management_System.Common;
using Hot_Pot_Restaurant_Management_System.Common.Enums;
using Hot_Pot_Restaurant_Management_System.Common.Interfaces;
using Hot_Pot_Restaurant_Management_System.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.DataServices
{
    public class BillService : DataService, IDataService<Bill>
    {
        
        public List<Bill> Query(QueryConditions queryConditions, out int totalCount)
        {
            return Query<Bill>(queryConditions, out totalCount);
        }

        
        public DBResult Add(Bill entity)
        {
            return Add<Bill>(entity,
                new string[] { "Discount", "DiscountType", "Remark", "MemberID", "TotalCost", "ExactCost", "ReceivedMoney", "Change" }, new string[] { "ID" });
        }

        
        public DBResult Edit(Bill entity)
        {
            return Edit<Bill>(entity,
                new string[] { "Discount", "DiscountType", "Remark", "MemberID", "TotalCost", "ExactCost", "ReceivedMoney", "Change" }, new string[] { "ID" });
        }

        
        public DBResult EditAll(List<Bill> entities)
        {
            return EditAll<Bill>(entities,
                new string[] { "Discount", "DiscountType", "Remark", "MemberID", "TotalCost", "ExactCost", "ReceivedMoney", "Change" }, new string[] { "ID" });
        }

        
        public DBResult Delete(Bill entity)
        {
            return Delete<Bill>(entity);
        }

        
        public DBResult DeleteAll(List<Bill> entities)
        {
            return DeleteAll<Bill>(entities);
        }


        public DBResult Delete(int id)
        {
            return Delete<Bill, int>(id);
        }

        
        public DBResult DeleteAll(List<int> list)
        {
            return DeleteAll<Bill, int>(list);
        }
    }
}