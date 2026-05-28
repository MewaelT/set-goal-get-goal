namespace Backend.Models;

public class ProgressEntry
{
    public int Id { get; set; }
    public int GoalId { get; set; }
    public Goal? Goal { get; set; }
    public DateTime Date { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
