using Hot_Pot_Restaurant_Management_System.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Hot_Pot_Restaurant_Management_System.Common.Authentication
{
    public class CustomRoleProvider : RoleProvider
    {
        //Get the role
        public override string[] GetRolesForUser(string username)
        {
            var result = new string[] { "0" };

            var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null || string.IsNullOrEmpty(cookie.Value))
                return result;
            
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            if (ticket == null || string.IsNullOrEmpty(ticket.UserData))
                return result;

            var userData = (new JavaScriptSerializer()).Deserialize<UserViewResult>(ticket.UserData);
            result = new string[] { userData.Role.ToString() };

            return result;
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}