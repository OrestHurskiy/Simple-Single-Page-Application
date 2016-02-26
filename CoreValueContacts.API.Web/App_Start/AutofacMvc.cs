using CoreValueContacts.API.Client.ApiContext;
using Autofac;
using Autofac.Integration.Mvc;
using System.Web;
using System.Web.Mvc;
using CoreValueContacts.API.Client.Clients.Interfaces;

namespace CoreValueContacts.API.Web
{
    internal static class AutofacMvc
    {
        internal static void Initialize()
        {
            var builder = new ContainerBuilder();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(RegisterServices(builder)));
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            ApiClientContext apiClientContext = ApiClientContext.Create(cfg =>
                                                    cfg.SetCredentialsFromAppSetting(
                                                        "Api:Username", "Api:Password"
                                                        ).ConnectTo("https://localhost:44300"));
            //Register the clients
            builder.Register(c => apiClientContext.GetProjectsClient()).As<IProjectsClient>().InstancePerRequest();

            return builder.Build();

        }
    }
}