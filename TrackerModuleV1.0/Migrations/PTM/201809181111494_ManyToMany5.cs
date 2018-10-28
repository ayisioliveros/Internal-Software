namespace TrackerModuleV1._0.Migrations.PTM
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToMany5 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Project", newName: "Projects");
            RenameTable(name: "dbo.User", newName: "Users");
            RenameTable(name: "dbo.ProjectIdUserId", newName: "UserProjects");
            RenameColumn(table: "dbo.UserProjects", name: "ProjectId", newName: "Project_ProjectId");
            RenameColumn(table: "dbo.UserProjects", name: "UserId", newName: "User_UserId");
            RenameIndex(table: "dbo.UserProjects", name: "IX_UserId", newName: "IX_User_UserId");
            RenameIndex(table: "dbo.UserProjects", name: "IX_ProjectId", newName: "IX_Project_ProjectId");
            DropPrimaryKey("dbo.UserProjects");
            AddPrimaryKey("dbo.UserProjects", new[] { "User_UserId", "Project_ProjectId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserProjects");
            AddPrimaryKey("dbo.UserProjects", new[] { "ProjectId", "UserId" });
            RenameIndex(table: "dbo.UserProjects", name: "IX_Project_ProjectId", newName: "IX_ProjectId");
            RenameIndex(table: "dbo.UserProjects", name: "IX_User_UserId", newName: "IX_UserId");
            RenameColumn(table: "dbo.UserProjects", name: "User_UserId", newName: "UserId");
            RenameColumn(table: "dbo.UserProjects", name: "Project_ProjectId", newName: "ProjectId");
            RenameTable(name: "dbo.UserProjects", newName: "ProjectIdUserId");
            RenameTable(name: "dbo.Users", newName: "User");
            RenameTable(name: "dbo.Projects", newName: "Project");
        }
    }
}
