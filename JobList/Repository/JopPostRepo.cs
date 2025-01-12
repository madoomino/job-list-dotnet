using JobList.Data;
using JobList.Interfaces;
using JobList.Models;
using Microsoft.EntityFrameworkCore;

namespace JobList.Repository;

public class JopPostRepo(ApplicationDbContext context) : IJopPostRepo
{
    public async Task<List<JobPost>> GetJobPostsAsync()
    {
        return await context.JobsPosts.ToListAsync();
    }

    public async Task<JobPost?> GetJobPostByIdAsync(Guid id)
    {
        var jobPost = await context.JobsPosts.FirstOrDefaultAsync(jp => jp.Id == id);
        return jobPost;
    }

    public async Task<JobPost> AddJobPostAsync(JobPost jobPost)
    {
        var createdJobPost = await context.JobsPosts.AddAsync(jobPost);
        await context.SaveChangesAsync();
        return createdJobPost.Entity;
    }

    public async Task<JobPost?> UpdateJobPostAsync(Guid id, JobPost updatedJobPost)
    {
        var jobPost = await context.JobsPosts.FindAsync(id);
        if (jobPost == null) return null;

        jobPost.Title = updatedJobPost.Title;
        jobPost.Description = updatedJobPost.Description;
        jobPost.Company = updatedJobPost.Company;
        jobPost.Location = updatedJobPost.Location;
        jobPost.Requirements = updatedJobPost.Requirements;
        jobPost.SalaryRange = updatedJobPost.SalaryRange;
        jobPost.JobType = updatedJobPost.JobType;

        await context.SaveChangesAsync();
        return jobPost;
    }

    public async Task<JobPost> DeleteJobPostAsync(Guid id)
    {
        var jobPost = await context.JobsPosts.FindAsync(id);
        if (jobPost == null) return null;

        context.JobsPosts.Remove(jobPost);
        await context.SaveChangesAsync();
        return jobPost;
    }
}