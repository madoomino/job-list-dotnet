namespace JobList.Models;

public class Application
{
    public Guid Id { get; init; }
    public string CoverLetter { get; set; }
    public string ApplicationStatus { get; set; }
    public DateTime AppliedAt { get; set; }

    // Applicant
    public Applicant Applicant { get; set; }

    // JobPost
    public JobPost JobPost { get; set; }
}