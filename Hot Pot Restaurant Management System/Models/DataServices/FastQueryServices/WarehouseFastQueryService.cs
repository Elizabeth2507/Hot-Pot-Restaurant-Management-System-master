﻿using Hot_Pot_Restaurant_Management_System.Common.Interfaces;
using Hot_Pot_Restaurant_Management_System.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Models.DataServices.FastQueryServices
{
    public class WarehouseFastQueryService : FastQueryService, IFastQueryService<Warehouse>
    {
        public List<Warehouse> FastQuery(string queryText)
        {
            return FastQuery<Warehouse>(queryText);
        }

        public override List<T> CustomQuery<T>(DbSet<T> dbSet, string queryText)
        {
            var results = new List<T>();

            results = IntFastQuery(dbSet, queryText);
            if (results != null && results.Count() != 0)
                return results;

            return StringFastQuery(dbSet, queryText, "Name");
        }
    }
}