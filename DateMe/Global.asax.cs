using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Models;
using Models.Context;

namespace DateMe
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            Response.Clear();

            if (exception != null)
            {
                if (exception.GetType() == typeof (NullReferenceException))
                {
                    Debug.WriteLine("nullr");
                    Response.Redirect("/Home/Error");
                }
                else if (exception.GetType() == typeof (HttpException))
                {
                    Debug.WriteLine("HttpEx");
                    Response.Redirect(String.Format("/Home/Error/{0}/?message={1}",
                        (exception as HttpException)?.GetHttpCode(), exception.Message));
                }
                else
                {

                }
            }
            else
            {
                Response.Redirect("~/Error");
            }

            Server.ClearError();
        }
    }
}
