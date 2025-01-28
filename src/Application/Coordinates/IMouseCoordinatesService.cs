using MouseTracker.Contracts.Coordinates;
using MouseTracker.Domain.Models;

namespace MouseTracker.Application.Coordinates;

public interface IMouseCoordinatesService
{
    Task<MouseCoordinate> AddAsync(List<CoordinateWithTime> coordinate, CancellationToken cancellationToken);
}