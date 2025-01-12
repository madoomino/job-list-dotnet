using JobList.Interfaces;
using JobList.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobList.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobPostController(IJopPostRepo postRepo) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllJobs()
    {
        return Ok(postRepo.GetJobPostsAsync());
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetJobPostById(Guid id)
    {
        var jobPost = postRepo.GetJobPostByIdAsync(id);
        return Ok(jobPost);
    }

    [HttpPost]
    public IActionResult AddJobPost(JobPost jobPost)
    {
        var createdJobPost = postRepo.AddJobPostAsync(jobPost);
        return CreatedAtAction(nameof(GetJobPostById), new { id = createdJobPost.Id },
            createdJobPost);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateJobPost(Guid id, JobPost updatedJobPost)
    {
        var jobPost = postRepo.UpdateJobPostAsync(id, updatedJobPost);
        return Ok(jobPost);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteJobPost(Guid id)
    {
        var jobPost = postRepo.DeleteJobPostAsync(id);
        return Ok(jobPost);
    }
}