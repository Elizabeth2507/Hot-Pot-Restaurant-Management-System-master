using Hot_Pot_Restaurant_Management_System.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Common.Authentication
{
    public class UserPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }

        public UserPrincipal(UserIdentity idnetity)
        {
            this.Identity = idnetity;
        }

        public bool IsInRole(string role)
        {
            return role.Split(',').Contains(((UserRoles)((UserIdentity)Identity).Role).ToString());
        }
    }
}