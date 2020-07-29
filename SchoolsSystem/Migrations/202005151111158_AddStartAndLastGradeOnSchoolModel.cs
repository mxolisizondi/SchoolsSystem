namespace SchoolsSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStartAndLastGradeOnSchoolModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schools", "StartingGrade", c => c.Byte(nullable: false));
            AddColumn("dbo.Schools", "LastGrade", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schools", "LastGrade");
            DropColumn("dbo.Schools", "StartingGrade");
        }
    }
}
