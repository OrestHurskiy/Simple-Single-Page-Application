using System;

namespace CoreValueContacts.Domain.Entities.Configuration
{
    class UserInRoleConfiguration : EntityBaseConfiguration<UserRole>
    {
        public UserInRoleConfiguration()
        {
            Property(e => e.UserId).IsRequired();
            Property(e => e.RoleId).IsRequired();
        }
    }
}
