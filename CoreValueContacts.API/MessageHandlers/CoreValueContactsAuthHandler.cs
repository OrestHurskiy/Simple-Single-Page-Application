using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using WebApiDoodle.Web.MessageHandlers;
using CoreValueContacts.API.Extensions.Http;

namespace CoreValueContacts.API.MessageHandlers
{
    public class CoreValueContactsAuthHandler : BasicAuthenticationHandler
    {
        protected override Task<IPrincipal> AuthenticateUserAsync(HttpRequestMessage request, string username, string password, CancellationToken cancellationToken)
        {
            var membershipService = request.GetMembershipService();

            var validUserCtx = membershipService.ValidateUser(username, password);

            return Task.FromResult(validUserCtx.Principal);
        }
    }
}
