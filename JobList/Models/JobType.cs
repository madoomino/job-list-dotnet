namespace JobList.Models;

public class JobType
{
    public int Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public int? ParentId { get; set; }
}