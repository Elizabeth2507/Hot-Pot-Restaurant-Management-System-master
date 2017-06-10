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
    public class CategoryService : DataService, IDataService<Category>
    {
        
        public List<Category> Query(QueryConditions queryConditions, out int totalCount)
        {
            return Query<Category>(queryConditions, out totalCount);
        }

        
        public DBResult Add(Category entity)
        {
            return Add<Category>(entity, new string[] { "ID", "SuperiorID" }, new string[] { "ShortID", "Name" });
        }

        
        public DBResult Edit(Category entity)
        {
            return Edit<Category>(entity, new string[] { "SuperiorID" }, new string[] { "ShortID", "Name" });
        }

        
        public DBResult EditAll(List<Category> entities)
        {
            return EditAll<Category>(entities, new string[] { "SuperiorID" }, new string[] { "ShortID", "Name" });
        }

        
        public DBResult Delete(Category entity)
        {
            return Delete<Category>(entity);
        }

        
        public DBResult DeleteAll(List<Category> entities)
        {
            return DeleteAll<Category>(entities);
        }

        
        public DBResult Delete(int id)
        {
            return Delete<Category, int>(id);
        }

        
        public DBResult DeleteAll(List<int> list)
        {
            return DeleteAll<Category, int>(list);
        }
    }
}