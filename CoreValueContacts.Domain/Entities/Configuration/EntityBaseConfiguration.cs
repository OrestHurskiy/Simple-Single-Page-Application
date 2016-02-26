using CoreValueContacts.Domain.Entities.Core;
using System;
using System.Data.Entity.ModelConfiguration;

namespace CoreValueContacts.Domain.Entities.Configuration
{
    public class EntityBaseConfiguration<T> : EntityTypeConfiguration<T> where T : class, IEntity
    {
        public EntityBaseConfiguration()
        {
            HasKey(e => e.Id);
        }
    }
}
