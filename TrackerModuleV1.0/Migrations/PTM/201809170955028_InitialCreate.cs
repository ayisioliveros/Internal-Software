namespace TrackerModuleV1._0.Migrations.PTM
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ProjectNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UserProjects",
                c => new
                    {
                        User_UserId = c.Int(nullable: false),
                        Project_ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.Project_ProjectId })
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectId, cascadeDelete: true)
                .Index(t => t.User_UserId)
                .Index(t => t.Project_ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProjects", "Project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.UserProjects", "User_UserId", "dbo.Users");
            DropIndex("dbo.UserProjects", new[] { "Project_ProjectId" });
            DropIndex("dbo.UserProjects", new[] { "User_UserId" });
            DropTable("dbo.UserProjects");
            DropTable("dbo.Users");
            DropTable("dbo.Projects");
        }
    }
}
