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
    public class InventoryListService : DataService, IDataService<InventoryList>
    {
        
        public List<InventoryList> Query(QueryConditions queryConditions, out int totalCount)
        {
            return Query<InventoryList>(queryConditions, out totalCount);
        }

        
        public DBResult Add(InventoryList entity)
        {
            if (EntityHelper.HasNullProperty(entity))
                return DBResult.WrongParameter;

            using (var db = new WarehouseEntities())
            {
                if (db.InventoryList.Any(l => l.POID == entity.POID))
                    return Edit(entity);

                db.InventoryList.Add(entity);
                db.SaveChanges();
                return DBResult.Succeed;
            }
        }

        
        public DBResult Edit(InventoryList entity)
        {
            if (EntityHelper.HasNullProperty(entity))
                return DBResult.WrongParameter;

            using (var db = new WarehouseEntities())
            {
                var inventoryList = db.InventoryList.FirstOrDefault(l => l.POID == entity.POID);
                if (inventoryList == null)
                    return DBResult.NotFound;

                EntityHelper.CopyEntity(entity, inventoryList);
                db.SaveChanges();
                return DBResult.Succeed;
            }
        }

        
        public DBResult EditAll(List<InventoryList> entities)
        {
            if (entities == null)
                return DBResult.WrongParameter;

            using (var db = new WarehouseEntities())
            {
                foreach (var entity in entities)
                {
                    if (EntityHelper.HasNullProperty(entity))
                        return DBResult.WrongParameter;

                    var inventoryList = db.InventoryList.FirstOrDefault(l => l.POID == entity.POID);
                    if (inventoryList == null)
                        return DBResult.NotFound;

                    EntityHelper.CopyEntity(entity, inventoryList);
                }

                db.SaveChanges();
                return DBResult.Succeed;
            }
        }

        
        public DBResult Delete(InventoryList entity)
        {
            if (entity == null || string.IsNullOrEmpty(entity.POID))
                return DBResult.WrongParameter;

            using (var db = new WarehouseEntities())
            {
                var inventoryList = db.InventoryList.FirstOrDefault(l => l.POID == entity.POID);
                if (inventoryList == null)
                    return DBResult.NotFound;

                db.InventoryList.Remove(inventoryList);
                db.SaveChanges();
                return DBResult.Succeed;
            }
        }

        
        public DBResult DeleteAll(List<InventoryList> entities)
        {
            if (entities == null)
                return DBResult.WrongParameter;

            using (var db = new WarehouseEntities())
            {
                foreach (var entity in entities)
                {
                    if (string.IsNullOrEmpty(entity.POID))
                        return DBResult.WrongParameter;

                    var inventoryList = db.InventoryList.FirstOrDefault(l => l.POID == entity.POID);
                    if (inventoryList == null)
                        return DBResult.NotFound;

                    db.InventoryList.Remove(inventoryList);
                }

                db.SaveChanges();
                return DBResult.Succeed;
            }
        }

        
        public DBResult Delete(int id)
        {
            var entity = new InventoryList { POID = id.ToString() };
            return Delete(entity);
        }

        
        public DBResult DeleteAll(List<int> list)
        {
            List<InventoryList> entities = new List<InventoryList>();
            foreach (var id in list)
            {
                var entity = new InventoryList { POID = id.ToString() };
                entities.Add(entity);
            }

            return DeleteAll(entities);
        }
    }
}