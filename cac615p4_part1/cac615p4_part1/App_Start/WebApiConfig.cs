using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace cac615p4_part1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{person}",
                defaults: new { person = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "DefaultApi1",
               routeTemplate: "api/{controller}/{person}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );
        }
    }
}
