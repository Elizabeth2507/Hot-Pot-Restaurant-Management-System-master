using Hot_Pot_Restaurant_Management_System.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Hot_Pot_Restaurant_Management_System.Common.Authentication
{
    public class UserAuthentication
    {
        //create cookie
        public static HttpCookie CreateCookie(UserViewResult userViewResult)
        {
            var userData = (new JavaScriptSerializer()).Serialize(userViewResult);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket
                (1, userViewResult.UserName, DateTime.Now, DateTime.Now.AddHours(12), true, userData);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
            cookie.Expires = DateTime.Now.AddHours(12);

            return cookie;
        }

        //Set up user information
        public static void TrySetUserInfo(HttpContext context)
        {
            if (context == null)
                return;

            HttpCookie cookie = context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null || string.IsNullOrEmpty(cookie.Value))
                return;

            try
            {
                UserViewResult userViewResult = null;
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
                if (ticket == null || string.IsNullOrEmpty(ticket.UserData))
                    return;

                userViewResult = (new JavaScriptSerializer()).Deserialize<UserViewResult>(ticket.UserData);
                if (userViewResult == null)
                    return;

                context.User = new UserPrincipal(new UserIdentity(userViewResult));
            }
            catch
            {

            }
        }
    }
}