using System.Linq.Expressions;
using MouseTracker.Domain.Models;

namespace MouseTracker.Application.Coordinates;

public interface IMouseCoordinatesRepository
{
    Task<MouseCoordinate?> GetFirstOrDefaultAsync(Expression<Func<MouseCoordinate, bool>> predicate, CancellationToken cancellationToken = default);
    
    Task AddAsync(MouseCoordinate mouseCoordinate, CancellationToken cancellationToken = default);
}