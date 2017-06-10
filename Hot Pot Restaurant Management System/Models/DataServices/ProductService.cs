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
    public class ProductService : DataService, IDataService<Product>
    {
        
        public List<Product> Query(QueryConditions queryConditions, out int totalCount)
        {
            return Query<Product>(queryConditions, out totalCount);
        }

        
        public DBResult Add(Product entity)
        {
            return Add<Product>(entity, new string[] { "ID" }, new string[] { "ShortID", "Name", "ShortName" });
        }

        
        public DBResult Edit(Product entity)
        {
            return Edit<Product>(entity, null, new string[] { "ShortID", "Name", "ShortName" });
        }

        
        public DBResult EditAll(List<Product> entities)
        {
            return EditAll<Product>(entities, null, new string[] { "ShortID", "Name", "ShortName" });
        }

        
        public DBResult Delete(Product entity)
        {
            return Delete<Product>(entity);
        }

        
        public DBResult DeleteAll(List<Product> entities)
        {
            return DeleteAll<Product>(entities);
        }

        
        public DBResult Delete(int id)
        {
            return Delete<Product, int>(id);
        }

        
        public DBResult DeleteAll(List<int> list)
        {
            return DeleteAll<Product, int>(list);
        }
    }
}