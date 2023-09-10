using Microsoft.EntityFrameworkCore;
using SurveyFormProject.Entities;
using SurveyFormProject.Models;
using System.Reflection.Metadata;

namespace SurveyFormProject.DbContexts
{
    public class SurveyFormContext : DbContext
    {
        //DbSet stores entities only
        public DbSet<GuestResponse> GuestResponses { get; set; } = null!;

        public SurveyFormContext(DbContextOptions<SurveyFormContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuestResponse>()
            .HasIndex(b => b.Email)
            .IsUnique();

            modelBuilder.Entity<GuestResponse>()
            .HasIndex(b => b.Phone)
            .IsUnique();
        }
    }
}
