namespace SchoolsSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssignAdminRole : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'18a066a9-a235-4a2c-8f1a-9881f82f969b', N'0e3cf7c8-b62b-4eae-aec1-b5939d79df21')");
        }

        public override void Down()
        {
        }
    }
}
