using System.Text.Json;
using MouseTracker.Contracts.Coordinates;
using MouseTracker.Domain.Models;

namespace MouseTracker.Application.Coordinates;

internal sealed class MouseCoordinatesService : IMouseCoordinatesService
{
    private readonly IMouseCoordinatesRepository mouseCoordinatesRepository;

    public MouseCoordinatesService(IMouseCoordinatesRepository mouseCoordinatesRepository)
    {
        this.mouseCoordinatesRepository = mouseCoordinatesRepository;
    }
    
    public async Task<MouseCoordinate> AddAsync(List<CoordinateWithTime> coordinate, CancellationToken cancellationToken)
    {
        var coordinatesJson = JsonSerializer.Serialize(coordinate);
        
        var mouseCoordinate = MouseCoordinate.Create(coordinatesJson);
        
        await mouseCoordinatesRepository.AddAsync(mouseCoordinate, cancellationToken);
        
        return mouseCoordinate;
    }
}