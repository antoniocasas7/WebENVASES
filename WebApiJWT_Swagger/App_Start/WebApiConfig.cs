using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiJWT_Swagger.Controllers.LoginJWT;

namespace WebApiJWT_Swagger
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            //Para el login de la webapi con JWT
            config.MessageHandlers.Add(new ValidarTokenHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );        
        }
    }
}
