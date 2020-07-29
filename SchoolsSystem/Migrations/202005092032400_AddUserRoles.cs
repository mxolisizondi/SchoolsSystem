namespace SchoolsSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8a02c1fe-ea8c-49c9-8fc8-cebd87b5bf30', N'Clerk')
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'fd43d5d6-7507-421e-806c-1d2339f4c5e8', N'Learner')
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0e3cf7c8-b62b-4eae-aec1-b5939d79df21', N'SystemAdmin')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
