using Hot_Pot_Restaurant_Management_System.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hot_Pot_Restaurant_Management_System.Common
{
    public class ServiceHelper
    {
        
        public static IDataService<T> GetDataService<T>()
            where T : class
        {
            return (IDataService<T>)Activator.CreateInstance(
                Type.GetType("Hot_Pot_Restaurant_Management_System.Models.DataServices." + typeof(T).Name + "Service"));
        }

        
        public static IOrderService<T> GetOrderService<T>()
            where T : class
        {
            return (IOrderService<T>)Activator.CreateInstance(Type.GetType("Hot_Pot_Restaurant_Management_System.Models.DataServices.BusinessServices." 
                + typeof(T).Name.Replace("ViewResult", string.Empty) + "BusinessService"));
        }

        
        public static IFastQueryService<T> GetFastQueryService<T>()
            where T : class
        {
            return (IFastQueryService<T>)Activator.CreateInstance(Type.GetType("Hot_Pot_Restaurant_Management_System.Models.DataServices.FastQueryServices."
                + typeof(T).Name + "FastQueryService"));
        }
    }
}