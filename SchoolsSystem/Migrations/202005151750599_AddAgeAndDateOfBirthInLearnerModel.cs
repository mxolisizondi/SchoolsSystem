namespace SchoolsSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAgeAndDateOfBirthInLearnerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Learners", "Age", c => c.Byte());
            AddColumn("dbo.Learners", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Learners", "DateOfBirth");
            DropColumn("dbo.Learners", "Age");
        }
    }
}
