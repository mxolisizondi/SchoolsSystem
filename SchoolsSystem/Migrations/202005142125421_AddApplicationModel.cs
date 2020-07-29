namespace SchoolsSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplicationModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationDocuments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        ContentType = c.String(),
                        Data = c.Binary(),
                        ApplicationId = c.Int(nullable: false),
                        LearnerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applications", t => t.ApplicationId, cascadeDelete: true)
                .ForeignKey("dbo.Learners", t => t.LearnerId)
                .Index(t => t.ApplicationId)
                .Index(t => t.LearnerId);
            
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentDetailId = c.Int(nullable: false),
                        ApplicationStatusId = c.Byte(nullable: false),
                        SchoolId = c.Int(nullable: false),
                        DateSubmitted = c.DateTime(nullable: false),
                        LearnerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationStatus", t => t.ApplicationStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Learners", t => t.LearnerId)
                .ForeignKey("dbo.ParentDetails", t => t.ParentDetailId, cascadeDelete: true)
                .ForeignKey("dbo.Schools", t => t.SchoolId, cascadeDelete: true)
                .Index(t => t.ParentDetailId)
                .Index(t => t.ApplicationStatusId)
                .Index(t => t.SchoolId)
                .Index(t => t.LearnerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationDocuments", "Learner_UseId", "dbo.Learners");
            DropForeignKey("dbo.Applications", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Applications", "ParentDetailId", "dbo.ParentDetails");
            DropForeignKey("dbo.Applications", "Learner_UseId", "dbo.Learners");
            DropForeignKey("dbo.Applications", "ApplicationStatusId", "dbo.ApplicationStatus");
            DropForeignKey("dbo.ApplicationDocuments", "ApplicationId", "dbo.Applications");
            DropIndex("dbo.Applications", new[] { "Learner_UseId" });
            DropIndex("dbo.Applications", new[] { "SchoolId" });
            DropIndex("dbo.Applications", new[] { "ApplicationStatusId" });
            DropIndex("dbo.Applications", new[] { "ParentDetailId" });
            DropIndex("dbo.ApplicationDocuments", new[] { "Learner_UseId" });
            DropIndex("dbo.ApplicationDocuments", new[] { "ApplicationId" });
            DropTable("dbo.Applications");
            DropTable("dbo.ApplicationDocuments");
        }
    }
}
