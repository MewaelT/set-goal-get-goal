using Backend.DTOs;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/goals/{goalId}/[controller]")]
public class ProgressController : ControllerBase
{
    private readonly IProgressEntryService _progressEntryService;

    public ProgressController(IProgressEntryService progressEntryService)
    {
        _progressEntryService = progressEntryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProgressEntryDto>>> GetAll(int goalId)
    {
        var entries = await _progressEntryService.GetByGoalIdAsync(goalId);
        return Ok(entries.Select(entry => new ProgressEntryDto
        {
            Id = entry.Id,
            GoalId = entry.GoalId,
            Date = entry.Date,
            Notes = entry.Notes,
            CreatedAt = entry.CreatedAt,
        }));
    }

    [HttpPost]
    public async Task<ActionResult<ProgressEntryDto>> Create(int goalId, CreateProgressEntryDto dto)
    {
        if (dto.GoalId != goalId)
        {
            return BadRequest(new { error = "GoalId in the route must match GoalId in the request body." });
        }

        if (dto.Date == default)
        {
            return BadRequest(new { error = "Date is required." });
        }

        try
        {
            var entry = await _progressEntryService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetAll), new { goalId }, new ProgressEntryDto
            {
                Id = entry.Id,
                GoalId = entry.GoalId,
                Date = entry.Date,
                Notes = entry.Notes,
                CreatedAt = entry.CreatedAt,
            });
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new { error = ex.Message });
        }
    }
}
