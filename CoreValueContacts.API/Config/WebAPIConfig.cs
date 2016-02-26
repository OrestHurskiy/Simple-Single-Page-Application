using System.Web.Http;
using System.Linq;
using System.Web.Http.ModelBinding;
using CoreValueContacts.API.Formatting;
using System.Net.Http.Formatting;
using System.Web.Http.Validation;
using System.Web.Http.Validation.Providers;
using CoreValueContacts.API.MessageHandlers;
using WebApiDoodle.Web.Filters;

namespace CoreValueContacts.API.Config
{
    public class WebAPIConfig
    {
        public static void Configure(HttpConfiguration config)
        {
            //Handlers
            //config.MessageHandlers.Add(new RequireHttpsMessageHandler());
            //config.MessageHandlers.Add(new CoreValueContactsAuthHandler());

            
            //Formatters
            //var jqueryFormatter = config.Formatters.FirstOrDefault(
            //    f => f.GetType() == typeof(JQueryMvcFormUrlEncodedFormatter));

            config.Formatters.Remove(config.Formatters.FormUrlEncodedFormatter);

           //config.Formatters.Remove(jqueryFormatter);

            foreach(var formatter in config.Formatters)
            {
                formatter.RequiredMemberSelector = new SuppressedRequiredMemberSelector();
            }

            //Filters
            config.Filters.Add(new InvalidModelStateFilterAttribute());

            //Services
            config.Services.Replace(typeof(IContentNegotiator),
                new DefaultContentNegotiator(excludeMatchOnTypeOnly: true));

            config.Services.RemoveAll(typeof(ModelValidatorProvider), validator => !(validator is DataAnnotationsModelValidatorProvider));
        }
    }
}
