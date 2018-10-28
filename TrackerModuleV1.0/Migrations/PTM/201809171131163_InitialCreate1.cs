namespace TrackerModuleV1._0.Migrations.PTM
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "JobRole", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "JobRole");
            DropColumn("dbo.Projects", "UserId");
        }
    }
}
