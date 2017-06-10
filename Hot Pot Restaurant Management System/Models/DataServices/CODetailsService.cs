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
    public class CODetailsService : DataService, IDataService<CODetails>
    {
        
        public List<CODetails> Query(QueryConditions queryConditions, out int totalCount)
        {
            return Query<CODetails>(queryConditions, out totalCount);
        }

        
        public DBResult Add(CODetails entity)
        {
            return Add<CODetails>(entity, new string[] { "Price" }, new string[] { "ID" });
        }

        
        public DBResult Edit(CODetails entity)
        {
            return Edit<CODetails>(entity, new string[] { "Price" }, new string[] { "ID" });
        }

        
        public DBResult EditAll(List<CODetails> entities)
        {
            return EditAll<CODetails>(entities, new string[] { "Price" }, new string[] { "ID" });
        }

        
        public DBResult Delete(CODetails entity)
        {
            return Delete<CODetails>(entity);
        }

        
        public DBResult DeleteAll(List<CODetails> entities)
        {
            return DeleteAll<CODetails>(entities);
        }

        
        public DBResult Delete(int id)
        {
            return Delete<CODetails, int>(id);
        }

        
        public DBResult DeleteAll(List<int> list)
        {
            return DeleteAll<CODetails, int>(list);
        }
    }
}