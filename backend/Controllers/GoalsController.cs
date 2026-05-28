using Backend.DTOs;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GoalsController : ControllerBase
{
    private readonly IGoalService _goalService;

    public GoalsController(IGoalService goalService)
    {
        _goalService = goalService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GoalDto>>> GetAll()
    {
        var goals = await _goalService.GetAllAsync();
        return Ok(goals.Select(Map));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GoalDto>> GetById(int id)
    {
        var goal = await _goalService.GetByIdAsync(id);
        if (goal is null)
        {
            return NotFound();
        }

        return Ok(Map(goal));
    }

    [HttpPost]
    public async Task<ActionResult<GoalDto>> Create(CreateGoalDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
        {
            return BadRequest(new { error = "Title is required." });
        }

        var goal = await _goalService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = goal.Id }, Map(goal));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<GoalDto>> Update(int id, UpdateGoalDto dto)
    {
        if (dto.Title is not null && string.IsNullOrWhiteSpace(dto.Title))
        {
            return BadRequest(new { error = "Title cannot be empty." });
        }

        var goal = await _goalService.UpdateAsync(id, dto);
        if (goal is null)
        {
            return NotFound();
        }

        return Ok(Map(goal));
    }

    [HttpPost("{id}/complete")]
    public async Task<ActionResult<GoalDto>> Complete(int id)
    {
        var goal = await _goalService.MarkCompletedAsync(id);
        if (goal is null)
        {
            return NotFound();
        }

        return Ok(Map(goal));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _goalService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }

    private static GoalDto Map(Backend.Models.Goal goal)
    {
        return new GoalDto
        {
            Id = goal.Id,
            Title = goal.Title,
            Description = goal.Description,
            Status = goal.Status.ToString(),
            CreatedAt = goal.CreatedAt,
            UpdatedAt = goal.UpdatedAt,
            TargetDate = goal.TargetDate,
            CompletedAt = goal.CompletedAt,
            ProgressEntries = goal.ProgressEntries
                .OrderByDescending(entry => entry.Date)
                .Select(entry => new ProgressEntryDto
                {
                    Id = entry.Id,
                    GoalId = entry.GoalId,
                    Date = entry.Date,
                    Notes = entry.Notes,
                    CreatedAt = entry.CreatedAt,
                })
                .ToList(),
        };
    }
}
