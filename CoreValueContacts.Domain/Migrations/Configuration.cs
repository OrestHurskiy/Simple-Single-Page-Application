namespace CoreValueContacts.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class Configuration : DbMigrationsConfiguration<CoreValueContacts.Domain.Entities.Core.EntitiesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CoreValueContacts.Domain.Entities.Core.EntitiesContext context)
        {
            context.Roles.AddOrUpdate(role => role.Name,
                new Entities.Role {Id = Guid.NewGuid(), Name = "Admin" },
                new Entities.Role {Id = Guid.NewGuid(), Name = "User" }
                );

            context.Users.AddOrUpdate(user => user.UserName,
                new Entities.User {Id = Guid.NewGuid(), UserName = "CompanyA", Email = "companya@example.com", Salt = "olNfhyN683B4BOf68Rwkfg==", HashedPassword = "gFx171zOge4EX/6U8YmEc7l+N1ySrgHqE8czpMj65+o=", IsLocked = false, CreatedOn = DateTime.Now }
                );

            context.Projects.AddOrUpdate(project => project.Name,
                new Entities.Project { Id = Guid.NewGuid(), Name = "Contacts", NumberOfEmployers = 5 },
                new Entities.Project { Id = Guid.NewGuid(), Name = "EpiServer", NumberOfEmployers = 2 }
                );
        }
    }
}
