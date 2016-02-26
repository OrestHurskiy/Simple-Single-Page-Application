using CoreValueContacts.Services.Services.HelperClasses;
using System.Security.Principal;

namespace CoreValueContacts.Services.Services
{
    public class MembershipContext
    {
        public IPrincipal Principal { get; set; }
        public UserInRoles User { get; set; }

        public bool IsValid()
        {
            return Principal != null;
        }
    }
}
