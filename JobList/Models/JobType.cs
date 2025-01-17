namespace JobList.Models;

public class JobType
{
    public Guid Id { get; set; }
    public string Name { get; set; } // e.g., "Backend," "Frontend," etc.

    // Self-referential relationship
    public Guid? ParentId { get; set; } // Optional parent JobType (e.g., "Backend -> .NET")
    public JobType Parent { get; set; }
    public ICollection<JobType> Children { get; set; }

    // Navigation property for related JobPosts
    public ICollection<JobPost> JobPosts { get; set; }
}