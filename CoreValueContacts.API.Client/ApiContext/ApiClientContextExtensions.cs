using CoreValueContacts.API.Client.Clients.Implementation;
using CoreValueContacts.API.Client.Clients.Interfaces;
using System;

namespace CoreValueContacts.API.Client.ApiContext
{
    public static class ApiClientContextExtensions
    {
        public static IProjectsClient GetProjectsClient(this ApiClientContext apiClientContext)
        {
            return apiClientContext.GetClient<IProjectsClient>(() =>
                new ProjectsClient(apiClientContext.HttpClient));
        }

        public static TClient GetClient<TClient>(this ApiClientContext apiClientContext, Func<TClient> valueFactory)
        {
            return (TClient)apiClientContext.Clients.GetOrAdd(typeof(TClient), k => valueFactory());
        }
    }
}
