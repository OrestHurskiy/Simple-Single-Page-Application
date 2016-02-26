using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CoreValueContacts.Domain.Entities.Configuration;

namespace CoreValueContacts.Domain.Entities.Core
{
    public class EntitiesContext : DbContext
    {
        public EntitiesContext()
        {
            //Database.SetInitializer<EntitiesContext>(null);
        }

        #region Entry Sets
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Project> Projects { get; set; }
   

        public IDbSet<User> Users { get; set; }
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<UserRole> UserRoles { get; set; }
        #endregion

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserInRoleConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new ProjectConfiguration());
        }
    }
}
