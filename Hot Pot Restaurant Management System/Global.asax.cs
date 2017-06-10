using Hot_Pot_Restaurant_Management_System.Common.Authentication;
using Hot_Pot_Restaurant_Management_System.Common.CustomValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Hot_Pot_Restaurant_Management_System
{
    

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var DataTypeValidator = ModelValidatorProviders.Providers.OfType<ClientDataTypeModelValidatorProvider>().FirstOrDefault();
            if (DataTypeValidator != null)
                ModelValidatorProviders.Providers.Remove(DataTypeValidator);
            ModelValidatorProviders.Providers.Add(new FilterableClientDataTypeModelValidatorProvider());
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            UserAuthentication.TrySetUserInfo(app.Context);
        }
    }
}