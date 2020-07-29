namespace SchoolsSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOpenAndClosingDateInAcceptApplication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AcceptApplications", "OpenDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AcceptApplications", "ClosingDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AcceptApplications", "ClosingDate");
            DropColumn("dbo.AcceptApplications", "OpenDate");
        }
    }
}
