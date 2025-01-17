using JobList.Models;
using Microsoft.EntityFrameworkCore;

namespace JobList.Data;

public class ApplicationDbContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<Applicant> Applicants { get; set; }
    public DbSet<JobPost> JobsPosts { get; set; }
    public DbSet<Application> Applications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define Company-JobPost Relationship (One-to-Many)
        modelBuilder.Entity<JobPost>()
            .HasOne(jp => jp.Company) // JobPost belongs to one Company
            .WithMany(c => c.JobPosts) // Company has many JobPosts
            .HasForeignKey(jp => jp.CompanyId) // Foreign key in JobPost
            .OnDelete(DeleteBehavior.Cascade); // Cascade deletes for related JobPosts

        // Define Applicant-Application Relationship (One-to-Many)
        modelBuilder.Entity<Application>()
            .HasOne(a => a.Applicant) // Application belongs to one Applicant
            .WithMany(ap => ap.Applications) // Applicant has many Applications
            .HasForeignKey(a => a.ApplicantId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade deletes for related Applications

        // Define JobPost-Application Relationship (One-to-Many)
        modelBuilder.Entity<Application>()
            .HasOne(a => a.JobPost) // Application belongs to one JobPost
            .WithMany(jp => jp.Applications) // JobPost has many Applications
            .HasForeignKey(a => a.JobPostId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade deletes for related Applications
    }
}