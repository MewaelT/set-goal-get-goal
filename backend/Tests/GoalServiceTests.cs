using Backend.Data;
using Backend.DTOs;
using Backend.Models;
using Backend.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Tests;

[TestFixture]
public class GoalServiceTests
{
    private static ApplicationDbContext CreateInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new ApplicationDbContext(options);
    }

    [Test]
    public async Task CreateAsync_ShouldPersistGoal()
    {
        using var context = CreateInMemoryContext();
        var service = new GoalService(context);
        var dto = new CreateGoalDto
        {
            Title = "Finish onboarding",
            Description = "Complete initial product setup.",
            TargetDate = DateTime.UtcNow.AddDays(14),
        };

        var goal = await service.CreateAsync(dto);

        Assert.NotNull(goal);
        Assert.AreEqual(dto.Title, goal.Title);
        Assert.AreEqual(dto.Description, goal.Description);
        Assert.AreEqual(GoalStatus.Active, goal.Status);
        Assert.Greater(goal.Id, 0);

        var persisted = await context.Goals.FindAsync(goal.Id);
        Assert.NotNull(persisted);
    }

    [Test]
    public async Task UpdateAsync_ShouldModifyExistingGoal()
    {
        using var context = CreateInMemoryContext();
        var service = new GoalService(context);
        var createDto = new CreateGoalDto
        {
            Title = "Launch MVP",
            Description = "Ship the first version.",
            TargetDate = DateTime.UtcNow.AddDays(30),
        };

        var created = await service.CreateAsync(createDto);
        var updateDto = new UpdateGoalDto
        {
            Title = "Launch MVP v1",
            Description = "Ship the first production-ready version.",
            MarkCompleted = true,
        };

        var updated = await service.UpdateAsync(created.Id, updateDto);

        Assert.NotNull(updated);
        Assert.AreEqual(updateDto.Title, updated!.Title);
        Assert.AreEqual(updateDto.Description, updated.Description);
        Assert.AreEqual(GoalStatus.Completed, updated.Status);
        Assert.NotNull(updated.CompletedAt);
    }
}
