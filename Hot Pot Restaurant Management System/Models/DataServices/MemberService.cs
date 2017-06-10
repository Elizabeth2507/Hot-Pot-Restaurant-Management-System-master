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
    public class MemberService : DataService, IDataService<Member>
    {
        
        public List<Member> Query(QueryConditions queryConditions, out int totalCount)
        {
            return Query<Member>(queryConditions, out totalCount);
        }

        
        public DBResult Add(Member entity)
        {
            return Add<Member>(entity, new string[] { "Point" }, new string[] { "ID" });
        }

        
        public DBResult Edit(Member entity)
        {
            return Edit<Member>(entity, new string[] { "Point" }, null);
        }

        
        public DBResult EditAll(List<Member> entities)
        {
            return EditAll<Member>(entities, new string[] { "Point" }, null);
        }

        
        public DBResult Delete(Member entity)
        {
            return Delete<Member>(entity);
        }

        
        public DBResult DeleteAll(List<Member> entities)
        {
            return DeleteAll<Member>(entities);
        }

        
        public DBResult Delete(int id)
        {
            return Delete<Member, int>(id);
        }

        
        public DBResult DeleteAll(List<int> list)
        {
            return DeleteAll<Member, int>(list);
        }
    }
}