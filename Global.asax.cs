using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Castle.Windsor;

namespace MISM5104
{
    public class MvcApplication : System.Web.HttpApplication
    {
	    private static IWindsorContainer _container;
		protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Install castle container
            var container = new WindsorContainer();
            container.Install(new CastleInstaller());

            //Set controller factory
            var castleControllerFactory = new ControllerFactory(container);
            ControllerBuilder.Current.SetControllerFactory(castleControllerFactory);
		}
		protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
		{
			var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
			if (authCookie == null || authCookie.Value == "")
				return;
			var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
			if (authTicket == null || authTicket.Expired)
				return;
			var roles = authTicket.UserData.Split(',');
			HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(new FormsIdentity(authTicket), roles);
		}

		protected void Application_Error()
		{
			var ex = Server.GetLastError();
		}
		protected void Application_End()
		{
			// Dispose of the container when the application shuts down
			// _container.Dispose();
		}
	}
}
