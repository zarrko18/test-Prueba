﻿using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication28
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Home",
               url: "{controller}/{action}",
               defaults: new { controller = "Home", action = "Lista_Usuario", id = UrlParameter.Optional }
           );
        }
    }
}
