using CoreValueContacts.Domain.Entities.Core;
using System;
using System.Collections.Generic;

namespace CoreValueContacts.Domain.Entities
{
    public class Customer : IEntity
    {
        public Customer()
        {
            Projects = new List<Project>();
        }

        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string Mail { get; set; }

        public string Phone { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
