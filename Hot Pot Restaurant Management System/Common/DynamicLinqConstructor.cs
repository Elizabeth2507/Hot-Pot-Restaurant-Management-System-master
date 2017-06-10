using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Common
{
    public class DynamicLinqConstructor
    {
        //v=>v.property
        public static Expression<Func<T, S>> PropertySelect<T, S>(string propertyName)
        {
            var para = Expression.Parameter(typeof(T), "para");
            var body = Expression.Convert(Expression.Property(para, propertyName), typeof(S));
            return Expression.Lambda<Func<T, S>>(body, para);
        }

        //v=>v.property == queryValue
        public static Expression<Func<T,bool>> PropertyEqual<T>( string propertyName, object queryValue)
        {
            var para = Expression.Parameter(typeof(T), "para");
            var body = Expression.Equal(
                Expression.Convert(Expression.Property(para, propertyName), queryValue.GetType()),
                Expression.Constant(queryValue));
            return Expression.Lambda<Func<T, bool>>(body, para);
        }

        //v=>v.property != queryValue
        public static Expression<Func<T, bool>> PropertyNotEqual<T>(string propertyName, object queryValue)
        {
            var para = Expression.Parameter(typeof(T), "para");
            var body = Expression.NotEqual(
                Expression.Convert(Expression.Property(para, propertyName), queryValue.GetType()), 
                Expression.Constant(queryValue));
            return Expression.Lambda<Func<T, bool>>(body, para);
        }

        //v=>v.property.contains((string)queryValue)
        public static Expression<Func<T, bool>> PropertyContains<T>(string propertyName, string queryValue)
        {
            var para = Expression.Parameter(typeof(T), "para");
            var body = Expression.Call(
                Expression.Property(para, propertyName),
                typeof(string).GetMethod("Contains", new Type[] { typeof(string) }),
                Expression.Constant(queryValue));
            return Expression.Lambda<Func<T, bool>>(body, para);
        }

        //v=>v.property >= (int)queryValue
        public static Expression<Func<T, bool>> PropertyGreaterThan<T>(string propertyName, object queryValue)
        {
            var para = Expression.Parameter(typeof(T), "para");
            var body = Expression.GreaterThanOrEqual(
                Expression.Convert(Expression.Property(para, propertyName), queryValue.GetType()),                
                Expression.Constant(queryValue));
            return Expression.Lambda<Func<T, bool>>(body, para);
        }

        //v=>v.property <= (int)queryValue
        public static Expression<Func<T, bool>> PropertySmallerThan<T>(string propertyName, object queryValue)
        {
            var para = Expression.Parameter(typeof(T), "para");
            var body = Expression.GreaterThanOrEqual(
                Expression.Constant(queryValue),
                Expression.Convert(Expression.Property(para, propertyName), queryValue.GetType()));
            return Expression.Lambda<Func<T, bool>>(body, para);
        }

        //propertyMax, propertyMin
        public static Expression<Func<T, bool>> PropertyBetween<T>(string propertyName, object queryValue)
        {
            if (propertyName.Contains("Min"))
                return PropertyGreaterThan<T>(propertyName.Remove(propertyName.Length - 3), queryValue);

            else if (propertyName.Contains("Max"))
                return PropertySmallerThan<T>(propertyName.Remove(propertyName.Length - 3), queryValue);

            else
                return PropertyEqual<T>(propertyName, queryValue);
        }
    }
}