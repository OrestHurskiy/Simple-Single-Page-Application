using System.Web.Routing;
using System.Web.Mvc;

namespace CoreValueContacts.API.WebHost
{
    public class RouteMvcConfig
    {
        public static void RegisterMvcRoute(RouteCollection routes)
        {
            routes.MapRoute(
                name: "DefeaultMvcRouting",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );
        }
    }
}