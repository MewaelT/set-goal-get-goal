using Backend.Data;
using Backend.DTOs;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public interface IProgressEntryService
{
    Task<ProgressEntry> CreateAsync(CreateProgressEntryDto dto);
    Task<IEnumerable<ProgressEntry>> GetByGoalIdAsync(int goalId);
}

public class ProgressEntryService : IProgressEntryService
{
    private readonly ApplicationDbContext _dbContext;

    public ProgressEntryService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ProgressEntry> CreateAsync(CreateProgressEntryDto dto)
    {
        var goal = await _dbContext.Goals.FindAsync(dto.GoalId);
        if (goal is null)
        {
            throw new InvalidOperationException("Goal not found");
        }

        var progressEntry = new ProgressEntry
        {
            GoalId = dto.GoalId,
            Date = dto.Date.Date,
            Notes = dto.Notes,
            CreatedAt = DateTime.UtcNow,
        };

        _dbContext.ProgressEntries.Add(progressEntry);
        goal.UpdatedAt = DateTime.UtcNow;
        await _dbContext.SaveChangesAsync();
        return progressEntry;
    }

    public async Task<IEnumerable<ProgressEntry>> GetByGoalIdAsync(int goalId)
    {
        return await _dbContext.ProgressEntries
            .Where(x => x.GoalId == goalId)
            .OrderByDescending(x => x.Date)
            .ToListAsync();
    }
}
