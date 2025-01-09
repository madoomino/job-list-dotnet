namespace JobList.Models;

public class Application
{
    public Guid Id { get; init; }
    public string CoverLetter { get; set; }
    public string ApplicationStatus { get; set; }
    public DateTime AppliedAt { get; set; }

    // Applicant
    public Guid ApplicantId { get; set; }
    public Applicant Applicant { get; set; }

    // JobPost
    public Guid JobPostId { get; set; }
    public JobPost JobPost { get; set; }
}