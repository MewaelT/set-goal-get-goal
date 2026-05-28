namespace Backend.DTOs;

public class CreateProgressEntryDto
{
    public int GoalId { get; set; }
    public DateTime Date { get; set; }
    public string? Notes { get; set; }
}
