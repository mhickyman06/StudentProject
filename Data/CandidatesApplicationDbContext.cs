using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;
using StudentProject.Models;

namespace StudentProject.Data
{
    public class CandidatesApplicationDbContext : IdentityDbContext<CandidatesApplicationUser>
    {

        public CandidatesApplicationDbContext(DbContextOptions<CandidatesApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}