namespace CoreValueContacts.Domain.Entities.Configuration
{
    class CustomerConfiguration : EntityBaseConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            HasKey(e => e.Id);
            Property(e => e.Name).IsRequired().HasMaxLength(100);
            Property(e => e.Mail).IsRequired().HasMaxLength(200);
        }
    }
}
