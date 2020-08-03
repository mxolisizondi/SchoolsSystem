namespace SchoolsSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNotificationStatusWithData : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[NotificationStatus] ([Id], [Status]) VALUES (1, N'Read')
                  INSERT INTO [dbo].[NotificationStatus] ([Id], [Status]) VALUES (2, N'Unread')");
        }
        
        public override void Down()
        {
        }
    }
}
