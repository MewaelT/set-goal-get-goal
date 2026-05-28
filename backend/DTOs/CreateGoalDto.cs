namespace Backend.DTOs;

public class CreateGoalDto
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime? TargetDate { get; set; }
}
