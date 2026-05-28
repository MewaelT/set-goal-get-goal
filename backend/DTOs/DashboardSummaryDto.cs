namespace Backend.DTOs;

public class DashboardSummaryDto
{
    public int TotalGoals { get; set; }
    public int ActiveGoals { get; set; }
    public int CompletedGoals { get; set; }
    public int MissedGoals { get; set; }
    public int CurrentStreak { get; set; }
}
