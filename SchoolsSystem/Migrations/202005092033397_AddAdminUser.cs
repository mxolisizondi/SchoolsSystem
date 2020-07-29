namespace SchoolsSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdminUser : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'18a066a9-a235-4a2c-8f1a-9881f82f969b', N'mxolisizondi20@gmail.com', 0, N'ANWt4DZF5ZWa5NAJ1yJkiZxh1Z2gKIR/XqNVcjoQaO+H7nhulR1BV+rWxYTcvZVc9A==', N'731ff2a2-eb15-4855-bc88-2e47369a14f2', NULL, 0, 0, NULL, 1, 0, N'mxolisizondi20@gmail.com')");
        }

        public override void Down()
        {
        }
    }
}
