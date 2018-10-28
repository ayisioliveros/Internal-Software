namespace TrackerModuleV1._0.Migrations.PTM
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToMany8 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ProjectIdUserId", name: "ProjectId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.ProjectIdUserId", name: "UserId", newName: "ProjectId");
            RenameColumn(table: "dbo.ProjectIdUserId", name: "__mig_tmp__0", newName: "UserId");
            RenameIndex(table: "dbo.ProjectIdUserId", name: "IX_UserId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.ProjectIdUserId", name: "IX_ProjectId", newName: "IX_UserId");
            RenameIndex(table: "dbo.ProjectIdUserId", name: "__mig_tmp__0", newName: "IX_ProjectId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ProjectIdUserId", name: "IX_ProjectId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.ProjectIdUserId", name: "IX_UserId", newName: "IX_ProjectId");
            RenameIndex(table: "dbo.ProjectIdUserId", name: "__mig_tmp__0", newName: "IX_UserId");
            RenameColumn(table: "dbo.ProjectIdUserId", name: "UserId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.ProjectIdUserId", name: "ProjectId", newName: "UserId");
            RenameColumn(table: "dbo.ProjectIdUserId", name: "__mig_tmp__0", newName: "ProjectId");
        }
    }
}
