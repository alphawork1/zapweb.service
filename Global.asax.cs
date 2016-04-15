using System;
using System.Web.Routing;
using System.Web.Mvc;

namespace zapweb
{    
    public class Global : System.Web.HttpApplication
    {
                
        protected void Application_Start(object sender, EventArgs e)
        {

            Pillar.Mvc.Application.Config("config.ini");

            RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            RouteTable.Routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}