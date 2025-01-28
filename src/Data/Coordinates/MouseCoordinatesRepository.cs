using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MouseTracker.Application.Coordinates;
using MouseTracker.Data.Engine;
using MouseTracker.Domain.Models;

namespace MouseTracker.Data.Coordinates;

internal sealed class MouseCoordinatesRepository : IMouseCoordinatesRepository
{
    private readonly AppDbContext context;

    public MouseCoordinatesRepository(AppDbContext context)
    {
        this.context = context;
    }

    public Task<MouseCoordinate?> GetFirstOrDefaultAsync(
        Expression<Func<MouseCoordinate, bool>> predicate,
        CancellationToken cancellationToken) 
            => context.MouseCoordinates.FirstOrDefaultAsync(predicate, cancellationToken);

    public async Task AddAsync(MouseCoordinate mouseCoordinate, CancellationToken cancellationToken)
    {
        await context.MouseCoordinates.AddAsync(mouseCoordinate, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}