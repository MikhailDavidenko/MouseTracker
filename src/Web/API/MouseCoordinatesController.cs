using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MouseTracker.Application.Coordinates;
using MouseTracker.Contracts.Coordinates;

namespace MouseTracker.Web.API;

[Route("api/v1/[controller]")]
[ApiController]
public sealed class MouseCoordinatesController : ControllerBase
{
    private readonly IMouseCoordinatesService mouseCoordinatesService;
    
    public MouseCoordinatesController(IMouseCoordinatesService mouseCoordinatesService)
    {
        this.mouseCoordinatesService = mouseCoordinatesService;
    }

    [HttpPost]
    public async Task<MouseCoordinatesResponse> AddMouseCoordinatesAsync(
        [FromBody] List<CoordinateWithTime>? coordinates,
        CancellationToken cancellationToken)
    {
        if(coordinates is null || coordinates.Count == 0)
            throw new ArgumentNullException(nameof(coordinates), "Список координат не может быть пустым");
        
        var mouseCoordinate = await mouseCoordinatesService.AddAsync(coordinates, cancellationToken);
        
        var coordinatesWithTime = JsonSerializer.Deserialize<List<CoordinateWithTime>>(mouseCoordinate.CoordinatesJson);
        
        return new MouseCoordinatesResponse
        {
            Id = mouseCoordinate.Id,
            Coordinates = coordinatesWithTime
        };
    }
    
}