using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "Admin", new
            {
                controller = "Admin",
                action = "Index"
            }
            );

            routes.MapRoute(null, "", new
            {
                controller = "Product",
                action = "List",
                p_category = (string)null,
                p_page = 1
            });

            routes.MapRoute(null, "Page{p_page}", new {
                controller = "Product",
                action = "List",
                p_category = (string)null }, 
                new { p_page = @"\d+" }
            );

            routes.MapRoute(null, "{p_category}", new {
                controller = "Product",
                action = "List",
                p_page = 1 }
            );

            routes.MapRoute(null, "{p_category}/Page{p_page}", new {
                controller = "Product",
                action = "List" }, 
                new { p_page = @"\d+" }
            );

            routes.MapRoute(null, "{controller}/{action}");

  
              






                    routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "List", id = UrlParameter.Optional }
            );
        }
    }
}
