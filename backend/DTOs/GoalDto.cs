namespace Backend.DTOs;

public class GoalDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string Status { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? TargetDate { get; set; }
    public DateTime? CompletedAt { get; set; }
    public IList<ProgressEntryDto> ProgressEntries { get; set; } = new List<ProgressEntryDto>();
}
