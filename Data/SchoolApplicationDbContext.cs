using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;
using StudentProject.Models;

namespace StudentProject.Data
{
   public class SchoolApplicationDbContext : IdentityDbContext<SchoolApplicationUser>
    {

        public SchoolApplicationDbContext(DbContextOptions<SchoolApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<SchoolVideos> schoolVideos { get; set; }
        public DbSet<SchoolCandidates> schoolCandidates { get; set; }
        public DbSet<LocalGovtSchool> localGovtSchools { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<SchoolApplicationUser>()
                .HasMany(sc => sc.SchoolCandidates);

            modelBuilder.Entity<SchoolApplicationUser>()
               .HasOne(sv => sv.SchoolVideos);

            modelBuilder.Entity<SchoolVideos>()
                .HasOne(x => x.schoolApplicationUser)
                .WithOne(y => y.SchoolVideos);
                
                
            //modelBuilder.Entity<SchoolVideos>()
            //   .HasOne(s=>s.schoolApplicationUser);


            modelBuilder.Entity<LocalGovtSchool>()
                .HasKey(ent => ent.Id);

                
                            
            base.OnModelCreating(modelBuilder);
        }
    }
}