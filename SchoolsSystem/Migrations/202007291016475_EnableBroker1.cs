namespace SchoolsSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnableBroker1 : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER DATABASE SchoolsSystem SET ENABLE_BROKER");
        }
        
        public override void Down()
        {
        }
    }
}
