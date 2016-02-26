namespace CoreValueContacts.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProjectCustomertable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Mail = c.String(nullable: false, maxLength: 200),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        NumberOfEmployers = c.Int(nullable: false),
                        Customer_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Project", "Customer_Id", "dbo.Customer");
            DropIndex("dbo.Project", new[] { "Customer_Id" });
            DropTable("dbo.Project");
            DropTable("dbo.Customer");
        }
    }
}
