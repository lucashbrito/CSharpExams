using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Aspnet.UI.Controllers;
using NLog;

namespace Aspnet.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }

        public void Application_Error(Object sender, EventArgs e)
        {
            HttpContext appContext = ((MvcApplication)sender).Context;

            Exception ex = Server.GetLastError().GetBaseException();

            //Logger.Error(ex);

            Server.ClearError();

            IController errorController = new ErrorManagerController();

            RouteData routeData = new RouteData();

            routeData.Values["controller"] = "ErrorManagerController";

            routeData.Values["action"] = "ServerError";

            errorController.Execute(new RequestContext(new HttpContextWrapper(appContext), routeData));



        }
    }
}
