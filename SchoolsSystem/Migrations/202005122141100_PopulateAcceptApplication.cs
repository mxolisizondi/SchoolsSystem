namespace SchoolsSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAcceptApplication : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO AcceptApplications (Id, Status) VALUES(1, 'Accept')");
            Sql("INSERT INTO AcceptApplications (Id, Status) VALUES(2, 'Closed')");
        }
        
        public override void Down()
        {
        }
    }
}
