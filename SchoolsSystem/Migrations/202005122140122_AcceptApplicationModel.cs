namespace SchoolsSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AcceptApplicationModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcceptApplications",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AcceptApplications");
        }
    }
}
