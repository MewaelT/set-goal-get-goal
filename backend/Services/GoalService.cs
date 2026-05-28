using Backend.Data;
using Backend.DTOs;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public interface IGoalService
{
    Task<Goal> CreateAsync(CreateGoalDto dto);
    Task<IEnumerable<Goal>> GetAllAsync();
    Task<Goal?> GetByIdAsync(int id);
    Task<Goal?> UpdateAsync(int id, UpdateGoalDto dto);
    Task<bool> DeleteAsync(int id);
    Task<Goal?> MarkCompletedAsync(int id);
}

public class GoalService : IGoalService
{
    private readonly ApplicationDbContext _dbContext;

    public GoalService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Goal> CreateAsync(CreateGoalDto dto)
    {
        var goal = new Goal
        {
            Title = dto.Title,
            Description = dto.Description,
            TargetDate = dto.TargetDate,
            Status = GoalStatus.Active,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };

        _dbContext.Goals.Add(goal);
        await _dbContext.SaveChangesAsync();
        return goal;
    }

    public async Task<IEnumerable<Goal>> GetAllAsync()
    {
        return await _dbContext.Goals
            .Include(g => g.ProgressEntries)
            .OrderByDescending(g => g.UpdatedAt)
            .ToListAsync();
    }

    public async Task<Goal?> GetByIdAsync(int id)
    {
        return await _dbContext.Goals
            .Include(g => g.ProgressEntries)
            .FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task<Goal?> UpdateAsync(int id, UpdateGoalDto dto)
    {
        var goal = await _dbContext.Goals.FindAsync(id);
        if (goal == null)
        {
            return null;
        }

        if (!string.IsNullOrWhiteSpace(dto.Title))
        {
            goal.Title = dto.Title;
        }

        if (dto.Description is not null)
        {
            goal.Description = dto.Description;
        }

        if (dto.TargetDate.HasValue)
        {
            goal.TargetDate = dto.TargetDate;
        }

        if (dto.MarkCompleted.HasValue && dto.MarkCompleted.Value)
        {
            goal.Status = GoalStatus.Completed;
            goal.CompletedAt = DateTime.UtcNow;
        }

        goal.UpdatedAt = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();
        return goal;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var goal = await _dbContext.Goals.FindAsync(id);
        if (goal == null)
        {
            return false;
        }

        _dbContext.Goals.Remove(goal);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<Goal?> MarkCompletedAsync(int id)
    {
        var goal = await _dbContext.Goals.FindAsync(id);
        if (goal == null)
        {
            return null;
        }

        goal.Status = GoalStatus.Completed;
        goal.CompletedAt = DateTime.UtcNow;
        goal.UpdatedAt = DateTime.UtcNow;
        await _dbContext.SaveChangesAsync();
        return goal;
    }
}
