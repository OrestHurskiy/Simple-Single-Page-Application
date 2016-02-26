using System;


namespace CoreValueContacts.Domain.Entities.Configuration
{
    public class UserConfiguration : EntityBaseConfiguration<User>
    {
        public UserConfiguration()
        {
            HasMany(e => e.UserRoles).WithRequired().HasForeignKey(ur => ur.UserId);
            Property(e => e.UserName).IsRequired().HasMaxLength(100);
            Property(e => e.Email).IsRequired().HasMaxLength(200);
            Property(e => e.HashedPassword).IsRequired().HasMaxLength(200);
            Property(e => e.Salt).IsRequired().HasMaxLength(200);
            Property(e => e.IsLocked).IsRequired();
        }
    }
}
