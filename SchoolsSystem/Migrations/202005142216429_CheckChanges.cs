namespace SchoolsSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationDocuments", "ApplicationId", "dbo.Applications");
            DropForeignKey("dbo.Applications", "ApplicationStatusId", "dbo.ApplicationStatus");
            DropForeignKey("dbo.Applications", "Learner_UseId", "dbo.Learners");
            DropForeignKey("dbo.Applications", "ParentDetailId", "dbo.ParentDetails");
            DropForeignKey("dbo.Applications", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.ApplicationDocuments", "Learner_UseId", "dbo.Learners");
            DropIndex("dbo.ApplicationDocuments", new[] { "ApplicationId" });
            DropIndex("dbo.ApplicationDocuments", new[] { "Learner_UseId" });
            DropIndex("dbo.Applications", new[] { "ParentDetailId" });
            DropIndex("dbo.Applications", new[] { "ApplicationStatusId" });
            DropIndex("dbo.Applications", new[] { "SchoolId" });
            DropIndex("dbo.Applications", new[] { "Learner_UseId" });
            DropTable("dbo.ApplicationDocuments");
            DropTable("dbo.Applications");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LearnerId = c.String(),
                        ParentDetailId = c.Int(nullable: false),
                        ApplicationStatusId = c.Byte(nullable: false),
                        SchoolId = c.Int(nullable: false),
                        DateSubmitted = c.DateTime(nullable: false),
                        Learner_UseId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationDocuments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        ContentType = c.String(),
                        Data = c.Binary(),
                        LearnerId = c.String(),
                        ApplicationId = c.Int(nullable: false),
                        Learner_UseId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Applications", "Learner_UseId");
            CreateIndex("dbo.Applications", "SchoolId");
            CreateIndex("dbo.Applications", "ApplicationStatusId");
            CreateIndex("dbo.Applications", "ParentDetailId");
            CreateIndex("dbo.ApplicationDocuments", "Learner_UseId");
            CreateIndex("dbo.ApplicationDocuments", "ApplicationId");
            AddForeignKey("dbo.ApplicationDocuments", "Learner_UseId", "dbo.Learners", "UseId");
            AddForeignKey("dbo.Applications", "SchoolId", "dbo.Schools", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Applications", "ParentDetailId", "dbo.ParentDetails", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Applications", "Learner_UseId", "dbo.Learners", "UseId");
            AddForeignKey("dbo.Applications", "ApplicationStatusId", "dbo.ApplicationStatus", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationDocuments", "ApplicationId", "dbo.Applications", "Id", cascadeDelete: true);
        }
    }
}
