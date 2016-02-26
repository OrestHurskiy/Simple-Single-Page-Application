using CoreValueContacts.Domain.Entities.Core;
using System;
using System.Collections.Generic;

namespace CoreValueContacts.Domain.Entities
{
    public class Role : IEntity
    {
        public Role()
        {
            UserRoles = new List<UserRole>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
