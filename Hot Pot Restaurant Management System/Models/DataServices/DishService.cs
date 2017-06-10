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
    public class DishService : DataService, IDataService<Dish>
    {
        
        public List<Dish> Query(QueryConditions queryConditions, out int totalCount)
        {
            return Query<Dish>(queryConditions, out totalCount);
        }

        
        public DBResult Add(Dish entity)
        {
            if (!CheckInventoryControl(entity))
                return DBResult.NotFound;
            
            return Add<Dish>(entity, new string[] { "ID", "Image", "Description", "UnitConversion", "PriceEditable", "InventoryControl" }, new string[] { "ShortID", "Name", "ShortName" });
        }

        
        public DBResult Edit(Dish entity)
        {
            if (!CheckInventoryControl(entity))
                return DBResult.NotFound;

            return Edit<Dish>(entity, new string[] { "Image", "Description", "UnitConversion", "PriceEditable", "InventoryControl" }, new string[] { "ShortID", "Name", "ShortName" });
        }

        
        public DBResult EditAll(List<Dish> entities)
        {
            foreach (var entity in entities)
            {
                if (!CheckInventoryControl(entity))
                    return DBResult.NotFound;
            }

            return EditAll<Dish>(entities, new string[] { "Image", "Description", "UnitConversion", "PriceEditable", "InventoryControl" }, new string[] { "ShortID", "Name", "ShortName" });
        }

        
        public DBResult Delete(Dish entity)
        {
            return Delete<Dish>(entity);
        }

        
        public DBResult DeleteAll(List<Dish> entities)
        {
            return DeleteAll<Dish>(entities);
        }

        
        public DBResult Delete(int id)
        {
            return Delete<Dish, int>(id);
        }

        
        public DBResult DeleteAll(List<int> list)
        {
            return DeleteAll<Dish, int>(list);
        }

        
        private bool CheckInventoryControl(Dish entity)
        {
            if (!entity.InventoryControl)
                return true;

            using (var db = new WarehouseEntities())
            {
                if (db.Product.Any(p => p.Name == entity.Name))
                    return true;

                return false;
            }
        }
    }
}