using System.Data.Entity.Migrations;

namespace CoreValueContacts.API.WebHost
{
    public class EFConfig
    {
        public static void Initialize()
        {
            RunMigrations();
        }

        private static void RunMigrations()
        {
            var efMigrationsSettings = new Domain.Migrations.Configuration();
            var efMigrator = new DbMigrator(efMigrationsSettings);
            efMigrator.Update();
        }
    }
}