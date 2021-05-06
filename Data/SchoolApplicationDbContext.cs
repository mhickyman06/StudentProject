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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchoolApplicationUser>()
                .HasOne(c => c.CandidatesApplicationUser);

            modelBuilder.Entity<LocalGovtSchool>()
                .HasMany(s => s.Schools)
                .WithOne(l => l.LocalGovtSchools);
                   
               
            base.OnModelCreating(modelBuilder);
        }
    }
}