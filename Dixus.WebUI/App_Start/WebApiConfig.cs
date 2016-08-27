using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Dixus.WebUI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Requerir que usuarios sean autenticados para usar WebApi
            config.Filters.Add(new AuthorizeAttribute());

            // Ignorar referencias circulares al serializar y desactivar XML como formato disponible.
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            config.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            // Desactivar la siguiente linea si se desea que los valores "NULL" sean ignorados al serializar a Json
            // config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
        }

        
    }
}
