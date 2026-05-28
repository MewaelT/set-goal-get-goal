using Backend.Data;
using Backend.DTOs;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public interface IDashboardService
{
    Task<DashboardSummaryDto> GetSummaryAsync();
}

public class DashboardService : IDashboardService
{
    private readonly ApplicationDbContext _dbContext;

    public DashboardService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<DashboardSummaryDto> GetSummaryAsync()
    {
        var today = DateTime.UtcNow.Date;

        var goals = await _dbContext.Goals
            .Include(g => g.ProgressEntries)
            .ToListAsync();

        var totalGoals = goals.Count;
        var completedGoals = goals.Count(g => g.Status == GoalStatus.Completed);
        var activeGoals = goals.Count(g => g.Status == GoalStatus.Active);

        var missedGoals = goals.Count(g =>
            g.Status == GoalStatus.Active &&
            g.TargetDate.HasValue &&
            g.TargetDate.Value.Date < today &&
            !g.ProgressEntries.Any(p => p.Date <= g.TargetDate.Value.Date));

        var streakDays = await _dbContext.ProgressEntries
            .Select(x => x.Date)
            .Distinct()
            .OrderByDescending(x => x)
            .ToListAsync();

        var streakDates = new HashSet<DateTime>(
            streakDays
                .Where(date => date != default)
                .Select(date => date));

        var currentStreak = 0;
        var streakDate = today;
        while (streakDates.Contains(streakDate))
        {
            currentStreak++;
            streakDate = streakDate.AddDays(-1);
        }

        return new DashboardSummaryDto
        {
            TotalGoals = totalGoals,
            ActiveGoals = activeGoals,
            CompletedGoals = completedGoals,
            MissedGoals = missedGoals,
            CurrentStreak = currentStreak,
        };
    }
}
