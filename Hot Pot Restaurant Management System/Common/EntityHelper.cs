using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Common
{
    public class EntityHelper
    {
        
        public static T CopyEntity<S, T>(S source, T target, string[] ignoredProperties = null)
        {
            if (source == null || target == null)
                return target;

            var sProperties = source.GetType().GetProperties();
            var tProperties = target.GetType().GetProperties();

            foreach (var tProperty in tProperties)
            {
                if (ignoredProperties != null && ignoredProperties.Contains(tProperty.Name))
                    continue;

                var sProperty = sProperties.FirstOrDefault(s => s.Name == tProperty.Name && s.PropertyType == tProperty.PropertyType);
                if (sProperty != null)
                    tProperty.SetValue(target, sProperty.GetValue(source));
            }

            return target;
        }

        /
        public static List<T> CopyEntities<T, S>(List<S> source, List<T> target, string[] ignoredProperties = null)
            where T : new()
        {
            if (source == null || target == null)
                return target;

            foreach (var s in source)
            {
                T t = new T();
                CopyEntity(s, t, ignoredProperties);
                target.Add(t);
            }

            return target;
        }

        
        public static bool HasNullProperty(object entity, string[] ignoredProperties = null)
        {
            if (entity == null)
                return true;

            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (ignoredProperties != null && ignoredProperties.Contains(property.Name))
                    continue;

                Type propertyType = property.PropertyType;
                if (property.GetValue(entity) == null)
                    return true;
                else if (propertyType.IsValueType && property.GetValue(entity).Equals(Activator.CreateInstance(propertyType)))
                    return true;
            }

            return false;
        }

        
        public static object GetEntityID(object entity)
        {
            var propertyID = entity.GetType().GetProperty("ID");
            if (propertyID == null)
                return null;

            return propertyID.GetValue(entity);
        }

        
        public static void SetEntityID(object entity, object id)
        {
            var propertyID = entity.GetType().GetProperty("ID");
            if (propertyID == null)
                return;

            propertyID.SetValue(entity, id);
        }

        
        public static object GetPropertyValue(object entity, string propertyName)
        {
            var property = entity.GetType().GetProperty(propertyName);
            if (property == null)
                return null;

            return property.GetValue(entity);
        }

        
        public static void SetPropertyValue(object entity, string propertyName, object value)
        {
            var property = entity.GetType().GetProperty(propertyName);
            if (property == null)
                return;

            property.SetValue(entity, value);
        }
    }
}