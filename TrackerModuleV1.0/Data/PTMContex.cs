using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using TrackerModuleV1._0.Models.PTM;

namespace TrackerModuleV1._0.Data
{
    public class PTMContex :DbContext
    {
        public PTMContex():base("DefaultConnection")
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Part> parts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<User>()
                .HasMany(i => i.projects)
                .WithMany(u => u.users)
                .Map(m =>
                {
                    m.ToTable("ProjectIdUserId");
                    m.MapLeftKey("ProjectId");
                    m.MapRightKey("UserId");
                });

            modelBuilder.Entity<Project>()
                .HasMany(i => i.parts)
                .WithMany(p => p.Projects)
                .Map(m =>
                {
                    m.ToTable("PartProject");
                    m.MapLeftKey("PartId");
                    m.MapRightKey("ProjectId");
                });

            modelBuilder.Entity<Part>()
                .HasRequired<User>(p => p.CreatedBy)
                .WithMany(u => u.Parts)
                .HasForeignKey<int>(p => p.CreatedUserId);
                

           

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Project>()
            //    .HasMany(c => c.users).WithMany(i => i.projects)
            //    .Map(t => t.MapLeftKey("ProjectId")
            //        .MapRightKey("UserId")
            //        .ToTable("ProjectIdUserId"));
        }
    }
}