using JobList.Models;

namespace JobList.Interfaces;

public interface IJopPostRepo
{
    Task<List<JobPost>> GetJobPostsAsync();
    Task<JobPost?> GetJobPostByIdAsync(Guid id);
    Task<JobPost> AddJobPostAsync(JobPost jobPost);
    Task<JobPost?> UpdateJobPostAsync(Guid id, JobPost jobPost);
    Task<JobPost> DeleteJobPostAsync(Guid id);
}