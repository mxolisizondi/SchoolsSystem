namespace SchoolsSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateRecivedStatusInApplicationStatus : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ApplicationStatus (Id, Status) VALUES(5, 'Received')");
        }
        
        public override void Down()
        {
        }
    }
}
