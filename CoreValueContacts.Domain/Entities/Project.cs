using CoreValueContacts.Domain.Entities.Core;
using System;

namespace CoreValueContacts.Domain.Entities
{
    public class Project : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int NumberOfEmployers { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
