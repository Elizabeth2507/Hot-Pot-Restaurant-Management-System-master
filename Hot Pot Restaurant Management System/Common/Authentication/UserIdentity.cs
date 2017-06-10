using Hot_Pot_Restaurant_Management_System.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Common.Authentication
{
    public class UserIdentity : IIdentity
    {
        public int ID { get; private set; }
        public int ShortID { get; private set; }
        public string Name { get; private set; }
        public int Role { get; private set; }
        public string RealName { get; private set; }
        public string RealPost { get; private set; }
        public bool IsAuthenticated { get; private set; }

        public UserIdentity(UserViewResult user)
        {
            if (user != null)
            {
                ID = user.ID;
                ShortID = user.ShortID;
                Name = user.UserName;
                Role = user.Role;
                RealName = user.RealName;
                RealPost = user.RealPost;
                IsAuthenticated = true;
            }
        }

        public string AuthenticationType
        {
            get { return "MyAuthentication"; }
        }
    }
}