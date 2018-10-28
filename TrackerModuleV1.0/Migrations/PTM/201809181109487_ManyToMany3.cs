namespace TrackerModuleV1._0.Migrations.PTM
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToMany3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Projects", newName: "Project");
            RenameTable(name: "dbo.Users", newName: "User");
            RenameTable(name: "dbo.UserProjects", newName: "ProjectIdUserId");
            RenameColumn(table: "dbo.ProjectIdUserId", name: "User_UserId", newName: "UserId");
            RenameColumn(table: "dbo.ProjectIdUserId", name: "Project_ProjectId", newName: "ProjectId");
            RenameIndex(table: "dbo.ProjectIdUserId", name: "IX_Project_ProjectId", newName: "IX_ProjectId");
            RenameIndex(table: "dbo.ProjectIdUserId", name: "IX_User_UserId", newName: "IX_UserId");
            DropPrimaryKey("dbo.ProjectIdUserId");
            AddPrimaryKey("dbo.ProjectIdUserId", new[] { "ProjectId", "UserId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ProjectIdUserId");
            AddPrimaryKey("dbo.ProjectIdUserId", new[] { "User_UserId", "Project_ProjectId" });
            RenameIndex(table: "dbo.ProjectIdUserId", name: "IX_UserId", newName: "IX_User_UserId");
            RenameIndex(table: "dbo.ProjectIdUserId", name: "IX_ProjectId", newName: "IX_Project_ProjectId");
            RenameColumn(table: "dbo.ProjectIdUserId", name: "ProjectId", newName: "Project_ProjectId");
            RenameColumn(table: "dbo.ProjectIdUserId", name: "UserId", newName: "User_UserId");
            RenameTable(name: "dbo.ProjectIdUserId", newName: "UserProjects");
            RenameTable(name: "dbo.User", newName: "Users");
            RenameTable(name: "dbo.Project", newName: "Projects");
        }
    }
}
