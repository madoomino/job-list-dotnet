using JobList.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobList.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobController(ApplicationDbContext context) : ControllerBase
{
    private readonly ApplicationDbContext _context = context;

    [HttpGet]
    public IActionResult GetAllJobs()
    {
        return Ok(_context.JobsPosts.ToListAsync());
        // TODO: Return all jobs from the database
    }
}