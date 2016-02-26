using Autofac;
using Autofac.Integration.WebApi;
using CoreValueContacts.Domain.Entities.Core;
using CoreValueContacts.Domain.Infrastructure;
using CoreValueContacts.Domain.Repositories;
using CoreValueContacts.Services.Services.Implementation;
using CoreValueContacts.Services.Services.Interfaces;
using System.Data.Entity;
using System.Reflection;
using System.Web.Http;

namespace CoreValueContacts.API.Config
{
    public class AutofacConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //EF DbContext
            builder.RegisterType<EntitiesContext>().As<DbContext>().InstancePerRequest();

            //DbFactory
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            //UnitOfWork
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            //Repositories
            builder.RegisterGeneric(typeof(EntityBaseRepository<>)).As(typeof(IEntityBaseRepository<>)).InstancePerRequest();

            //Services
            builder.RegisterType<CryptoService>().As<ICryptoService>().InstancePerRequest();
            builder.RegisterType<MembershipService>().As<IMembershipService>().InstancePerRequest();
            builder.RegisterType<ProjectService>().As<IProjectService>().InstancePerRequest();

            Container = builder.Build();
            return Container;
        }

    }
}
