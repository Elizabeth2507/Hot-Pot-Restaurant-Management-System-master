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
    public class PODetailsService : DataService, IDataService<PODetails>
    {
        
        public List<PODetails> Query(QueryConditions queryConditions, out int totalCount)
        {
            return Query<PODetails>(queryConditions, out totalCount);
        }

        
        public DBResult Add(PODetails entity)
        {
            return Add<PODetails>(entity, new string[] { "Price" }, new string[] { "ID" });
        }

        
        public DBResult Edit(PODetails entity)
        {
            return Edit<PODetails>(entity, new string[] { "Price" }, new string[] { "ID" });
        }

        
        public DBResult EditAll(List<PODetails> entities)
        {
            return EditAll<PODetails>(entities, new string[] { "Price" }, new string[] { "ID" });
        }

        
        public DBResult Delete(PODetails entity)
        {
            return Delete<PODetails>(entity);
        }

        
        public DBResult DeleteAll(List<PODetails> entities)
        {
            return DeleteAll<PODetails>(entities);
        }

        
        public DBResult Delete(int id)
        {
            return Delete<PODetails, int>(id);
        }

        
        public DBResult DeleteAll(List<int> list)
        {
            return DeleteAll<PODetails, int>(list);
        }
    }
}