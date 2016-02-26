using CoreValueContacts.API.Routing;
using System.Web.Http;

namespace CoreValueContacts.API.Config
{
    public class RouteConfig
    {
        public static void RegisterRoutes(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            
            var routes = config.Routes;

            routes.MapHttpRoute(
                "DefaultHttpRoute",
                "api/{controller}/{key}",
                defaults: new { key = RouteParameter.Optional },
                constraints: new { key = new GuidRouteConstraint() }
                );
        }
    }
}
