﻿using RestAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RestAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //Adding logger
            config.MessageHandlers.Add(new LoggingHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
