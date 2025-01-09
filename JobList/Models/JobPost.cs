namespace JobList.Models;

public class JobPost
{
    public Guid Id { get; init; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Requirements { get; set; }
    public string SalaryRange { get; set; }
    public string Location { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // JobType
    public JobType JobType { get; set; }

    // Company
    public Company Company { get; set; }
}