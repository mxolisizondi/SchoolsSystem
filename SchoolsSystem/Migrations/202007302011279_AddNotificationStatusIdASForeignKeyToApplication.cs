namespace SchoolsSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotificationStatusIdASForeignKeyToApplication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "NotificationStatusId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Applications", "NotificationStatusId");
            AddForeignKey("dbo.Applications", "NotificationStatusId", "dbo.NotificationStatus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applications", "NotificationStatusId", "dbo.NotificationStatus");
            DropIndex("dbo.Applications", new[] { "NotificationStatusId" });
            DropColumn("dbo.Applications", "NotificationStatusId");
        }
    }
}
