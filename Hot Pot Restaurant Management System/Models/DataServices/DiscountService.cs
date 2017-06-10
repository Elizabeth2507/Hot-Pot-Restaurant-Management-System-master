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
    public class DiscountService : DataService, IDataService<Discount>
    {
        
        public List<Discount> Query(QueryConditions queryConditions, out int totalCount)
        {
            return Query<Discount>(queryConditions, out totalCount);
        }

        
        public DBResult Add(Discount entity)
        {
            return Add<Discount>(entity, new string[] { "ID", "IgnoredCategories","IsMemberOnly" }, new string[] { "Description" });
        }

        
        public DBResult Edit(Discount entity)
        {
            return Edit<Discount>(entity, new string[] { "IgnoredCategories", "IsMemberOnly" }, new string[] { "Description" });
        }

        
        public DBResult EditAll(List<Discount> entities)
        {
            return EditAll<Discount>(entities, new string[] { "IgnoredCategories", "IsMemberOnly" }, new string[] { "Description" });
        }

        
        public DBResult Delete(Discount entity)
        {
            return Delete<Discount>(entity);
        }

        
        public DBResult DeleteAll(List<Discount> entities)
        {
            return DeleteAll<Discount>(entities);
        }

        
        public DBResult Delete(int id)
        {
            return Delete<Discount, int>(id);
        }

        
        public DBResult DeleteAll(List<int> list)
        {
            return DeleteAll<Discount, int>(list);
        }
    }
}