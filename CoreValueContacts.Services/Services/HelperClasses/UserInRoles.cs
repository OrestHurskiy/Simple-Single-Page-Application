using CoreValueContacts.Domain.Entities;
using System.Collections.Generic;

namespace CoreValueContacts.Services.Services.HelperClasses
{
    public class UserInRoles
    {
        public User User { get; set; }

        public IList<Role> Roles { get; set; }
    }
}
