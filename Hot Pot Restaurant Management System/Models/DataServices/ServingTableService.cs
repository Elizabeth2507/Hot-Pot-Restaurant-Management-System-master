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
    public class ServingTableService : DataService, IDataService<ServingTable>
    {
        
        public List<ServingTable> Query(QueryConditions queryConditions, out int totalCount)
        {
            return Query<ServingTable>(queryConditions, out totalCount);
        }

        
        public DBResult Add(ServingTable entity)
        {
            return Add<ServingTable>(entity, null, new string[] { "ID", "BillID" });
        }

        
        public DBResult Edit(ServingTable entity)
        {
            return Edit<ServingTable>(entity, null, new string[] { "ID" });
        }

        
        public DBResult EditAll(List<ServingTable> entities)
        {
            return EditAll<ServingTable>(entities, null, new string[] { "ID" });
        }

        
        public DBResult Delete(ServingTable entity)
        {
            return Delete<ServingTable>(entity);
        }

        
        public DBResult DeleteAll(List<ServingTable> entities)
        {
            return DeleteAll<ServingTable>(entities);
        }

        
        public DBResult Delete(int id)
        {
            return Delete<ServingTable, int>(id);
        }

        
        public DBResult DeleteAll(List<int> list)
        {
            return DeleteAll<ServingTable, int>(list);
        }
    }
}