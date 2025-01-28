using Microsoft.EntityFrameworkCore;
using MouseTracker.Domain.Models;

namespace MouseTracker.Data.Engine;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
    
    public DbSet<MouseCoordinate> MouseCoordinates { get; init; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}