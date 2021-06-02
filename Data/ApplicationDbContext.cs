using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;
using StudentProject.Models;

namespace StudentProject.Data
{

   public class ApplicationDbContext : IdentityDbContext<SchoolsApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //public DbSet<SpellersVideos> schoolVideos { get; set; }
        public DbSet<LocalGovtSchool> localGovtSchools { get; set; }
        public DbSet<SpellersVideos> SpellersVideos { get; set; }
        public DbSet<SchoolTab> SchoolTab { get; set; }
        public DbSet<SpellersTab> SpellersTabs { get; set; }
        public DbSet<SpellersImg> SpellersImgs { get; set; }
        //public DbSet<RoleTab> RoleTab { get; set; }
        public DbSet<SchoolsApplicationUser> SchoolsApplicationUser { get; set; }

        //public DbSet<SchoolSpeller> SchoolSpellers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<SpellersTab>()
                 .HasKey(x => x.SpellersId);

            modelBuilder.Entity<SpellersTab>()
                .HasOne(x => x.SpellersVideos)
                .WithOne(x => x.SpellersTab);

            modelBuilder.Entity<SpellersTab>()
                .HasOne(x => x.SpellersImg)
                .WithOne(x => x.SpellersTab);

            //modelBuilder.Entity<SpellersVideos>()
            //    .HasOne(x => x.SpellersTab);


            modelBuilder.Entity<LocalGovtSchool>()
                .HasKey(ent => ent.Id);



            base.OnModelCreating(modelBuilder);
            //modelBuilder.Ignore<IdentityUserLogin<string>>();
            //modelBuilder.Ignore<IdentityUserRole<string>>();
            //modelBuilder.Ignore<IdentityUserClaim<string>>();
            //modelBuilder.Ignore<IdentityUserToken<string>>();
            //modelBuilder.Ignore<IdentityUser<string>>();
            //modelBuilder.Ignore<SchoolsApplicationUser>();
        }
    }
}