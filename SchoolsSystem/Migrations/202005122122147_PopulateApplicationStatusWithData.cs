namespace SchoolsSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateApplicationStatusWithData : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ApplicationStatus");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApplicationStatus",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
