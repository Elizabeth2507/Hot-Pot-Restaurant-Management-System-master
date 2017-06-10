using Hot_Pot_Restaurant_Management_System.Common;
using Hot_Pot_Restaurant_Management_System.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hot_Pot_Restaurant_Management_System.Common.Enums;
using Hot_Pot_Restaurant_Management_System.Common.Interfaces;

namespace Hot_Pot_Restaurant_Management_System.Models.DataServices
{
    public class WarehouseService : DataService, IDataService<Warehouse>
    {
        
        public List<Warehouse> Query(QueryConditions queryConditions, out int totalCount)
        {
            return Query<Warehouse>(queryConditions, out totalCount);
        }

        
        public DBResult Add(Warehouse entity)
        {
            return Add<Warehouse>(entity, new string[] { "ID" }, new string[] { "ShortID", "Name" });
        }

        
        public DBResult Edit(Warehouse entity)
        {
            return Edit<Warehouse>(entity, null, new string[] { "ShortID", "Name" });
        }

        
        public DBResult EditAll(List<Warehouse> entities)
        {
            return EditAll<Warehouse>(entities, null, new string[] { "ShortID", "Name" });
        }

        
        public DBResult Delete(Warehouse entity)
        {
            return Delete<Warehouse>(entity);
        }

        
        public DBResult DeleteAll(List<Warehouse> entities)
        {
            return DeleteAll<Warehouse>(entities);
        }

        
        public DBResult Delete(int id)
        {
            return Delete<Warehouse, int>(id);
        }

        
        public DBResult DeleteAll(List<int> list)
        {
            return DeleteAll<Warehouse, int>(list);
        }
    }
}