using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace CoreValueContacts.API.MessageHandlers
{
    public class RequireHttpsMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if(request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                HttpResponseMessage forbiddenResponse = request.CreateResponse(HttpStatusCode.Forbidden);

                forbiddenResponse.ReasonPhrase = "SSL Required";
                return Task.FromResult(forbiddenResponse);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}
