using System.Web.Mvc;
using System.Web.Routing;

namespace CoreValueContacts.API.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Defeault",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Projects", action = "Index", id = UrlParameter.Optional }
                );
        }
    }
}