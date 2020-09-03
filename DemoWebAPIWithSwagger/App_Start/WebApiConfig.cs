using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DemoWebAPIWithSwagger
{
    #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
