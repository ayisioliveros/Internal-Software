namespace TrackerModuleV1._0.Migrations.PTM
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Data;

    internal sealed class Configuration : DbMigrationsConfiguration<TrackerModuleV1._0.Data.PTMContex>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\PTM";
        }
        void AddOrUpdateUser(PTMContex context, string ProjectName, string FirstName)
        {
            var prjct = context.Projects.SingleOrDefault(p => p.ProjectName == ProjectName);
            var usr = context.Users.SingleOrDefault(u => u.FirstName == FirstName);
            if (usr != null)
            {
                prjct.users.Add(context.Users.Single(u => u.FirstName == FirstName));

            }


        }
        void AddorUpdatePart(PTMContex contex, string projectName,string partName)
        {
            var prjct = contex.Projects.SingleOrDefault(p => p.ProjectName == projectName);
            var prt = contex.parts.SingleOrDefault(i => i.PartName == partName);
            if(prt != null)
            {
                prjct.parts.Add(contex.parts.Single(p => p.PartName == partName));
            }
        }
        protected override void Seed(TrackerModuleV1._0.Data.PTMContex context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Projects.AddOrUpdate(
                p =>  p.ProjectName, DummyData.getProjects().ToArray());
            context.SaveChanges();

            context.Users.AddOrUpdate(
                u => new { u.FirstName, u.LastName }, DummyData.getUsers().ToArray());
            context.SaveChanges();

            context.parts.AddOrUpdate(
                p => p.PartId, DummyData.getParts(context).ToArray());
            context.SaveChanges();
            AddOrUpdateUser(context, "Wafer Sorter", "Abienash");
            AddOrUpdateUser(context, "Bakeout Chamber", "Leo");
            AddOrUpdateUser(context, "Carbon Nanotube CVD Chamber", "Devinda");
            AddOrUpdateUser(context, "Process Kit Transporter", "Danny");
            AddOrUpdateUser(context, "Bakeout Chamber", "Devinda");

            AddorUpdatePart(context, "Wafer Sorter", "ScrewDriver");
            AddorUpdatePart(context, "Process Kit Transporter", "BreadBoard");
            AddorUpdatePart(context, "Process Kit Transporter", "ScrewDriver");
            context.SaveChanges();

        }
    }
}
