namespace TrackerModuleV1._0.Migrations.PTM
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Project", "ShortDescription", c => c.String());
            AlterColumn("dbo.Project", "ProjectName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Project", "ProjectName", c => c.String());
            DropColumn("dbo.Project", "ShortDescription");
        }
    }
}
