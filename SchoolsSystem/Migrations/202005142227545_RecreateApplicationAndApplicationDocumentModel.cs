namespace SchoolsSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecreateApplicationAndApplicationDocumentModel : DbMigration
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
                        LearnerUseId = c.String(maxLength: 128),
                        ApplicationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applications", t => t.ApplicationId, cascadeDelete: true)
                .ForeignKey("dbo.Learners", t => t.LearnerUseId)
                .Index(t => t.LearnerUseId)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LearnerUseId = c.String(maxLength: 128),
                        ParentDetailId = c.Int(nullable: false),
                        ApplicationStatusId = c.Byte(nullable: false),
                        SchoolId = c.Int(nullable: false),
                        DateSubmitted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationStatus", t => t.ApplicationStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Learners", t => t.LearnerUseId)
                .ForeignKey("dbo.ParentDetails", t => t.ParentDetailId, cascadeDelete: true)
                .ForeignKey("dbo.Schools", t => t.SchoolId, cascadeDelete: true)
                .Index(t => t.LearnerUseId)
                .Index(t => t.ParentDetailId)
                .Index(t => t.ApplicationStatusId)
                .Index(t => t.SchoolId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationDocuments", "LearnerUseId", "dbo.Learners");
            DropForeignKey("dbo.Applications", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Applications", "ParentDetailId", "dbo.ParentDetails");
            DropForeignKey("dbo.Applications", "LearnerUseId", "dbo.Learners");
            DropForeignKey("dbo.Applications", "ApplicationStatusId", "dbo.ApplicationStatus");
            DropForeignKey("dbo.ApplicationDocuments", "ApplicationId", "dbo.Applications");
            DropIndex("dbo.Applications", new[] { "SchoolId" });
            DropIndex("dbo.Applications", new[] { "ApplicationStatusId" });
            DropIndex("dbo.Applications", new[] { "ParentDetailId" });
            DropIndex("dbo.Applications", new[] { "LearnerUseId" });
            DropIndex("dbo.ApplicationDocuments", new[] { "ApplicationId" });
            DropIndex("dbo.ApplicationDocuments", new[] { "LearnerUseId" });
            DropTable("dbo.Applications");
            DropTable("dbo.ApplicationDocuments");
        }
    }
}
