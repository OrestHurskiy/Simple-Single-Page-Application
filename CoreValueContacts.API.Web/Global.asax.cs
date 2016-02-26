using System.Web;
using System.Web.Routing;

namespace CoreValueContacts.API.Web
{

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AutofacMvc.Initialize();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }

}