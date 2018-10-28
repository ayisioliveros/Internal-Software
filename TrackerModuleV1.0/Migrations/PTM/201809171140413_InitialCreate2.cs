namespace TrackerModuleV1._0.Migrations.PTM
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ProjectName", c => c.String());
            DropColumn("dbo.Users", "ProjectNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "ProjectNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "ProjectName");
        }
    }
}
