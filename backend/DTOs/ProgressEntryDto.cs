namespace Backend.DTOs;

public class ProgressEntryDto
{
    public int Id { get; set; }
    public int GoalId { get; set; }
    public DateTime Date { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }
}
