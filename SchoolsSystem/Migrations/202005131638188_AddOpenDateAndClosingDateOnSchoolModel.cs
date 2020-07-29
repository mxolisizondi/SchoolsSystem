namespace SchoolsSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOpenDateAndClosingDateOnSchoolModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schools", "OpenDate", c => c.DateTime());
            AddColumn("dbo.Schools", "ClosingDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schools", "ClosingDate");
            DropColumn("dbo.Schools", "OpenDate");
        }
    }
}
