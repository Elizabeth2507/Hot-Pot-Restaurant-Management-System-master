using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Common
{
    public class QueryConditions
    {
        
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        
        public string OrderBy { get; set; }
        public string OrderByDescending { get; set; }

        
        public string[] IgnoredProperties { get; set; }

        
        public void GetValues(NameValueCollection queryRequest)
        {
            var properties = this.GetType().GetProperties();
            List<string> ignoredProperties = new List<string>();

            foreach (var property in properties)
            {
                var queryValue = queryRequest[property.Name];
                if (string.IsNullOrEmpty(queryValue))
                {
                    ignoredProperties.Add(property.Name);
                    continue;
                }

                var propertyType = property.PropertyType;
                object typedValue;

                if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    typedValue = Convert.ChangeType(queryValue, propertyType.GetGenericArguments()[0]);
                else if (propertyType == typeof(bool))
                {
                    typedValue = false;
                    switch (queryValue)
                    {
                        case "true": typedValue = true; break;
                        case "false": typedValue = false; break;
                        case "all": ignoredProperties.Add(property.Name); break;
                        default: ignoredProperties.Add(property.Name); break;
                    }
                }
                else
                    typedValue = Convert.ChangeType(queryValue, propertyType);

                property.SetValue(this, typedValue);
            }

            this.IgnoredProperties = ignoredProperties.ToArray();
        }
    }
}