using Hot_Pot_Restaurant_Management_System.Common;
using Hot_Pot_Restaurant_Management_System.Common.Dictionaries;
using Hot_Pot_Restaurant_Management_System.Common.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.DataServices.FastQueryServices
{
    public class FastQueryService : DataService
    {
        
        protected List<T> FastQuery<T>(string queryText)
            where T : class
        {
            if (string.IsNullOrEmpty(queryText))
                return null;

            var contextName = DBDictionary.DBEntitiesDictionary.FirstOrDefault(i => i.Value.Contains(typeof(T))).Key;
            if (string.IsNullOrEmpty(contextName))
                return null;

            using (var db = (DbContext)GetDbContext(contextName))
            {
                var dbSet = db.Set<T>();
                return CustomQuery<T>(dbSet, queryText);
            }
        }

        
        public virtual List<T> CustomQuery<T>(DbSet<T> dbSet, string queryText)
            where T : class
        {
            var results = new List<T>();

            results = IntFastQuery(dbSet, queryText);
            if (results != null && results.Count() != 0)
                return results;

            results = StringFastQuery(dbSet, queryText);
            if (results != null && results.Count() != 0)
                return results;

            return StringFastQuery(dbSet, queryText, "Name");
        }

        
        public List<T> IntFastQuery<T>(DbSet<T> dbSet, string queryText, string propertyName = "ShortID")
            where T : class
        {
            int queryTextInt = 0;
            if (!int.TryParse(queryText, out queryTextInt))
                return null;

            var lambda = DynamicLinqConstructor.PropertyEqual<T>(propertyName, queryTextInt);
            return dbSet.Where(lambda).ToList();
        }

        
        protected List<T> StringFastQuery<T>(DbSet<T> dbSet, string queryText, string propertyName = "ShortName")
            where T : class
        {
            var lambda = DynamicLinqConstructor.PropertyContains<T>(propertyName, queryText);
            return dbSet.Where(lambda).ToList();
        }
    }
}