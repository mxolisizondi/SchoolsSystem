namespace SchoolsSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPreviousSchoolInApplicationModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "PreviousSchool", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applications", "PreviousSchool");
        }
    }
}
