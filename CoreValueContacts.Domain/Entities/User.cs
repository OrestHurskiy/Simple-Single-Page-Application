using CoreValueContacts.Domain.Entities.Core;
using System;
using System.Collections.Generic;

namespace CoreValueContacts.Domain.Entities
{
    public class User : IEntity
    {

        public User()
        {
            UserRoles = new List<UserRole>();
        }

        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string HashedPassword { get; set; }

        public string Salt { get; set; }

        public bool IsLocked { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? LastUpdatedOn { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
