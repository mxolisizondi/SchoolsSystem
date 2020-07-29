namespace SchoolsSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateApplicationStatusWithData1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ApplicationStatus (Id, Status) VALUES(1, 'Reviewed')");
            Sql("INSERT INTO ApplicationStatus (Id, Status) VALUES(2, 'RequiredDocuments')");
            Sql("INSERT INTO ApplicationStatus (Id, Status) VALUES(3, 'Accepted')");
            Sql("INSERT INTO ApplicationStatus (Id, Status) VALUES(4, 'Declined')");
        }
        
        public override void Down()
        {
        }
    }
}
