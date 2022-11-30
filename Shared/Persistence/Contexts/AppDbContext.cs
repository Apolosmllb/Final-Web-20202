using Microsoft.EntityFrameworkCore;
using si730ebu201920124.API.Loyalty.Domain.Models;
using si730ebu201920124.API.Shared.Extensions;

namespace si730ebu201920124.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Reward> Rewards { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // REWARDS Configuration

        builder.Entity<Reward>().ToTable("Rewards");
        builder.Entity<Reward>().HasKey(p => p.Id);
        builder.Entity<Reward>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Reward>().Property(p => p.fleetId).IsRequired();
        builder.Entity<Reward>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Reward>().Property(p => p.Description);
        builder.Entity<Reward>().Property(p => p.Score).IsRequired().HasMaxLength(50);










        // Apply Snake Case Naming Convention

        builder.UseSnakeCaseNamingConvention();

    }


}
