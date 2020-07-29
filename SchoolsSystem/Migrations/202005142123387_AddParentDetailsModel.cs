namespace SchoolsSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddParentDetailsModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParentDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        IdNumber = c.String(),
                        EmailAddress = c.String(),
                        CellNumber = c.String(),
                        HomeAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ParentDetails");
        }
    }
}
