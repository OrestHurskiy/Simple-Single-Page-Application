using System;


namespace CoreValueContacts.Domain.Entities.Configuration
{
    public class RoleConfiguration : EntityBaseConfiguration<Role>
    {
        public RoleConfiguration()
        {
            HasMany(e => e.UserRoles).WithRequired().HasForeignKey(ur => ur.RoleId);
            Property(e => e.Name).IsRequired().HasMaxLength(50);
        }
    }
}
