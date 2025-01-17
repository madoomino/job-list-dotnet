namespace JobList.Models;

public class Application
{
    public Guid Id { get; init; }
    public string CoverLetter { get; set; }
    public string ApplicationStatus { get; set; }
    public DateTime AppliedAt { get; set; }

    // Foreign keys
    public Guid ApplicantId { get; set; }
    public Guid JobPostId { get; set; }

    // Navigation properties
    public Applicant Applicant { get; set; }
    public JobPost JobPost { get; set; }
}