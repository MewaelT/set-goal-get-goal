using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Goal> Goals => Set<Goal>();
    public DbSet<ProgressEntry> ProgressEntries => Set<ProgressEntry>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Goal>(entity =>
        {
            entity.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(x => x.Status)
                .HasConversion<string>()
                .IsRequired();

            entity.HasMany(x => x.ProgressEntries)
                .WithOne(x => x.Goal)
                .HasForeignKey(x => x.GoalId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ProgressEntry>(entity =>
        {
            entity.Property(x => x.Date)
                .HasColumnType("date")
                .IsRequired();

            entity.Property(x => x.Notes)
                .HasMaxLength(1000);
        });
    }
}
