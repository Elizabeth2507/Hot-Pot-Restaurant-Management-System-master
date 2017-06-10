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
    public class UserService : DataService, IDataService<User>
    {
        
        public List<User> Query(QueryConditions queryConditions, out int totalCount)
        {
            return Query<User>(queryConditions, out totalCount);
        }

        
        public DBResult Add(User entity)
        {
            return Add<User>(entity, new string[] { "ID" }, new string[] { "ShortID", "UserName" });
        }

        
        public DBResult Edit(User entity)
        {
            if (EntityHelper.HasNullProperty(entity, new string[] { "Password" }))
                return DBResult.WrongParameter;

            using (var db = new SystemEntities())
            {
                var user = db.User.FirstOrDefault(u => u.ID == entity.ID);
                if (user == null)
                    return DBResult.NotFound;

                var existResult = CheckExists(db.User, new string[] { "ShortID", "UserName" }, entity, true);
                if (existResult != DBResult.Succeed)
                    return existResult;

                EntityHelper.CopyEntity(entity, user, new string[] { "Password" });
                db.SaveChanges();
                return DBResult.Succeed;
            }
        }

        
        public DBResult EditAll(List<User> entities)
        {
            if (entities == null)
                return DBResult.WrongParameter;

            using (var db = new SystemEntities())
            {
                foreach (var entity in entities)
                {
                    if (EntityHelper.HasNullProperty(entity, new string[] { "Password" }))
                        return DBResult.WrongParameter;

                    var user = db.User.FirstOrDefault(u => u.ID == entity.ID);
                    if (user == null)
                        return DBResult.NotFound;

                    var existResult = CheckExists(db.User, new string[] { "ShortID", "UserName" }, entity, true);
                    if (existResult != DBResult.Succeed)
                        return existResult;

                    EntityHelper.CopyEntity(entity, user, new string[] { "Password" });
                }

                db.SaveChanges();
                return DBResult.Succeed;
            }
        }

        
        public DBResult ChangePassword(User entity)
        {
            if (entity == null || entity.ID == 0 || string.IsNullOrEmpty(entity.Password))
                return DBResult.WrongParameter;

            using (var db = new SystemEntities())
            {
                var user = db.User.FirstOrDefault(u => u.ID == entity.ID);
                if (user == null)
                    return DBResult.NotFound;

                user.Password = entity.Password;

                db.SaveChanges();
                return DBResult.Succeed;
            }
        }

        
        public DBResult Delete(User entity)
        {
            return Delete<User>(entity);
        }

        
        public DBResult DeleteAll(List<User> entities)
        {
            return DeleteAll<User>(entities);
        }

        
        public DBResult Delete(int id)
        {
            return Delete<User, int>(id);
        }

        
        public DBResult DeleteAll(List<int> list)
        {
            return DeleteAll<User, int>(list);
        }

        
        public DBResult Check(string userName, string password, out User user)
        {
            user = new User();
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return DBResult.WrongParameter;

            using (var db = new SystemEntities())
            {
                user = db.User.FirstOrDefault(u => u.UserName == userName && u.Password == password);
                if (user == null)
                    return DBResult.UserNotFound;

                return DBResult.Succeed;
            }
        }
    }
}