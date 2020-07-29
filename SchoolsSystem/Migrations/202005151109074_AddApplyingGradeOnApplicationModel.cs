namespace SchoolsSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplyingGradeOnApplicationModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "PreviousGrade", c => c.Byte(nullable: false));
            AddColumn("dbo.Applications", "ApplyingGrade", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applications", "ApplyingGrade");
            DropColumn("dbo.Applications", "PreviousGrade");
        }
    }
}
