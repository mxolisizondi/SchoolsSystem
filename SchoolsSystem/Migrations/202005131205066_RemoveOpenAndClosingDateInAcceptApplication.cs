namespace SchoolsSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveOpenAndClosingDateInAcceptApplication : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AcceptApplications", "OpenDate");
            DropColumn("dbo.AcceptApplications", "ClosingDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AcceptApplications", "ClosingDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AcceptApplications", "OpenDate", c => c.DateTime(nullable: false));
        }
    }
}
