using JobList.Models;
using Microsoft.EntityFrameworkCore;

namespace JobList.Data;

public class ApplicationDbContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<Applicant> Applicants { get; set; }
    public DbSet<JobPost> JobsPosts { get; set; }
    public DbSet<Application> Applications { get; set; }
}