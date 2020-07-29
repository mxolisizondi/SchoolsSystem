namespace SchoolsSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkSchoolWithAcceptApplication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schools", "AcceptApplicationId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Schools", "AcceptApplicationId");
            AddForeignKey("dbo.Schools", "AcceptApplicationId", "dbo.AcceptApplications", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schools", "AcceptApplicationId", "dbo.AcceptApplications");
            DropIndex("dbo.Schools", new[] { "AcceptApplicationId" });
            DropColumn("dbo.Schools", "AcceptApplicationId");
        }
    }
}
