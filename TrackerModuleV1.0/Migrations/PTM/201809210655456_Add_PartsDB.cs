namespace TrackerModuleV1._0.Migrations.PTM
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_PartsDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Part",
                c => new
                    {
                        PartId = c.Int(nullable: false, identity: true),
                        PartName = c.String(nullable: false),
                        PartDescription = c.String(),
                        NovenaTecPartNumber = c.String(),
                        SwissRanksPartNumber = c.String(),
                        OEMPartNumber = c.String(),
                        VendorPartNumber = c.String(),
                        stockQuantity = c.Int(nullable: false),
                        status = c.String(),
                        CreatedUserId = c.Int(nullable: false),
                        ApproveBy_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.PartId)
                .ForeignKey("dbo.User", t => t.ApproveBy_UserId)
                .ForeignKey("dbo.User", t => t.CreatedUserId, cascadeDelete: true)
                .Index(t => t.CreatedUserId)
                .Index(t => t.ApproveBy_UserId);
            
            CreateTable(
                "dbo.PartProject",
                c => new
                    {
                        PartId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PartId, t.ProjectId })
                .ForeignKey("dbo.Project", t => t.PartId, cascadeDelete: true)
                .ForeignKey("dbo.Part", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.PartId)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Part", "CreatedUserId", "dbo.User");
            DropForeignKey("dbo.Part", "ApproveBy_UserId", "dbo.User");
            DropForeignKey("dbo.PartProject", "ProjectId", "dbo.Part");
            DropForeignKey("dbo.PartProject", "PartId", "dbo.Project");
            DropIndex("dbo.PartProject", new[] { "ProjectId" });
            DropIndex("dbo.PartProject", new[] { "PartId" });
            DropIndex("dbo.Part", new[] { "ApproveBy_UserId" });
            DropIndex("dbo.Part", new[] { "CreatedUserId" });
            DropTable("dbo.PartProject");
            DropTable("dbo.Part");
        }
    }
}
