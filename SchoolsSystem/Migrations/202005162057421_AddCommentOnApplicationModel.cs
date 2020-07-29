namespace SchoolsSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentOnApplicationModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applications", "Comment");
        }
    }
}
