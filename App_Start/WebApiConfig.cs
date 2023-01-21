using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace Gateways
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var setting = config.Formatters.JsonFormatter.SerializerSettings;
            config.MapHttpAttributeRoutes();
            setting.ContractResolver = new CamelCasePropertyNamesContractResolver();
            setting.Formatting = Newtonsoft.Json.Formatting.Indented;


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
