namespace Backend.DTOs;

public class UpdateGoalDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? TargetDate { get; set; }
    public bool? MarkCompleted { get; set; }
}
