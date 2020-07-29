namespace SchoolsSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeFieldRequiredToSchoolModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Schools", "Name", c => c.String(nullable: false, maxLength: 225));
            AlterColumn("dbo.Schools", "EmailAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Schools", "TelephoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Schools", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schools", "Address", c => c.String());
            AlterColumn("dbo.Schools", "TelephoneNumber", c => c.String());
            AlterColumn("dbo.Schools", "EmailAddress", c => c.String());
            AlterColumn("dbo.Schools", "Name", c => c.String());
        }
    }
}
