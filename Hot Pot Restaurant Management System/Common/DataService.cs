using Hot_Pot_Restaurant_Management_System.Common.Dictionaries;
using Hot_Pot_Restaurant_Management_System.Common.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Common
{
    public class DataService
    {
        
        protected IQueryable<T> SetQuery<T>(DbSet<T> dbSet, QueryConditions queryConditions, out int totalCount)
            where T : class
        {
            totalCount = 0;

            var query = dbSet.AsQueryable();
            var queryProperties = queryConditions.GetType().GetProperties();

            string orderByName = queryConditions.OrderBy;
            string orderByDescendingName = queryConditions.OrderByDescending;

            query = SetQueryOnly(query, queryConditions, out totalCount);
            
            if (!string.IsNullOrEmpty(orderByName))
            {
                var orderProperty = queryProperties.FirstOrDefault(p => p.Name.ToLower() == orderByName.ToLower());
                var orderPropertyName = orderProperty.Name;
                var orderPropertyType = orderProperty.PropertyType;

                query = SetOrder(query, orderPropertyName, orderPropertyType, false);
            }
            else if (!string.IsNullOrEmpty(orderByDescendingName))
            {
                var orderProperty = queryProperties.FirstOrDefault(p => p.Name.ToLower() == orderByDescendingName.ToLower());
                var orderPropertyName = orderProperty.Name;
                var orderPropertyType = orderProperty.PropertyType;

                query = SetOrder<T>(query, orderPropertyName, orderPropertyType, true);
            }

            if (!string.IsNullOrEmpty(orderByName) || !string.IsNullOrEmpty(orderByDescendingName))
            {
                int? pageIndex = (int?)queryProperties.FirstOrDefault(p => p.Name == "PageIndex").GetValue(queryConditions);
                int? pageSize = (int?)queryProperties.FirstOrDefault(p => p.Name == "PageSize").GetValue(queryConditions);

                query = SetPagination<T>(query, pageIndex, pageSize);
            }

            return query;
        }

        
        protected IQueryable<T> SetQueryOnly<T>(IQueryable<T> query, QueryConditions queryConditions, out int totalCount)
            where T : class
        {
            totalCount = 0;

            var queryProperties = queryConditions.GetType().GetProperties()
                .Where(p => p.Name != "PageIndex" && p.Name != "PageSize" && p.Name != "OrderBy" && p.Name != "OrderByDescending").ToArray();

            foreach (var queryProperty in queryProperties)
            {
                if (queryConditions.IgnoredProperties != null && queryConditions.IgnoredProperties.Contains(queryProperty.Name))
                    continue;

                var queryValue = queryProperty.GetValue(queryConditions);
                var queryType = queryProperty.PropertyType;

                if (queryType == typeof(bool))
                {
                    var lambda = DynamicLinqConstructor.PropertyEqual<T>(queryProperty.Name, queryValue);
                    query = query.Where(lambda);
                }
                else if (queryType.IsGenericType && queryType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    if (queryValue == null)
                        continue;

                    var typedValue = Convert.ChangeType(queryValue, queryType.GetGenericArguments()[0]);

                    var lambda = DynamicLinqConstructor.PropertyBetween<T>(queryProperty.Name, typedValue);
                    query = query.Where(lambda);
                }
                else if (queryType.IsValueType && !queryValue.Equals(Activator.CreateInstance(queryType)))
                {
                    var lambda = DynamicLinqConstructor.PropertyBetween<T>(queryProperty.Name, queryValue);
                    query = query.Where(lambda);
                }
                else if (queryType == typeof(string) && !string.IsNullOrEmpty((string)queryValue))
                {
                    var lambda = DynamicLinqConstructor.PropertyContains<T>(queryProperty.Name, (string)queryValue);
                    query = query.Where(lambda);
                }
            }

            totalCount = query.Count();
            return query;
        }

        
        protected IQueryable<T> SetOrder<T>(IQueryable<T> query, string orderPropertyName, Type orderPropertyType, bool isDescending)
            where T : class
        {
            if (!isDescending)
            {
                if (orderPropertyType == typeof(int))
                {
                    var lambda = DynamicLinqConstructor.PropertySelect<T, int>(orderPropertyName);
                    query = query.OrderBy(lambda);
                }
                else if (orderPropertyType == typeof(decimal))
                {
                    var lambda = DynamicLinqConstructor.PropertySelect<T, decimal>(orderPropertyName);
                    query = query.OrderBy(lambda);
                }
                else if (orderPropertyType == typeof(DateTime))
                {
                    var lambda = DynamicLinqConstructor.PropertySelect<T, DateTime>(orderPropertyName);
                    query = query.OrderBy(lambda);
                }
                else if (orderPropertyType == typeof(string))
                {
                    var lambda = DynamicLinqConstructor.PropertySelect<T, string>(orderPropertyName);
                    query = query.OrderBy(lambda);
                }
                else if (orderPropertyType == typeof(Nullable<int>))
                {
                    var lambda = DynamicLinqConstructor.PropertySelect<T, Nullable<int>>(orderPropertyName);
                    query = query.OrderBy(lambda);
                }
                else if (orderPropertyType == typeof(Nullable<decimal>))
                {
                    var lambda = DynamicLinqConstructor.PropertySelect<T, Nullable<decimal>>(orderPropertyName);
                    query = query.OrderBy(lambda);
                }
            }
            else
            {
                if (orderPropertyType == typeof(int))
                {
                    var lambda = DynamicLinqConstructor.PropertySelect<T, int>(orderPropertyName);
                    query = query.OrderByDescending(lambda);
                }
                else if (orderPropertyType == typeof(decimal))
                {
                    var lambda = DynamicLinqConstructor.PropertySelect<T, decimal>(orderPropertyName);
                    query = query.OrderByDescending(lambda);
                }
                else if (orderPropertyType == typeof(DateTime))
                {
                    var lambda = DynamicLinqConstructor.PropertySelect<T, DateTime>(orderPropertyName);
                    query = query.OrderByDescending(lambda);
                }
                else if (orderPropertyType == typeof(string))
                {
                    var lambda = DynamicLinqConstructor.PropertySelect<T, string>(orderPropertyName);
                    query = query.OrderByDescending(lambda);
                }
                else if (orderPropertyType == typeof(Nullable<int>))
                {
                    var lambda = DynamicLinqConstructor.PropertySelect<T, Nullable<int>>(orderPropertyName);
                    query = query.OrderByDescending(lambda);
                }
                else if (orderPropertyType == typeof(Nullable<decimal>))
                {
                    var lambda = DynamicLinqConstructor.PropertySelect<T, Nullable<decimal>>(orderPropertyName);
                    query = query.OrderByDescending(lambda);
                }
            }

            return query;
        }

        
        protected IQueryable<T> SetPagination<T>(IQueryable<T> query, int? pageIndex, int? pageSize)
            where T : class
        {
            if (pageIndex == null || pageSize == null || pageIndex < 1 || pageSize < 1)
                return query;

            int index = pageIndex.Value;
            int size = pageSize.Value;
            int startRow = (index - 1) * size;

            query = query.Skip(startRow).Take(size);

            return query;
        }

        
        protected DBResult CheckExists<T>(DbSet<T> dbSet, string[] propertyNames, T entity, bool excludeSelf = false)
            where T : class
        {
            if (dbSet == null)
                return DBResult.WrongParameter;

            if (propertyNames == null)
                return DBResult.Succeed;

            if (entity == null)
                return DBResult.WrongParameter;

            var query = dbSet.AsQueryable();
            var properties = entity.GetType().GetProperties();
            
            if (excludeSelf)
            {
                var entityID = EntityHelper.GetEntityID(entity);
                if (entityID != null)
                {
                    var Lambda = DynamicLinqConstructor.PropertyNotEqual<T>("ID", entityID);
                    query = dbSet.Where(Lambda);
                }
            }

            foreach (var propertyName in propertyNames)
            {
                var property = properties.FirstOrDefault(p => p.Name == propertyName);
                if (property == null)
                    continue;

                var objectValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                var propertyValue = Convert.ChangeType(objectValue, propertyType);

                var Lambda = DynamicLinqConstructor.PropertyEqual<T>(propertyName, propertyValue);
                if (query.Any(Lambda))
                {
                    var result = DBDictionary.ExistsDictionary.FirstOrDefault(i => i.Key == propertyName);
                    if (string.IsNullOrEmpty(result.Key))
                        return DBResult.PropertyValueExisted;

                    return result.Value;
                }
            }

            return DBResult.Succeed;
        }

        
        protected object GetDbContext(string contextName)
        {
            return Activator.CreateInstance(Type.GetType("Hot_Pot_Restaurant_Management_System.Models.Entities." + contextName));
        }

        
        protected List<T> Query<T>(QueryConditions queryConditions, out int totalCount)
            where T : class
        {
            var result = new List<T>();
            totalCount = 0;

            var contextName = DBDictionary.DBEntitiesDictionary.FirstOrDefault(i => i.Value.Contains(typeof(T))).Key;
            if (string.IsNullOrEmpty(contextName))
                return result;

            using (var db = (DbContext)GetDbContext(contextName))
            {
                var dbSet = db.Set<T>();
                return SetQuery(dbSet, queryConditions, out totalCount).ToList();
            }
        }

        
        protected DBResult Add<T>(T entity, string[] ignoreNullCheck, string[] checkExists)
            where T : class
        {
            if (EntityHelper.HasNullProperty(entity, ignoreNullCheck))
                return DBResult.WrongParameter;

            var contextName = DBDictionary.DBEntitiesDictionary.FirstOrDefault(i => i.Value.Contains(typeof(T))).Key;
            if (string.IsNullOrEmpty(contextName))
                return DBResult.Unknown;

            using (var db = (DbContext)GetDbContext(contextName))
            {
                var dbSet = db.Set<T>();

                var existResult = CheckExists(dbSet, checkExists, entity);
                if (existResult != DBResult.Succeed)
                    return existResult;

                dbSet.Add(entity);
                db.SaveChanges();
                return DBResult.Succeed;
            }
        }

        
        protected DBResult Edit<T>(T entity, string[] ignoreNullCheck = null, string[] checkExists = null)
            where T : class
        {
            if (EntityHelper.HasNullProperty(entity, ignoreNullCheck))
                return DBResult.WrongParameter;

            var contextName = DBDictionary.DBEntitiesDictionary.FirstOrDefault(i => i.Value.Contains(typeof(T))).Key;
            if (string.IsNullOrEmpty(contextName))
                return DBResult.Unknown;

            using (var db = (DbContext)GetDbContext(contextName))
            {
                var dbSet = db.Set<T>();

                var lambda = DynamicLinqConstructor.PropertyEqual<T>("ID", EntityHelper.GetEntityID(entity));
                var target = dbSet.FirstOrDefault(lambda);
                if (target == null)
                    return DBResult.NotFound;

                var existResult = CheckExists(dbSet, checkExists, entity, true);
                if (existResult != DBResult.Succeed)
                    return existResult;

                EntityHelper.CopyEntity(entity, target);
                db.SaveChanges();
                return DBResult.Succeed;
            }
        }

        
        protected DBResult EditAll<T>(List<T> entities, string[] ignoreNullCheck = null, string[] checkExists = null)
            where T : class
        {
            if (entities == null)
                return DBResult.WrongParameter;

            var contextName = DBDictionary.DBEntitiesDictionary.FirstOrDefault(i => i.Value.Contains(typeof(T))).Key;
            if (string.IsNullOrEmpty(contextName))
                return DBResult.Unknown;

            using (var db = (DbContext)GetDbContext(contextName))
            {
                var dbSet = db.Set<T>();
                foreach (var entity in entities)
                {
                    if (EntityHelper.HasNullProperty(entity, ignoreNullCheck))
                        return DBResult.WrongParameter;

                    var lambda = DynamicLinqConstructor.PropertyEqual<T>("ID", EntityHelper.GetEntityID(entity));
                    var target = dbSet.FirstOrDefault(lambda);
                    if (target == null)
                        return DBResult.NotFound;

                    var existResult = CheckExists(dbSet, checkExists, entity, true);
                    if (existResult != DBResult.Succeed)
                        return existResult;

                    EntityHelper.CopyEntity(entity, target);
                }

                db.SaveChanges();
                return DBResult.Succeed;
            }
        }

        
        protected DBResult Delete<T>(T entity)
            where T : class
        {
            var entityID = EntityHelper.GetEntityID(entity);
            bool isValueType = entityID.GetType().IsValueType;

            if (entity == null || (isValueType && (int)entityID == 0) || (!isValueType && string.IsNullOrEmpty((string)entityID)))
                return DBResult.WrongParameter;

            var contextName = DBDictionary.DBEntitiesDictionary.FirstOrDefault(i => i.Value.Contains(typeof(T))).Key;
            if (string.IsNullOrEmpty(contextName))
                return DBResult.Unknown;

            using (var db = (DbContext)GetDbContext(contextName))
            {
                var dbSet = db.Set<T>();

                var lambda = DynamicLinqConstructor.PropertyEqual<T>("ID", entityID);
                var target = dbSet.FirstOrDefault(lambda);
                if (target == null)
                    return DBResult.NotFound;

                dbSet.Remove(target);
                db.SaveChanges();
                return DBResult.Succeed;
            }
        }

        
        protected DBResult DeleteAll<T>(List<T> entities)
            where T : class
        {
            if (entities == null)
                return DBResult.WrongParameter;

            var contextName = DBDictionary.DBEntitiesDictionary.FirstOrDefault(i => i.Value.Contains(typeof(T))).Key;
            if (string.IsNullOrEmpty(contextName))
                return DBResult.Unknown;
            
            using (var db = (DbContext)GetDbContext(contextName))
            {
                var dbSet = db.Set<T>();
                foreach (var entity in entities)
                {
                    var entityID = EntityHelper.GetEntityID(entity);
                    bool isValueType = entityID.GetType().IsValueType;

                    if ((isValueType && (int)entityID == 0) || (!isValueType && string.IsNullOrEmpty((string)entityID)))
                        return DBResult.WrongParameter;

                    var lambda = DynamicLinqConstructor.PropertyEqual<T>("ID", EntityHelper.GetEntityID(entity));
                    var target = dbSet.FirstOrDefault(lambda);
                    if (target == null)
                        return DBResult.NotFound;

                    dbSet.Remove(target);
                }

                db.SaveChanges();
                return DBResult.Succeed;
            }
        }

        
        protected DBResult Delete<T, S>(S id)
            where T : class, new()
        {
            var entity = new T();

            var entityID = typeof(T).GetProperty("ID");
            if (entityID == null)
                return DBResult.Unknown;

            entityID.SetValue(entity, id);
            return Delete<T>(entity);
        }

        
        protected DBResult DeleteAll<T, S>(List<S> list)
            where T : class, new()
        {
            var entities = new List<T>();
            foreach (var id in list)
            {
                var entity = new T();

                var entityID = typeof(T).GetProperty("ID");
                if (entityID == null)
                    return DBResult.Unknown;

                entityID.SetValue(entity, id);
                entities.Add(entity);
            }

            return DeleteAll(entities);
        }
    }
}