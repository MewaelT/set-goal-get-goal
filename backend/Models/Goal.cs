namespace Backend.Models;

public enum GoalStatus
{
    Active,
    Completed
}

public class Goal
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public GoalStatus Status { get; set; } = GoalStatus.Active;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? TargetDate { get; set; }
    public DateTime? CompletedAt { get; set; }
    public IList<ProgressEntry> ProgressEntries { get; set; } = new List<ProgressEntry>();
}
