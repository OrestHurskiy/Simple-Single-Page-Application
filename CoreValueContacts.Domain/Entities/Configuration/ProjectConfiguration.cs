namespace CoreValueContacts.Domain.Entities.Configuration
{
    public class ProjectConfiguration : EntityBaseConfiguration<Project>
    {
        public ProjectConfiguration()
        {
            HasKey(e => e.Id);
            Property(e => e.Name).IsRequired().HasMaxLength(100);

        }
    }
}
